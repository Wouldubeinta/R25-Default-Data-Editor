using PackageIO;

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
