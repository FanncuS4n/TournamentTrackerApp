namespace TrackerUI
{
    partial class CreateTeamForm
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
            TeamNameValue = new TextBox();
            TeamNameLabel = new Label();
            HeaderLabel = new Label();
            AddMemberButton = new Button();
            SelectTeamMemberDropdown = new ComboBox();
            SelectTeamMemberLabel = new Label();
            AddNewMemberGroupBox = new GroupBox();
            CreateMemberButton = new Button();
            CellphoneValue = new TextBox();
            CellphoneLabel = new Label();
            EmailValue = new TextBox();
            LastNameValue = new TextBox();
            EmailLable = new Label();
            LastNameLabel = new Label();
            FirstNameValue = new TextBox();
            FirstNameLabel = new Label();
            TeamMembersListBox = new ListBox();
            RemoveSelectedButton = new Button();
            CreateTeamButton = new Button();
            AddNewMemberGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // TeamNameValue
            // 
            TeamNameValue.Location = new Point(43, 127);
            TeamNameValue.Margin = new Padding(5, 6, 5, 6);
            TeamNameValue.Name = "TeamNameValue";
            TeamNameValue.Size = new Size(417, 36);
            TeamNameValue.TabIndex = 15;
            // 
            // TeamNameLabel
            // 
            TeamNameLabel.AutoSize = true;
            TeamNameLabel.Font = new Font("Segoe UI", 16F);
            TeamNameLabel.Location = new Point(48, 91);
            TeamNameLabel.Margin = new Padding(5, 0, 5, 0);
            TeamNameLabel.Name = "TeamNameLabel";
            TeamNameLabel.Size = new Size(129, 30);
            TeamNameLabel.TabIndex = 14;
            TeamNameLabel.Text = "Team Name";
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HeaderLabel.Location = new Point(13, 19);
            HeaderLabel.Margin = new Padding(5, 0, 5, 0);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(163, 37);
            HeaderLabel.TabIndex = 13;
            HeaderLabel.Text = "Create Team";
            // 
            // AddMemberButton
            // 
            AddMemberButton.FlatAppearance.BorderColor = Color.Silver;
            AddMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            AddMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            AddMemberButton.FlatStyle = FlatStyle.Flat;
            AddMemberButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddMemberButton.Location = new Point(129, 290);
            AddMemberButton.Margin = new Padding(5, 6, 5, 6);
            AddMemberButton.Name = "AddMemberButton";
            AddMemberButton.Size = new Size(214, 46);
            AddMemberButton.TabIndex = 21;
            AddMemberButton.Text = "Add Member";
            AddMemberButton.UseVisualStyleBackColor = true;
            AddMemberButton.Click += AddMemberButton_Click;
            // 
            // SelectTeamMemberDropdown
            // 
            SelectTeamMemberDropdown.FormattingEnabled = true;
            SelectTeamMemberDropdown.Location = new Point(43, 240);
            SelectTeamMemberDropdown.Margin = new Padding(5, 6, 5, 6);
            SelectTeamMemberDropdown.Name = "SelectTeamMemberDropdown";
            SelectTeamMemberDropdown.Size = new Size(422, 38);
            SelectTeamMemberDropdown.TabIndex = 20;
            SelectTeamMemberDropdown.SelectedIndexChanged += SelectTeamMemberDropdown_SelectedIndexChanged;
            // 
            // SelectTeamMemberLabel
            // 
            SelectTeamMemberLabel.AutoSize = true;
            SelectTeamMemberLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectTeamMemberLabel.Location = new Point(48, 204);
            SelectTeamMemberLabel.Margin = new Padding(5, 0, 5, 0);
            SelectTeamMemberLabel.Name = "SelectTeamMemberLabel";
            SelectTeamMemberLabel.Size = new Size(207, 30);
            SelectTeamMemberLabel.TabIndex = 19;
            SelectTeamMemberLabel.Text = "Select Team Member";
            // 
            // AddNewMemberGroupBox
            // 
            AddNewMemberGroupBox.Controls.Add(CreateMemberButton);
            AddNewMemberGroupBox.Controls.Add(CellphoneValue);
            AddNewMemberGroupBox.Controls.Add(CellphoneLabel);
            AddNewMemberGroupBox.Controls.Add(EmailValue);
            AddNewMemberGroupBox.Controls.Add(LastNameValue);
            AddNewMemberGroupBox.Controls.Add(EmailLable);
            AddNewMemberGroupBox.Controls.Add(LastNameLabel);
            AddNewMemberGroupBox.Controls.Add(FirstNameValue);
            AddNewMemberGroupBox.Controls.Add(FirstNameLabel);
            AddNewMemberGroupBox.Location = new Point(48, 370);
            AddNewMemberGroupBox.Name = "AddNewMemberGroupBox";
            AddNewMemberGroupBox.Size = new Size(412, 346);
            AddNewMemberGroupBox.TabIndex = 22;
            AddNewMemberGroupBox.TabStop = false;
            AddNewMemberGroupBox.Text = "Add New Member";
            // 
            // CreateMemberButton
            // 
            CreateMemberButton.FlatAppearance.BorderColor = Color.Silver;
            CreateMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            CreateMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            CreateMemberButton.FlatStyle = FlatStyle.Flat;
            CreateMemberButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateMemberButton.Location = new Point(92, 266);
            CreateMemberButton.Margin = new Padding(5, 6, 5, 6);
            CreateMemberButton.Name = "CreateMemberButton";
            CreateMemberButton.Size = new Size(203, 38);
            CreateMemberButton.TabIndex = 23;
            CreateMemberButton.Text = "Create Member";
            CreateMemberButton.UseVisualStyleBackColor = true;
            CreateMemberButton.Click += CreateMemberButton_Click;
            // 
            // CellphoneValue
            // 
            CellphoneValue.Location = new Point(141, 184);
            CellphoneValue.Margin = new Padding(5, 6, 5, 6);
            CellphoneValue.Name = "CellphoneValue";
            CellphoneValue.Size = new Size(227, 36);
            CellphoneValue.TabIndex = 28;
            // 
            // CellphoneLabel
            // 
            CellphoneLabel.AutoSize = true;
            CellphoneLabel.Font = new Font("Segoe UI", 16F);
            CellphoneLabel.Location = new Point(11, 187);
            CellphoneLabel.Margin = new Padding(5, 0, 5, 0);
            CellphoneLabel.Name = "CellphoneLabel";
            CellphoneLabel.Size = new Size(130, 30);
            CellphoneLabel.TabIndex = 27;
            CellphoneLabel.Text = "Cellphone #";
            // 
            // EmailValue
            // 
            EmailValue.Location = new Point(141, 128);
            EmailValue.Margin = new Padding(5, 6, 5, 6);
            EmailValue.Name = "EmailValue";
            EmailValue.Size = new Size(227, 36);
            EmailValue.TabIndex = 26;
            // 
            // LastNameValue
            // 
            LastNameValue.Location = new Point(141, 85);
            LastNameValue.Margin = new Padding(5, 6, 5, 6);
            LastNameValue.Name = "LastNameValue";
            LastNameValue.Size = new Size(227, 36);
            LastNameValue.TabIndex = 26;
            // 
            // EmailLable
            // 
            EmailLable.AutoSize = true;
            EmailLable.Font = new Font("Segoe UI", 16F);
            EmailLable.Location = new Point(14, 134);
            EmailLable.Margin = new Padding(5, 0, 5, 0);
            EmailLable.Name = "EmailLable";
            EmailLable.Size = new Size(64, 30);
            EmailLable.TabIndex = 25;
            EmailLable.Text = "Email";
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Font = new Font("Segoe UI", 16F);
            LastNameLabel.Location = new Point(14, 91);
            LastNameLabel.Margin = new Padding(5, 0, 5, 0);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(114, 30);
            LastNameLabel.TabIndex = 25;
            LastNameLabel.Text = "Last Name";
            // 
            // FirstNameValue
            // 
            FirstNameValue.Location = new Point(141, 38);
            FirstNameValue.Margin = new Padding(5, 6, 5, 6);
            FirstNameValue.Name = "FirstNameValue";
            FirstNameValue.Size = new Size(227, 36);
            FirstNameValue.TabIndex = 24;
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Font = new Font("Segoe UI", 16F);
            FirstNameLabel.Location = new Point(14, 44);
            FirstNameLabel.Margin = new Padding(5, 0, 5, 0);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(117, 30);
            FirstNameLabel.TabIndex = 23;
            FirstNameLabel.Text = "First Name";
            // 
            // TeamMembersListBox
            // 
            TeamMembersListBox.BorderStyle = BorderStyle.FixedSingle;
            TeamMembersListBox.FormattingEnabled = true;
            TeamMembersListBox.ItemHeight = 30;
            TeamMembersListBox.Location = new Point(550, 127);
            TeamMembersListBox.Margin = new Padding(5, 6, 5, 6);
            TeamMembersListBox.Name = "TeamMembersListBox";
            TeamMembersListBox.Size = new Size(433, 572);
            TeamMembersListBox.TabIndex = 23;
            // 
            // RemoveSelectedButton
            // 
            RemoveSelectedButton.FlatAppearance.BorderColor = Color.Silver;
            RemoveSelectedButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            RemoveSelectedButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            RemoveSelectedButton.FlatStyle = FlatStyle.Flat;
            RemoveSelectedButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RemoveSelectedButton.Location = new Point(1004, 370);
            RemoveSelectedButton.Margin = new Padding(5, 6, 5, 6);
            RemoveSelectedButton.Name = "RemoveSelectedButton";
            RemoveSelectedButton.Size = new Size(120, 139);
            RemoveSelectedButton.TabIndex = 24;
            RemoveSelectedButton.Text = "Remove Selected";
            RemoveSelectedButton.UseVisualStyleBackColor = true;
            RemoveSelectedButton.Click += RemoveSelectedButton_Click;
            // 
            // CreateTeamButton
            // 
            CreateTeamButton.FlatAppearance.BorderColor = Color.Silver;
            CreateTeamButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            CreateTeamButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            CreateTeamButton.FlatStyle = FlatStyle.Flat;
            CreateTeamButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateTeamButton.Location = new Point(476, 779);
            CreateTeamButton.Margin = new Padding(5, 6, 5, 6);
            CreateTeamButton.Name = "CreateTeamButton";
            CreateTeamButton.Size = new Size(214, 46);
            CreateTeamButton.TabIndex = 25;
            CreateTeamButton.Text = "Create Team";
            CreateTeamButton.UseVisualStyleBackColor = true;
            CreateTeamButton.Click += CreateTeamButton_Click;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1371, 900);
            Controls.Add(CreateTeamButton);
            Controls.Add(RemoveSelectedButton);
            Controls.Add(TeamMembersListBox);
            Controls.Add(AddNewMemberGroupBox);
            Controls.Add(AddMemberButton);
            Controls.Add(SelectTeamMemberDropdown);
            Controls.Add(SelectTeamMemberLabel);
            Controls.Add(TeamNameValue);
            Controls.Add(TeamNameLabel);
            Controls.Add(HeaderLabel);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "CreateTeamForm";
            Text = "CreateTeam Form";
            AddNewMemberGroupBox.ResumeLayout(false);
            AddNewMemberGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TeamNameValue;
        private Label TeamNameLabel;
        private Label HeaderLabel;
        private Button AddMemberButton;
        private ComboBox SelectTeamMemberDropdown;
        private Label SelectTeamMemberLabel;
        private GroupBox AddNewMemberGroupBox;
        private TextBox FirstNameValue;
        private Label FirstNameLabel;
        private Button CreateMemberButton;
        private TextBox CellphoneValue;
        private Label CellphoneLabel;
        private TextBox EmailValue;
        private TextBox LastNameValue;
        private Label EmailLable;
        private Label LastNameLabel;
        private ListBox TeamMembersListBox;
        private Button RemoveSelectedButton;
        private Button CreateTeamButton;
    }
}