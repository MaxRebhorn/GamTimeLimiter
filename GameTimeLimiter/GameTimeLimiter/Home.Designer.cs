namespace GameTimeLimiter
{
    partial class Home
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
            game_time = new Button();
            game_monitoring = new Button();
            option = new Button();
            SuspendLayout();
            // 
            // game_time
            // 
            game_time.BackColor = Color.RoyalBlue;
            game_time.FlatAppearance.BorderColor = Color.White;
            game_time.FlatStyle = FlatStyle.Flat;
            game_time.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            game_time.ForeColor = Color.White;
            game_time.Location = new Point(12, 151);
            game_time.Name = "game_time";
            game_time.Size = new Size(251, 124);
            game_time.TabIndex = 0;
            game_time.Text = "Spielzeit";
            game_time.UseVisualStyleBackColor = false;
            game_time.Click += game_time_Click;
            // 
            // game_monitoring
            // 
            game_monitoring.BackColor = Color.RoyalBlue;
            game_monitoring.FlatAppearance.BorderColor = Color.White;
            game_monitoring.FlatStyle = FlatStyle.Flat;
            game_monitoring.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            game_monitoring.ForeColor = Color.White;
            game_monitoring.Location = new Point(12, 12);
            game_monitoring.Name = "game_monitoring";
            game_monitoring.Size = new Size(251, 124);
            game_monitoring.TabIndex = 1;
            game_monitoring.Text = "Spiele Auswahl";
            game_monitoring.UseVisualStyleBackColor = false;
            game_monitoring.Click += game_monitor_Click;
            // 
            // option
            // 
            option.BackColor = Color.RoyalBlue;
            option.FlatAppearance.BorderColor = Color.White;
            option.FlatStyle = FlatStyle.Flat;
            option.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            option.ForeColor = Color.White;
            option.Location = new Point(12, 302);
            option.Name = "option";
            option.Size = new Size(251, 124);
            option.TabIndex = 2;
            option.Text = "Einstellungen";
            option.UseVisualStyleBackColor = false;
            option.Click += options_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(800, 450);
            Controls.Add(option);
            Controls.Add(game_monitoring);
            Controls.Add(game_time);
            Font = new Font("Segoe UI", 12F);
            Name = "Home";
            Text = "GameTime";
            Load += Home_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button game_time;
        private Button game_monitoring;
        private Button option;
    }
}
