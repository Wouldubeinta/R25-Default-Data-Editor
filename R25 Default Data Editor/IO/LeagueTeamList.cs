using PackageIO;

/// <summary>
/// League Team List Class.
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
namespace R25_Default_Data_Editor
{
    internal class LeagueTeamList
    {
        #region Fields
        private int teamsCount = 0;
        private Entry[]? entries;
        #endregion

        public LeagueTeamList()
        {
            entries = null;
        }

        public class Entry
        {
            public int Id = 0;
            public byte TeamNameSize = 0;
            public string? TeamName = string.Empty;
        }

        #region Properties
        public int TeamsCount
        {
            get { return teamsCount; }
            set { teamsCount = value; }
        }

        public Entry[]? Entries
        {
            get { return entries; }
            set { entries = value; }
        }
        #endregion

        #region "Deserialize"
        /// <summary>
        /// Deserialize TeamList stream
        /// </summary>
        /// <param name="input">TeamList input stream</param>
        public void Deserialize(Reader input)
        {
            TeamsCount = input.ReadInt32();

            Entries = new Entry[TeamsCount];

            for (int i = 0; i < TeamsCount; i++)
            {
                Entries[i] = new Entry();
                Entries[i].Id = input.ReadInt32();
                Entries[i].TeamNameSize = input.ReadByte();
                Entries[i].TeamName = input.ReadString(Entries[i].TeamNameSize);
            }
        }
        #endregion
    }
}
