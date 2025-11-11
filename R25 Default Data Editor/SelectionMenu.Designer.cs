namespace R25_Default_Data_Editor
{
    partial class SelectionMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionMenu));
            tableLayoutPanel1 = new TableLayoutPanel();
            leagueEditor_button = new Button();
            skillEditor_button = new Button();
            button3 = new Button();
            button4 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(leagueEditor_button, 0, 0);
            tableLayoutPanel1.Controls.Add(skillEditor_button, 1, 0);
            tableLayoutPanel1.Controls.Add(button3, 0, 1);
            tableLayoutPanel1.Controls.Add(button4, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(680, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // leagueEditor_button
            // 
            leagueEditor_button.Dock = DockStyle.Fill;
            leagueEditor_button.Image = Properties.Resources.LeagueEditor;
            leagueEditor_button.Location = new Point(3, 3);
            leagueEditor_button.Name = "leagueEditor_button";
            leagueEditor_button.Size = new Size(334, 219);
            leagueEditor_button.TabIndex = 0;
            leagueEditor_button.UseVisualStyleBackColor = true;
            leagueEditor_button.Click += leagueEditor_button_Click;
            // 
            // skillEditor_button
            // 
            skillEditor_button.Dock = DockStyle.Fill;
            skillEditor_button.Image = Properties.Resources.SkillsEditor;
            skillEditor_button.Location = new Point(343, 3);
            skillEditor_button.Name = "skillEditor_button";
            skillEditor_button.Size = new Size(334, 219);
            skillEditor_button.TabIndex = 1;
            skillEditor_button.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 228);
            button3.Name = "button3";
            button3.Size = new Size(334, 219);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(343, 228);
            button4.Name = "button4";
            button4.Size = new Size(334, 219);
            button4.TabIndex = 3;
            button4.UseVisualStyleBackColor = false;
            // 
            // SelectionMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectionMenu";
            Text = "Editor Selection Menu";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button leagueEditor_button;
        private Button skillEditor_button;
        private Button button3;
        private Button button4;
    }
}
