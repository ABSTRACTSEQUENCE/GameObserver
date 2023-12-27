using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
	public partial class CommentDisplay : Form
	{
		Comment comment;
		public CommentDisplay(Comment comment)
		{
			InitializeComponent();
			this.comment = comment;
			l_username.Text = comment.User.Name;
			tb_comment.Text = comment.Text;
		}
		
	}
}
