namespace AdminPanel
{
	partial class Add
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add));
			this.panel1 = new System.Windows.Forms.Panel();
			this.l_torrent = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.bt_add_torrent = new System.Windows.Forms.Button();
			this.bt_del_screenshot = new System.Windows.Forms.Button();
			this.lb_screenshots = new System.Windows.Forms.ListBox();
			this.pb_screenshots = new System.Windows.Forms.PictureBox();
			this.bt_screenshots = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.pb_preview = new System.Windows.Forms.PictureBox();
			this.bt_preview = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tb_steam = new System.Windows.Forms.TextBox();
			this.bt_add = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tb_desc = new System.Windows.Forms.TextBox();
			this.tb_name = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_screenshots)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_preview)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkGray;
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel1.Controls.Add(this.l_torrent);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.bt_add_torrent);
			this.panel1.Controls.Add(this.bt_del_screenshot);
			this.panel1.Controls.Add(this.lb_screenshots);
			this.panel1.Controls.Add(this.pb_screenshots);
			this.panel1.Controls.Add(this.bt_screenshots);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.pb_preview);
			this.panel1.Controls.Add(this.bt_preview);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.tb_steam);
			this.panel1.Controls.Add(this.bt_add);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tb_desc);
			this.panel1.Controls.Add(this.tb_name);
			this.panel1.Location = new System.Drawing.Point(-2, -6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1861, 1139);
			this.panel1.TabIndex = 0;
			// 
			// l_torrent
			// 
			this.l_torrent.AutoSize = true;
			this.l_torrent.BackColor = System.Drawing.Color.Black;
			this.l_torrent.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.l_torrent.ForeColor = System.Drawing.Color.Red;
			this.l_torrent.Location = new System.Drawing.Point(414, 292);
			this.l_torrent.Name = "l_torrent";
			this.l_torrent.Size = new System.Drawing.Size(116, 18);
			this.l_torrent.TabIndex = 18;
			this.l_torrent.Text = "Не добавлен";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Black;
			this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.Info;
			this.label6.Location = new System.Drawing.Point(272, 292);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(124, 18);
			this.label6.TabIndex = 17;
			this.label6.Text = "Торрент Файл";
			// 
			// bt_add_torrent
			// 
			this.bt_add_torrent.BackColor = System.Drawing.Color.DimGray;
			this.bt_add_torrent.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.bt_add_torrent.Location = new System.Drawing.Point(266, 324);
			this.bt_add_torrent.Name = "bt_add_torrent";
			this.bt_add_torrent.Size = new System.Drawing.Size(145, 31);
			this.bt_add_torrent.TabIndex = 16;
			this.bt_add_torrent.Text = "Добавить торрент-файл";
			this.bt_add_torrent.UseVisualStyleBackColor = false;
			this.bt_add_torrent.Click += new System.EventHandler(this.bt_add_torrent_Click);
			// 
			// bt_del_screenshot
			// 
			this.bt_del_screenshot.BackColor = System.Drawing.Color.DimGray;
			this.bt_del_screenshot.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.bt_del_screenshot.Location = new System.Drawing.Point(1343, 648);
			this.bt_del_screenshot.Name = "bt_del_screenshot";
			this.bt_del_screenshot.Size = new System.Drawing.Size(135, 31);
			this.bt_del_screenshot.TabIndex = 15;
			this.bt_del_screenshot.Text = "Удалить изображение";
			this.bt_del_screenshot.UseVisualStyleBackColor = false;
			this.bt_del_screenshot.Click += new System.EventHandler(this.bt_del_screenshot_Click);
			// 
			// lb_screenshots
			// 
			this.lb_screenshots.FormattingEnabled = true;
			this.lb_screenshots.Location = new System.Drawing.Point(1192, 482);
			this.lb_screenshots.Name = "lb_screenshots";
			this.lb_screenshots.Size = new System.Drawing.Size(286, 160);
			this.lb_screenshots.TabIndex = 14;
			this.lb_screenshots.SelectedIndexChanged += new System.EventHandler(this.lb_screenshots_SelectedIndexChanged);
			// 
			// pb_screenshots
			// 
			this.pb_screenshots.BackColor = System.Drawing.Color.Transparent;
			this.pb_screenshots.Location = new System.Drawing.Point(1276, 45);
			this.pb_screenshots.Name = "pb_screenshots";
			this.pb_screenshots.Size = new System.Drawing.Size(245, 347);
			this.pb_screenshots.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pb_screenshots.TabIndex = 13;
			this.pb_screenshots.TabStop = false;
			// 
			// bt_screenshots
			// 
			this.bt_screenshots.BackColor = System.Drawing.Color.DimGray;
			this.bt_screenshots.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.bt_screenshots.Location = new System.Drawing.Point(1192, 648);
			this.bt_screenshots.Name = "bt_screenshots";
			this.bt_screenshots.Size = new System.Drawing.Size(145, 31);
			this.bt_screenshots.TabIndex = 12;
			this.bt_screenshots.Text = "Добавить изображение";
			this.bt_screenshots.UseVisualStyleBackColor = false;
			this.bt_screenshots.Click += new System.EventHandler(this.bt_screenshots_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Black;
			this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.Info;
			this.label5.Location = new System.Drawing.Point(1273, 461);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 18);
			this.label5.TabIndex = 11;
			this.label5.Text = "Скриншоты";
			// 
			// pb_preview
			// 
			this.pb_preview.BackColor = System.Drawing.Color.Transparent;
			this.pb_preview.Location = new System.Drawing.Point(683, 45);
			this.pb_preview.Name = "pb_preview";
			this.pb_preview.Size = new System.Drawing.Size(245, 347);
			this.pb_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pb_preview.TabIndex = 10;
			this.pb_preview.TabStop = false;
			// 
			// bt_preview
			// 
			this.bt_preview.BackColor = System.Drawing.Color.DimGray;
			this.bt_preview.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.bt_preview.Location = new System.Drawing.Point(758, 12);
			this.bt_preview.Name = "bt_preview";
			this.bt_preview.Size = new System.Drawing.Size(141, 31);
			this.bt_preview.TabIndex = 8;
			this.bt_preview.Text = "Добавить изображение";
			this.bt_preview.UseVisualStyleBackColor = false;
			this.bt_preview.Click += new System.EventHandler(this.bt_preview_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.Info;
			this.label4.Location = new System.Drawing.Point(680, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 18);
			this.label4.TabIndex = 7;
			this.label4.Text = "Превью";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Black;
			this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.Info;
			this.label3.Location = new System.Drawing.Point(414, 675);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 18);
			this.label3.TabIndex = 6;
			this.label3.Text = "Ссылка на Steam";
			// 
			// tb_steam
			// 
			this.tb_steam.Location = new System.Drawing.Point(573, 673);
			this.tb_steam.Name = "tb_steam";
			this.tb_steam.Size = new System.Drawing.Size(403, 20);
			this.tb_steam.TabIndex = 5;
			// 
			// bt_add
			// 
			this.bt_add.BackColor = System.Drawing.Color.DimGray;
			this.bt_add.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.bt_add.Location = new System.Drawing.Point(252, 361);
			this.bt_add.Name = "bt_add";
			this.bt_add.Size = new System.Drawing.Size(181, 31);
			this.bt_add.TabIndex = 4;
			this.bt_add.Text = "Добавить игру";
			this.bt_add.UseVisualStyleBackColor = false;
			this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Black;
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Info;
			this.label2.Location = new System.Drawing.Point(477, 482);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Описание";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Info;
			this.label1.Location = new System.Drawing.Point(432, 427);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "Название игры";
			// 
			// tb_desc
			// 
			this.tb_desc.Location = new System.Drawing.Point(573, 482);
			this.tb_desc.Multiline = true;
			this.tb_desc.Name = "tb_desc";
			this.tb_desc.Size = new System.Drawing.Size(505, 175);
			this.tb_desc.TabIndex = 1;
			// 
			// tb_name
			// 
			this.tb_name.Location = new System.Drawing.Point(573, 428);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(505, 20);
			this.tb_name.TabIndex = 0;
			// 
			// Add
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1593, 688);
			this.Controls.Add(this.panel1);
			this.Name = "Add";
			this.Text = "Добавить игру";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_screenshots)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pb_preview)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox tb_desc;
		private System.Windows.Forms.TextBox tb_name;
		private System.Windows.Forms.Button bt_add;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tb_steam;
		private System.Windows.Forms.Button bt_preview;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pb_preview;
		private System.Windows.Forms.Button bt_screenshots;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ListBox lb_screenshots;
		private System.Windows.Forms.PictureBox pb_screenshots;
		private System.Windows.Forms.Button bt_del_screenshot;
		private System.Windows.Forms.Button bt_add_torrent;
		private System.Windows.Forms.Label l_torrent;
		private System.Windows.Forms.Label label6;
	}
}