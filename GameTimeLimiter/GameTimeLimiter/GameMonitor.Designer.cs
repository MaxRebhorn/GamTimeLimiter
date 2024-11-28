namespace GameTimeLimiter
{
    partial class GameMonitor
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
    dataGridView1 = new DataGridView();
    games = new DataGridViewTextBoxColumn();
    playtime_today = new DataGridViewTextBoxColumn();
    playtime_week = new DataGridViewTextBoxColumn();
    playtime_month = new DataGridViewTextBoxColumn();
    last_played = new DataGridViewTextBoxColumn();
    back = new Button();
    add_game = new Button();
    ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
    SuspendLayout();

    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    dataGridView1.Columns.AddRange(new DataGridViewColumn[] { games, playtime_today, playtime_week, playtime_month, last_played });
    dataGridView1.Location = new Point(0, 0);
    dataGridView1.Name = "dataGridView1";
    dataGridView1.RowHeadersWidth = 62;
    dataGridView1.Size = new Size(797, 287);
    dataGridView1.DefaultCellStyle.BackColor = Color.AliceBlue;
    dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
    dataGridView1.TabIndex = 0;
    dataGridView1.CellContentClick += dataGridView1_CellContentClick;

    games.HeaderText = "Spiele";
    games.MinimumWidth = 8;
    games.Name = "games";
    games.Width = 150;

    playtime_today.HeaderText = "Heutige Spielzeit";
    playtime_today.MinimumWidth = 8;
    playtime_today.Name = "playtime_today";
    playtime_today.Width = 150;

    playtime_week.HeaderText = "Wöchentliche Spielzeit";
    playtime_week.MinimumWidth = 8;
    playtime_week.Name = "playtime_week";
    playtime_week.Width = 150;

    playtime_month.HeaderText = "Monatliche Spielzeit";
    playtime_month.MinimumWidth = 8;
    playtime_month.Name = "playtime_month";
    playtime_month.Width = 150;

    last_played.HeaderText = "Zuletzt Gespielt am";
    last_played.MinimumWidth = 8;
    last_played.Name = "last_played";
    last_played.Width = 150;

    back.Location = new Point(12, 404);
    back.Name = "back";
    back.BackColor = Color.LightSteelBlue;
    back.ForeColor = Color.White;
    back.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
    back.Size = new Size(112, 34);
    back.TabIndex = 1;
    back.Text = "zurück";
    back.UseVisualStyleBackColor = true;

    add_game.BackgroundImageLayout = ImageLayout.None;
    add_game.Location = new Point(599, 386);
    add_game.Name = "add_game";
    add_game.BackColor = Color.LightSeaGreen;
    add_game.ForeColor = Color.White;
    add_game.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
    add_game.Size = new Size(183, 52);
    add_game.TabIndex = 2;
    add_game.Text = "Spiel hinzufügen";
    add_game.UseVisualStyleBackColor = true;
    add_game.Click += add_game_Click;

    AutoScaleDimensions = new SizeF(10F, 25F);
    AutoScaleMode = AutoScaleMode.Font;
    ClientSize = new Size(794, 450);
    Controls.Add(add_game);
    Controls.Add(back);
    Controls.Add(dataGridView1);
    BackColor = Color.LightGoldenrodYellow;
    Font = new Font("Segoe UI", 10);
    Name = "GameMonitor";
    Text = "Game Monitor";
    Load += GameMonitor_Load;

    ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
    ResumeLayout(false);
}


        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn games;
        private DataGridViewTextBoxColumn playtime_today;
        private DataGridViewTextBoxColumn playtime_week;
        private DataGridViewTextBoxColumn playtime_month;
        private DataGridViewTextBoxColumn last_played;
        private Button back;
        private Button add_game;
    }
}