using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
	public partial class EditGame : Form
	{
		Game game;
		public EditGame(Game game)
		{
			InitializeComponent();
			using(Context c = new Context()) 
			{ 
				this.game = c.Games.Where((g) => g.Id == game.Id).First(); 
			}
			tb_name.Text = game.Name;
			tb_description.Text = game.Description;
			tb_steam.Text = game.Steam;
		}

		private void bt_ok_Click(object sender, EventArgs e)
		{
			game.Name = tb_name.Text;
			game.Description = tb_description.Text;
			game.Steam = tb_steam.Text;
			using (Context c = new Context()) {c.Games.AddOrUpdate(game); c.SaveChanges(); }
			Close();
		}
	}
}
