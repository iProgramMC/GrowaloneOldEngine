using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	public class CharacterSprite
	{
		public CharacterAnimatedSpriteMode mode = CharacterAnimatedSpriteMode.Still;

		public Texture2D spritesheet;

		public Growalone game;

		public int currentFrame;

		public int[] animLengths = new int[]
		{
			1,
			4,
			4,
			4,
			1,
			1,
			1
		};

		public int[] deadAnimFrameHeights = new int[360];

		public int delay = 8;

		public CharacterSprite(Growalone growalone)
		{
			this.LoadContent(growalone);
			this.game = growalone;
			for (int i = 0; i < 360; i++)
			{
				this.deadAnimFrameHeights[i] = 0;
			}
			int num = 0;
			int num2 = 16;
			for (int i = 60; i < 360; i += 2)
			{
				this.deadAnimFrameHeights[i] = num;
				this.deadAnimFrameHeights[i + 1] = num;
				num -= num2;
				num2--;
			}
		}

		public void Draw(int ActualCameraX, int guyPosition)
		{
			if (this.game.isDead)
			{
				this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(guyPosition - ActualCameraX, (this.game.GraphicsDevice.Viewport.Height - 32) / 2 + this.deadAnimFrameHeights[Math.Abs(this.game.globalTimer - this.game.tickWhenWasKilled) % 360], 32, 32), new Rectangle?(new Rectangle(0, 128, 32, 32)), Color.White);
			}
			else if (this.game.facesLeft)
			{
				SpriteEffects effects = SpriteEffects.FlipHorizontally;
				this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(guyPosition - ActualCameraX, (this.game.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Rectangle?(new Rectangle(this.currentFrame / this.delay * 32, this.GetY() * 32, 32, 32)), Color.White, 0f, new Vector2(0f, 0f), effects, 0f);
			}
			else
			{
				this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(guyPosition - ActualCameraX, (this.game.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Rectangle?(new Rectangle(this.currentFrame / this.delay * 32, this.GetY() * 32, 32, 32)), Color.White);
			}
		}

		public void SetAnimation(CharacterAnimatedSpriteMode _mode)
		{
			this.currentFrame = 0;
			this.mode = _mode;
		}

		public void Draw(int ActualCameraX, int guyPosition, bool isShadow, int ShadowOffset)
		{
			if (isShadow)
			{
				if (this.game.isDead)
				{
					this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(guyPosition - ActualCameraX + ShadowOffset, (this.game.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset + this.deadAnimFrameHeights[Math.Abs(this.game.globalTimer - this.game.tickWhenWasKilled) % 360], 32, 32), new Rectangle?(new Rectangle(0, 128, 32, 32)), Color.FromNonPremultiplied(0, 0, 0, 127));
				}
				else if (this.game.facesLeft)
				{
					SpriteEffects effects = SpriteEffects.FlipHorizontally;
					this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(guyPosition - ActualCameraX + ShadowOffset, (this.game.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Rectangle?(new Rectangle(this.currentFrame / this.delay * 32, this.GetY() * 32, 32, 32)), Color.FromNonPremultiplied(0, 0, 0, 127), 0f, new Vector2(0f, 0f), effects, 0f);
				}
				else
				{
					this.game.spriteBatch.Draw(this.spritesheet, new Rectangle(guyPosition - ActualCameraX + ShadowOffset, (this.game.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Rectangle?(new Rectangle(this.currentFrame / this.delay * 32, this.GetY() * 32, 32, 32)), Color.FromNonPremultiplied(0, 0, 0, 127));
				}
			}
		}

		public void Update()
		{
			if (this.mode == CharacterAnimatedSpriteMode.Jumping || this.mode == CharacterAnimatedSpriteMode.Falling)
			{
				this.currentFrame++;
				if (this.currentFrame >= this.animLengths[this.GetY()] * this.delay)
				{
					this.currentFrame = 3 * this.delay;
				}
			}
			else
			{
				this.currentFrame++;
				if (this.currentFrame >= this.animLengths[this.GetY()] * this.delay)
				{
					this.currentFrame = 0;
				}
			}
		}

		public void LoadContent(Growalone growalone)
		{
			this.spritesheet = growalone.Content.Load<Texture2D>("charanims");
		}

		public override string ToString()
		{
			return this.GetY().ToString();
		}

		private int GetY()
		{
			int result;
			switch (this.mode)
			{
			case CharacterAnimatedSpriteMode.Still:
				result = 0;
				break;
			case CharacterAnimatedSpriteMode.Walking:
				result = 1;
				break;
			case CharacterAnimatedSpriteMode.Jumping:
				result = 2;
				break;
			case CharacterAnimatedSpriteMode.Falling:
				result = 3;
				break;
			case CharacterAnimatedSpriteMode.Dead:
				result = 4;
				break;
			case CharacterAnimatedSpriteMode.Crouching:
				result = 6;
				break;
			default:
				result = 5;
				break;
			}
			return result;
		}
	}
}
