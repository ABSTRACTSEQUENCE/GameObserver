using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Math.Field;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPanel
{
	public partial class Add : Form
	{
		OpenFileDialog PictureSelector;
		List<Bitmap> Screenshots;
		string ServerPath;
		byte[] Torrent;
		bool EditMode = false;
		//int OldId;
		Game game;

		string TorrentAdded = "Добавлен";
		string TorrentNotAdded = "Не добавлен";
		public Add(string serverPath)
		{
			InitializeComponent(); Init();
			EditMode = false;
			ServerPath = serverPath;
		}
		public Add(Game game) 
		{
			EditMode = true;
			this.game = game;
			InitializeComponent(); Init();
			Fill();
		}
		void Init()
		{
			Screenshots = new List<Bitmap>();
			if (EditMode)
			{
				Screenshot[] screenshots;
				using (Context c = new Context())
				{
					screenshots = c.Screenshots.Where(s=>s.Game.Id == game.Id).ToArray();
				}
				foreach(Screenshot s in screenshots)
				{
					using(MemoryStream ms = new MemoryStream(s.Image))
					{
						Screenshots.Add(new Bitmap(ms));
					}
				}
			}
			PictureSelector = new OpenFileDialog();
			PictureSelector.Filter = "Изображения|*.png|Изображения|*.jpg";//вот тут сделать чтобы все форматы поддерживал
			PictureSelector.Multiselect = false;
			HandleTorrentFile();
		}
		void Fill() //Этот метод используется при редактировании игры
		{
			//OldId = g.Id;
			using (Stream s = new MemoryStream(game.Preview))
			{
				pb_preview.Image = Image.FromStream(s);
			}
			
			using(Context c = new Context())
			{
				Screenshot[] screenshots = c.Screenshots.Where((s)=>s.Game.Id == game.Id).ToArray();
				foreach(Screenshot screenshot in screenshots)
				{
					using(MemoryStream ms = new MemoryStream(screenshot.Image)) 
						lb_screenshots.Items.Add(new Bitmap(Image.FromStream(ms), new Size(500,300)));
				}

				tb_desc.Text = game.Description;
				tb_name.Text =game.Name;
				Torrent = game.Torrent;
				HandleTorrentFile();

				using (MemoryStream ms = new MemoryStream(game.Preview)) 
					pb_preview.Image = new Bitmap(Image.FromStream(ms), new Size(500, 300));
			}
			
			//if (g.Preview != null) pb_preview.Image = Image.FromStream(
		}
		void HandleTorrentFile()
		{
			if (Torrent != null || EditMode)
			{
				l_torrent.Text = TorrentAdded; l_torrent.ForeColor = Color.Green;
			}
			else { l_torrent.Text = TorrentNotAdded; l_torrent.ForeColor = Color.Red; }
		}
		private void bt_add_Click(object sender, EventArgs e)
		{
			Validate();
			if (AllFieldsAreFilled()) AddGame();
			//foreach(var i in lb_genres.Items) Genres.Add((Genre)i);
		}

		private void bt_preview_Click(object sender, EventArgs e)
		{
			//string temp = ServerPath + "\\Pictures\\temp\\temp.png";
			if (PictureSelector.ShowDialog() == DialogResult.OK)
			{
				/*//if (PictureSelector.FileName.Contains(".webp")) { MessageBox.Show("Формат '.webp' не поддерживается"); }
				pb_preview.Image = null;
				if (File.Exists(temp)) File.Delete(temp);//Проблема возникает при попытке поменять превью
				new Bitmap(Image.FromFile(PictureSelector.FileName), new Size(500, 300)).Save(temp, ImageFormat.Png);
				//System.OutOfMemoryException: "Недостаточно памяти."
				pb_preview.Load(temp);*/
				pb_preview.Image = new Bitmap(Image.FromFile(PictureSelector.FileName), new Size(500, 300));
			}
		}
		//void CreateServer() { }
		void Validate()
		{
			//if (String.IsNullOrEmpty(tb_name.Text)) { MessageBox.Show("Название игры не указано"); return; }
			string name = tb_name.Text;
			List<string> Folders = new List<string>()
			{
				ServerPath+"\\Pictures\\",
				ServerPath+"\\Pictures\\Previews\\"+name,
				ServerPath+"\\Pictures\\Screenshots\\"+name,
				ServerPath+"\\Pictures\\temp"
			};
			foreach (var i in Folders) if (!Directory.Exists(i)) Directory.CreateDirectory(i);
			//if (File.Exists(ServerPath + "\\Pictures\\temp\\temp.png")) File.Delete(ServerPath + "\\Pictures\\temp\\temp.png");
		}
		bool AllFieldsAreFilled()
		{
			if(lb_screenshots.Items.Count <2) { MessageBox.Show("Необходимо добавить 3 скриншота"); return false; }
			//if (String.IsNullOrEmpty(ServerPath)) { MessageBox.Show("Выберите путь к серверу"); return false; }
			if (pb_preview.Image == null){ MessageBox.Show("Выберите превью"); return false; }
			if (String.IsNullOrEmpty(tb_name.Text)) { MessageBox.Show("Название игры не введено"); return false; }
			if(Torrent == null) { MessageBox.Show("Для игры нужен torrent файл");return false; }
			return true;
		}
		void AddGame()///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		{
			string Name = tb_name.Text; string Description = tb_desc.Text; string Steam = tb_steam.Text;
			//string PreviewPath = ServerPath + "\\Pictures\\Previews\\" + Name + "\\" + Name + ".png";
			//Bitmap Preview = new Bitmap(PreviewPath);
			//string ScreenshotPath = ServerPath + "\\Pictures\\Screenshots\\" + Name;
			//PictureSelector.Dispose();
			//string pic = pb_preview.ImageLocation;
			//PictureSelector = null;
			
			using (var context = new Context())
			{
				context.Database.CreateIfNotExists();
				byte[] preview;
				List<Screenshot> screenhots = new List<Screenshot>();
				using(MemoryStream ms = new MemoryStream())
				{
					pb_preview.Image.Save(ms, ImageFormat.Png);
					preview = ms.ToArray();
				}
				
				
				if (EditMode)
				{
					Screenshot[] ToDel = context.Screenshots.Where((s) => s.Game.Id == game.Id).ToArray();
					foreach (Screenshot s in ToDel) s.Game = game;
					game.Name = Name;
					game.Description = Description;
					game.Steam = Steam;
					game.Preview = preview;
					game.Torrent = Torrent;
				}
				else
				{
					game = new Game(Name, Torrent, Description, preview, Steam);
					foreach (Image Screenshot in lb_screenshots.Items) context.Screenshots.Add(new Screenshot(game, Screenshot));
					//context.Games.Add(game);
				}
				context.Games.AddOrUpdate(game);

				/*if (!File.Exists(PreviewPath)) File.Move(pic, PreviewPath);
				//for (int i = 0; i < ScreenshotLocations.Count; i++){string path = ScreenshotPath + "\\" + i + ".png";if (!File.Exists(path)) File.Copy(ScreenshotLocations[i],path);};
				//File.Create(ScreenshotPath + ".png").Close();

				for (int i = 0; i <= Screenshots.Count - 1; i++)
				{
					string str = ScreenshotPath + "\\" + i + ".png";
					Screenshots[i].Save(str);
				}*/
				//pb_preview.Dispose();
				//pb_preview = null;
				MessageBox.Show("Готово!");
				context.SaveChanges();
				Close(); return;
			}
		}
		private void bt_screenshots_Click(object sender, EventArgs e)
		{
			if (Screenshots == null) Screenshots = new List<Bitmap>();
			if(lb_screenshots.Items.Count > 2) { MessageBox.Show("Нужно добавить ровно 3 скриншота"); return; }
			if(PictureSelector.ShowDialog() == DialogResult.OK)
			{
				Bitmap pic = new Bitmap(Image.FromFile(PictureSelector.FileName), new Size(350, 300));
				lb_screenshots.Items.Add(pic);
				Screenshots.Add(pic);
			}
		}

		private void lb_screenshots_SelectedIndexChanged(object sender, EventArgs e)
		{
			Bitmap screenshot = lb_screenshots.SelectedItem as Bitmap;
			if (screenshot == null) return;
			pb_screenshots.Image = screenshot;
		}

		private void bt_del_screenshot_Click(object sender, EventArgs e)
		{
			if (lb_screenshots.SelectedItems.Count <= 0) return;
			Screenshots.Remove((Bitmap)pb_screenshots.Image);
			pb_screenshots.Image = null;
			lb_screenshots.Items.Remove(lb_screenshots.SelectedItem);
		}

		private void bt_add_torrent_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog();
			fd.Filter = "Торрент-файлы |*.torrent";
			if(fd.ShowDialog() == DialogResult.OK)
			{
				Torrent = File.ReadAllBytes(fd.FileName);
				HandleTorrentFile();
			}
		}
	}
}
//TODO: При редактировании скрины не те