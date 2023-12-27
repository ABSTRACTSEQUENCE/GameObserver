namespace AdminPanel
{
	partial class GenreBind
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
			this.lb_genres = new System.Windows.Forms.ListBox();
			this.lb_games = new System.Windows.Forms.ListBox();
			this.data_binded = new System.Windows.Forms.DataGridView();
			this.bt_bind = new System.Windows.Forms.Button();
			this.bt_del = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.data_binded)).BeginInit();
			this.SuspendLayout();
			// 
			// lb_genres
			// 
			this.lb_genres.FormattingEnabled = true;
			this.lb_genres.Location = new System.Drawing.Point(145, 125);
			this.lb_genres.Name = "lb_genres";
			this.lb_genres.Size = new System.Drawing.Size(120, 95);
			this.lb_genres.TabIndex = 0;
			this.lb_genres.SelectedIndexChanged += new System.EventHandler(this.lb_genres_SelectedIndexChanged);
			// 
			// lb_games
			// 
			this.lb_games.FormattingEnabled = true;
			this.lb_games.Location = new System.Drawing.Point(566, 125);
			this.lb_games.Name = "lb_games";
			this.lb_games.Size = new System.Drawing.Size(120, 95);
			this.lb_games.TabIndex = 1;
			this.lb_games.SelectedIndexChanged += new System.EventHandler(this.lb_games_SelectedIndexChanged);
			// 
			// data_binded
			// 
			this.data_binded.AllowUserToAddRows = false;
			this.data_binded.AllowUserToDeleteRows = false;
			this.data_binded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.data_binded.Location = new System.Drawing.Point(271, 56);
			this.data_binded.MultiSelect = false;
			this.data_binded.Name = "data_binded";
			this.data_binded.ReadOnly = true;
			this.data_binded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.data_binded.Size = new System.Drawing.Size(289, 264);
			this.data_binded.TabIndex = 2;
			this.data_binded.SelectionChanged += new System.EventHandler(this.data_binded_SelectionChanged);
			// 
			// bt_bind
			// 
			this.bt_bind.Enabled = false;
			this.bt_bind.Location = new System.Drawing.Point(442, 337);
			this.bt_bind.Name = "bt_bind";
			this.bt_bind.Size = new System.Drawing.Size(118, 23);
			this.bt_bind.TabIndex = 3;
			this.bt_bind.Text = "Связать жанр";
			this.bt_bind.UseVisualStyleBackColor = true;
			this.bt_bind.Click += new System.EventHandler(this.bt_bind_Click);
			// 
			// bt_del
			// 
			this.bt_del.Enabled = false;
			this.bt_del.Location = new System.Drawing.Point(271, 337);
			this.bt_del.Name = "bt_del";
			this.bt_del.Size = new System.Drawing.Size(118, 23);
			this.bt_del.TabIndex = 4;
			this.bt_del.Text = "Удалить связь";
			this.bt_del.UseVisualStyleBackColor = true;
			this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(579, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Список всех игр";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(158, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(111, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Список всех жанров";
			// 
			// GenreBind
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(831, 411);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bt_del);
			this.Controls.Add(this.bt_bind);
			this.Controls.Add(this.data_binded);
			this.Controls.Add(this.lb_games);
			this.Controls.Add(this.lb_genres);
			this.Name = "GenreBind";
			this.Text = "Связать жанр";
			((System.ComponentModel.ISupportInitialize)(this.data_binded)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lb_genres;
		private System.Windows.Forms.ListBox lb_games;
		private System.Windows.Forms.DataGridView data_binded;
		private System.Windows.Forms.Button bt_bind;
		private System.Windows.Forms.Button bt_del;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}