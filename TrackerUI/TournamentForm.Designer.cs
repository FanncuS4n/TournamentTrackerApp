namespace TrackerUI;

partial class TournamentForm
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
        HeaderLabel = new Label();
        TournamentName = new Label();
        RoundLabel = new Label();
        TeamOneName = new Label();
        TeamOneScore = new Label();
        VersusLabel = new Label();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        UnplayedOnlyCheckBox = new CheckBox();
        ScoreButton = new Button();
        RoundDropdown = new ComboBox();
        MatchupListBox = new ListBox();
        TeamOneScoreValue = new TextBox();
        TeamTwoScoreValue = new TextBox();
        TeamTwoScore = new Label();
        TeamTwoName = new Label();
        SuspendLayout();
        // 
        // HeaderLabel
        // 
        HeaderLabel.AutoSize = true;
        HeaderLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        HeaderLabel.Location = new Point(38, 18);
        HeaderLabel.Margin = new Padding(5, 0, 5, 0);
        HeaderLabel.Name = "HeaderLabel";
        HeaderLabel.Size = new Size(164, 37);
        HeaderLabel.TabIndex = 0;
        HeaderLabel.Text = "Tournament:";
        // 
        // TournamentName
        // 
        TournamentName.AutoSize = true;
        TournamentName.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TournamentName.Location = new Point(307, 18);
        TournamentName.Margin = new Padding(5, 0, 5, 0);
        TournamentName.Name = "TournamentName";
        TournamentName.Size = new Size(118, 37);
        TournamentName.TabIndex = 1;
        TournamentName.Text = "<None>";
        // 
        // RoundLabel
        // 
        RoundLabel.AutoSize = true;
        RoundLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        RoundLabel.Location = new Point(38, 146);
        RoundLabel.Margin = new Padding(5, 0, 5, 0);
        RoundLabel.Name = "RoundLabel";
        RoundLabel.Size = new Size(73, 30);
        RoundLabel.TabIndex = 2;
        RoundLabel.Text = "Round";
        // 
        // TeamOneName
        // 
        TeamOneName.AutoSize = true;
        TeamOneName.Font = new Font("Segoe UI", 16F);
        TeamOneName.Location = new Point(665, 332);
        TeamOneName.Margin = new Padding(5, 0, 5, 0);
        TeamOneName.Name = "TeamOneName";
        TeamOneName.Size = new Size(142, 30);
        TeamOneName.TabIndex = 3;
        TeamOneName.Text = "<Team One>";
        // 
        // TeamOneScore
        // 
        TeamOneScore.AutoSize = true;
        TeamOneScore.Font = new Font("Segoe UI", 16F);
        TeamOneScore.Location = new Point(667, 392);
        TeamOneScore.Margin = new Padding(5, 0, 5, 0);
        TeamOneScore.Name = "TeamOneScore";
        TeamOneScore.Size = new Size(68, 30);
        TeamOneScore.TabIndex = 4;
        TeamOneScore.Text = "Score";
        // 
        // VersusLabel
        // 
        VersusLabel.AutoSize = true;
        VersusLabel.Font = new Font("Segoe UI", 16F);
        VersusLabel.Location = new Point(790, 500);
        VersusLabel.Margin = new Padding(5, 0, 5, 0);
        VersusLabel.Name = "VersusLabel";
        VersusLabel.Size = new Size(69, 30);
        VersusLabel.TabIndex = 5;
        VersusLabel.Text = "- VS -";
        // 
        // UnplayedOnlyCheckBox
        // 
        UnplayedOnlyCheckBox.AutoSize = true;
        UnplayedOnlyCheckBox.FlatStyle = FlatStyle.Flat;
        UnplayedOnlyCheckBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        UnplayedOnlyCheckBox.Location = new Point(38, 242);
        UnplayedOnlyCheckBox.Margin = new Padding(5, 6, 5, 6);
        UnplayedOnlyCheckBox.Name = "UnplayedOnlyCheckBox";
        UnplayedOnlyCheckBox.Size = new Size(165, 34);
        UnplayedOnlyCheckBox.TabIndex = 6;
        UnplayedOnlyCheckBox.Text = "Unplayed Only";
        UnplayedOnlyCheckBox.UseVisualStyleBackColor = true;
        UnplayedOnlyCheckBox.CheckedChanged += UnplayedOnlyCheckBox_CheckedChanged;
        // 
        // ScoreButton
        // 
        ScoreButton.FlatAppearance.BorderColor = Color.Silver;
        ScoreButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
        ScoreButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
        ScoreButton.FlatStyle = FlatStyle.Flat;
        ScoreButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        ScoreButton.Location = new Point(1070, 480);
        ScoreButton.Margin = new Padding(5, 6, 5, 6);
        ScoreButton.Name = "ScoreButton";
        ScoreButton.Size = new Size(201, 102);
        ScoreButton.TabIndex = 7;
        ScoreButton.Text = "Score";
        ScoreButton.UseVisualStyleBackColor = true;
        ScoreButton.Click += ScoreButton_Click;
        // 
        // RoundDropdown
        // 
        RoundDropdown.FormattingEnabled = true;
        RoundDropdown.Location = new Point(189, 160);
        RoundDropdown.Margin = new Padding(5, 6, 5, 6);
        RoundDropdown.Name = "RoundDropdown";
        RoundDropdown.Size = new Size(297, 38);
        RoundDropdown.TabIndex = 8;
        RoundDropdown.SelectedIndexChanged += RoundDropdown_SelectedIndexChanged;
        // 
        // MatchupListBox
        // 
        MatchupListBox.BorderStyle = BorderStyle.FixedSingle;
        MatchupListBox.FormattingEnabled = true;
        MatchupListBox.ItemHeight = 30;
        MatchupListBox.Location = new Point(38, 332);
        MatchupListBox.Margin = new Padding(5, 6, 5, 6);
        MatchupListBox.Name = "MatchupListBox";
        MatchupListBox.Size = new Size(492, 482);
        MatchupListBox.TabIndex = 9;
        MatchupListBox.SelectedIndexChanged += MatchupListBox_SelectedIndexChanged;
        // 
        // TeamOneScoreValue
        // 
        TeamOneScoreValue.Location = new Point(792, 406);
        TeamOneScoreValue.Margin = new Padding(5, 6, 5, 6);
        TeamOneScoreValue.Name = "TeamOneScoreValue";
        TeamOneScoreValue.Size = new Size(227, 36);
        TeamOneScoreValue.TabIndex = 10;
        // 
        // TeamTwoScoreValue
        // 
        TeamTwoScoreValue.Location = new Point(792, 656);
        TeamTwoScoreValue.Margin = new Padding(5, 6, 5, 6);
        TeamTwoScoreValue.Name = "TeamTwoScoreValue";
        TeamTwoScoreValue.Size = new Size(227, 36);
        TeamTwoScoreValue.TabIndex = 13;
        // 
        // TeamTwoScore
        // 
        TeamTwoScore.AutoSize = true;
        TeamTwoScore.Font = new Font("Segoe UI", 16F);
        TeamTwoScore.Location = new Point(665, 642);
        TeamTwoScore.Margin = new Padding(5, 0, 5, 0);
        TeamTwoScore.Name = "TeamTwoScore";
        TeamTwoScore.Size = new Size(68, 30);
        TeamTwoScore.TabIndex = 12;
        TeamTwoScore.Text = "Score";
        // 
        // TeamTwoName
        // 
        TeamTwoName.AutoSize = true;
        TeamTwoName.Font = new Font("Segoe UI", 16F);
        TeamTwoName.Location = new Point(667, 582);
        TeamTwoName.Margin = new Padding(5, 0, 5, 0);
        TeamTwoName.Name = "TeamTwoName";
        TeamTwoName.Size = new Size(141, 30);
        TeamTwoName.TabIndex = 11;
        TeamTwoName.Text = "<Team Two>";
        // 
        // TournamentForm
        // 
        AutoScaleDimensions = new SizeF(12F, 30F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1371, 900);
        Controls.Add(TeamTwoScoreValue);
        Controls.Add(TeamTwoScore);
        Controls.Add(TeamTwoName);
        Controls.Add(TeamOneScoreValue);
        Controls.Add(MatchupListBox);
        Controls.Add(RoundDropdown);
        Controls.Add(ScoreButton);
        Controls.Add(UnplayedOnlyCheckBox);
        Controls.Add(VersusLabel);
        Controls.Add(TeamOneScore);
        Controls.Add(TeamOneName);
        Controls.Add(RoundLabel);
        Controls.Add(TournamentName);
        Controls.Add(HeaderLabel);
        Font = new Font("Segoe UI", 16F);
        Margin = new Padding(5, 6, 5, 6);
        Name = "TournamentForm";
        Text = " ";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label HeaderLabel;
    private Label TournamentName;
    private Label RoundLabel;
    private Label TeamOneName;
    private Label TeamOneScore;
    private Label VersusLabel;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private CheckBox UnplayedOnlyCheckBox;
    private Button ScoreButton;
    private ComboBox RoundDropdown;
    private ListBox MatchupListBox;
    private TextBox TeamOneScoreValue;
    private TextBox TeamTwoScoreValue;
    private Label TeamTwoScore;
    private Label TeamTwoName;
}
