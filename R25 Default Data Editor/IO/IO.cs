using PackageIO;
using System.Diagnostics.Eventing.Reader;
using System.Xml;
using System.Xml.Serialization;
using ZstdSharp;

namespace R25_Default_Data_Editor
{
    /// <summary>
    /// IO functions.
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
    /// [Wouldubeinta]	   21/10/2025	Created
    /// </history>
    internal class IO
    {
        /// <summary>
        /// Get ChunkCount from uncompressed file size.
        /// </summary>
        /// <param name="UnCommpressedS">Uncompressed file size</param>
        /// <param name="ChunkSize">Chunk Size. For blobset file v4 - 262144, v1, v2 and v3 - 32768</param>
        public static int ChunkAmount(int UnCommpressedSize, int ChunkSize = 32768)
        {
            int ChunkCount = 0;
            decimal ChunkSizeDec = UnCommpressedSize / (decimal)ChunkSize;

            if (UnCommpressedSize < ChunkSize)
            {
                ChunkCount = 1;
            }
            else if (decimal.Round(ChunkSizeDec, 0) == ChunkSizeDec)
            {
                ChunkCount = UnCommpressedSize / ChunkSize;
            }
            else if (decimal.Round(ChunkSizeDec, 0) != ChunkSizeDec)
            {
                ChunkCount = (UnCommpressedSize / ChunkSize) + 1;
            }
            return ChunkCount;
        }

        /// <summary>
        /// Gets a ChunkSize array from uncompressed file size and chunk count.
        /// </summary>
        /// <param name="UnCommpressedSize">Uncompressed file size</param>
        /// <param name="ChunkAmount">Chunk Count</param>
        /// <param name="ChunkSize">Chunk Size. For blobset file v3 - 262144, v1 and v2 - 32768</param>
        public static long[] ChunkSizes(int UnCommpressedSize, int ChunkAmount, int ChunkSize = 32768)
        {
            long[] ChunkS = new long[ChunkAmount];
            decimal ChunkSizeDec = (decimal)UnCommpressedSize / ChunkSize;

            if (UnCommpressedSize < ChunkSize)
            {
                ChunkS[0] = UnCommpressedSize;
            }
            else if (decimal.Round(ChunkSizeDec, 0) == ChunkSizeDec)
            {
                for (int i = 0; i < ChunkAmount; i++)
                {
                    ChunkS[i] = ChunkSize;
                }
            }
            else if (decimal.Round(ChunkSizeDec, 0) != ChunkSizeDec)
            {
                for (int i = 0; i < ChunkAmount - 1; i++)
                {
                    ChunkS[i] = ChunkSize;
                }

                int Chunk = UnCommpressedSize / ChunkSize;
                int LastChunkSize = ChunkSize * Chunk;
                ChunkS[ChunkAmount - 1] = UnCommpressedSize - LastChunkSize;
            }
            return ChunkS;
        }

        public static long FileInfo(string file)
        {
            return new FileInfo(file).Length;
        }

