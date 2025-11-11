using PackageIO;
using System.ComponentModel;
using static R25_Default_Data_Editor.M3MP;

namespace R25_Default_Data_Editor
{
    /// <summary>
    /// M3MP Create Class.
    /// </summary>
    /// <remarks>
    ///   RL26 Default Data Editor. Written by Wouldubeinta
    ///   Copyright (C) 2025 Wouldy Mods.
    ///   
    ///   This program is free software; you can redistribute it and/or
    ///   modify it under the terms of the GNU General Public License
    ///   as published by the Free Software Foundation; either version 3
    ///   of the License, or (at your option) any later version.
    ///   
    ///   This program is distributed in the hope that it will be useful,
    ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
    ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ///   GNU General Public License for more details.
    /// 
    ///   The author may be contacted at:
    ///   Discord: Wouldubeinta
    /// </remarks>
    /// <history>
    /// [Wouldubeinta]	   23/10/2025	Created
    /// </history>
    internal class M3MP_IO
    {
        public static bool CreateM3MP(BackgroundWorker? M3MP_Create_bgw)
        {
            Reader? br = null;
            Writer? bw = null;
            FileStream? writer = null;
            bool result = false;
            M3MP? m3mp = new();

            try
            {
                int chunkSize = 32768;
                int compressedOffset = 16;
                int totalFileSize = 0;
                long[]? chunkSizes = null;

                if (!File.Exists(Global.currentPath + @"\data\M3MP_List.xml"))
                {
                    MessageBox.Show("Could not find M3MP_List.xml.", "XML Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                ExtractFileInfo? M3MP_Xml_In = IO.XmlDeserialize<ExtractFileInfo>(Global.currentPath + @"\data\M3MP_List.xml");

                if (M3MP_Xml_In == null)
                {
                    MessageBox.Show("There is a problem with the xml file - M3MP_List.xml", "XML Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                m3mp.UnCompressedEntries = new UnCompressedEntry[M3MP_Xml_In.Entries.Length];

                for (int i = 0; i < M3MP_Xml_In.Entries.Length; i++)
                {
                    string filePath = Global.currentPath + @"\" + M3MP_Xml_In.Entries[i].FilePath.Replace("/", @"\");

                    m3mp.UnCompressedEntries[i] = new();
                    m3mp.UnCompressedEntries[i].UncompressedDataInfo = new UncompressedDataInfo();
                    m3mp.UnCompressedEntries[i].UncompressedDataInfo.Size = (uint)IO.FileInfo(filePath);

                    totalFileSize += (int)m3mp.UnCompressedEntries[i].UncompressedDataInfo.Size;
                    m3mp.UnCompressedEntries[i].UncompressedDataInfo.Reserved = 0;
                    m3mp.UnCompressedEntries[i].FilePath = M3MP_Xml_In.Entries[i].FilePath.Replace(@"\", @"/");

                    int filePathLength = M3MP_Xml_In.Entries[i].FilePath.Length + 1;
                    compressedOffset += filePathLength;
                    compressedOffset += 16;

                    int percentProgress = 100 * i / M3MP_Xml_In.Entries.Length;
                    M3MP_Create_bgw.ReportProgress(percentProgress, "Getting header data ready: " + M3MP_Xml_In.Entries[i].FilePath);
                }

                m3mp.CompressedDataOffset = (uint)compressedOffset;
                m3mp.ChunksCount = (uint)IO.ChunkAmount(totalFileSize, chunkSize);
                chunkSizes = IO.ChunkSizes(totalFileSize, (int)m3mp.ChunksCount, chunkSize);

                m3mp.CompressedEntries = new CompressedEntry[m3mp.ChunksCount];

                for (int i = 0; i < m3mp.ChunksCount; i++)
                {
                    CompressedEntry entry = new();
                    entry.CompressedDataInfo = new();
                    int percentProgress = 100 * i / (int)m3mp.ChunksCount;
                    M3MP_Create_bgw.ReportProgress(percentProgress, "Initializing chunk compressed data info array chunk " + (i + 1).ToString());
                    m3mp.CompressedEntries[i] = entry;
                }

                m3mp.FilesCount = (uint)M3MP_Xml_In.Entries.Length;

                bw = new Writer(Global.currentPath + @"\m3mp_header.tmp");

                m3mp.Serialize(bw);

                m3mp.UnCompressedEntries[0].UncompressedDataInfo.Offset = 0;

                writer = new FileStream(Global.currentPath + @"\m3mp_uncompressed_data.tmp", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);

                uint uncompressedOffset = 0;

                for (int i = 0; i < M3MP_Xml_In.Entries.Length; i++)
                {
                    string filePath = Global.currentPath + @"\" + M3MP_Xml_In.Entries[i].FilePath.Replace("/", @"\");
                    br = new Reader(filePath);

                    int tmpChunkCount = IO.ChunkAmount((int)IO.FileInfo(filePath));
                    long[] tmpChunkSizes = IO.ChunkSizes((int)IO.FileInfo(filePath), tmpChunkCount);

                    for (int j = 0; j < tmpChunkCount; j++)
                    {
                        byte[] tmpData = br.ReadBytes((int)tmpChunkSizes[j]);
                        IO.ReadWriteData(tmpData, writer, (int)tmpChunkSizes[j]);
                    }

                    if (br != null) { br.Close(); br = null; }

                    m3mp.UnCompressedEntries[i].UncompressedDataInfo.Offset = uncompressedOffset;

                    uncompressedOffset += m3mp.UnCompressedEntries[i].UncompressedDataInfo.Size;

                    int percentProgress = 100 * i / M3MP_Xml_In.Entries.Length;
                    M3MP_Create_bgw.ReportProgress(percentProgress, "Writing temp data : " + M3MP_Xml_In.Entries[i].FilePath);
                }

                if (writer != null) { writer.Dispose(); writer = null; }
                if (bw != null) { bw.Close(); bw = null; }

                br = new(Global.currentPath + @"\m3mp_uncompressed_data.tmp");
                writer = new(Global.currentPath + @"\m3mp_compressed_data.tmp", FileMode.OpenOrCreate, FileAccess.Write);

                long m3mpHeaderSize = IO.FileInfo(Global.currentPath + @"\m3mp_header.tmp");

                for (int i = 0; i < m3mp.ChunksCount; i++)
                {
                    byte[] buffer2 = br.ReadBytes((int)chunkSizes[i]);
                    int chunkCOffset = 0;
                    int chunkCSize = IO.CompressAndWrite(buffer2, writer, ref chunkCOffset, (int)chunkSizes[i]);
                    m3mp.CompressedEntries[i].CompressedDataInfo.Offset = (uint)chunkCOffset + (uint)m3mpHeaderSize;
                    m3mp.CompressedEntries[i].CompressedDataInfo.CompressedSize = (uint)chunkCSize;
                    m3mp.CompressedEntries[i].CompressedDataInfo.UnCompressedSize = (uint)buffer2.Length;

                    int percentProgress = 100 * i / (int)m3mp.ChunksCount;
                    M3MP_Create_bgw.ReportProgress(percentProgress, "Writing M3MP compressed data chunk " + (i + 1).ToString());
                }

                if (writer != null) { writer.Dispose(); writer = null; }
                if (br != null) { br.Close(); br = null; }

                bw = new(Global.currentPath + @"\m3mp_header.tmp");

                bw.Position = 0;
                m3mp.Serialize(bw);
                bw.Flush();
                if (bw != null) { bw.Close(); bw = null; }

                writer = new FileStream(Global.currentPath + @"\defaultdata.m3mp", FileMode.OpenOrCreate, FileAccess.Write);

                IO.ReadWriteData(Global.currentPath + @"\m3mp_header.tmp", writer);
                IO.ReadWriteData(Global.currentPath + @"\m3mp_compressed_data.tmp", writer);

                int fileSize = (int)IO.FileInfo(Global.currentPath + @"\m3mp_header.tmp") + (int)IO.FileInfo(Global.currentPath + @"\m3mp_compressed_data.tmp");

                ModifyFileInfo m3mpXmlOut = new();
                m3mpXmlOut.Index = M3MP_Xml_In.Index;
                m3mpXmlOut.IsCompressed = false;
                m3mpXmlOut.MainCompressedSize = fileSize;
                m3mpXmlOut.MainUnCompressedSize = fileSize;
                m3mpXmlOut.VramCompressedSize = 0;
                m3mpXmlOut.VramUnCompressedSize = 0;
                IO.XmlSerialize(Global.currentPath + @"\defaultdata.xml", m3mpXmlOut);

                if (writer != null) { writer.Dispose(); writer = null; }

                if (File.Exists(Global.currentPath + @"\m3mp_header.tmp"))
                    File.Delete(Global.currentPath + @"\m3mp_header.tmp");

                if (File.Exists(Global.currentPath + @"\m3mp_uncompressed_data.tmp"))
                    File.Delete(Global.currentPath + @"\m3mp_uncompressed_data.tmp");

                if (File.Exists(Global.currentPath + @"\m3mp_compressed_data.tmp"))
                    File.Delete(Global.currentPath + @"\m3mp_compressed_data.tmp");
            }
            catch (Exception error)
            {
                result = true;
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null) { br.Close(); br = null; }
                if (bw != null) { bw.Close(); bw = null; }
                if (writer != null) { writer.Dispose(); writer = null; }
            }

            return result;
        }
    }
}
