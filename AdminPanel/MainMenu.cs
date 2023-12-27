using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace AdminPanel
{
	/*
	TODO:
	1)Сделать формы для изменения игр и для связи жанров к играм
	 */
	public partial class MainMenu : Form
	{
		enum Data //ds.Tables: [0] - Users; [1] - Games; [2] - Genres; [3] Comments
		{
			Users = 0,
			Games = 1,
			Genres = 2,
			Comments = 3
		}
		bool ServerStarted;
		const string domain = "http://localhost/index.php";
		string ServerPath;
		//string DbPath;
		//string SavedPath = "./ServerPath.txt";
		Process[] ApacheProcesses;
		//корневая папка GameObserver/
		DirectoryInfo Root;
		//Thread ServerStatusCheck;
		Task ServerStatusCheck;
		//Папка с Apache GameObserver/Apache
		DirectoryInfo ApacheDir;
		SqlDataAdapter Adapter;
		DataSet ds;
		int ActiveTableIndex = 0;
		public MainMenu()
		{

			InitializeComponent();

			ServerStatusCheck = new Task(() =>
			{
				bool CheckServerState()
				{
					ApacheProcesses = Process.GetProcessesByName("httpd");
					if (InvokeRequired)
						BeginInvoke(new Action(() => { ServerStarted = ApacheProcesses.Length > 0; }));
					else ServerStarted = ApacheProcesses.Length > 0;

					if (ServerStarted)
					{
						void Set()
						{
							l_server_status.Text = "Онлайн";
							l_server_status.ForeColor = Color.Green;
							bt_server_toggle.Text = "Остановить сервер";

							bt_open_in_browser.Enabled = true;
						}
						if (InvokeRequired) { BeginInvoke(new Action(Set)); }
						else Set();
						return true; 
					}
					else
					{
						void Set()
						{
							l_server_status.Text = "Офлайн";
							l_server_status.ForeColor = Color.Red;
							bt_server_toggle.Text = "Запустить сервер";

							bt_open_in_browser.Enabled = false;
						}
						if (InvokeRequired)
							BeginInvoke(new Action(Set));
						else Set();
						return false;
					}
				}
				while(true)CheckServerState();
			});
			ServerStatusCheck.Start();
			//new Thread(()=> { while(true) if(ServerStatusCheck.Status == TaskStatus.RanToCompletion) { ServerStatusCheck.Start(); } }).Start();
			Adapter = new SqlDataAdapter();
			
			//Инициализация корневой директории и директории с Apache
			Root = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.GetDirectories().Where((dir) => { return dir.Name.Contains("GameObserver"); }).FirstOrDefault();
			if (Root == null)
			{
				MessageBox.Show("Невозможно обнаружить корневую директорию с GameObserver");
				Environment.Exit(0);
			}
			ApacheDir = Root.GetDirectories().Where((dir) => { return dir.Name.Contains("Apache"); }).FirstOrDefault();
			if (ApacheDir == null)
			{
				MessageBox.Show(
				"Невозможно найти директорию с Apache" +
				$"\nПожалуйста, убедитесь что папка с Apache находится в директории {Root.FullName + "/Apache24"}",
				"Невозможно найти директорию с Apache");
				Environment.Exit(0);
			}
			//Настройки для окна отображения данных
			{
				data.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
				data.MultiSelect = false; //сделать true
				data.AllowUserToAddRows = false;
				data.AllowUserToDeleteRows = false;
				data.AllowUserToResizeColumns = false;
				data.AllowUserToResizeRows = false;
			}

			UpdateData();
		}
		void UpdateData()
		{
			if (ActiveTableIndex == (int)Data.Games) ToggleControl(true);
			Adapter.SelectCommand = null;
			ds = new DataSet();
			using (var c = new Context())
			{
				//////////////////////Запросы к БД//////////////////////
				string GenreQuery = "SELECT Genres.Name AS 'Жанры'FROM Genres;";
				string GameQuery = "SELECT Games.Id,Name, Description FROM dbo.Games;";
				string UserQuery = "SELECT * FROM dbo.Users;";
				string CommentQuery =
					"SELECT Comments.Id, " +
					"Users.Name AS 'Пользователь', " +
					"Games.Name AS 'Игра', " +
					"Text AS 'Коментарий' " +
					"FROM Comments, Users, Games " +
					"WHERE User_Id = Users.Id " +
					"AND Game_Id = Games.Id; ";
				//SELECT Genres.Id, Games.Id, Games.Name AS 'Игра', Genres.Name AS 'Жанр' FROM GenreGames, Genres, Games WHERE Genre_Id = Genres.Id AND Game_Id = Games.Id;
				string AllQuery = UserQuery + GameQuery + GenreQuery + CommentQuery;
				///////////////////////////////////////////////////////
				Adapter.SelectCommand = new SqlCommand(AllQuery,
				new SqlConnection(c.Database.Connection.ConnectionString));

				//Я не знаю почему иногда добавляются пустые пользователи без всяких данных, поэтому пока-что оставлю тут 'костыль',
				//который будет удалять всех пустых пользователей

				//ds.Tables: [0] - Users; [1] - Games; [2] - Genres; [3] Comments
				Adapter.Fill(ds);
				data.DataSource = ds.Tables[ActiveTableIndex];
				c.Users.RemoveRange(c.Users.Where((u) => String.IsNullOrEmpty(u.Name)));
				c.SaveChanges();
			}
			if (data.RowCount > 0) bt_del.Enabled = true;
			else bt_del.Enabled = false;
		}
		
		void ToggleControl(bool On)
		{
			if (On)
			{
				//bt_edit.Enabled = true;
				bt_del.Enabled = true;
				bt_update.Enabled = true;
			}
			else
			{
				//bt_edit.Enabled = false;
				bt_del.Enabled = false;
				bt_update.Enabled = false;
			}
		}
		private void bt_view_users_Click(object sender, EventArgs e)
		{
			if (bt_genres_bind.Visible) bt_genres_bind.Visible = false;
			ActiveTableIndex = ((int)Data.Users);
			data.DataSource = ds.Tables[(int)Data.Users];
		}

		private void bt_view_comments_Click(object sender, EventArgs e)
		{
			if (bt_genres_bind.Visible) bt_genres_bind.Visible = false;
			ActiveTableIndex = (int)Data.Comments;
			data.DataSource = ds.Tables[(int)Data.Comments];
		}

		private void bt_view_games_Click(object sender, EventArgs e)
		{
			if (bt_genres_bind.Visible) bt_genres_bind.Visible = false;
			ActiveTableIndex = (int)Data.Games;
			data.DataSource = ds.Tables[(int)Data.Games];
			UpdateData();
		}

		private async void bt_del_Click(object sender, EventArgs e)//!!!
		{
			bt_del.Enabled = false;
			using (var c = new Context())
			{
				var source = data.DataSource;
				int id = 0;
				if (source == ds.Tables[(int)Data.Genres])
				{
					string name = data.SelectedCells[0].Value.ToString();
					id = c.Genres.Where((g) => g.Name == name).ToArray()[0].Id;
					c.Genres.Remove(c.Genres.Find(id));
				}

				else if (source == ds.Tables[(int)Data.Users])
				{
					id = (int)data.SelectedCells[0].Value;
					if (data.SelectedCells[1].Value.ToString() != "admin") c.Users.Remove(c.Users.Find(id));
					else MessageBox.Show("Аккаунт администратора можно удалить только через запрос в БД"); //Чтобы случайно не удалить аккаунт администратора
				}
				else if (source == ds.Tables[(int)Data.Games])
				{
					if (data.Rows.Count > 0)
					{
						id = (int)data.SelectedCells[0].Value;
						Game game = c.Games.Find(id);
						Screenshot[] Screenshots = c.Screenshots.Where((s) => s.Game.Id == game.Id).ToArray();
						Comment[] Comments = c.Comments.Where((comment) => comment.Game.Id == game.Id).ToArray();
						c.Screenshots.RemoveRange(Screenshots);
						c.Comments.RemoveRange(Comments);
						c.Games.Remove(game);
					}
				}
				else if (source == ds.Tables[(int)Data.Comments])
				{
					id = (int)data.SelectedRows[0].Cells[0].Value;
					c.Comments.Remove(c.Comments.Find(id));
				}
				//else MessageBox.Show("Ошибка при удалении");
				await c.SaveChangesAsync(); // При попытке удаления игры, выходит исключения (необходимо удалить все связи с игрой, после чего удалить саму игру)
				UpdateData();
			}
			bt_del.Enabled= true;

		}

		private void bt_update_Click(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void bt_add_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(ServerPath)) { SetServerPath(); return; }
			//using(Context c = new Context())
			var source = data.DataSource;
			//if (source == ds.Tables[(int)Data.Users]) { /*Create new user*/ }//Users
			if (source == ds.Tables[(int)Data.Games])//Games
			{
				if (ServerPath == String.Empty) {SetServerPath(); return;}
				Hide();
				new Add(ServerPath).ShowDialog();
				Show();
				UpdateData();
			}
			if (source == ds.Tables[(int)Data.Genres])//Genres
			{
				bt_genre_add_ok.Visible = true;
				l_genre_name.Visible = true;
				tb_genre.Visible = true;
			}
		}
		private void SetServerPath()
		{
			/*using (var f = new FolderBrowserDialog())
				if (f.ShowDialog() == DialogResult.OK)
				{
					ServerPath = f.SelectedPath;
					File.WriteAllText(SavedPath, ServerPath);
				
					
				foreach (var i in Directory.GetFiles(ServerPath))
					if (i == "index.php") return;
				switch (MessageBox.Show("В выбранной вами директории отсуствует index.php. Вы хотите создать в ней сервер?", "Пусто", MessageBoxButtons.YesNo))
				{
					case DialogResult.Yes: CreateServer(); break;
					case DialogResult.No: return;
				}
				}
			bt_add.Enabled = true;
			bt_del.Enabled = true;
			l_server_path.Text = ServerPath;*/
			//Current dir: Project/AdminPanel/bin/debug
			//DirectoryInfo root = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent;

			ServerPath = Root.FullName;
			l_server_path.Text = ServerPath;
			//bt_edit.Enabled = true;
			bt_del.Enabled = true;

		}

		private void bt_genres_Click(object sender, EventArgs e)
		{
			bt_genres_bind.Visible = true;
			ActiveTableIndex = (int)Data.Genres;
			data.DataSource = ds.Tables[(int)Data.Genres];
		}

		private void bt_genre_add_ok_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(tb_genre.Text)) { MessageBox.Show("Название жанра не может быть пустым"); return; }
			for (int i = 0; i < data.RowCount; i++)
				if (data[0, i].Value.ToString() == tb_genre.Text) { MessageBox.Show("Такой жанр уже существует"); return; }
			bt_genre_add_ok.Visible = false;
			l_genre_name.Visible = false;
			tb_genre.Visible = false;

			using (Context c = new Context()) { c.Genres.Add(new Genre(tb_genre.Text)); c.SaveChanges(); }
			UpdateData();
		}

		private void data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//ds.Tables: [0] - Users; [1] - Games; [2] - Genres; [3] Comments
			var source = data.DataSource;
			if (source == ds.Tables[(int)Data.Games]) 
			{
				//DataTable games = ds.Tables[(int)Data.Games];
				using (Context c = new Context())
				{
					string name = data.SelectedCells[1].Value.ToString();
					int id = c.Games.Where((g)=>g.Name == name).FirstOrDefault().Id;
					Hide();
					new Add(c.Games.Where((g) => g.Id == id).FirstOrDefault()).ShowDialog();
					UpdateData();
					Show();
				};
				return; 
			}
			if(source == ds.Tables[(int)Data.Comments])
			{
				if(data.SelectedRows.Count > 0)
				{
					Hide();
					Comment comment;
					using (Context c = new Context())
					{
						int id = (int)data.SelectedCells[0].Value;
						comment = c.Comments.Where((com) => com.Id == id).FirstOrDefault();
					}
					new CommentDisplay(comment).ShowDialog();
					Show();
				}
				
			}
			//if(source == ds.Tables[(int)Data.Genres]) { Hide(); new GenreBind().ShowDialog(); Show(); return; }
		}

		private void bt_genres_bind_Click(object sender, EventArgs e)
		{
			Hide(); new GenreBind().ShowDialog(); Show(); return;
		}

		private void bt_server_toggle_Click(object sender, EventArgs e)
		{
			if (ServerStarted) foreach (Process process in ApacheProcesses) process.Kill();
			else Process.Start(ApacheDir.FullName + "/bin/httpd");
		}

		private void ts_settings_choosePath_server_Click(object sender, EventArgs e)
		{
			SetServerPath();
		}

		private void bt_open_in_browser_Click(object sender, EventArgs e)
		{
			Process.Start(domain);
		}

		private void bt_fast_add_Click(object sender, EventArgs e)
		{
			const string wait = "Пожалуйста, подождите";
			const string Default = "Быстро добавить игру";
			bt_fast_add.Text = wait;
			bt_fast_add.Enabled = false;
			using (Context c = new Context())
			{
				string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam porttitor sagittis interdum. Phasellus arcu tortor, pulvinar id sagittis nec, commodo eu felis. Cras quis nunc orci. Morbi posuere, nulla eu hendrerit semper, libero leo ornare justo, sed pretium ante enim at nunc. Integer aliquam est non varius posuere. Suspendisse porttitor nunc tellus, et mattis turpis tincidunt vitae. Morbi eu tempor sapien, eu cursus erat. Maecenas malesuada dui at velit condimentum mollis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;\r\n\r\nSed auctor odio augue, eu mollis odio rhoncus eget. Nam facilisis ultricies arcu sed ultricies. Vivamus diam nisl, auctor sit amet pellentesque quis, sagittis id ligula. Nunc sagittis neque nec ligula iaculis, eu accumsan nulla tempor. Maecenas viverra nisi eu tortor mattis volutpat. Duis tristique nisi fringilla ipsum posuere, a scelerisque mauris sollicitudin. Nullam sollicitudin leo et tincidunt semper.\r\n\r\nVivamus ut leo lacinia, suscipit metus nec, tincidunt nunc. Aliquam egestas elit vel felis ullamcorper, quis tempor tortor efficitur. Donec finibus tincidunt magna a placerat. Aenean vestibulum blandit dui, nec tempor nibh eleifend in. Duis quis ipsum mollis, suscipit leo in, varius elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sed sem libero.\r\n\r\nDuis ut lobortis odio. Vestibulum vestibulum est eget gravida pulvinar. Vestibulum viverra luctus massa quis ultrices. Cras orci velit, venenatis congue rhoncus tincidunt, ultrices viverra erat. Etiam eget risus tortor. Nam quis velit non erat malesuada consequat at ac nisi. Nulla sollicitudin est nisi, quis scelerisque sem porttitor in.\r\n\r\nCras eget luctus nunc, vitae consequat sem. Suspendisse volutpat dolor sit amet tellus tempus condimentum. Pellentesque dictum, purus vitae pharetra lobortis, est ex tempus risus, in auctor lectus turpis vitae mauris. Mauris eu pretium mi. Quisque at ullamcorper tortor. Nunc a aliquet libero. In hac habitasse platea dictumst. Donec sed lacus mauris.";
				string root = "C:\\Users\\AbstractSequence\\Desktop\\Project\\GameObserver\\Placeholder Game\\Hotline Miami";
				byte[] preview = File.ReadAllBytes(root + "\\Preview\\hm.jpg");
				byte[] torrent = File.ReadAllBytes(root + "\\Hotline_Miami.torrent");
				Game game = new Game()
				{
					Name = "Hotline Miami",
					Description = lorem,
					Preview = preview,
					Torrent = torrent,
					Steam = "https://store.steampowered.com/app/219150/Hotline_Miami/"
				};
				List<Screenshot> screenshots = new List<Screenshot>();
				IEnumerable<string> ScreenshotsFolder = Directory.EnumerateFiles(root + "\\Screenshots");
				foreach (string screenshot in ScreenshotsFolder)
				{
					screenshots.Add(new Screenshot(game,Image.FromFile(screenshot)));
				}
				c.Games.Add(game);
				foreach(Screenshot screenshot in screenshots) c.Screenshots.Add(screenshot);
				c.SaveChanges();
				UpdateData();
			}
			
			bt_fast_add.Text = Default;
			bt_fast_add.Enabled = true;
		}
	}
}