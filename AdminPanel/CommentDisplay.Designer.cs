namespace AdminPanel
{
	partial class CommentDisplay
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentDisplay));
			this.l_username = new System.Windows.Forms.Label();
			this.tb_comment = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// l_username
			// 
			this.l_username.AutoSize = true;
			this.l_username.BackColor = System.Drawing.Color.Transparent;
			this.l_username.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.l_username.ForeColor = System.Drawing.Color.Black;
			this.l_username.Location = new System.Drawing.Point(318, 56);
			this.l_username.Name = "l_username";
			this.l_username.Size = new System.Drawing.Size(155, 18);
			this.l_username.TabIndex = 9;
			this.l_username.Text = "Имя пользоваеля";
			this.l_username.Visible = false;
			// 
			// tb_comment
			// 
			this.tb_comment.Location = new System.Drawing.Point(12, 88);
			this.tb_comment.Multiline = true;
			this.tb_comment.Name = "tb_comment";
			this.tb_comment.Size = new System.Drawing.Size(776, 362);
			this.tb_comment.TabIndex = 10;
			// 
			// CommentDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tb_comment);
			this.Controls.Add(this.l_username);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "CommentDisplay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CommentDisplay";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label l_username;
		private System.Windows.Forms.TextBox tb_comment;
	}
}