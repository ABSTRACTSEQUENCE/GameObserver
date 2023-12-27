namespace AdminPanel
{
	partial class EditGame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGame));
			this.l_name = new System.Windows.Forms.Label();
			this.tb_name = new System.Windows.Forms.TextBox();
			this.tb_description = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bt_ok = new System.Windows.Forms.Button();
			this.tb_steam = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// l_name
			// 
			this.l_name.AutoSize = true;
			this.l_name.BackColor = System.Drawing.Color.Black;
			this.l_name.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.l_name.ForeColor = System.Drawing.Color.Transparent;
			this.l_name.Location = new System.Drawing.Point(391, 153);
			this.l_name.Name = "l_name";
			this.l_name.Size = new System.Drawing.Size(89, 18);
			this.l_name.TabIndex = 15;
			this.l_name.Text = "Название";
			// 
			// tb_name
			// 
			this.tb_name.Location = new System.Drawing.Point(486, 151);
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size(206, 20);
			this.tb_name.TabIndex = 16;
			// 
			// tb_description
			// 
			this.tb_description.Location = new System.Drawing.Point(393, 225);
			this.tb_description.Multiline = true;
			this.tb_description.Name = "tb_description";
			this.tb_description.Size = new System.Drawing.Size(330, 151);
			this.tb_description.TabIndex = 18;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(510, 202);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 18);
			this.label1.TabIndex = 17;
			this.label1.Text = "Описание";
			// 
			// bt_ok
			// 
			this.bt_ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.bt_ok.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.bt_ok.FlatAppearance.BorderSize = 0;
			this.bt_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bt_ok.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.bt_ok.Location = new System.Drawing.Point(511, 464);
			this.bt_ok.Name = "bt_ok";
			this.bt_ok.Size = new System.Drawing.Size(89, 23);
			this.bt_ok.TabIndex = 19;
			this.bt_ok.Text = "OK";
			this.bt_ok.UseVisualStyleBackColor = false;
			this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
			// 
			// tb_steam
			// 
			this.tb_steam.Location = new System.Drawing.Point(486, 407);
			this.tb_steam.Name = "tb_steam";
			this.tb_steam.Size = new System.Drawing.Size(206, 20);
			this.tb_steam.TabIndex = 21;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Black;
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(327, 409);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(153, 18);
			this.label2.TabIndex = 20;
			this.label2.Text = "Ссылка на Steam";
			// 
			// EditGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1032, 613);
			this.Controls.Add(this.tb_steam);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bt_ok);
			this.Controls.Add(this.tb_description);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tb_name);
			this.Controls.Add(this.l_name);
			this.Name = "EditGame";
			this.Text = "EditUser";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label l_name;
		private System.Windows.Forms.TextBox tb_name;
		private System.Windows.Forms.TextBox tb_description;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bt_ok;
		private System.Windows.Forms.TextBox tb_steam;
		private System.Windows.Forms.Label label2;
	}
}