namespace AdminPanel
{
	partial class MainMenu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
			this.bt_view_users = new System.Windows.Forms.Button();
			this.bt_view_comments = new System.Windows.Forms.Button();
			this.bt_view_games = new System.Windows.Forms.Button();
			this.data = new System.Windows.Forms.DataGridView();
			this.bt_del = new System.Windows.Forms.Button();
			this.bt_update = new System.Windows.Forms.Button();
			this.l_server_path = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.bt_genres = new System.Windows.Forms.Button();
			this.bt_genre_add_ok = new System.Windows.Forms.Button();
			this.l_genre_name = new System.Windows.Forms.Label();
			this.tb_genre = new System.Windows.Forms.TextBox();
			this.bt_genres_bind = new System.Windows.Forms.Button();
			this.bt_server_toggle = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.l_server_status = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ts_settings = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_settings_choosePath = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_settings_choosePath_server = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_settings_choosePath_db = new System.Windows.Forms.ToolStripMenuItem();
			this.bt_add = new System.Windows.Forms.Button();
			this.bt_open_in_browser = new System.Windows.Forms.Button();
			this.bt_fast_add = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bt_view_users
			// 
			this.bt_view_users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_view_users.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_view_users.FlatAppearance.BorderSize = 0;
			this.bt_view_users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_view_users.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_view_users.Location = new System.Drawing.Point(145, 170);
			this.bt_view_users.Name = "bt_view_users";
			this.bt_view_users.Size = new System.Drawing.Size(184, 46);
			this.bt_view_users.TabIndex = 0;
			this.bt_view_users.Text = "Отобразить пользователей";
			this.bt_view_users.UseVisualStyleBackColor = false;
			this.bt_view_users.Click += new System.EventHandler(this.bt_view_users_Click);
			// 
			// bt_view_comments
			// 
			this.bt_view_comments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_view_comments.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_view_comments.FlatAppearance.BorderSize = 0;
			this.bt_view_comments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_view_comments.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_view_comments.Location = new System.Drawing.Point(145, 222);
			this.bt_view_comments.Name = "bt_view_comments";
			this.bt_view_comments.Size = new System.Drawing.Size(184, 46);
			this.bt_view_comments.TabIndex = 1;
			this.bt_view_comments.Text = "Отобразить комментарии";
			this.bt_view_comments.UseVisualStyleBackColor = false;
			this.bt_view_comments.Click += new System.EventHandler(this.bt_view_comments_Click);
			// 
			// bt_view_games
			// 
			this.bt_view_games.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_view_games.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_view_games.FlatAppearance.BorderSize = 0;
			this.bt_view_games.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_view_games.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_view_games.Location = new System.Drawing.Point(145, 274);
			this.bt_view_games.Name = "bt_view_games";
			this.bt_view_games.Size = new System.Drawing.Size(184, 46);
			this.bt_view_games.TabIndex = 2;
			this.bt_view_games.Text = "Отобразить игры";
			this.bt_view_games.UseVisualStyleBackColor = false;
			this.bt_view_games.Click += new System.EventHandler(this.bt_view_games_Click);
			// 
			// data
			// 
			this.data.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.data.GridColor = System.Drawing.SystemColors.ControlLight;
			this.data.Location = new System.Drawing.Point(507, 118);
			this.data.MultiSelect = false;
			this.data.Name = "data";
			this.data.ReadOnly = true;
			this.data.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.data.Size = new System.Drawing.Size(425, 287);
			this.data.TabIndex = 3;
			this.data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellDoubleClick);
			// 
			// bt_del
			// 
			this.bt_del.BackColor = System.Drawing.Color.White;
			this.bt_del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_del.BackgroundImage")));
			this.bt_del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bt_del.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_del.FlatAppearance.BorderSize = 0;
			this.bt_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_del.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_del.Location = new System.Drawing.Point(507, 411);
			this.bt_del.Name = "bt_del";
			this.bt_del.Size = new System.Drawing.Size(68, 41);
			this.bt_del.TabIndex = 4;
			this.bt_del.UseVisualStyleBackColor = false;
			this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
			// 
			// bt_update
			// 
			this.bt_update.BackColor = System.Drawing.Color.White;
			this.bt_update.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_update.BackgroundImage")));
			this.bt_update.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bt_update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_update.FlatAppearance.BorderSize = 0;
			this.bt_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_update.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_update.Location = new System.Drawing.Point(864, 411);
			this.bt_update.Name = "bt_update";
			this.bt_update.Size = new System.Drawing.Size(68, 41);
			this.bt_update.TabIndex = 5;
			this.bt_update.UseVisualStyleBackColor = false;
			this.bt_update.Click += new System.EventHandler(this.bt_update_Click);
			// 
			// l_server_path
			// 
			this.l_server_path.AutoSize = true;
			this.l_server_path.BackColor = System.Drawing.Color.Transparent;
			this.l_server_path.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.l_server_path.ForeColor = System.Drawing.Color.Transparent;
			this.l_server_path.Location = new System.Drawing.Point(279, 119);
			this.l_server_path.Name = "l_server_path";
			this.l_server_path.Size = new System.Drawing.Size(93, 18);
			this.l_server_path.TabIndex = 9;
			this.l_server_path.Text = "Не указан";
			this.l_server_path.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(142, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 18);
			this.label2.TabIndex = 8;
			this.label2.Text = "Путь к серверу: ";
			this.label2.Visible = false;
			// 
			// bt_genres
			// 
			this.bt_genres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_genres.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_genres.FlatAppearance.BorderSize = 0;
			this.bt_genres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_genres.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_genres.Location = new System.Drawing.Point(145, 326);
			this.bt_genres.Name = "bt_genres";
			this.bt_genres.Size = new System.Drawing.Size(184, 46);
			this.bt_genres.TabIndex = 11;
			this.bt_genres.Text = "Отобразить жанры";
			this.bt_genres.UseVisualStyleBackColor = false;
			this.bt_genres.Click += new System.EventHandler(this.bt_genres_Click);
			// 
			// bt_genre_add_ok
			// 
			this.bt_genre_add_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_genre_add_ok.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_genre_add_ok.FlatAppearance.BorderSize = 0;
			this.bt_genre_add_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_genre_add_ok.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_genre_add_ok.Location = new System.Drawing.Point(673, 89);
			this.bt_genre_add_ok.Name = "bt_genre_add_ok";
			this.bt_genre_add_ok.Size = new System.Drawing.Size(89, 23);
			this.bt_genre_add_ok.TabIndex = 12;
			this.bt_genre_add_ok.Text = "OK";
			this.bt_genre_add_ok.UseVisualStyleBackColor = false;
			this.bt_genre_add_ok.Visible = false;
			this.bt_genre_add_ok.Click += new System.EventHandler(this.bt_genre_add_ok_Click);
			// 
			// l_genre_name
			// 
			this.l_genre_name.AutoSize = true;
			this.l_genre_name.BackColor = System.Drawing.Color.Transparent;
			this.l_genre_name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.l_genre_name.ForeColor = System.Drawing.Color.Transparent;
			this.l_genre_name.Location = new System.Drawing.Point(508, 64);
			this.l_genre_name.Name = "l_genre_name";
			this.l_genre_name.Size = new System.Drawing.Size(155, 18);
			this.l_genre_name.TabIndex = 13;
			this.l_genre_name.Text = "Название жанра:";
			this.l_genre_name.Visible = false;
			// 
			// tb_genre
			// 
			this.tb_genre.Location = new System.Drawing.Point(669, 65);
			this.tb_genre.Name = "tb_genre";
			this.tb_genre.Size = new System.Drawing.Size(100, 20);
			this.tb_genre.TabIndex = 14;
			this.tb_genre.Visible = false;
			// 
			// bt_genres_bind
			// 
			this.bt_genres_bind.BackColor = System.Drawing.Color.White;
			this.bt_genres_bind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_genres_bind.BackgroundImage")));
			this.bt_genres_bind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bt_genres_bind.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_genres_bind.FlatAppearance.BorderSize = 0;
			this.bt_genres_bind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_genres_bind.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_genres_bind.Location = new System.Drawing.Point(457, 227);
			this.bt_genres_bind.Name = "bt_genres_bind";
			this.bt_genres_bind.Size = new System.Drawing.Size(44, 79);
			this.bt_genres_bind.TabIndex = 15;
			this.bt_genres_bind.UseVisualStyleBackColor = false;
			this.bt_genres_bind.Visible = false;
			this.bt_genres_bind.Click += new System.EventHandler(this.bt_genres_bind_Click);
			// 
			// bt_server_toggle
			// 
			this.bt_server_toggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_server_toggle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_server_toggle.FlatAppearance.BorderSize = 0;
			this.bt_server_toggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_server_toggle.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_server_toggle.Location = new System.Drawing.Point(145, 411);
			this.bt_server_toggle.Name = "bt_server_toggle";
			this.bt_server_toggle.Size = new System.Drawing.Size(233, 46);
			this.bt_server_toggle.TabIndex = 16;
			this.bt_server_toggle.Text = "Вкл/Выкл";
			this.bt_server_toggle.UseVisualStyleBackColor = false;
			this.bt_server_toggle.Click += new System.EventHandler(this.bt_server_toggle_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(142, 390);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 18);
			this.label1.TabIndex = 17;
			this.label1.Text = "Статус сервера:";
			// 
			// l_server_status
			// 
			this.l_server_status.AutoSize = true;
			this.l_server_status.BackColor = System.Drawing.Color.Transparent;
			this.l_server_status.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.l_server_status.ForeColor = System.Drawing.Color.Transparent;
			this.l_server_status.Location = new System.Drawing.Point(291, 390);
			this.l_server_status.Name = "l_server_status";
			this.l_server_status.Size = new System.Drawing.Size(105, 18);
			this.l_server_status.TabIndex = 18;
			this.l_server_status.Text = "Недоступно";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_settings});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1027, 24);
			this.menuStrip1.TabIndex = 19;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ts_settings
			// 
			this.ts_settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_settings_choosePath});
			this.ts_settings.Name = "ts_settings";
			this.ts_settings.Size = new System.Drawing.Size(79, 20);
			this.ts_settings.Text = "Настройки";
			// 
			// ts_settings_choosePath
			// 
			this.ts_settings_choosePath.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_settings_choosePath_server,
            this.ts_settings_choosePath_db});
			this.ts_settings_choosePath.Name = "ts_settings_choosePath";
			this.ts_settings_choosePath.Size = new System.Drawing.Size(160, 22);
			this.ts_settings_choosePath.Text = "Указать путь к...";
			// 
			// ts_settings_choosePath_server
			// 
			this.ts_settings_choosePath_server.Name = "ts_settings_choosePath_server";
			this.ts_settings_choosePath_server.Size = new System.Drawing.Size(144, 22);
			this.ts_settings_choosePath_server.Text = "Серверу";
			this.ts_settings_choosePath_server.Click += new System.EventHandler(this.ts_settings_choosePath_server_Click);
			// 
			// ts_settings_choosePath_db
			// 
			this.ts_settings_choosePath_db.Name = "ts_settings_choosePath_db";
			this.ts_settings_choosePath_db.Size = new System.Drawing.Size(144, 22);
			this.ts_settings_choosePath_db.Text = "Базе Данных";
			// 
			// bt_add
			// 
			this.bt_add.BackColor = System.Drawing.Color.White;
			this.bt_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_add.BackgroundImage")));
			this.bt_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.bt_add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_add.FlatAppearance.BorderSize = 0;
			this.bt_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_add.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_add.Location = new System.Drawing.Point(660, 411);
			this.bt_add.Name = "bt_add";
			this.bt_add.Size = new System.Drawing.Size(96, 41);
			this.bt_add.TabIndex = 20;
			this.bt_add.UseVisualStyleBackColor = false;
			this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
			// 
			// bt_open_in_browser
			// 
			this.bt_open_in_browser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_open_in_browser.Enabled = false;
			this.bt_open_in_browser.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_open_in_browser.FlatAppearance.BorderSize = 0;
			this.bt_open_in_browser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_open_in_browser.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_open_in_browser.Location = new System.Drawing.Point(145, 463);
			this.bt_open_in_browser.Name = "bt_open_in_browser";
			this.bt_open_in_browser.Size = new System.Drawing.Size(233, 46);
			this.bt_open_in_browser.TabIndex = 21;
			this.bt_open_in_browser.Text = "Открыть сайт в браузере";
			this.bt_open_in_browser.UseVisualStyleBackColor = false;
			this.bt_open_in_browser.Click += new System.EventHandler(this.bt_open_in_browser_Click);
			// 
			// bt_fast_add
			// 
			this.bt_fast_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_fast_add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_fast_add.FlatAppearance.BorderSize = 0;
			this.bt_fast_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_fast_add.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_fast_add.Location = new System.Drawing.Point(628, 478);
			this.bt_fast_add.Name = "bt_fast_add";
			this.bt_fast_add.Size = new System.Drawing.Size(141, 46);
			this.bt_fast_add.TabIndex = 22;
			this.bt_fast_add.Text = "Быстро добавить игру";
			this.bt_fast_add.UseVisualStyleBackColor = false;
			this.bt_fast_add.Click += new System.EventHandler(this.bt_fast_add_Click);
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1027, 548);
			this.Controls.Add(this.bt_fast_add);
			this.Controls.Add(this.bt_open_in_browser);
			this.Controls.Add(this.bt_add);
			this.Controls.Add(this.l_server_status);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bt_server_toggle);
			this.Controls.Add(this.bt_genres_bind);
			this.Controls.Add(this.tb_genre);
			this.Controls.Add(this.l_genre_name);
			this.Controls.Add(this.bt_genre_add_ok);
			this.Controls.Add(this.bt_genres);
			this.Controls.Add(this.l_server_path);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bt_update);
			this.Controls.Add(this.bt_del);
			this.Controls.Add(this.data);
			this.Controls.Add(this.bt_view_games);
			this.Controls.Add(this.bt_view_comments);
			this.Controls.Add(this.bt_view_users);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainMenu";
			this.Text = "MainMenu";
			((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bt_view_users;
		private System.Windows.Forms.Button bt_view_comments;
		private System.Windows.Forms.Button bt_view_games;
		private System.Windows.Forms.DataGridView data;
		private System.Windows.Forms.Button bt_del;
		private System.Windows.Forms.Button bt_update;
		private System.Windows.Forms.Label l_server_path;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bt_genres;
		private System.Windows.Forms.Button bt_genre_add_ok;
		private System.Windows.Forms.Label l_genre_name;
		private System.Windows.Forms.TextBox tb_genre;
		private System.Windows.Forms.Button bt_genres_bind;
		private System.Windows.Forms.Button bt_server_toggle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label l_server_status;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ts_settings;
		private System.Windows.Forms.ToolStripMenuItem ts_settings_choosePath;
		private System.Windows.Forms.ToolStripMenuItem ts_settings_choosePath_server;
		private System.Windows.Forms.ToolStripMenuItem ts_settings_choosePath_db;
		private System.Windows.Forms.Button bt_add;
		private System.Windows.Forms.Button bt_open_in_browser;
		private System.Windows.Forms.Button bt_fast_add;
	}
}