using LitJson;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.IO;
using System.Net;

namespace GrowaloneXNAEdition
{
	public class GalleryOfWorlds
	{
		public const string MainWebsite = "http://growalonegame.000webhostapp.com/gallery_of_worlds/";

		public Color clearColor = new Color(1, 1, 1, 1);

		public bool IsOnline = true;

		public Rectangle BackToTitleScreenBtn = new Rectangle(8, 8, 180, 64);

		public OnlineWorldItem[] onlineWorldItems = new OnlineWorldItem[]
		{
			new OnlineWorldItem("thumb.png", "test", "world.gaw", "iProgramMC")
		};

		public int MasterY = 0;

		public bool MouseClicked = true;

		public int EveryUIItemHeight = 0;

		private int LastRecordedScrollValue = 0;

		public World DownloadWorld(OnlineWorldItem owi)
		{
			OnlineWorldItem onlineWorldItem = new OnlineWorldItem("thumb.png", "test", "world.gaw", "iProgramMC");
			WebClient webClient = new WebClient();
			string address = "http://growalonegame.000webhostapp.com/gallery_of_worlds/" + owi.name + "/" + owi.file;
			byte[] bytes = webClient.DownloadData(address);
			File.WriteAllBytes("C:\\growalone_maps\\temp.gaw", bytes);
			World result = (World)DataHandler.LoadMap("C:\\growalone_maps\\temp.gaw");
			File.Delete("C:\\growalone_maps\\temp.gaw");
			return result;
		}

		public OnlineWorldItem[] Initialize(Growalone growalone)
		{
			OnlineWorldItem[] array = new OnlineWorldItem[1];
			WebClient webClient = new WebClient();
			JsonData jsonData;
			OnlineWorldItem[] result;
			try
			{
				string text = webClient.DownloadString("http://growalonegame.000webhostapp.com/gallery_of_worlds/worlds.json");
				Console.WriteLine(text);
				jsonData = JsonMapper.ToObject(text);
			}
			catch
			{
				this.IsOnline = false;
				result = null;
				return result;
			}
			JsonData jsonData2 = jsonData["worlds"];
			int count = jsonData2.Count;
			Array.Resize<OnlineWorldItem>(ref array, count);
			int num = 0;
			foreach (JsonData jsonData3 in ((IEnumerable)jsonData2))
			{
				OnlineWorldItem onlineWorldItem = new OnlineWorldItem(jsonData3["thumb"].ToString(), jsonData3["name"].ToString(), jsonData3["wfile"].ToString(), jsonData3["creator"].ToString());
				onlineWorldItem.UpdatePic(growalone.GraphicsDevice);
				if (num >= count)
				{
					throw new NotSupportedException();
				}
				array[num] = onlineWorldItem;
				num++;
			}
			result = array;
			return result;
		}

		public GalleryOfWorlds(Growalone growalone)
		{
			this.onlineWorldItems = this.Initialize(growalone);
			this.GetAllUIItemHeight(growalone);
		}

		public void Update(Growalone growalone)
		{
			MouseState state = Mouse.GetState();
			if (state.LeftButton == ButtonState.Released)
			{
				this.MouseClicked = false;
			}
			if (this.IsOnline)
			{
				int num = 0;
				if (!this.MouseClicked)
				{
					OnlineWorldItem[] array = this.onlineWorldItems;
					for (int i = 0; i < array.Length; i++)
					{
						OnlineWorldItem onlineWorldItem = array[i];
						Vector2 vector = growalone.defaultFont.MeasureString(onlineWorldItem.ToString());
						Rectangle rectangle = new Rectangle(10, 80 + num + this.MasterY, 780, (int)vector.Y / 4 + 4);
						if (rectangle.Contains(new Point(state.X, state.Y)) && state.LeftButton == ButtonState.Pressed)
						{
							World world = this.DownloadWorld(onlineWorldItem);
							growalone.LoadWorldInGOW(world, onlineWorldItem.name);
						}
						num += (int)vector.Y / 4 + 4 + 2;
					}
				}
				if (this.BackToTitleScreenBtn.Contains(new Point(state.X, state.Y)) && state.LeftButton == ButtonState.Pressed)
				{
					growalone.Screen = ScreenType.TitleScreen;
				}
				if (state.ScrollWheelValue > this.LastRecordedScrollValue)
				{
					this.MasterY += (state.ScrollWheelValue - this.LastRecordedScrollValue) / 25;
				}
				if (state.ScrollWheelValue < this.LastRecordedScrollValue)
				{
					this.MasterY += (state.ScrollWheelValue - this.LastRecordedScrollValue) / 25;
				}
				if (this.MasterY > 0)
				{
					this.MasterY = 0;
				}
				if (this.MasterY < -(this.EveryUIItemHeight - growalone.GraphicsDevice.Viewport.Height))
				{
					this.MasterY = -(this.EveryUIItemHeight - growalone.GraphicsDevice.Viewport.Height);
				}
			}
			else
			{
				Rectangle rectangle = new Rectangle(353, 175, 100, 20);
				if (rectangle.Contains(new Point(state.X, state.Y)) && state.LeftButton == ButtonState.Pressed)
				{
					growalone.Screen = ScreenType.TitleScreen;
				}
				this.clearColor = Color.DarkBlue;
			}
			this.LastRecordedScrollValue = state.ScrollWheelValue;
			this.clearColor = Color.FromNonPremultiplied(129, 203, 255, 255);
		}

