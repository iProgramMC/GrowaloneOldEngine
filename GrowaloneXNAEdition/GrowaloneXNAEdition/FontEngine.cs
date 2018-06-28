using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	public class FontEngine
	{
		public Texture2D spritesheet;

		public SpriteBatch spriteBatch;

		public byte LetterWidth = 8;

		public FontEngine(SpriteBatch sb, ContentManager Content)
		{
			this.spriteBatch = sb;
			this.LoadContent(Content);
		}

		public void LoadContent(ContentManager Content)
		{
			this.spritesheet = Content.Load<Texture2D>("Fonts\\font");
		}

		public Vector2 MeasureString(string text, float scale)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (c != '\n')
				{
					num += (int)this.LetterWidth * (int)scale;
				}
				else
				{
					num2 += (int)this.LetterWidth * (int)scale;
				}
			}
			return new Vector2((float)num, (float)num2);
		}

		public void DrawString(string text, float scale, Vector2 position)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (c != '\n')
				{
					this.spriteBatch.Draw(this.spritesheet, new Rectangle((int)position.X + num, (int)position.Y + num2, (int)this.LetterWidth * (int)scale, (int)this.LetterWidth * (int)scale), new Rectangle?(new Rectangle((int)(Convert.ToByte(c) * this.LetterWidth) % this.spritesheet.Width, (int)(Convert.ToByte(c) * this.LetterWidth) / this.spritesheet.Width * (int)this.LetterWidth, (int)this.LetterWidth, (int)this.LetterWidth)), Color.White);
					num += (int)this.LetterWidth * (int)scale;
				}
				else
				{
					num = 0;
					num2 += (int)this.LetterWidth * (int)scale;
				}
			}
		}
	}
}
