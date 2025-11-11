namespace R25_Default_Data_Editor
{
    /// <summary>
    /// Holds all the global variables.
    /// </summary>
    /// <remarks>
    ///   Rugby 25 Default Data Editor. Written by Wouldubeinta
    ///   Copyright (C) 2025 Wouldy Mods.
    ///   
    ///   This program is free software; you can redistribute it and/or
    ///   modify it under the terms of the GNU General Public License
    ///   as published by the Free Software Foundation; either version 2
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
    /// [Wouldubeinta]	   31/10/2025	Created
    /// </history>
    internal class Global
    {
        private static string? _version = string.Empty;
        private static string? _currentPath = string.Empty;
        private static int _leagueIndex = 0;
        private static int _leagueRowIndex = 0;
        private static LeagueTeamList.Entry[]? _teamsList = null;
        private static LeagueData? _leagueData = null;

        public static string? version
        {
            get { return _version; }
            set { _version = value; }
        }

        public static string? currentPath
        {
            get { return _currentPath; }
            set { _currentPath = value; }
        }

        public static int leagueIndex
        {
            get { return _leagueIndex; }
            set { _leagueIndex = value; }
        }

        public static int leagueRowIndex
        {
            get { return _leagueRowIndex; }
            set { _leagueRowIndex = value; }
        }

        public static LeagueData? leagueData
        {
            get { return _leagueData; }
            set { _leagueData = value; }
        }

        public static LeagueTeamList.Entry[]? teamsList
        {
            get { return _teamsList; }
            set { _teamsList = value; }
        }
    }
}
