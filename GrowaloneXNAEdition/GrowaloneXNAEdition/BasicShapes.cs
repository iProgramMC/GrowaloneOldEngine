using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	public class BasicShapes
	{
		public Texture2D t;

		public SpriteBatch sb;

		public BasicShapes(GraphicsDevice device, SpriteBatch spr)
		{
			this.t = new Texture2D(device, 1, 1);
			Color[] data = new Color[]
			{
				Color.FromNonPremultiplied(255, 255, 255, 255)
			};
			this.t.SetData<Color>(data);
			this.sb = spr;
		}

		public void FillRectangle(Rectangle rect, Color color)
		{
			this.sb.Draw(this.t, rect, color);
		}

		public void DrawRectangle(Rectangle rect, Color color)
		{
			this.DrawLine(new Vector2((float)rect.X, (float)rect.Y), new Vector2((float)(rect.X + rect.Width), (float)rect.Y), color);
			this.DrawLine(new Vector2((float)rect.X, (float)rect.Y), new Vector2((float)rect.X, (float)(rect.Y + rect.Height)), color);
			this.DrawLine(new Vector2((float)(rect.X + rect.Width), (float)(rect.Y + rect.Height)), new Vector2((float)(rect.X + rect.Width), (float)rect.Y), color);
			this.DrawLine(new Vector2((float)(rect.X + rect.Width), (float)(rect.Y + rect.Height)), new Vector2((float)rect.X, (float)(rect.Y + rect.Height)), color);
		}

		public void DrawLine(Vector2 start, Vector2 end, Color color)
		{
			Vector2 vector = end - start;
			float rotation = (float)Math.Atan2((double)vector.Y, (double)vector.X);
			this.sb.Draw(this.t, new Rectangle((int)start.X, (int)start.Y, (int)vector.Length(), 1), null, color, rotation, new Vector2(0f, 0f), SpriteEffects.None, 0f);
		}

		public void DrawLinedTexture(Vector2 start, Vector2 end, Texture2D texture, int thickness)
		{
			Vector2 vector = end - start;
			float rotation = (float)Math.Atan2((double)vector.Y, (double)vector.X);
			this.sb.Draw(texture, new Rectangle((int)start.X, (int)start.Y, (int)vector.Length(), thickness), null, Color.White, rotation, new Vector2(-2f, (float)(thickness / 2)), SpriteEffects.None, 0f);
		}
	}
}
