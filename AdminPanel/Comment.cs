using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public Users User { get; set; }
		public Game Game { get; set; }
		public Comment(string Text, Users user, Game game)
		{
			this.Text = Text;
			User = user;
			Game = game;
		}
		public Comment() { User = new Users(); }

	}
}
