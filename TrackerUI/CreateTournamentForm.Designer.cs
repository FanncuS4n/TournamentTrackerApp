﻿namespace TrackerUI
{
    partial class CreateTournamentForm
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
            HeaderLabel = new Label();
            TournamentNameValue = new TextBox();
            TournamentNameLabel = new Label();
            EntryFeeValue = new TextBox();
            EntryFeeLabel = new Label();
            SelectTeamDropdown = new ComboBox();
            SelectTeamLabel = new Label();
            CreateNewTeamLink = new LinkLabel();
            AddTeamButton = new Button();
            CreatePriceButton = new Button();
            TournamentTeamsListBox = new ListBox();
            TournamentPlayersLable = new Label();
            RemoveSelectedTeam = new Button();
            RemoveSelectedPrizeButton = new Button();
            PrizesLabel = new Label();
            PrizesListBox = new ListBox();
            CreateTournamentButton = new Button();
            SuspendLayout();
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HeaderLabel.Location = new Point(21, 18);
            HeaderLabel.Margin = new Padding(5, 0, 5, 0);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(242, 37);
            HeaderLabel.TabIndex = 1;
            HeaderLabel.Text = "Create Tournament";
            // 
            // TournamentNameValue
            // 
            TournamentNameValue.Location = new Point(26, 228);
            TournamentNameValue.Margin = new Padding(5, 6, 5, 6);
            TournamentNameValue.Name = "TournamentNameValue";
            TournamentNameValue.Size = new Size(407, 36);
            TournamentNameValue.TabIndex = 12;
            // 
            // TournamentNameLabel
            // 
            TournamentNameLabel.AutoSize = true;
            TournamentNameLabel.Font = new Font("Segoe UI", 16F);
            TournamentNameLabel.Location = new Point(26, 162);
            TournamentNameLabel.Margin = new Padding(5, 0, 5, 0);
            TournamentNameLabel.Name = "TournamentNameLabel";
            TournamentNameLabel.Size = new Size(189, 30);
            TournamentNameLabel.TabIndex = 11;
            TournamentNameLabel.Text = "Tournament name";
            // 
            // EntryFeeValue
            // 
            EntryFeeValue.Location = new Point(213, 328);
            EntryFeeValue.Margin = new Padding(5, 6, 5, 6);
            EntryFeeValue.Name = "EntryFeeValue";
            EntryFeeValue.Size = new Size(220, 36);
            EntryFeeValue.TabIndex = 14;
            EntryFeeValue.Text = "0";
            // 
            // EntryFeeLabel
            // 
            EntryFeeLabel.AutoSize = true;
            EntryFeeLabel.Font = new Font("Segoe UI", 16F);
            EntryFeeLabel.Location = new Point(26, 314);
            EntryFeeLabel.Margin = new Padding(5, 0, 5, 0);
            EntryFeeLabel.Name = "EntryFeeLabel";
            EntryFeeLabel.Size = new Size(103, 30);
            EntryFeeLabel.TabIndex = 13;
            EntryFeeLabel.Text = "Entry Fee";
            // 
            // SelectTeamDropdown
            // 
            SelectTeamDropdown.FormattingEnabled = true;
            SelectTeamDropdown.Location = new Point(21, 486);
            SelectTeamDropdown.Margin = new Padding(5, 6, 5, 6);
            SelectTeamDropdown.Name = "SelectTeamDropdown";
            SelectTeamDropdown.Size = new Size(412, 38);
            SelectTeamDropdown.TabIndex = 16;
            // 
            // SelectTeamLabel
            // 
            SelectTeamLabel.AutoSize = true;
            SelectTeamLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SelectTeamLabel.Location = new Point(26, 420);
            SelectTeamLabel.Margin = new Padding(5, 0, 5, 0);
            SelectTeamLabel.Name = "SelectTeamLabel";
            SelectTeamLabel.Size = new Size(123, 30);
            SelectTeamLabel.TabIndex = 15;
            SelectTeamLabel.Text = "Select Team";
            // 
            // CreateNewTeamLink
            // 
            CreateNewTeamLink.AutoSize = true;
            CreateNewTeamLink.Location = new Point(331, 444);
            CreateNewTeamLink.Margin = new Padding(5, 0, 5, 0);
            CreateNewTeamLink.Name = "CreateNewTeamLink";
            CreateNewTeamLink.Size = new Size(112, 30);
            CreateNewTeamLink.TabIndex = 17;
            CreateNewTeamLink.TabStop = true;
            CreateNewTeamLink.Text = "New team";
            CreateNewTeamLink.LinkClicked += CreateNewTeamLink_LinkClicked;
            // 
            // AddTeamButton
            // 
            AddTeamButton.FlatAppearance.BorderColor = Color.Silver;
            AddTeamButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            AddTeamButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            AddTeamButton.FlatStyle = FlatStyle.Flat;
            AddTeamButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddTeamButton.Location = new Point(21, 564);
            AddTeamButton.Margin = new Padding(5, 6, 5, 6);
            AddTeamButton.Name = "AddTeamButton";
            AddTeamButton.Size = new Size(333, 102);
            AddTeamButton.TabIndex = 18;
            AddTeamButton.Text = "Add Team";
            AddTeamButton.UseVisualStyleBackColor = true;
            AddTeamButton.Click += AddTeamButton_Click;
            // 
            // CreatePriceButton
            // 
            CreatePriceButton.FlatAppearance.BorderColor = Color.Silver;
            CreatePriceButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            CreatePriceButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            CreatePriceButton.FlatStyle = FlatStyle.Flat;
            CreatePriceButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreatePriceButton.Location = new Point(21, 678);
            CreatePriceButton.Margin = new Padding(5, 6, 5, 6);
            CreatePriceButton.Name = "CreatePriceButton";
            CreatePriceButton.Size = new Size(333, 102);
            CreatePriceButton.TabIndex = 19;
            CreatePriceButton.Text = "Create Prize";
            CreatePriceButton.UseVisualStyleBackColor = true;
            CreatePriceButton.Click += CreatePriceButton_Click;
            // 
            // TournamentTeamsListBox
            // 
            TournamentTeamsListBox.BorderStyle = BorderStyle.FixedSingle;
            TournamentTeamsListBox.FormattingEnabled = true;
            TournamentTeamsListBox.ItemHeight = 30;
            TournamentTeamsListBox.Location = new Point(552, 162);
            TournamentTeamsListBox.Margin = new Padding(5, 6, 5, 6);
            TournamentTeamsListBox.Name = "TournamentTeamsListBox";
            TournamentTeamsListBox.Size = new Size(492, 152);
            TournamentTeamsListBox.TabIndex = 20;
            // 
            // TournamentPlayersLable
            // 
            TournamentPlayersLable.AutoSize = true;
            TournamentPlayersLable.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TournamentPlayersLable.Location = new Point(552, 82);
            TournamentPlayersLable.Margin = new Padding(5, 0, 5, 0);
            TournamentPlayersLable.Name = "TournamentPlayersLable";
            TournamentPlayersLable.Size = new Size(198, 37);
            TournamentPlayersLable.TabIndex = 21;
            TournamentPlayersLable.Text = "Teams / Players";
            // 
            // RemoveSelectedTeam
            // 
            RemoveSelectedTeam.FlatAppearance.BorderColor = Color.Silver;
            RemoveSelectedTeam.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            RemoveSelectedTeam.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            RemoveSelectedTeam.FlatStyle = FlatStyle.Flat;
            RemoveSelectedTeam.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RemoveSelectedTeam.Location = new Point(1116, 170);
            RemoveSelectedTeam.Margin = new Padding(5, 6, 5, 6);
            RemoveSelectedTeam.Name = "RemoveSelectedTeam";
            RemoveSelectedTeam.Size = new Size(201, 146);
            RemoveSelectedTeam.TabIndex = 22;
            RemoveSelectedTeam.Text = "Remove Selected";
            RemoveSelectedTeam.UseVisualStyleBackColor = true;
            RemoveSelectedTeam.Click += RemoveSelectedTeam_Click;
            // 
            // RemoveSelectedPrizeButton
            // 
            RemoveSelectedPrizeButton.FlatAppearance.BorderColor = Color.Silver;
            RemoveSelectedPrizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            RemoveSelectedPrizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            RemoveSelectedPrizeButton.FlatStyle = FlatStyle.Flat;
            RemoveSelectedPrizeButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RemoveSelectedPrizeButton.Location = new Point(1116, 486);
            RemoveSelectedPrizeButton.Margin = new Padding(5, 6, 5, 6);
            RemoveSelectedPrizeButton.Name = "RemoveSelectedPrizeButton";
            RemoveSelectedPrizeButton.Size = new Size(201, 154);
            RemoveSelectedPrizeButton.TabIndex = 25;
            RemoveSelectedPrizeButton.Text = "Remove Selected";
            RemoveSelectedPrizeButton.UseVisualStyleBackColor = true;
            RemoveSelectedPrizeButton.Click += RemoveSelectedPrizeButton_Click;
            // 
            // PrizesLabel
            // 
            PrizesLabel.AutoSize = true;
            PrizesLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PrizesLabel.Location = new Point(552, 400);
            PrizesLabel.Margin = new Padding(5, 0, 5, 0);
            PrizesLabel.Name = "PrizesLabel";
            PrizesLabel.Size = new Size(198, 37);
            PrizesLabel.TabIndex = 24;
            PrizesLabel.Text = "Teams / Players";
            // 
            // PrizesListBox
            // 
            PrizesListBox.BorderStyle = BorderStyle.FixedSingle;
            PrizesListBox.FormattingEnabled = true;
            PrizesListBox.ItemHeight = 30;
            PrizesListBox.Location = new Point(552, 480);
            PrizesListBox.Margin = new Padding(5, 6, 5, 6);
            PrizesListBox.Name = "PrizesListBox";
            PrizesListBox.Size = new Size(492, 152);
            PrizesListBox.TabIndex = 23;
            // 
            // CreateTournamentButton
            // 
            CreateTournamentButton.FlatAppearance.BorderColor = Color.Silver;
            CreateTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            CreateTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            CreateTournamentButton.FlatStyle = FlatStyle.Flat;
            CreateTournamentButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateTournamentButton.Location = new Point(552, 774);
            CreateTournamentButton.Margin = new Padding(5, 6, 5, 6);
            CreateTournamentButton.Name = "CreateTournamentButton";
            CreateTournamentButton.Size = new Size(393, 102);
            CreateTournamentButton.TabIndex = 26;
            CreateTournamentButton.Text = "Create Tournament";
            CreateTournamentButton.UseVisualStyleBackColor = true;
            CreateTournamentButton.Click += CreateTournamentButton_Click;
            // 
            // CreateTournamentForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1371, 900);
            Controls.Add(CreateTournamentButton);
            Controls.Add(RemoveSelectedPrizeButton);
            Controls.Add(PrizesLabel);
            Controls.Add(PrizesListBox);
            Controls.Add(RemoveSelectedTeam);
            Controls.Add(TournamentPlayersLable);
            Controls.Add(TournamentTeamsListBox);
            Controls.Add(CreatePriceButton);
            Controls.Add(AddTeamButton);
            Controls.Add(CreateNewTeamLink);
            Controls.Add(SelectTeamDropdown);
            Controls.Add(SelectTeamLabel);
            Controls.Add(EntryFeeValue);
            Controls.Add(EntryFeeLabel);
            Controls.Add(TournamentNameValue);
            Controls.Add(TournamentNameLabel);
            Controls.Add(HeaderLabel);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "CreateTournamentForm";
            Text = "CreateTournament";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeaderLabel;
        private TextBox TournamentNameValue;
        private Label TournamentNameLabel;
        private TextBox EntryFeeValue;
        private Label EntryFeeLabel;
        private ComboBox SelectTeamDropdown;
        private Label SelectTeamLabel;
        private LinkLabel CreateNewTeamLink;
        private Button AddTeamButton;
        private Button CreatePriceButton;
        private ListBox TournamentTeamsListBox;
        private Label TournamentPlayersLable;
        private Button RemoveSelectedTeam;
        private Button RemoveSelectedPrizeButton;
        private Label PrizesLabel;
        private ListBox PrizesListBox;
        private Button CreateTournamentButton;
    }
}