using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace GrowaloneXNAEdition
{
	public class OnlineWorldItem
	{
		public string thumbnail = "";

		public string name = "";

		public string file = "";

		public string creator = "";

		public Texture2D thumbTex;

		public OnlineWorldItem(string thumb, string n, string f, string c)
		{
			this.thumbnail = thumb;
			this.name = n;
			this.file = f;
			this.creator = c;
		}

		public void UpdatePic(GraphicsDevice gd)
		{
			WebClient webClient = new WebClient();
			byte[] bytes = webClient.DownloadData("http://growalonegame.000webhostapp.com/gallery_of_worlds//" + this.name + "/" + this.thumbnail);
			File.WriteAllBytes("c:\\growalone_maps\\thumb.png", bytes);
			Bitmap bitmap = new Bitmap(1, 1);
			using (FileStream fileStream = new FileStream("c:\\growalone_maps\\thumb.png", FileMode.Open, FileAccess.Read))
			{
				bitmap = (Bitmap)Image.FromStream(fileStream);
			}
			System.Drawing.Color[] array = new System.Drawing.Color[bitmap.Width * bitmap.Height];
			array = GraphicOptions.DrawingBitmapToDrawingColorArray(bitmap);
			Microsoft.Xna.Framework.Color[] array2 = new Microsoft.Xna.Framework.Color[bitmap.Width * bitmap.Height];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = GraphicOptions.DrawingColorToXnaColor(array[i]);
			}
			this.thumbTex = new Texture2D(gd, bitmap.Width, bitmap.Height);
			this.thumbTex.SetData<Microsoft.Xna.Framework.Color>(array2);
			File.Delete("c:\\growalone_maps\\thumb.png");
		}

		public override string ToString()
		{
			return "                         World Name: " + this.name + "\n\n\n                         Created by " + this.creator;
		}
	}
}
