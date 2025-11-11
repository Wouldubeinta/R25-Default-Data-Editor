using System.Data;

namespace R25_Default_Data_Editor
{
    public partial class LeagueEditor : Form
    {
        private readonly DataGridView leagues_dataGridView;

        public LeagueEditor(DataGridView leagues_dataGridView)
        {
            InitializeComponent();
            this.leagues_dataGridView = leagues_dataGridView;
        }

        private int LeagueIndex = 0;

        private void LeagueEditor_Load(object sender, EventArgs e)
        {
            try
            {
                leagueIndex_textBox.Text = Global.leagueIndex.ToString();
                LeagueIndex = Global.leagueIndex;
                leagueId_textBox.Text = Global.leagueData.Leagues[LeagueIndex].Id.ToString();
                sortOrder_textBox.Text = Global.leagueData.Leagues[LeagueIndex].UiSorting.ToString();
                eaFlag_textBox.Text = Global.leagueData.Leagues[LeagueIndex].EAFlag.ToString();
                leagueIsFrontEnd_checkBox.Checked = Global.leagueData.Leagues[LeagueIndex].IsFrontend;
                leagueIsWorldCup_checkBox.Checked = Global.leagueData.Leagues[LeagueIndex].IsWorldCupLeague;
                leagueName_textBox.Text = Global.leagueData.Leagues[LeagueIndex].Name;
                leagueTitle_label.Text = Global.leagueData.Leagues[LeagueIndex].Name;
                leagueShortName_textBox.Text = Global.leagueData.Leagues[LeagueIndex].ShortName;
                leagueGender_comboBox.SelectedIndex = Global.leagueData.Leagues[LeagueIndex].Gender;
                Bitmap logo = BitmapImage.GetLeagueLogo(LeagueIndex);

                if (leagueGender_comboBox.SelectedIndex == 1)
                    SexLogo_label.Image = Properties.Resources.Female;

                leagueTitle_pictureBox.Image = logo;
                league_pictureBox.Image = logo;
                AddTeams();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AddTeams()
        {
            DataTable? dt = null;
            DataGridViewComboBoxColumn? cmb = null;
            DataGridViewTextBoxColumn? column = null;

            try
            {
                if (Global.teamsList == null)
                    return;

                dt = new DataTable();

                column = new DataGridViewTextBoxColumn();
                column.Name = "Index";
                column.DataPropertyName = "Index";
                column.HeaderText = "Index";

                cmb = new DataGridViewComboBoxColumn();
                cmb.Name = "Team";
                cmb.DataPropertyName = "Team";
                cmb.HeaderText = "Team";

                cmb.Items.Add("---Empty---");

                foreach (var team in Global.teamsList)
                {
                    cmb.Items.Add("[" + team.Id + "] - " + team.TeamName);
                }

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("Team", typeof(string));

                for (int i = 0; i < Global.leagueData.Leagues[LeagueIndex].Teams.Length; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i + 1;
                    dt.Rows[dt.Rows.Count - 1]["Team"] = IO.GetTeamName(Global.leagueData.Leagues[LeagueIndex].Teams[i].TeamId);
                }

                leagueTeams_dataGridView.Columns.Add(column);
                leagueTeams_dataGridView.Columns.Add(cmb);
                leagueTeams_dataGridView.DataSource = dt;
                leagueTeams_dataGridView.Columns["Team"].Width = 300;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void leagueSaveChangers_button_Click(object sender, EventArgs e)
        {
            leagueTeams_dataGridView.Rows[0].Cells[0].Selected = true;

            Global.leagueData.Leagues[LeagueIndex].Id = Convert.ToInt32(leagueId_textBox.Text);
            Global.leagueData.Leagues[LeagueIndex].IsFrontend = leagueIsFrontEnd_checkBox.Checked;
            Global.leagueData.Leagues[LeagueIndex].IsWorldCupLeague = leagueIsWorldCup_checkBox.Checked;
            Global.leagueData.Leagues[LeagueIndex].Name = leagueName_textBox.Text;
            Global.leagueData.Leagues[LeagueIndex].NameSize = Convert.ToByte(leagueName_textBox.Text.Length);
            Global.leagueData.Leagues[LeagueIndex].ShortName = leagueShortName_textBox.Text;
            Global.leagueData.Leagues[LeagueIndex].ShortNameSize = Convert.ToByte(leagueShortName_textBox.Text.Length);
            Global.leagueData.Leagues[LeagueIndex].Gender = leagueGender_comboBox.SelectedIndex;

            for (int i = 0; i < 43; i++)
            {
                Global.leagueData.Leagues[LeagueIndex].Teams[i].IsTeamEnabled = false;
                Global.leagueData.Leagues[LeagueIndex].Teams[i].TeamId = 0;

                int id = IO.GetTeamIndex(leagueTeams_dataGridView.Rows[i].Cells[1].Value.ToString());

                if (id > 0)
                {
                    Global.leagueData.Leagues[LeagueIndex].Teams[i].IsTeamEnabled = true;
                    Global.leagueData.Leagues[LeagueIndex].Teams[i].TeamId = id;
                }
            }

            leagueTitle_label.Text = Global.leagueData.Leagues[LeagueIndex].Name;

            UI.LoadLeagues(leagues_dataGridView);

            MessageBox.Show("Changers have been saved to this league", "Save Changers Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void leagueGender_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (leagueGender_comboBox.SelectedIndex == 0)
                SexLogo_label.Image = Properties.Resources.Male;
            else
                SexLogo_label.Image = Properties.Resources.Female;
        }
    }
}
