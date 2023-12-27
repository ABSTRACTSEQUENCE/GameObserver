using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Builders;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel
{
	public class Screenshot
	{
		public int Id { get; set; }
		[Required]
		public Game Game { get; set; }
		public byte[] Image { get; set; }

		public Screenshot(Game game, byte[] Image) 
		{
			this.Game = game; this.Image = Image;
		}
		public Screenshot(Game game, Image image)
		{
			this.Game = game;
			using(MemoryStream stream = new MemoryStream())
			{
				image.Save(stream, ImageFormat.Png);
				Image = stream.ToArray();
			}
		}
		public Screenshot() { }
	}
}
