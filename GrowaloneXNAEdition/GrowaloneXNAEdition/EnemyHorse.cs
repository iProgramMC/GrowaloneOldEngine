using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class EnemyHorse : Enemy
	{
		public bool isBeingAttackedAlongWithPlayer;

		public EnemyHorse(int X, int Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public override void Draw(Growalone game)
		{
			SpriteEffects effects;
			if (this.facingLeft)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			else
			{
				effects = SpriteEffects.None;
			}
			game.spriteBatch.Draw(game.HorseTexture, new Rectangle(-game.cameraX + this.X - 32 + (game.GraphicsDevice.Viewport.Width - 800), -game.cameraY + this.Y + (game.GraphicsDevice.Viewport.Height - 480), 32, 32), new Rectangle?(new Rectangle(0, 0, 32, 32)), Color.White, 0f, Vector2.Zero, effects, 0f);
		}

		public override void Update(Growalone game)
		{
			if (this.isBeingAttackedAlongWithPlayer)
			{
				this.isPlayerRiding = false;
				game.enemyThatThePlayerRides = null;
				game.doesRideAnEnemy = false;
			}
			if (this.isPlayerRiding)
			{
				this.X = game.guyX;
				this.Y = game.guyY;
			}
			int x = this.X;
			int y = this.Y;
			int num = (int)Math.Round((double)this.X / 32.0);
			int num2 = (int)Math.Floor((double)this.Y / 32.0);
			try
			{
				Console.WriteLine(string.Concat(new object[]
				{
					num.ToString(),
					",",
					num2.ToString(),
					"=",
					game.world.Map[num, num2, 0].ID
				}));
				if (game.world.Map[num, num2, 0].ID == 86)
				{
					this.Y += 4;
				}
				else if (game.collided[game.world.Map[num, num2, 0].ID] == 0)
				{
					this.Y += 8;
				}
				else if (game.collided[game.world.Map[num, num2, 0].ID] != 3)
				{
					if (game.collided[game.world.Map[num, num2, 0].ID] == 1)
					{
						this.Y -= 8;
					}
				}
			}
			catch
			{
			}
		}
	}
}
