namespace R25_Default_Data_Editor
{
    partial class LeagueEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeagueEditor));
            tabControl1 = new TabControl();
            info_tabPage = new TabPage();
            SexLogo_label = new Label();
            eaFlag_textBox = new TextBox();
            eaFlag_label = new Label();
            sortOrder_textBox = new TextBox();
            sortOrder_label = new Label();
            leagueIndex_textBox = new TextBox();
            leagueIndex_label = new Label();
            leagueIsWorldCup_checkBox = new CheckBox();
            leagueIsFrontEnd_checkBox = new CheckBox();
            leagueGender_comboBox = new ComboBox();
            leagueGender_label = new Label();
            league_pictureBox = new PictureBox();
            leagueShortName_textBox = new TextBox();
            leagueShortName_label = new Label();
            leagueName_textBox = new TextBox();
            leagueName_label = new Label();
            leagueId_textBox = new TextBox();
            leagueId_label = new Label();
            teams_tabPage = new TabPage();
            leagueTeams_dataGridView = new DataGridView();
            leagueTitle_pictureBox = new PictureBox();
            leagueTitle_label = new Label();
            leagueSaveChangers_button = new Button();
            tabControl1.SuspendLayout();
            info_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)league_pictureBox).BeginInit();
            teams_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)leagueTeams_dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)leagueTitle_pictureBox).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(info_tabPage);
            tabControl1.Controls.Add(teams_tabPage);
            tabControl1.Location = new Point(12, 125);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 514);
            tabControl1.TabIndex = 0;
            // 
            // info_tabPage
            // 
            info_tabPage.Controls.Add(SexLogo_label);
            info_tabPage.Controls.Add(eaFlag_textBox);
            info_tabPage.Controls.Add(eaFlag_label);
            info_tabPage.Controls.Add(sortOrder_textBox);
            info_tabPage.Controls.Add(sortOrder_label);
            info_tabPage.Controls.Add(leagueIndex_textBox);
            info_tabPage.Controls.Add(leagueIndex_label);
            info_tabPage.Controls.Add(leagueIsWorldCup_checkBox);
            info_tabPage.Controls.Add(leagueIsFrontEnd_checkBox);
            info_tabPage.Controls.Add(leagueGender_comboBox);
            info_tabPage.Controls.Add(leagueGender_label);
            info_tabPage.Controls.Add(league_pictureBox);
            info_tabPage.Controls.Add(leagueShortName_textBox);
            info_tabPage.Controls.Add(leagueShortName_label);
            info_tabPage.Controls.Add(leagueName_textBox);
            info_tabPage.Controls.Add(leagueName_label);
            info_tabPage.Controls.Add(leagueId_textBox);
            info_tabPage.Controls.Add(leagueId_label);
            info_tabPage.Location = new Point(4, 24);
            info_tabPage.Name = "info_tabPage";
            info_tabPage.Padding = new Padding(3);
            info_tabPage.Size = new Size(768, 486);
            info_tabPage.TabIndex = 0;
            info_tabPage.Text = "Info";
            info_tabPage.UseVisualStyleBackColor = true;
            // 
            // SexLogo_label
            // 
            SexLogo_label.Image = Properties.Resources.Male;
            SexLogo_label.Location = new Point(194, 228);
            SexLogo_label.Name = "SexLogo_label";
            SexLogo_label.Size = new Size(27, 23);
            SexLogo_label.TabIndex = 18;
            // 
            // eaFlag_textBox
            // 
            eaFlag_textBox.Location = new Point(98, 126);
            eaFlag_textBox.Name = "eaFlag_textBox";
            eaFlag_textBox.Size = new Size(54, 23);
            eaFlag_textBox.TabIndex = 17;
            // 
            // eaFlag_label
            // 
            eaFlag_label.AutoSize = true;
            eaFlag_label.Location = new Point(46, 130);
            eaFlag_label.Name = "eaFlag_label";
            eaFlag_label.Size = new Size(49, 15);
            eaFlag_label.TabIndex = 16;
            eaFlag_label.Text = "EA Flag:";
            // 
            // sortOrder_textBox
            // 
            sortOrder_textBox.Location = new Point(98, 93);
            sortOrder_textBox.Name = "sortOrder_textBox";
            sortOrder_textBox.Size = new Size(54, 23);
            sortOrder_textBox.TabIndex = 15;
            // 
            // sortOrder_label
            // 
            sortOrder_label.AutoSize = true;
            sortOrder_label.Location = new Point(31, 97);
            sortOrder_label.Name = "sortOrder_label";
            sortOrder_label.Size = new Size(64, 15);
            sortOrder_label.TabIndex = 14;
            sortOrder_label.Text = "Sort Order:";
            // 
            // leagueIndex_textBox
            // 
            leagueIndex_textBox.Location = new Point(98, 27);
            leagueIndex_textBox.Name = "leagueIndex_textBox";
            leagueIndex_textBox.ReadOnly = true;
            leagueIndex_textBox.Size = new Size(54, 23);
            leagueIndex_textBox.TabIndex = 13;
            // 
            // leagueIndex_label
            // 
            leagueIndex_label.AutoSize = true;
            leagueIndex_label.Location = new Point(58, 31);
            leagueIndex_label.Name = "leagueIndex_label";
            leagueIndex_label.Size = new Size(38, 15);
            leagueIndex_label.TabIndex = 12;
            leagueIndex_label.Text = "Index:";
            // 
            // leagueIsWorldCup_checkBox
            // 
            leagueIsWorldCup_checkBox.AutoSize = true;
            leagueIsWorldCup_checkBox.CheckAlign = ContentAlignment.MiddleRight;
            leagueIsWorldCup_checkBox.Location = new Point(294, 129);
            leagueIsWorldCup_checkBox.Name = "leagueIsWorldCup_checkBox";
            leagueIsWorldCup_checkBox.Size = new Size(94, 19);
            leagueIsWorldCup_checkBox.TabIndex = 11;
            leagueIsWorldCup_checkBox.Text = "Is World Cup";
            leagueIsWorldCup_checkBox.UseVisualStyleBackColor = true;
            // 
            // leagueIsFrontEnd_checkBox
            // 
            leagueIsFrontEnd_checkBox.AutoSize = true;
            leagueIsFrontEnd_checkBox.CheckAlign = ContentAlignment.MiddleRight;
            leagueIsFrontEnd_checkBox.Location = new Point(176, 129);
            leagueIsFrontEnd_checkBox.Name = "leagueIsFrontEnd_checkBox";
            leagueIsFrontEnd_checkBox.Size = new Size(85, 19);
            leagueIsFrontEnd_checkBox.TabIndex = 10;
            leagueIsFrontEnd_checkBox.Text = "Is Frontend";
            leagueIsFrontEnd_checkBox.UseVisualStyleBackColor = true;
            // 
            // leagueGender_comboBox
            // 
            leagueGender_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            leagueGender_comboBox.FormattingEnabled = true;
            leagueGender_comboBox.Items.AddRange(new object[] { "Male", "Female" });
            leagueGender_comboBox.Location = new Point(98, 227);
            leagueGender_comboBox.Name = "leagueGender_comboBox";
            leagueGender_comboBox.Size = new Size(91, 23);
            leagueGender_comboBox.TabIndex = 9;
            leagueGender_comboBox.SelectedIndexChanged += leagueGender_comboBox_SelectedIndexChanged;
            // 
            // leagueGender_label
            // 
            leagueGender_label.AutoSize = true;
            leagueGender_label.Location = new Point(47, 231);
            leagueGender_label.Name = "leagueGender_label";
            leagueGender_label.Size = new Size(48, 15);
            leagueGender_label.TabIndex = 8;
            leagueGender_label.Text = "Gender:";
            // 
            // league_pictureBox
            // 
            league_pictureBox.Location = new Point(547, 16);
            league_pictureBox.Name = "league_pictureBox";
            league_pictureBox.Size = new Size(200, 200);
            league_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            league_pictureBox.TabIndex = 1;
            league_pictureBox.TabStop = false;
            // 
            // leagueShortName_textBox
            // 
            leagueShortName_textBox.Location = new Point(98, 193);
            leagueShortName_textBox.MaxLength = 20;
            leagueShortName_textBox.Name = "leagueShortName_textBox";
            leagueShortName_textBox.Size = new Size(410, 23);
            leagueShortName_textBox.TabIndex = 5;
            // 
            // leagueShortName_label
            // 
            leagueShortName_label.AutoSize = true;
            leagueShortName_label.Location = new Point(22, 197);
            leagueShortName_label.Name = "leagueShortName_label";
            leagueShortName_label.Size = new Size(73, 15);
            leagueShortName_label.TabIndex = 4;
            leagueShortName_label.Text = "Short Name:";
            // 
            // leagueName_textBox
            // 
            leagueName_textBox.Location = new Point(98, 159);
            leagueName_textBox.MaxLength = 35;
            leagueName_textBox.Name = "leagueName_textBox";
            leagueName_textBox.Size = new Size(410, 23);
            leagueName_textBox.TabIndex = 3;
            // 
            // leagueName_label
            // 
            leagueName_label.AutoSize = true;
            leagueName_label.Location = new Point(53, 163);
            leagueName_label.Name = "leagueName_label";
            leagueName_label.Size = new Size(42, 15);
            leagueName_label.TabIndex = 2;
            leagueName_label.Text = "Name:";
            // 
            // leagueId_textBox
            // 
            leagueId_textBox.Location = new Point(98, 60);
            leagueId_textBox.Name = "leagueId_textBox";
            leagueId_textBox.Size = new Size(54, 23);
            leagueId_textBox.TabIndex = 1;
            // 
            // leagueId_label
            // 
            leagueId_label.AutoSize = true;
            leagueId_label.Location = new Point(75, 64);
            leagueId_label.Name = "leagueId_label";
            leagueId_label.Size = new Size(20, 15);
            leagueId_label.TabIndex = 0;
            leagueId_label.Text = "Id:";
            // 
            // teams_tabPage
            // 
            teams_tabPage.Controls.Add(leagueTeams_dataGridView);
            teams_tabPage.Location = new Point(4, 24);
            teams_tabPage.Name = "teams_tabPage";
            teams_tabPage.Padding = new Padding(3);
            teams_tabPage.Size = new Size(768, 486);
            teams_tabPage.TabIndex = 1;
            teams_tabPage.Text = "Teams";
            teams_tabPage.UseVisualStyleBackColor = true;
            // 
            // leagueTeams_dataGridView
            // 
            leagueTeams_dataGridView.AllowUserToAddRows = false;
            leagueTeams_dataGridView.AllowUserToDeleteRows = false;
            leagueTeams_dataGridView.Dock = DockStyle.Fill;
            leagueTeams_dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            leagueTeams_dataGridView.Location = new Point(3, 3);
            leagueTeams_dataGridView.Name = "leagueTeams_dataGridView";
            leagueTeams_dataGridView.Size = new Size(762, 480);
            leagueTeams_dataGridView.TabIndex = 0;
            // 
            // leagueTitle_pictureBox
            // 
            leagueTitle_pictureBox.Location = new Point(12, 12);
            leagueTitle_pictureBox.Name = "leagueTitle_pictureBox";
            leagueTitle_pictureBox.Size = new Size(100, 100);
            leagueTitle_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            leagueTitle_pictureBox.TabIndex = 1;
            leagueTitle_pictureBox.TabStop = false;
            // 
            // leagueTitle_label
            // 
            leagueTitle_label.Font = new Font("Calibri", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            leagueTitle_label.Location = new Point(118, 39);
            leagueTitle_label.Name = "leagueTitle_label";
            leagueTitle_label.Size = new Size(670, 47);
            leagueTitle_label.TabIndex = 2;
            // 
            // leagueSaveChangers_button
            // 
            leagueSaveChangers_button.Location = new Point(17, 648);
            leagueSaveChangers_button.Name = "leagueSaveChangers_button";
            leagueSaveChangers_button.Size = new Size(99, 32);
            leagueSaveChangers_button.TabIndex = 3;
            leagueSaveChangers_button.Text = "Save Changers";
            leagueSaveChangers_button.UseVisualStyleBackColor = true;
            leagueSaveChangers_button.Click += leagueSaveChangers_button_Click;
            // 
            // LeagueEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 690);
            Controls.Add(leagueSaveChangers_button);
            Controls.Add(leagueTitle_label);
            Controls.Add(leagueTitle_pictureBox);
            Controls.Add(tabControl1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LeagueEditor";
            Text = "League Editor";
            Load += LeagueEditor_Load;
            tabControl1.ResumeLayout(false);
            info_tabPage.ResumeLayout(false);
            info_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)league_pictureBox).EndInit();
            teams_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)leagueTeams_dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)leagueTitle_pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage info_tabPage;
        private TabPage teams_tabPage;
        private Label leagueName_label;
        private TextBox leagueId_textBox;
        private Label leagueId_label;
        private TextBox leagueShortName_textBox;
        private Label leagueShortName_label;
        private TextBox leagueName_textBox;
        private PictureBox league_pictureBox;
        private PictureBox leagueTitle_pictureBox;
        private Label leagueTitle_label;
        private ComboBox leagueGender_comboBox;
        private Label leagueGender_label;
        private CheckBox leagueIsFrontEnd_checkBox;
        private CheckBox leagueIsWorldCup_checkBox;
        private DataGridView leagueTeams_dataGridView;
        private TextBox leagueIndex_textBox;
        private Label leagueIndex_label;
        private Button leagueSaveChangers_button;
        private TextBox eaFlag_textBox;
        private Label eaFlag_label;
        private TextBox sortOrder_textBox;
        private Label sortOrder_label;
        private Label SexLogo_label;
    }
}