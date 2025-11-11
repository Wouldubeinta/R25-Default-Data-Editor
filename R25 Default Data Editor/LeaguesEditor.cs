using PackageIO;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace R25_Default_Data_Editor
{
    public partial class LeaguesEditor : Form
    {
        public LeaguesEditor()
        {
            InitializeComponent();
        }

        private LeagueData.LeaguesEntries? _league = new();
        private BackgroundWorker? M3MP_Create_bgw = null;

        public LeagueData.LeaguesEntries? league
        {
            get { return _league; }
            set { _league = value; }
        }

        private void LeaguesEditor_Load(object sender, EventArgs e)
        {
            Global.version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            Global.currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Text = "R25 Leagues Editor - " + Global.version;
            LoadLeagues();
        }

        private void LoadLeagues()
        {
            Reader? br = null;
            Reader? teamList_br = null;
            DataTable? dt = null;
            Bitmap[]? Imagelist = null;

            try
            {
                dt = new ();
                Imagelist = BitmapImage.LeagueLogos();

                string TeamList = Global.currentPath + @"\data\TeamList.dat";

                teamList_br = new (TeamList);
                LeagueTeamList leagueTeamList = new LeagueTeamList();
                leagueTeamList.Deserialize(teamList_br);
                Global.teamsList = leagueTeamList.Entries;

                dt.Columns.Add("Index", typeof(int));
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Logo", typeof(Image));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Short Name", typeof(string));

                br = new (Global.currentPath + @"\defaultdata\defaultdata_leagues", Endian.Little);

                Global.leagueData = new LeagueData();
                Global.leagueData.Deserialize(br);

                if (Global.leagueData == null)
                    return;

                for (int i = 0; i < Global.leagueData.LeagueCount; i++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["Index"] = i;
                    dt.Rows[dt.Rows.Count - 1]["ID"] = Global.leagueData.Leagues[i].Id;
                    dt.Rows[dt.Rows.Count - 1]["Logo"] = Imagelist[i];
                    dt.Rows[dt.Rows.Count - 1]["Name"] = Global.leagueData.Leagues[i].Name;
                    dt.Rows[dt.Rows.Count - 1]["Short Name"] = Global.leagueData.Leagues[i].ShortName;
                }

                leagues_dataGridView.RowTemplate.Height = 70; // Set a default height for all rows
                leagues_dataGridView.DataSource = dt;
                leagues_dataGridView.Columns["Logo"].Width = 70;
                leagues_dataGridView.Columns["Name"].Width = 260;
                leagues_dataGridView.Columns["Short Name"].Width = 180;
                DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)leagues_dataGridView.Columns["Logo"];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Or Stretch, or Normal
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }

        private void leagues_dataGridView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (leagues_dataGridView.RowCount != 0)
            {
                LeagueEditor form = new(leagues_dataGridView);
                form.Show();
            }
        }

        private void leagues_dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (leagues_dataGridView.RowCount > 0)
            {
                Global.leagueRowIndex = leagues_dataGridView.CurrentCell.RowIndex;
                Global.leagueIndex = Convert.ToInt32(leagues_dataGridView.Rows[Global.leagueRowIndex].Cells[0].Value);
            }

            if (e.Button == MouseButtons.Right)
                league_contextMenuStrip.Show(Cursor.Position);
        }

        private void addNewLeague(bool Gender)
        {
            if (Global.leagueData.LeagueCount != 40)
            {
                AddRemove.AddLeague(Gender);
                UI.Update_LeagueList(leagues_dataGridView);

                int RowCount = leagues_dataGridView.RowCount;
                leagues_dataGridView.Rows[RowCount - 1].Selected = true;
                leagues_dataGridView.Focus();
                leagues_dataGridView.CurrentCell = leagues_dataGridView.Rows[RowCount - 1].Cells[0];
                leagues_dataGridView.Rows[RowCount - 1].Visible = true;
            }
            else
                MessageBox.Show("You have reached the league limit", "League Limit Maxed!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void maleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewLeague(false);
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewLeague(true);
        }

        private void removeLeague()
        {
            int RowIndex = leagues_dataGridView.CurrentCell.RowIndex;

            AddRemove.DeleteLeague(leagues_dataGridView.CurrentCell.RowIndex);

            if (RowIndex != -1)
                Global.leagueRowIndex = RowIndex - 1;

            UI.Update_LeagueList(leagues_dataGridView);
        }

        private void removeTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeLeague();
        }

        private void copyLeague()
        {
            league.NameSize = Global.leagueData.Leagues[Global.leagueIndex].NameSize;
            league.Name = Global.leagueData.Leagues[Global.leagueIndex].Name;
            league.ShortNameSize = Global.leagueData.Leagues[Global.leagueIndex].ShortNameSize;
            league.ShortName = Global.leagueData.Leagues[Global.leagueIndex].ShortName;
            league.Gender = Global.leagueData.Leagues[Global.leagueIndex].Gender;
            league.IsFrontend = Global.leagueData.Leagues[Global.leagueIndex].IsFrontend;
            league.IsWorldCupLeague = Global.leagueData.Leagues[Global.leagueIndex].IsWorldCupLeague;

            league.Teams = new LeagueData.TeamsEntries[43];

            for (int i = 0; i < 43; i++)
            {
                league.Teams[i] = new LeagueData.TeamsEntries();
                league.Teams[i] = Global.leagueData.Leagues[Global.leagueIndex].Teams[i];
            }
        }

        private void copyLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyLeague();
        }

        private void pasteLeague()
        {
            if (!string.IsNullOrEmpty(league.Name))
            {
                Global.leagueData.Leagues[Global.leagueIndex].NameSize = league.NameSize;
                Global.leagueData.Leagues[Global.leagueIndex].Name = league.Name;
                Global.leagueData.Leagues[Global.leagueIndex].ShortNameSize = league.ShortNameSize;
                Global.leagueData.Leagues[Global.leagueIndex].ShortName = league.ShortName;
                Global.leagueData.Leagues[Global.leagueIndex].Gender = league.Gender;
                Global.leagueData.Leagues[Global.leagueIndex].IsFrontend = league.IsFrontend;
                Global.leagueData.Leagues[Global.leagueIndex].IsWorldCupLeague = league.IsWorldCupLeague;

                for (int i = 0; i < 43; i++)
                {
                    Global.leagueData.Leagues[Global.leagueIndex].Teams[i] = league.Teams[i];
                }

                UI.Update_LeagueList(leagues_dataGridView);
            }
            else
                MessageBox.Show("No league was copied", "League Paste Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pasteLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteLeague();
        }

        private void leagues_dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (leagues_dataGridView.RowCount > 0)
            {
                if (ModifierKeys == Keys.Control && e.KeyCode == Keys.M)
                    addNewLeague(false);

                if (ModifierKeys == Keys.Control && e.KeyCode == Keys.F)
                    addNewLeague(true);

                if (e.KeyCode == Keys.Delete)
                    removeLeague();

                if (ModifierKeys == Keys.Control && e.KeyCode == Keys.C)
                    copyLeague();

                if (ModifierKeys == Keys.Control && e.KeyCode == Keys.P)
                    pasteLeague();
            }
        }

        private void saveLeagueData() 
        {
            Writer? bw = null;

            try
            {
                bw = new(Global.currentPath + @"\defaultdata\defaultdata_leagues", Endian.Little);
                LeagueData leagueData = Global.leagueData;
                leagueData.Serialize(bw);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred, report it to Wouldy : " + ex, "Hmm, something stuffed up :(", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                if (bw != null)
                    bw.Close();
            }
        }

        private void saveLeagueDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveLeagueData();
            status_toolStripStatusLabel.Text = "Saving to defaultdata_leagues has finished";
            MessageBox.Show("Changers have been saved to the defaultdata_leagues file", "Save To File Is Complete :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void compressLeagueDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveLeagueData();
            M3MP_Create();
        }

        private void M3MP_Create()
        {
            M3MP_Create_bgw = new BackgroundWorker();
            M3MP_Create_bgw.DoWork += new DoWorkEventHandler(M3MP_Create_bgw_DoWork);
            M3MP_Create_bgw.ProgressChanged += new ProgressChangedEventHandler(M3MP_Create_bgw_ProgressChanged);
            M3MP_Create_bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(M3MP_Create_bgw_RunWorkerCompleted);
            M3MP_Create_bgw.WorkerReportsProgress = true;
            M3MP_Create_bgw.WorkerSupportsCancellation = true;
            M3MP_Create_bgw.RunWorkerAsync();
        }

        private void M3MP_Create_bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool errorCheck = M3MP_IO.CreateM3MP(M3MP_Create_bgw);

            if (errorCheck)
                e.Cancel = true;
        }

        private void M3MP_Create_bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            progress_toolStripStatusLabel.Text = string.Format("{0} %", e.ProgressPercentage);
            status_toolStripStatusLabel.Text = e.UserState.ToString();
        }

        private void M3MP_Create_bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                status_toolStripStatusLabel.Text = "M3MP file has finished creating....";
                MessageBox.Show("M3MP file has finished creating", "M3MP Creating", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            toolStripProgressBar.Value = 0;
            progress_toolStripStatusLabel.Text = string.Empty;
            if (M3MP_Create_bgw != null) { M3MP_Create_bgw.Dispose(); M3MP_Create_bgw = null; }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
