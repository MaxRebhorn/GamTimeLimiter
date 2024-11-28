namespace GameTimeLimiter
{
    partial class GameTime
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
            PlayTimeLabel = new Label();
            PlayTime = new Label();
            bonus_time_label = new Label();
            bonubonus_time = new Label();
            SuspendLayout();
            // 
            // PlayTimeLabel
            // 
            PlayTimeLabel.AutoSize = true;
            PlayTimeLabel.BackColor = SystemColors.HotTrack;
            PlayTimeLabel.ForeColor = SystemColors.Control;
            PlayTimeLabel.Location = new Point(41, 76);
            PlayTimeLabel.Name = "PlayTimeLabel";
            PlayTimeLabel.Size = new Size(50, 15);
            PlayTimeLabel.TabIndex = 0;
            PlayTimeLabel.Text = "Spielzeit";
            // 
            // PlayTime
            // 
            PlayTime.AutoSize = true;
            PlayTime.BackColor = SystemColors.WindowText;
            PlayTime.ForeColor = SystemColors.Control;
            PlayTime.Location = new Point(108, 76);
            PlayTime.Name = "PlayTime";
            PlayTime.Size = new Size(50, 15);
            PlayTime.TabIndex = 1;
            PlayTime.Text = "Spielzeit";
            // 
            // bonus_time_label
            // 
            bonus_time_label.AutoSize = true;
            bonus_time_label.BackColor = SystemColors.HotTrack;
            bonus_time_label.ForeColor = SystemColors.Control;
            bonus_time_label.Location = new Point(12, 117);
            bonus_time_label.Name = "bonus_time_label";
            bonus_time_label.Size = new Size(79, 15);
            bonus_time_label.TabIndex = 2;
            bonus_time_label.Text = "Extra Spielzeit";
            // 
            // bonubonus_time
            // 
            bonubonus_time.AutoSize = true;
            bonubonus_time.BackColor = SystemColors.HotTrack;
            bonubonus_time.ForeColor = SystemColors.Control;
            bonubonus_time.Location = new Point(108, 117);
            bonubonus_time.Name = "bonubonus_time";
            bonubonus_time.Size = new Size(79, 15);
            bonubonus_time.TabIndex = 3;
            bonubonus_time.Text = "Extra Spielzeit";
            // 
            // GameTime
            // 
            ClientSize = new Size(205, 202);
            Controls.Add(bonubonus_time);
            Controls.Add(bonus_time_label);
            Controls.Add(PlayTime);
            Controls.Add(PlayTimeLabel);
            Name = "GameTime";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PlayTimeLabel;
        private Label PlayTime;
        private Label bonus_time_label;
        private Label bonubonus_time;
    }
}