namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            LoadExistingTournamentDropdown = new ComboBox();
            LoadExistingTournamentLabel = new Label();
            LoadTournamentButton = new Button();
            CreateTournamentButton = new Button();
            SuspendLayout();
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HeaderLabel.Location = new Point(105, 9);
            HeaderLabel.Margin = new Padding(5, 0, 5, 0);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(295, 37);
            HeaderLabel.TabIndex = 15;
            HeaderLabel.Text = "Tournament Dashboard";
            // 
            // LoadExistingTournamentDropdown
            // 
            LoadExistingTournamentDropdown.FormattingEnabled = true;
            LoadExistingTournamentDropdown.Location = new Point(105, 113);
            LoadExistingTournamentDropdown.Margin = new Padding(5, 6, 5, 6);
            LoadExistingTournamentDropdown.Name = "LoadExistingTournamentDropdown";
            LoadExistingTournamentDropdown.Size = new Size(422, 38);
            LoadExistingTournamentDropdown.TabIndex = 22;
            // 
            // LoadExistingTournamentLabel
            // 
            LoadExistingTournamentLabel.AutoSize = true;
            LoadExistingTournamentLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoadExistingTournamentLabel.Location = new Point(110, 77);
            LoadExistingTournamentLabel.Margin = new Padding(5, 0, 5, 0);
            LoadExistingTournamentLabel.Name = "LoadExistingTournamentLabel";
            LoadExistingTournamentLabel.Size = new Size(252, 30);
            LoadExistingTournamentLabel.TabIndex = 21;
            LoadExistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // LoadTournamentButton
            // 
            LoadTournamentButton.FlatAppearance.BorderColor = Color.Silver;
            LoadTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            LoadTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            LoadTournamentButton.FlatStyle = FlatStyle.Flat;
            LoadTournamentButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoadTournamentButton.Location = new Point(148, 201);
            LoadTournamentButton.Margin = new Padding(5, 6, 5, 6);
            LoadTournamentButton.Name = "LoadTournamentButton";
            LoadTournamentButton.Size = new Size(214, 46);
            LoadTournamentButton.TabIndex = 34;
            LoadTournamentButton.Text = "Load Tournament";
            LoadTournamentButton.UseVisualStyleBackColor = true;
            LoadTournamentButton.Click += LoadTournamentButton_Click;
            // 
            // CreateTournamentButton
            // 
            CreateTournamentButton.FlatAppearance.BorderColor = Color.Silver;
            CreateTournamentButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            CreateTournamentButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            CreateTournamentButton.FlatStyle = FlatStyle.Flat;
            CreateTournamentButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreateTournamentButton.Location = new Point(148, 310);
            CreateTournamentButton.Margin = new Padding(5, 6, 5, 6);
            CreateTournamentButton.Name = "CreateTournamentButton";
            CreateTournamentButton.Size = new Size(257, 78);
            CreateTournamentButton.TabIndex = 35;
            CreateTournamentButton.Text = "Create Tournament";
            CreateTournamentButton.UseVisualStyleBackColor = true;
            CreateTournamentButton.Click += CreateTournamentButton_Click;
            // 
            // TournamentDashboardForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(632, 618);
            Controls.Add(CreateTournamentButton);
            Controls.Add(LoadTournamentButton);
            Controls.Add(LoadExistingTournamentDropdown);
            Controls.Add(LoadExistingTournamentLabel);
            Controls.Add(HeaderLabel);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "TournamentDashboardForm";
            Text = "Tournament Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeaderLabel;
        private ComboBox LoadExistingTournamentDropdown;
        private Label LoadExistingTournamentLabel;
        private Button LoadTournamentButton;
        private Button CreateTournamentButton;
    }
}