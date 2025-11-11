namespace R25_Default_Data_Editor
{
    /// <summary>
    /// Add and remove leagues.
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
    internal class AddRemove
    {
        public static void AddLeague(bool Gender)
        {
            LeagueData.LeaguesEntries league = new();
            league.IsFrontEndEnabled = true;
            league.IsFrontend = true;
            league.IsGenderEnabled = true;
            league.Gender = Convert.ToInt32(Gender);
            league.IsIdEnabled = true;
            league.Id = Global.leagueData.Leagues[Global.leagueData.LeagueCount - 1].Id + 1;
            league.IsNameEnabled = true;

            string sex = "(M)";

            if (Gender)
                sex = "(F)";

            league.Name = "CUSTOM LEAGUE " + sex;
            league.NameSize = Convert.ToByte(league.Name.Length);
            league.IsShortNameEnabled = true;
            league.ShortName = "CL " + sex;
            league.ShortNameSize = Convert.ToByte(league.ShortName.Length);

            league.Teams = new LeagueData.TeamsEntries[43];

            for (int i = 0; i < 43; i++)
            {
                league.Teams[i] = new LeagueData.TeamsEntries();
            }

            league.Teams[0].IsTeamEnabled = true;
            league.Teams[1].IsTeamEnabled = true;
            league.Teams[0].TeamId = 1;
            league.Teams[1].TeamId = 2;

            if (Gender)
            {
                league.Teams[0].TeamId = 212;
                league.Teams[1].TeamId = 213;
            }


            Global.leagueData.Leagues[Global.leagueData.LeagueCount] = league;
            Global.leagueData.LeagueCount = Global.leagueData.LeagueCount + 1;
        }

        public static void DeleteLeague(int removeIndex)
        {
            LeagueData.LeaguesEntries[] leagues = new LeagueData.LeaguesEntries[20];
            int LeagueCount = Global.leagueData.LeagueCount - 1;

            for (int i = 0, j = 0; i < LeagueCount; i++, j++)
            {
                if (i == removeIndex)
                {
                    j++;
                }

                leagues[i] = Global.leagueData.Leagues[j];
            }

            Global.leagueData.Leagues = leagues;
            Global.leagueData.LeagueCount = LeagueCount;
        }
    }
}
