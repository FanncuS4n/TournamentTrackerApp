namespace TrackerUI
{
    partial class CreatePrizeForm
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
            PlaceNumberValue = new TextBox();
            PlaceNumberLabel = new Label();
            PrizeAmountValue = new TextBox();
            PrizeAmountLabel = new Label();
            PlaceNameValue = new TextBox();
            PlaceNameLabel = new Label();
            PrizePercentageValue = new TextBox();
            PrizePercentageLabel = new Label();
            OrLabel = new Label();
            CreatePrizeButton = new Button();
            SuspendLayout();
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HeaderLabel.Location = new Point(14, 9);
            HeaderLabel.Margin = new Padding(5, 0, 5, 0);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(158, 37);
            HeaderLabel.TabIndex = 14;
            HeaderLabel.Text = "Create Prize";
            // 
            // PlaceNumberValue
            // 
            PlaceNumberValue.Location = new Point(259, 59);
            PlaceNumberValue.Margin = new Padding(5, 6, 5, 6);
            PlaceNumberValue.Name = "PlaceNumberValue";
            PlaceNumberValue.Size = new Size(227, 36);
            PlaceNumberValue.TabIndex = 26;
            // 
            // PlaceNumberLabel
            // 
            PlaceNumberLabel.AutoSize = true;
            PlaceNumberLabel.Font = new Font("Segoe UI", 16F);
            PlaceNumberLabel.Location = new Point(55, 65);
            PlaceNumberLabel.Margin = new Padding(5, 0, 5, 0);
            PlaceNumberLabel.Name = "PlaceNumberLabel";
            PlaceNumberLabel.Size = new Size(149, 30);
            PlaceNumberLabel.TabIndex = 25;
            PlaceNumberLabel.Text = "Place Number";
            // 
            // PrizeAmountValue
            // 
            PrizeAmountValue.Location = new Point(259, 167);
            PrizeAmountValue.Margin = new Padding(5, 6, 5, 6);
            PrizeAmountValue.Name = "PrizeAmountValue";
            PrizeAmountValue.Size = new Size(227, 36);
            PrizeAmountValue.TabIndex = 28;
            PrizeAmountValue.Text = "0";
            // 
            // PrizeAmountLabel
            // 
            PrizeAmountLabel.AutoSize = true;
            PrizeAmountLabel.Font = new Font("Segoe UI", 16F);
            PrizeAmountLabel.Location = new Point(55, 173);
            PrizeAmountLabel.Margin = new Padding(5, 0, 5, 0);
            PrizeAmountLabel.Name = "PrizeAmountLabel";
            PrizeAmountLabel.Size = new Size(143, 30);
            PrizeAmountLabel.TabIndex = 27;
            PrizeAmountLabel.Text = "Prize Amount";
            // 
            // PlaceNameValue
            // 
            PlaceNameValue.Location = new Point(259, 113);
            PlaceNameValue.Margin = new Padding(5, 6, 5, 6);
            PlaceNameValue.Name = "PlaceNameValue";
            PlaceNameValue.Size = new Size(227, 36);
            PlaceNameValue.TabIndex = 30;
            // 
            // PlaceNameLabel
            // 
            PlaceNameLabel.AutoSize = true;
            PlaceNameLabel.Font = new Font("Segoe UI", 16F);
            PlaceNameLabel.Location = new Point(55, 119);
            PlaceNameLabel.Margin = new Padding(5, 0, 5, 0);
            PlaceNameLabel.Name = "PlaceNameLabel";
            PlaceNameLabel.Size = new Size(127, 30);
            PlaceNameLabel.TabIndex = 29;
            PlaceNameLabel.Text = "Place Name";
            // 
            // PrizePercentageValue
            // 
            PrizePercentageValue.Location = new Point(259, 281);
            PrizePercentageValue.Margin = new Padding(5, 6, 5, 6);
            PrizePercentageValue.Name = "PrizePercentageValue";
            PrizePercentageValue.Size = new Size(227, 36);
            PrizePercentageValue.TabIndex = 32;
            PrizePercentageValue.Text = "0";
            // 
            // PrizePercentageLabel
            // 
            PrizePercentageLabel.AutoSize = true;
            PrizePercentageLabel.Font = new Font("Segoe UI", 16F);
            PrizePercentageLabel.Location = new Point(55, 287);
            PrizePercentageLabel.Margin = new Padding(5, 0, 5, 0);
            PrizePercentageLabel.Name = "PrizePercentageLabel";
            PrizePercentageLabel.Size = new Size(174, 30);
            PrizePercentageLabel.TabIndex = 31;
            PrizePercentageLabel.Text = "Prize Percentage";
            // 
            // OrLabel
            // 
            OrLabel.AutoSize = true;
            OrLabel.Font = new Font("Segoe UI", 16F);
            OrLabel.Location = new Point(182, 229);
            OrLabel.Margin = new Padding(5, 0, 5, 0);
            OrLabel.Name = "OrLabel";
            OrLabel.Size = new Size(64, 30);
            OrLabel.TabIndex = 31;
            OrLabel.Text = "- or -";
            // 
            // CreatePrizeButton
            // 
            CreatePrizeButton.FlatAppearance.BorderColor = Color.Silver;
            CreatePrizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            CreatePrizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(204, 204, 204);
            CreatePrizeButton.FlatStyle = FlatStyle.Flat;
            CreatePrizeButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreatePrizeButton.Location = new Point(182, 404);
            CreatePrizeButton.Margin = new Padding(5, 6, 5, 6);
            CreatePrizeButton.Name = "CreatePrizeButton";
            CreatePrizeButton.Size = new Size(214, 46);
            CreatePrizeButton.TabIndex = 33;
            CreatePrizeButton.Text = "Create Prize";
            CreatePrizeButton.UseVisualStyleBackColor = true;
            CreatePrizeButton.Click += CreatePrizeButton_Click;
            // 
            // CreatePrizeForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1371, 900);
            Controls.Add(CreatePrizeButton);
            Controls.Add(PrizePercentageValue);
            Controls.Add(OrLabel);
            Controls.Add(PrizePercentageLabel);
            Controls.Add(PlaceNameValue);
            Controls.Add(PlaceNameLabel);
            Controls.Add(PrizeAmountValue);
            Controls.Add(PrizeAmountLabel);
            Controls.Add(PlaceNumberValue);
            Controls.Add(PlaceNumberLabel);
            Controls.Add(HeaderLabel);
            Font = new Font("Segoe UI", 16F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "CreatePrizeForm";
            Text = "CreatePrizeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeaderLabel;
        private TextBox PlaceNumberValue;
        private Label PlaceNumberLabel;
        private TextBox PrizeAmountValue;
        private Label PrizeAmountLabel;
        private TextBox PlaceNameValue;
        private Label PlaceNameLabel;
        private TextBox PrizePercentageValue;
        private Label PrizePercentageLabel;
        private Label OrLabel;
        private Button CreatePrizeButton;
    }
}