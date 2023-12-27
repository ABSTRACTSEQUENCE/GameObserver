using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
	public partial class GenreBind : Form
	{
		//TODO: 1) Добавить кнопку удаления
		Genre SelectedGenre;
		Game SelectedGame;
		public GenreBind()
		{
			InitializeComponent();
			using (Context c = new Context())
			{
				foreach (Game game in c.Games) lb_games.Items.Add(game);
				foreach (Genre genre in c.Genres) lb_genres.Items.Add(genre);
			}
			UpdateData();
		}
		private void bt_bind_Click(object sender, EventArgs e)
		{
			if (lb_games.SelectedItems.Count <= 0 || lb_genres.SelectedItems.Count <= 0) return;
			using (Context c = new Context())
			{
				Game game;
				{
					int id = (lb_games.SelectedItem as Game).Id;
					game = c.Games.Where((g) => g.Id == id ).FirstOrDefault(); //.ToArray()[0];
				}
				Genre genre;
				{
					int id = (lb_genres.SelectedItem as Genre).Id;
					genre = c.Genres.Where((g) => g.Id == id).FirstOrDefault(); //.ToArray()[0];
				}
				
				game.Genres.Add(genre);
				genre.Games.Add(game);
				c.SaveChanges();
				//System.Data.Entity.Infrastructure.DbUpdateException
				MessageBox.Show("Готово!");
				UpdateData();
				Check();
			}
		}

		void UpdateData()
		{
			
			using (Context c = new Context()) 
			{
				DataSet ds; 
				new SqlDataAdapter(
					new SqlCommand(
						@"SELECT Genres.Name AS 'Жанр', 
						Games.Name AS 'Игра'
						FROM GenreGames,Games,Genres 
						WHERE GenreGames.Game_Id = Games.Id AND Genres.Id = GenreGames.Genre_Id", 
						new SqlConnection(c.Database.Connection.ConnectionString))
					).Fill(ds = new DataSet());

				data_binded.DataSource= ds.Tables[0];
			}
			
		}
		private void lb_genres_SelectedIndexChanged(object sender, EventArgs e)
		{
			Check();
		}
		void Check()
		{
			if (lb_games.Items.Count > 0 && lb_genres.Items.Count > 0 &&
				lb_games.SelectedItem != null && lb_genres.SelectedItem != null)
			{
				string gameName = lb_games.SelectedItem.ToString();
				string genreName = lb_genres.SelectedItem.ToString();
				for (int i = 0; i < data_binded.Rows.Count; i++)
				{
					if (data_binded["Игра", i].Value.ToString() == gameName)
						for (int j = 0; j < data_binded.RowCount; j++)
							if (data_binded["Жанр", i].Value.ToString() == genreName) { bt_bind.Enabled = false; return; }

				}
				bt_bind.Enabled = true;
			}
		}
		private void lb_games_SelectedIndexChanged(object sender, EventArgs e)
		{
			Check();
		}

		private void bt_del_Click(object sender, EventArgs e)
		{	
			using (Context c = new Context())
			{
				using(SqlConnection connection = new SqlConnection(c.Database.Connection.ConnectionString))
				{
					connection.Open();
					new SqlCommand()
					{
						CommandText = $"DELETE FROM dbo.GenreGames WHERE Genre_Id = {SelectedGenre.Id} AND Game_Id = {SelectedGame.Id}",
						Connection = connection
					}.ExecuteNonQuery();
					connection.Close();
				}
				bt_del.Enabled = false;
				//Check();
				UpdateData();
			}
			
		}

		private void data_binded_SelectionChanged(object sender, EventArgs e)
		{
			if (data_binded.SelectedRows.Count > 0)
			{
				bt_del.Enabled = true;
				using (Context c = new Context())
				{
					string name = data_binded.SelectedRows[0].Cells["Игра"].Value.ToString();
					SelectedGame = c.Games.Where((g) => g.Name == name).ToArray()[0];

					name = data_binded.SelectedRows[0].Cells["Жанр"].Value.ToString();
					SelectedGenre = c.Genres.Where((g) => g.Name == name).ToArray()[0];
				}
			}
		}
	}
}