        /// <summary>
        /// Read data from a Byte[] array and writes chunk to file.
        /// </summary>
        /// <param name="data">Input byte[] array.</param>
        /// <param name="writer">Output FileStream writer.</param>
        /// <param name="chunkSize">Chunk size to write to file.</param>
        /// <history>
        /// [Wouldubeinta]		30/06/2025	Created
        /// </history>
        public static void ReadWriteData(byte[] data, FileStream writer, int chunkSize = 32768)
        {
            try
            {
                int tmpSize = chunkSize;

                if (chunkSize > data.Length)
                    tmpSize = data.Length;

                writer.Write(data, 0, tmpSize);
                writer.Flush();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// Read data from a Binary Reader and writes to file in chunks.
        /// </summary>
        /// <param name="fileIn">Input file path.</param>
        /// <param name="writer">Output FileStream writer.</param>
        /// <param name="chunkSize">Chunk size to write to file.</param>
        /// <history>
        /// [Wouldubeinta]		30/06/2025	Created
        /// </history>
        public static void ReadWriteData(string fileIn, FileStream writer, int chunkSize = 32768)
        {
            Reader? reader = null;

            try
            {
                reader = new Reader(fileIn);

                int readCount = 0;
                byte[] buffer = new byte[chunkSize];

                while ((readCount = reader.Read(buffer, 0, chunkSize)) != 0)
                {
                    writer.Write(buffer, 0, readCount);
                    writer.Flush();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (reader != null) { reader.Close(); reader = null; }
            }
        }

        /// <summary>
        /// Compresses chunk data and appends to output file.
        /// </summary>
        /// <param name="data">Byte array to be compressed.</param>
        /// <param name="writer">FileStream output writer.</param>
        /// <param name="offset">Compressed chunk offset.</param>
        /// <param name="chunkSize">Data chunk size.</param>
        /// <returns>Returns compressed chunk size.</returns>
        /// <history>
        /// [Wouldubeinta]		13/07/2025	Created
        /// </history>
        public static int CompressAndWrite(byte[] data, FileStream writer, ref int offset, int chunkSize = 262144)
        {
            MemoryStream? stream = null;
            Compressor? compressor = null;
            int compressedSize = 0;

            try
            {
                stream = new(data);
                compressor = new();
                compressor.SetParameter(ZstdSharp.Unsafe.ZSTD_cParameter.ZSTD_c_dictIDFlag, 1);
                compressor.SetParameter(ZstdSharp.Unsafe.ZSTD_cParameter.ZSTD_c_contentSizeFlag, 0);
                compressor.SetParameter(ZstdSharp.Unsafe.ZSTD_cParameter.ZSTD_c_compressionLevel, 4);

                int readCount = 0;
                byte[]? buffer = new byte[chunkSize];

                while ((readCount = stream.Read(buffer, 0, chunkSize)) != 0)
                {
                    offset = (int)writer.Position;
                    byte[]? output = compressor.Wrap(buffer).ToArray();
                    writer.Write(output, 0, output.Length);
                    writer.Flush();
                    compressedSize = output.Length;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (stream != null) { stream.Dispose(); stream = null; }
                if (compressor != null) { compressor.Dispose(); compressor = null; }
            }
            return compressedSize;
        }

        /// <summary>
        /// Deserialize XML data.
        /// </summary>
        /// <param name="fileIn">Xml file in.</param>
        /// <returns>Returns generic type class data.</returns>
        /// <history>
        /// [Wouldubeinta]		14/07/2025	Created
        /// </history>
        public static T XmlDeserialize<T>(string fileIn)
        {
            StreamReader? reader = null;
            T? xmlData = default;

            try
            {
                XmlSerializer serializer = new(typeof(T));
                reader = new(fileIn);
                xmlData = (T)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null) { reader.Dispose(); reader = null; }
            }
            return xmlData;
        }

        /// <summary>
        /// Serialize XML data.
        /// </summary>
        /// <param name="fileout">Xml file out.</param>
        /// <param name="data">Generic Type data.</param>
        /// <history>
        /// [Wouldubeinta]		14/07/2025	Created
        /// </history>
        public static void XmlSerialize<T>(string fileout, T data)
        {
            StringWriter? stringWriter = null;

            try
            {
                XmlWriterSettings settings = new();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                settings.NewLineHandling = NewLineHandling.None;
                stringWriter = new();
                XmlWriter writer = XmlWriter.Create(stringWriter, settings);
                XmlSerializer serializer = new(typeof(T));
                XmlSerializerNamespaces ns = new();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(writer, data, ns);
                string startDocuments = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>";
                File.WriteAllText(fileout, startDocuments + "\n" + stringWriter.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (stringWriter != null) { stringWriter.Dispose(); stringWriter = null; }
            }
        }

        public static string GetTeamName(int TeamID)
        {
            string? TeamName = "---Empty---";

            try
            {
                if (Global.teamsList != null) 
                {
                    for (int i = 0; i < Global.teamsList.Length; i++)
                    {
                        if (Global.teamsList[i].Id.Equals(TeamID))
                        {
                            TeamName = "[" + Global.teamsList[i].Id.ToString() + "] - " + Global.teamsList[i].TeamName;
                            break;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return TeamName;
        }

        public static int GetTeamIndex(string TeamName)
        {
            int id = 0;

            try
            {
                if (Global.teamsList != null)
                {
                    for (int i = 0; i < Global.teamsList.Length; i++)
                    {
                        string name = "[" + Global.teamsList[i].Id.ToString() + "] - " + Global.teamsList[i].TeamName;

                        if (name.Equals(TeamName))
                        {
                            id = Global.teamsList[i].Id;
                            break;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + error, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return id;
        }
    }
}
