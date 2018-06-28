using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	public class StarSprite
	{
		public Texture2D spritesheet;

		public Growalone game;

		public int currentFrame;

		public int animLength = 8;

		public int delay = 8;

		public StarSprite(Growalone growalone)
		{
			this.game = growalone;
		}

		public void Draw(int X, int Y)
		{
			this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(X, Y, 32, 32), new Rectangle?(new Rectangle(this.currentFrame / this.delay * 32, 0, 32, 32)), Color.White);
		}

		public void ResetAnimation()
		{
			this.currentFrame = 0;
		}

		public void Draw(int X, int Y, int ShadowOffset)
		{
			this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(X + ShadowOffset, Y + ShadowOffset, 32, 32), new Rectangle?(new Rectangle(this.currentFrame / this.delay * 32, 0, 32, 32)), Color.FromNonPremultiplied(0, 0, 0, 127));
		}

		public void Update()
		{
			this.currentFrame++;
			if (this.currentFrame >= this.animLength * this.delay)
			{
				this.ResetAnimation();
			}
		}

		public void LoadContent(Growalone growalone)
		{
			try
			{
				this.spritesheet = growalone.Content.Load<Texture2D>("star");
			}
			catch
			{
				Color[] data = GraphicOptions.DrawMissingnoTexture();
				Texture2D texture2D = new Texture2D(growalone.graphics.GraphicsDevice, 75, 25);
				texture2D.SetData<Color>(data);
				this.spritesheet = texture2D;
			}
		}
	}
}
