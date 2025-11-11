using PackageIO;

namespace R25_Default_Data_Editor
{
    /// <summary>
    /// League Data Class.
    /// </summary>
    /// <remarks>
    ///   Rugby 25 Default Data Editor. Written by Wouldubeinta
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
    /// [Wouldubeinta]	   10/11/2025	Created
    /// </history>
    public class LeagueData
    {
        #region Fields
        private byte[]? headerData = null;
        private int leagueCount = 0;
        private LeaguesEntries[]? leagues = null;
        #endregion

        public LeagueData()
        {
            leagues = null;
        }

        public class LeaguesEntries
        {
            public uint Identifier = 80085; // ? Always at the start of each league.
            public bool IsIdEnabled = true;
            public int Id = 0;
            public bool IsNameEnabled = true;
            public byte NameSize = 0;
            public string Name = string.Empty;
            public bool IsShortNameEnabled = true;
            public byte ShortNameSize = 0;
            public string ShortName = string.Empty;
            public bool IsGenderEnabled = true;
            public int Gender = 0;
            public bool IsFrontEndEnabled = true;
            public bool IsFrontend = true;
            public bool IsWorldCupLeagueEnabled = true;
            public bool IsWorldCupLeague = false;
            public TeamsEntries[]? Teams = null;
            public bool IsEAFlagEnabled = true;
            public int EAFlag = 0;
            public bool IsUiSorting = true;
            public int UiSorting = 0;
        }

        public class TeamsEntries
        {
            public bool IsTeamEnabled = false;
            public int TeamId = 0;
        }

        #region Properties
        public byte[]? HeaderData
        {
            get { return headerData; }
            set { headerData = value; }
        }

        public int LeagueCount
        {
            get { return leagueCount; }
            set { leagueCount = value; }
        }

        public LeaguesEntries[]? Leagues
        {
            get { return leagues; }
            set { leagues = value; }
        }
        #endregion

        #region "Deserialize"
        /// <summary>
        /// Deserialize defaultdata_leagues file.
        /// </summary>
        /// <param name="input">defaultdata_leagues input stream</param>
        public void Deserialize(Reader input)
        {
            HeaderData = input.ReadBytes(811);
            LeagueCount = input.ReadInt32();

            Leagues = new LeaguesEntries[40];

            for (int i = 0; i < LeagueCount; i++)
            {
                Leagues[i] = new LeaguesEntries();
                Leagues[i].Identifier = input.ReadUInt32();
                Leagues[i].IsIdEnabled = input.ReadBoolean();
                Leagues[i].Id = input.ReadInt32();
                Leagues[i].IsNameEnabled = input.ReadBoolean();
                Leagues[i].NameSize = input.ReadByte();
                Leagues[i].Name = input.ReadString(Leagues[i].NameSize);
                Leagues[i].IsShortNameEnabled = input.ReadBoolean();
                Leagues[i].ShortNameSize = input.ReadByte();
                Leagues[i].ShortName = input.ReadString(Leagues[i].ShortNameSize);
                Leagues[i].IsGenderEnabled = input.ReadBoolean();
                Leagues[i].Gender = input.ReadInt32();
                Leagues[i].IsFrontEndEnabled = input.ReadBoolean();
                Leagues[i].IsFrontend = input.ReadBoolean();
                Leagues[i].IsWorldCupLeagueEnabled = input.ReadBoolean();
                Leagues[i].IsWorldCupLeague = input.ReadBoolean();

                Leagues[i].Teams = new TeamsEntries[43];

                for (int j = 0; j < 43; j++)
                {
                    Leagues[i].Teams[j] = new TeamsEntries();
                    Leagues[i].Teams[j].IsTeamEnabled = input.ReadBoolean();

                    if (Leagues[i].Teams[j].IsTeamEnabled)
                    {
                        Leagues[i].Teams[j].TeamId = input.ReadInt32();
                    }
                }

                Leagues[i].IsEAFlagEnabled = input.ReadBoolean();

                if (Leagues[i].IsEAFlagEnabled)
                    Leagues[i].EAFlag = input.ReadInt32();

                Leagues[i].IsUiSorting = input.ReadBoolean();

                if (Leagues[i].IsUiSorting)
                    Leagues[i].UiSorting = input.ReadInt32();
            }
        }
        #endregion

        #region "Serialize"
        /// <summary>
        /// Serialize defaultdata_leagues file.
        /// </summary>
        /// <param name="output">defaultdata_leagues output stream</param>
        public void Serialize(Writer output)
        {
            if (HeaderData != null)
            {
                output.Write(HeaderData, Endian.Little);
                output.WriteInt32(LeagueCount, Endian.Little);

                if (Leagues != null)
                {
                    for (int i = 0; i < LeagueCount; i++)
                    {
                        output.WriteUInt32(Leagues[i].Identifier, Endian.Little);
                        output.WriteBool(Leagues[i].IsIdEnabled);
                        output.WriteInt32(Leagues[i].Id, Endian.Little);
                        output.WriteBool(Leagues[i].IsNameEnabled);
                        output.WriteUInt8(Leagues[i].NameSize, Endian.Little);
                        output.WriteString(Leagues[i].Name, Leagues[i].NameSize);
                        output.WriteBool(Leagues[i].IsShortNameEnabled);
                        output.WriteUInt8(Leagues[i].ShortNameSize);
                        output.WriteString(Leagues[i].ShortName, Leagues[i].ShortNameSize);
                        output.WriteBool(Leagues[i].IsGenderEnabled);
                        output.WriteInt32(Leagues[i].Gender, Endian.Little);
                        output.WriteBool(Leagues[i].IsFrontEndEnabled);
                        output.WriteBool(Leagues[i].IsFrontend);
                        output.WriteBool(Leagues[i].IsWorldCupLeagueEnabled);
                        output.WriteBool(Leagues[i].IsWorldCupLeague);

                        for (int j = 0; j < 43; j++)
                        {
                            output.WriteBool(Leagues[i].Teams[j].IsTeamEnabled);

                            if (Leagues[i].Teams[j].IsTeamEnabled)
                                output.WriteInt32(Leagues[i].Teams[j].TeamId, Endian.Little);
                        }

                        output.WriteBool(Leagues[i].IsEAFlagEnabled);

                        if (Leagues[i].IsEAFlagEnabled)
                            output.WriteInt32(Leagues[i].EAFlag, Endian.Little);

                        output.WriteBool(Leagues[i].IsUiSorting);

                        if (Leagues[i].IsUiSorting)
                            output.WriteInt32(Leagues[i].UiSorting, Endian.Little);
                    }
                }
            }
        }
        #endregion
    }
}
