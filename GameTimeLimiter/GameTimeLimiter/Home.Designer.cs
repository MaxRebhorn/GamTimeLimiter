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
            game_time.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            game_time.Location = new Point(487, 12);
            game_time.Name = "game_time";
            game_time.Size = new Size(301, 124);
            game_time.TabIndex = 0;
            game_time.Text = "Spielzeit";
            game_time.UseVisualStyleBackColor = true;
            game_time.BackColor = Color.LightSkyBlue;
            game_time.ForeColor = Color.White;
            game_time.FlatStyle = FlatStyle.Flat;
            game_time.FlatAppearance.BorderColor = Color.White;
            game_time.FlatAppearance.BorderSize = 1;
            game_time.Click += game_time_Click;
            // 
            // game_monitoring
            // 
            game_monitoring.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            game_monitoring.Location = new Point(12, 12);
            game_monitoring.Name = "game_monitoring";
            game_monitoring.Size = new Size(251, 124);
            game_monitoring.TabIndex = 1;
            game_monitoring.Text = "Spiele Auswahl";
            game_monitoring.UseVisualStyleBackColor = true;
            game_monitoring.BackColor = Color.SlateBlue;
            game_monitoring.ForeColor = Color.White;
            game_monitoring.FlatStyle = FlatStyle.Flat;
            game_monitoring.FlatAppearance.BorderColor = Color.White;
            game_monitoring.FlatAppearance.BorderSize = 1;
            game_monitoring.Click += game_monitor_Click;
            // 
            // option
            // 
            option.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            option.Location = new Point(676, 404);
            option.Name = "option";
            option.Size = new Size(112, 34);
            option.TabIndex = 2;
            option.Text = "Optionen";
            option.UseVisualStyleBackColor = true;
            option.BackColor = Color.LightSalmon;
            option.ForeColor = Color.White;
            option.FlatStyle = FlatStyle.Flat;
            option.FlatAppearance.BorderColor = Color.White;
            option.FlatAppearance.BorderSize = 1;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(option);
            Controls.Add(game_monitoring);
            Controls.Add(game_time);
            Name = "Home";
            Text = "GameTime";
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BackColor = Color.LightGoldenrodYellow;
            Load += Home_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button game_time;
        private Button game_monitoring;
        private Button option;
    }
}
