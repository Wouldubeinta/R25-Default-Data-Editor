namespace R25_Default_Data_Editor
{
    public partial class SelectionMenu : Form
    {
        public SelectionMenu()
        {
            InitializeComponent();
        }

        private void leagueEditor_button_Click(object sender, EventArgs e)
        {
            Hide();
            LeaguesEditor leagueEditors = new();
            leagueEditors.ShowDialog();
            Close();
        }
    }
}
