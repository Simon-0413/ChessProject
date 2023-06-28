namespace ChessProject
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            btnLocal = new Button();
            btnAI = new Button();
            TitleTextBox = new TextBox();
            SuspendLayout();
            // 
            // btnLocal
            // 
            btnLocal.BackColor = Color.PapayaWhip;
            btnLocal.FlatStyle = FlatStyle.Flat;
            btnLocal.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLocal.ForeColor = SystemColors.ActiveCaptionText;
            btnLocal.Location = new Point(186, 445);
            btnLocal.Name = "btnLocal";
            btnLocal.Size = new Size(445, 122);
            btnLocal.TabIndex = 0;
            btnLocal.Text = "Play against a Friend";
            btnLocal.UseVisualStyleBackColor = false;
            btnLocal.Click += btnLocal_Click;
            // 
            // btnAI
            // 
            btnAI.BackColor = Color.PapayaWhip;
            btnAI.Enabled = false;
            btnAI.FlatStyle = FlatStyle.Flat;
            btnAI.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btnAI.ForeColor = SystemColors.ActiveCaptionText;
            btnAI.Location = new Point(186, 584);
            btnAI.Name = "btnAI";
            btnAI.Size = new Size(445, 122);
            btnAI.TabIndex = 1;
            btnAI.Text = "Play against AI (coming soon)";
            btnAI.UseVisualStyleBackColor = false;
            // 
            // TitleTextBox
            // 
            TitleTextBox.BackColor = Color.PapayaWhip;
            TitleTextBox.Font = new Font("Segoe UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            TitleTextBox.Location = new Point(186, 25);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.ReadOnly = true;
            TitleTextBox.Size = new Size(445, 96);
            TitleTextBox.TabIndex = 2;
            TitleTextBox.Text = "Chess";
            TitleTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // StartScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.startScreen_Background;
            ClientSize = new Size(800, 799);
            Controls.Add(TitleTextBox);
            Controls.Add(btnAI);
            Controls.Add(btnLocal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "StartScreen";
            Text = "Chess";
            Load += StartScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLocal;
        private Button btnAI;
        private TextBox TitleTextBox;
    }
}