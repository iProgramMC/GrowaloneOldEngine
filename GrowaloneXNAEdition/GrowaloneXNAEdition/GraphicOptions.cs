using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;

namespace GrowaloneXNAEdition
{
	public class GraphicOptions
	{
		public static Microsoft.Xna.Framework.Color[] DrawMissingnoTexture()
		{
			Bitmap bitmap = new Bitmap(75, 25);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(System.Drawing.Color.White);
			Font font = new Font("System", 10f, FontStyle.Bold);
			graphics.DrawString("missingno", font, Brushes.Red, new PointF(5f, 5f));
			Microsoft.Xna.Framework.Color[] array = new Microsoft.Xna.Framework.Color[bitmap.Width * bitmap.Height];
			for (int i = 0; i < bitmap.Height; i++)
			{
				for (int j = 0; j < bitmap.Width; j++)
				{
					array[j + i * bitmap.Width] = GraphicOptions.DrawingColorToXnaColor(bitmap.GetPixel(j, i));
				}
			}
			return array;
		}

		public static Microsoft.Xna.Framework.Color[,] Texture2DtoColor(Texture2D texture)
		{
			Microsoft.Xna.Framework.Color[] array = new Microsoft.Xna.Framework.Color[texture.Width * texture.Height];
			texture.GetData<Microsoft.Xna.Framework.Color>(array);
			Microsoft.Xna.Framework.Color[,] array2 = new Microsoft.Xna.Framework.Color[texture.Width, texture.Height];
			for (int i = 0; i < texture.Width; i++)
			{
				for (int j = 0; j < texture.Height; j++)
				{
					array2[i, j] = array[i + j * texture.Width];
				}
			}
			return array2;
		}

		public static Microsoft.Xna.Framework.Color GetPixel(Texture2D texture, int x, int y)
		{
			Microsoft.Xna.Framework.Color[] array = new Microsoft.Xna.Framework.Color[texture.Width * texture.Height];
			texture.GetData<Microsoft.Xna.Framework.Color>(array);
			return array[x + y * texture.Width];
		}

		public static Microsoft.Xna.Framework.Color DrawingColorToXnaColor(System.Drawing.Color color)
		{
			return Microsoft.Xna.Framework.Color.FromNonPremultiplied((int)color.R, (int)color.G, (int)color.B, (int)color.A);
		}

		public static System.Drawing.Color XnaColorToDrawingColor(Microsoft.Xna.Framework.Color color)
		{
			return System.Drawing.Color.FromArgb((int)color.A, (int)color.R, (int)color.G, (int)color.B);
		}

		public static System.Drawing.Color[] DrawingBitmapToDrawingColorArray(Bitmap bmp)
		{
			System.Drawing.Color[] array = new System.Drawing.Color[bmp.Width * bmp.Height];
			for (int i = 0; i < bmp.Height; i++)
			{
				for (int j = 0; j < bmp.Width; j++)
				{
					array[i * bmp.Width + j] = bmp.GetPixel(j, i);
				}
			}
			return array;
		}
	}
}
