using System.ComponentModel;
using System.Data;

namespace R25_Default_Data_Editor
{
    /// <summary>
    /// UI stuff.
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
    /// [Wouldubeinta]	   20/10/2025	Created
    /// </history>
    internal class UI
    {
        public static void LoadLeagues(DataGridView dataGridView)
        {
            DataTable? dt = null;
            Bitmap[]? Imagelist = null;

            try
            {
                dt = new DataTable();
                Imagelist = BitmapImage.LeagueLogos();

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Logo", typeof(Image));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Short Name", typeof(string));

                for (int i = 0; i < Global.leagueData.LeagueCount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["ID"] = Global.leagueData.Leagues[i].Id;
                    dt.Rows[dt.Rows.Count - 1]["Logo"] = Imagelist[i];
                    dt.Rows[dt.Rows.Count - 1]["Name"] = Global.leagueData.Leagues[i].Name;
                    dt.Rows[dt.Rows.Count - 1]["Short Name"] = Global.leagueData.Leagues[i].ShortName;
                }

                dataGridView.RowTemplate.Height = 70; // Set a default height for all rows
                dataGridView.DataSource = dt;
                dataGridView.Columns["Logo"].Width = 70;
                dataGridView.Columns["Name"].Width = 260;
                dataGridView.Columns["Short Name"].Width = 180;
                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView.Columns["Logo"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Or Stretch, or Normal

                if (Global.leagueRowIndex != -1)
                {
                    dataGridView.Rows[Global.leagueRowIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[Global.leagueRowIndex].Cells[0];
                    dataGridView.Rows[Global.leagueRowIndex].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void Update_LeagueList(DataGridView dataGridView)
        {
            ListSortDirection[] sd = new ListSortDirection[5];
            bool[] none = new bool[5];

            for (int i = 0; i < 5; i++)
            {
                SortOrder sortOrder = dataGridView.Columns[i].HeaderCell.SortGlyphDirection;

                if (sortOrder != SortOrder.None)
                    sd[i] = sortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                else
                    none[i] = true;
            }

            LoadLeagues(dataGridView);

            for (int i = 0; i < 5; i++)
            {
                if (!none[i])
                    dataGridView.Sort(dataGridView.Columns[i], sd[i]);
            }
        }
    }
}