		public void GetAllUIItemHeight(Growalone growalone)
		{
			if (this.IsOnline)
			{
				int num = this.BackToTitleScreenBtn.Y + 8 + 3;
				OnlineWorldItem[] array = this.onlineWorldItems;
				for (int i = 0; i < array.Length; i++)
				{
					OnlineWorldItem onlineWorldItem = array[i];
					Vector2 vector = growalone.defaultFont.MeasureString(onlineWorldItem.ToString());
					Rectangle rectangle = new Rectangle(10, 80 + num + this.MasterY, 780, (int)vector.Y / 4 + 4);
					num += (int)vector.Y / 4 + 4 + 2;
				}
				this.EveryUIItemHeight = num + 76;
			}
			else
			{
				this.EveryUIItemHeight = 0;
			}
		}

		public void Draw(Growalone growalone)
		{
			if (this.IsOnline)
			{
				growalone.fontEngine.DrawString("Gallery of Worlds", 3f, new Vector2(208f, (float)(10 + this.MasterY)));
				growalone.spriteBatch.Draw(growalone.BackToTitleTex, new Rectangle(this.BackToTitleScreenBtn.X, this.BackToTitleScreenBtn.Y + this.MasterY, this.BackToTitleScreenBtn.Width, this.BackToTitleScreenBtn.Height), Color.White);
				int num = 0;
				OnlineWorldItem[] array = this.onlineWorldItems;
				for (int i = 0; i < array.Length; i++)
				{
					OnlineWorldItem onlineWorldItem = array[i];
					Vector2 vector = growalone.defaultFont.MeasureString(onlineWorldItem.ToString());
					Rectangle destinationRectangle = new Rectangle(10, 80 + num + this.MasterY, 780, (int)vector.Y / 4 + 4);
					growalone.spriteBatch.Draw(growalone.flatPanel, destinationRectangle, Color.Blue);
					if (onlineWorldItem.thumbTex != null)
					{
						growalone.spriteBatch.Draw(onlineWorldItem.thumbTex, new Rectangle(14, 84 + num + this.MasterY, 62, 62), Color.White);
					}
					growalone.spriteBatch.DrawString(growalone.defaultFont, onlineWorldItem.ToString(), new Vector2(10f, (float)(80 + num + this.MasterY)), Color.White, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
					num += (int)vector.Y / 4 + 4 + 2;
				}
			}
			else
			{
				growalone.fontEngine.DrawString("Gallery of Worlds", 3f, new Vector2(208f, (float)(10 + this.MasterY)));
				growalone.spriteBatch.Draw(growalone.flatPanel, new Rectangle(246, 116, 340, 100), Color.FromNonPremultiplied(0, 0, 50, 255));
				growalone.spriteBatch.Draw(growalone.flatPanel, new Rectangle(238, 108, 340, 100), Color.Blue);
				growalone.spriteBatch.Draw(growalone.flatPanel, new Rectangle(353, 175, 100, 20), Color.DarkBlue);
				growalone.spriteBatch.DrawString(growalone.defaultFont, "Sorry but the Gallery of Worlds service is offline.\nPlease wait a few hours. If the service is still offline, \nplease email growalonegame@gmail.com.\n\n                                       Okay", new Vector2(240f, 110f), Color.White, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
			}
		}
	}
}
