namespace R25_Default_Data_Editor
{
    partial class LeaguesEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaguesEditor));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            saveOptionsToolStripMenuItem = new ToolStripMenuItem();
            saveLeagueDataToolStripMenuItem = new ToolStripMenuItem();
            compressLeagueDataToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            status_toolStripStatusLabel = new ToolStripStatusLabel();
            progress_toolStripStatusLabel = new ToolStripStatusLabel();
            toolStripProgressBar = new ToolStripProgressBar();
            leagues_dataGridView = new DataGridView();
            league_contextMenuStrip = new ContextMenuStrip(components);
            addNewLeagueToolStripMenuItem = new ToolStripMenuItem();
            maleToolStripMenuItem = new ToolStripMenuItem();
            femaleToolStripMenuItem = new ToolStripMenuItem();
            removeTeamToolStripMenuItem = new ToolStripMenuItem();
            copyLeagueToolStripMenuItem = new ToolStripMenuItem();
            pasteLeagueToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leagues_dataGridView).BeginInit();
            league_contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, saveOptionsToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.close_16;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(92, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // saveOptionsToolStripMenuItem
            // 
            saveOptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveLeagueDataToolStripMenuItem, compressLeagueDataToolStripMenuItem });
            saveOptionsToolStripMenuItem.Name = "saveOptionsToolStripMenuItem";
            saveOptionsToolStripMenuItem.Size = new Size(88, 20);
            saveOptionsToolStripMenuItem.Text = "Save Options";
            // 
            // saveLeagueDataToolStripMenuItem
            // 
            saveLeagueDataToolStripMenuItem.Image = Properties.Resources.save_icon;
            saveLeagueDataToolStripMenuItem.Name = "saveLeagueDataToolStripMenuItem";
            saveLeagueDataToolStripMenuItem.Size = new Size(195, 22);
            saveLeagueDataToolStripMenuItem.Text = "Save League Data";
            saveLeagueDataToolStripMenuItem.Click += saveLeagueDataToolStripMenuItem_Click;
            // 
            // compressLeagueDataToolStripMenuItem
            // 
            compressLeagueDataToolStripMenuItem.Image = Properties.Resources.winzip;
            compressLeagueDataToolStripMenuItem.Name = "compressLeagueDataToolStripMenuItem";
            compressLeagueDataToolStripMenuItem.Size = new Size(195, 22);
            compressLeagueDataToolStripMenuItem.Text = "Compress League Data";
            compressLeagueDataToolStripMenuItem.Click += compressLeagueDataToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { status_toolStripStatusLabel, progress_toolStripStatusLabel, toolStripProgressBar });
            statusStrip.Location = new Point(0, 725);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // status_toolStripStatusLabel
            // 
            status_toolStripStatusLabel.ForeColor = Color.DarkGreen;
            status_toolStripStatusLabel.Name = "status_toolStripStatusLabel";
            status_toolStripStatusLabel.Size = new Size(483, 17);
            status_toolStripStatusLabel.Spring = true;
            status_toolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progress_toolStripStatusLabel
            // 
            progress_toolStripStatusLabel.Name = "progress_toolStripStatusLabel";
            progress_toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(300, 16);
            // 
            // leagues_dataGridView
            // 
            leagues_dataGridView.AllowUserToAddRows = false;
            leagues_dataGridView.Dock = DockStyle.Fill;
            leagues_dataGridView.Location = new Point(0, 24);
            leagues_dataGridView.MultiSelect = false;
            leagues_dataGridView.Name = "leagues_dataGridView";
            leagues_dataGridView.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
            leagues_dataGridView.RowTemplate.ReadOnly = true;
            leagues_dataGridView.RowTemplate.Resizable = DataGridViewTriState.True;
            leagues_dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            leagues_dataGridView.Size = new Size(800, 701);
            leagues_dataGridView.TabIndex = 2;
            leagues_dataGridView.KeyDown += leagues_dataGridView_KeyDown;
            leagues_dataGridView.MouseClick += leagues_dataGridView_MouseClick;
            leagues_dataGridView.MouseDoubleClick += leagues_dataGridView_MouseDoubleClick;
            // 
            // league_contextMenuStrip
            // 
            league_contextMenuStrip.Items.AddRange(new ToolStripItem[] { addNewLeagueToolStripMenuItem, removeTeamToolStripMenuItem, copyLeagueToolStripMenuItem, pasteLeagueToolStripMenuItem });
            league_contextMenuStrip.Name = "league_contextMenuStrip";
            league_contextMenuStrip.Size = new Size(186, 92);
            // 
            // addNewLeagueToolStripMenuItem
            // 
            addNewLeagueToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { maleToolStripMenuItem, femaleToolStripMenuItem });
            addNewLeagueToolStripMenuItem.Image = Properties.Resources.add_32;
            addNewLeagueToolStripMenuItem.Name = "addNewLeagueToolStripMenuItem";
            addNewLeagueToolStripMenuItem.Size = new Size(185, 22);
            addNewLeagueToolStripMenuItem.Text = "Add New League";
            // 
            // maleToolStripMenuItem
            // 
            maleToolStripMenuItem.Image = Properties.Resources.Male;
            maleToolStripMenuItem.Name = "maleToolStripMenuItem";
            maleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.M;
            maleToolStripMenuItem.Size = new Size(152, 22);
            maleToolStripMenuItem.Text = "Male";
            maleToolStripMenuItem.ToolTipText = "Add a new male league.";
            maleToolStripMenuItem.Click += maleToolStripMenuItem_Click;
            // 
            // femaleToolStripMenuItem
            // 
            femaleToolStripMenuItem.Image = Properties.Resources.Female;
            femaleToolStripMenuItem.Name = "femaleToolStripMenuItem";
            femaleToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            femaleToolStripMenuItem.Size = new Size(152, 22);
            femaleToolStripMenuItem.Text = "Female";
            femaleToolStripMenuItem.ToolTipText = "Add a new female league.";
            femaleToolStripMenuItem.Click += femaleToolStripMenuItem_Click;
            // 
            // removeTeamToolStripMenuItem
            // 
            removeTeamToolStripMenuItem.Image = Properties.Resources.remove_32;
            removeTeamToolStripMenuItem.Name = "removeTeamToolStripMenuItem";
            removeTeamToolStripMenuItem.ShortcutKeys = Keys.Delete;
            removeTeamToolStripMenuItem.Size = new Size(185, 22);
            removeTeamToolStripMenuItem.Text = "Remove League";
            removeTeamToolStripMenuItem.ToolTipText = "Delete selected league.";
            removeTeamToolStripMenuItem.Click += removeTeamToolStripMenuItem_Click;
            // 
            // copyLeagueToolStripMenuItem
            // 
            copyLeagueToolStripMenuItem.Image = Properties.Resources.copy_32;
            copyLeagueToolStripMenuItem.Name = "copyLeagueToolStripMenuItem";
            copyLeagueToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyLeagueToolStripMenuItem.Size = new Size(185, 22);
            copyLeagueToolStripMenuItem.Text = "Copy League";
            copyLeagueToolStripMenuItem.ToolTipText = "Copy selected league.";
            copyLeagueToolStripMenuItem.Click += copyLeagueToolStripMenuItem_Click;
            // 
            // pasteLeagueToolStripMenuItem
            // 
            pasteLeagueToolStripMenuItem.Image = Properties.Resources.paste_32;
            pasteLeagueToolStripMenuItem.Name = "pasteLeagueToolStripMenuItem";
            pasteLeagueToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            pasteLeagueToolStripMenuItem.Size = new Size(185, 22);
            pasteLeagueToolStripMenuItem.Text = "Paste League";
            pasteLeagueToolStripMenuItem.ToolTipText = "Replace selected league from the one you copied.";
            pasteLeagueToolStripMenuItem.Click += pasteLeagueToolStripMenuItem_Click;
            // 
            // LeaguesEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 747);
            Controls.Add(leagues_dataGridView);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Name = "LeaguesEditor";
            Text = "R25 Leagues Editor";
            Load += LeaguesEditor_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)leagues_dataGridView).EndInit();
            league_contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip;
        private DataGridView leagues_dataGridView;
        private ToolStripStatusLabel status_toolStripStatusLabel;
        private ToolStripStatusLabel progress_toolStripStatusLabel;
        private ToolStripProgressBar toolStripProgressBar;
        private ContextMenuStrip league_contextMenuStrip;
        private ToolStripMenuItem addNewLeagueToolStripMenuItem;
        private ToolStripMenuItem maleToolStripMenuItem;
        private ToolStripMenuItem femaleToolStripMenuItem;
        private ToolStripMenuItem removeTeamToolStripMenuItem;
        private ToolStripMenuItem copyLeagueToolStripMenuItem;
        private ToolStripMenuItem pasteLeagueToolStripMenuItem;
        private ToolStripMenuItem saveOptionsToolStripMenuItem;
        private ToolStripMenuItem saveLeagueDataToolStripMenuItem;
        private ToolStripMenuItem compressLeagueDataToolStripMenuItem;
    }
}