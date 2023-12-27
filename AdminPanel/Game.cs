using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace AdminPanel
{
	public class Game
	{
		public const char Separator = ',';
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Steam { get; set; }
		public byte[] Torrent { get; set; }
		public byte[] Preview { get; set; }
		//public List<byte[]> Screenshots { get; set; }
		public List<Genre> Genres{ get; set; }
		public List<Comment> Comments { get; set; }
		public Game(string name, byte[] torrent, string description, byte[] preview, string steam = "")
		{
			Name = name; Description = description; 
			Steam = steam; 
			Genres = new List<Genre>(); 
			Torrent = torrent;
			Preview = preview;
			//if(Screenshots!= null || Screenshots.Count >0)
			//foreach (var screenshot in Screenshots)
				//ScreenshotsSerialized += BitConverter.ToString(screenshot);
		}
		public Game()
		{
			Genres = new List<Genre>();
			/*using (Context c = new Context()) 
			{
				Genres = new List<Genre>();
				foreach(Genre genre in c.Genres)
				{ 
					foreach(Game game in genre.Games)
					{
						if (game == this) Genres.Add(genre);
					}
				}
			}*/
		}
		public Game(List<Genre> genres) { Genres = genres; }
		public override string ToString()
		{
			return Name;
		}
	
	}
}
