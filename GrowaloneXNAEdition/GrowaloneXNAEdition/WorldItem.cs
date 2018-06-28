using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class WorldItem
	{
		public int HOW_MANY_TIMES_ADDITEM_IS_RUN_IN_THE_GAME;

		public bool doesUpdate = true;

		public int ID;

		public byte amount;

		public int PosX;

		public int PosY;

		public sbyte anim = 0;

		public WorldItem()
		{
		}

		public WorldItem(int ID, int X, int Y)
		{
			this.ID = ID;
			this.PosX = X;
			this.PosY = Y;
			this.amount = 1;
			this.BgUpdate();
		}

		public WorldItem(int ID, byte Amount, int X, int Y)
		{
			this.ID = ID;
			this.PosX = X;
			this.PosY = Y;
			this.amount = Amount;
			this.BgUpdate();
		}

		public void Draw(SpriteBatch spriteBatch, Growalone that, Vector2 posOfCam, int ActualCameraX)
		{
			int num = (int)posOfCam.Y;
			int num2 = this.PosX - ActualCameraX + (that.GraphicsDevice.Viewport.Width - 800) / 2;
			int num3 = this.PosY - num + (that.GraphicsDevice.Viewport.Height - 480) / 2;
			if (ItemData.IsPlantable(this.ID))
			{
				Color[] array = new Color[that.tileTextures[this.ID - 1, 0].Width * that.tileTextures[this.ID - 1, 0].Height];
				that.tileTextures[this.ID - 1, 0].GetData<Color>(array);
				if (array[that.colorIndex1].A < 255 && array[that.colorIndex2].A < 255)
				{
					spriteBatch.Draw(that.seedTexture, new Rectangle(num2, num3 + (int)this.anim, that.seedWidth, that.seedHeight), new Rectangle?(new Rectangle(0, 0, that.seedWidth, that.seedHeight)), array[that.colorIndex1]);
					spriteBatch.Draw(that.seedTexture, new Rectangle(num2, num3 + (int)this.anim, that.seedWidth, that.seedHeight), new Rectangle?(new Rectangle(that.seedWidth, 0, that.seedWidth, that.seedHeight)), array[that.colorIndex2]);
				}
				else
				{
					bool flag = false;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					while (array[num4].A > 254 && array[num5].A > 254)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i].A > 254 && !flag)
							{
								num4 = i;
								i += 100;
								flag = true;
							}
							else if (array[i].A > 254 && flag)
							{
								num5 = i;
								break;
							}
						}
						if (num6 == 1)
						{
							break;
						}
						num6++;
					}
					if (num4 == 0)
					{
						num4 = 500;
					}
					if (num5 == 0)
					{
						num5 = 1000;
					}
					spriteBatch.Draw(that.seedTexture, new Rectangle(num2, num3 + (int)this.anim, that.seedWidth, that.seedHeight), new Rectangle?(new Rectangle(0, 0, that.seedWidth, that.seedHeight)), array[num4]);
					spriteBatch.Draw(that.seedTexture, new Rectangle(num2, num3 + (int)this.anim, that.seedWidth, that.seedHeight), new Rectangle?(new Rectangle(that.seedWidth, 0, that.seedWidth, that.seedHeight)), array[num5]);
				}
			}
			else if (this.ID >= 0)
			{
				spriteBatch.Draw(that.tileTextures[this.ID, 0], new Rectangle(num2, num3 + (int)this.anim, 17, 17), Color.White);
			}
			spriteBatch.DrawString(that.defaultFont, this.amount.ToString(), new Vector2((float)num2, (float)(num3 + (int)this.anim)), Color.White, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
		}

		public void BgUpdate()
		{
		}

		public void Update(int charX, int charY, Growalone that)
		{
			if (this.anim == 0)
			{
				this.anim = 1;
			}
			else if (this.anim == 1)
			{
				this.anim = -1;
			}
			else if (this.anim == -1)
			{
				this.anim = 0;
			}
			int num = (int)Math.Floor(this.PosX / 32m);
			int num2 = (int)Math.Ceiling(this.PosY / 32m);
			int num3 = (charX + 16) / 32;
			int num4 = (int)Math.Ceiling(charY / 32m);
			if (num == num3 && num2 == num4)
			{
				bool flag = that.AddItem(this.ID, (int)this.amount);
				that.PickupEffect.Play();
				if (flag)
				{
					this.ID = 0;
					this.amount = 0;
					this.PosX = -100;
					this.PosY = -100;
				}
				else
				{
					that.ShowDialog2("Backpack full!", 200);
				}
			}
		}
	}
}
