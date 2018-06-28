using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class World
	{
		public class WorldButton
		{
			public string AssignedWorldName;

			public Rectangle ButtonRectangle;

			public Growalone Game;

			public bool Initialized;

			public bool IsLavaCourse;

			public WorldButton(Growalone growalone, string worldName, Rectangle btn)
			{
				this.Game = growalone;
				this.AssignedWorldName = worldName;
				this.ButtonRectangle = btn;
				this.Initialized = true;
			}

			public void Update(MouseState state)
			{
				Point value = new Point(state.X, state.Y);
				if (this.ButtonRectangle.Contains(value) && this.Game.Screen == ScreenType.WorldSelect)
				{
					if (state.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
					{
						this.OnClickLeft();
					}
					else if (state.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
					{
						this.OnClickRight();
					}
				}
			}

			public void OnClickLeft()
			{
				this.Game.GoToWorld(this.AssignedWorldName);
				this.Game.Screen = ScreenType.Playground;
				if (this.Game.world.enemies == null)
				{
					this.Game.world.enemies = new Enemy[1024];
				}
			}

			public void OnClickRight()
			{
				DialogResult dialogResult = MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE WORLD \"" + this.AssignedWorldName + "\"?! YOU WILL LOSE THE WORLD AND EVERYTHING INSIDE! BE CAREFUL!", "Are you sure, dude?!", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					try
					{
						File.Delete("C:\\growalone_maps\\worlds\\" + this.AssignedWorldName + ".gaw");
						MessageBox.Show("Okay, you deleted the world \"" + this.AssignedWorldName + "\"...", "What a loser...");
					}
					catch
					{
						MessageBox.Show("Could not delete world \"" + this.AssignedWorldName + "\"...", "YAAAAAAAY!");
					}
				}
			}

			public void Draw()
			{
				this.Game.spriteBatch.Draw(this.Game.flatPanel, this.ButtonRectangle, Color.Purple);
				this.Game.spriteBatch.DrawString(this.Game.defaultFont, this.AssignedWorldName, new Vector2((float)(this.ButtonRectangle.X + 3), (float)(this.ButtonRectangle.Y + 3)), Color.White, 0f, Vector2.Zero, this.Game.fontSize, SpriteEffects.None, 1f);
			}
		}

		public Block[,,] Map = new Block[100, 60, 5];

		public byte[,] Locked = new byte[100, 60];

		public WorldItem[] worldItems = new WorldItem[1024];

		public Enemy[] enemies = new Enemy[1024];

		public byte[,] Cracks = new byte[100, 60];

		public byte[,] Timeout = new byte[100, 60];

		public WeatherMachine weatherMachine = WeatherMachine.Sunny;

		public void ClearAllItems()
		{
			for (int i = 0; i < this.worldItems.Length; i++)
			{
				this.worldItems[i] = null;
			}
		}

		public void ClearOneItem(WorldItem item)
		{
		}

		public void DropItem(int ID, byte Amount, int X, int Y, Growalone growalone)
		{
			for (int i = 0; i < 1024; i++)
			{
				if (this.worldItems[i] == null || this.worldItems[i] == new WorldItem(0, 0, -100, -100))
				{
					this.worldItems[i] = new WorldItem(ID, Amount, X, Y);
					return;
				}
			}
			growalone.ShowDialog("World item limit reached!");
		}

		public void SpawnEnemy(int ID, int X, int Y, Growalone growalone)
		{
			for (int i = 0; i < 1024; i++)
			{
				if (this.enemies[i] == null)
				{
					if (ID == 1)
					{
						this.enemies[i] = new EnemyHorse(X, Y);
					}
					return;
				}
			}
			growalone.ShowDialog("Enemy limit reached!");
		}

		public World()
		{
			this.Cracks = new byte[100, 60];
			this.Timeout = new byte[100, 60];
		}

		public void RegisterHit(int blockX, int blockY, Growalone that)
		{
		}
	}
}
