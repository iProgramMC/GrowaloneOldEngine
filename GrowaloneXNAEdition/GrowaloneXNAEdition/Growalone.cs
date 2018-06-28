using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	public class Growalone : Game
	{
		public enum MapRequestType
		{
			Load,
			Save,
			LoadOld
		}

		public const int HealthPrecision = 256;

		public const int HealthMin = 255;

		public const int HealthMax = 2176;

		public const int MaxAboutScreenPosition = 10;

		public const int DragSpeed = 10;

		public GalleryOfWorlds gow;

		public Texture2D seedTexture;

		public int seedWidth = 15;

		public int seedHeight = 14;

		public int colorIndex1 = 554;

		public int colorIndex2 = 928;

		public int Health = 2176;

		public int HEALTH_INC = 0;

		public int HEALTH_DEC = 0;

		public Microsoft.Xna.Framework.Rectangle HealthBarMainSrcRect = new Microsoft.Xna.Framework.Rectangle(0, 0, 200, 49);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP1SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 49, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP2SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 74, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP3SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 99, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP4SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 124, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP5SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 149, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP6SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 174, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP7SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 199, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarHP8SrcRect = new Microsoft.Xna.Framework.Rectangle(0, 224, 200, 25);

		public Microsoft.Xna.Framework.Rectangle HealthBarDrawDestRect = new Microsoft.Xna.Framework.Rectangle(400, 0, 200, 25);

		public Texture2D HealthMeterTex;

		public int tickWhenWasHurt;

		public int hitstunDuration = 180;

		public bool IsStunning = false;

		public bool IsCrouching = false;

		public string StarCollected;

		public int StarDanceCharacterY;

		public int ActualCameraX;

		public FontEngine fontEngine;

		public StarSprite starSprite;

		public CharacterSprite charSprite;

		public BasicShapes basicShapeEngine;

		public int tickWhenWasKilled;

		public int respawnDuration = 360;

		public bool isDead = false;

		public Enemy enemyThatThePlayerRides;

		public bool doesRideAnEnemy;

		public string worldSelectText = "Type in a world name then press 'Enter World'!";

		public int AboutScreenPosition = 10;

		public int timeout;

		public int GamerNPCTimeout = 1800;

		public int SpawnPointX;

		public int SpawnPointY;

		public Texture2D GazetteBadge;

		public Texture2D startGameBtnTex;

		public Texture2D exitGameBtnTex;

		public Texture2D optionsBtnTex;

		public Texture2D aboutBtnTex;

		public Texture2D canPlaceTile;

		public Texture2D iProgramMC_Logo;

		public Texture2D GrowaloneLogo;

		public Texture2D checkmark;

		public Texture2D Checkbox;

		public Texture2D handle;

		public Texture2D slot;

		public Texture2D selectedItemFrame;

		public Texture2D panel;

		public Texture2D theFlag;

		public Texture2D FistOFury;

		public Texture2D devPage0T;

		public Texture2D devPage1T;

		public Texture2D[] Skies = new Texture2D[3];

		public Texture2D UIBackground;

		public Texture2D punchTexture;

		public Texture2D textBoxTex;

		public Texture2D enterWorldTex;

		public Texture2D GOW_ButtonTex;

		public Texture2D BackToTitleTex;

		public Texture2D[,] tileTextures = new Texture2D[200, 16];

		public Texture2D[,] tilePreviewTextures = new Texture2D[200, 16];

		public Texture2D[] crackTextures = new Texture2D[5];

		public Texture2D[] shopItemSprites = new Texture2D[20];

		public Texture2D[] LockedTile = new Texture2D[16];

		public Texture2D charTexture;

		public Texture2D[] invButtonTextures = new Texture2D[4];

		public Texture2D coinTex;

		public Texture2D mnt1;

		public Texture2D mnt2;

		public Texture2D mnt3;

		public Texture2D sun;

		public Texture2D cloud;

		public Texture2D Moon;

		public Texture2D HorseTexture;

		public string msgBoxMessage;

		public bool msgBoxShown;

		public string msgBoxTitle;

		public int msgBoxIconID;

		public MessageBoxAction msgBoxAction;

		public string inputBoxMessage;

		public bool inputBoxShown;

		public string inputBoxTitle;

		public int inputBoxIconID;

		public string inputBoxResponse;

		public InputBoxAction inputBoxAction;

		public int globalTimer = 0;

		public bool DontEditBackgrounds;

		public float fontSize = 0.25f;

		public float worldDrawScale = 1f;

		public bool isDeveloper = false;

		public bool OptionsShowGfxClicked;

		public int LavaY = 1920;

		public bool fpsShown;

		public int FPS;

		public int calcFPS;

		public World.WorldButton[] worldBtns = new World.WorldButton[20];

		public int Mnt1X = 0;

		public int Mnt2X = 0;

		public int Mnt3X = 0;

		public float rotationOfLogo;

		public float scaleOfLogo;

		public bool directionOfLogoRot;

		public bool directionOfLogoGrow;

		public static string versionID = "v0.5.0";

		public static string CopyrightText = "Copyright (c) iProgramMC 2018. In beta.";

		public Localizer localizer;

		public Vector2 center = new Vector2(400f, 240f);

		public Vector2 mousecur;

		private Vector2 posOnTheWayToCursor;

		public bool isPunching = false;

		public string TheWorldName;

		public short CursorID;

		public Texture2D[] cursors = new Texture2D[5];

		public DateTime currentTime = DateTime.Now;

		public int MaximumPixelsJumped = 128;

		public int MaxDurability = 30;

		public int tSec;

		public string[] splashes = new string[]
		{
			"Loading \"splashs.txt\""
		};

		public int splashSel;

		public bool isRunning = true;

		public Microsoft.Xna.Framework.Rectangle infoRectangle = new Microsoft.Xna.Framework.Rectangle(100, 40, 600, 400);

		public bool gazetteDlgShown;

		public Microsoft.Xna.Framework.Rectangle startBtnRect = new Microsoft.Xna.Framework.Rectangle(310, 250, 180, 64);

		public Microsoft.Xna.Framework.Rectangle exitBtnRect = new Microsoft.Xna.Framework.Rectangle(310, 314, 180, 64);

		public Microsoft.Xna.Framework.Rectangle optionsBtnRect = new Microsoft.Xna.Framework.Rectangle(310, 378, 180, 64);

		public Microsoft.Xna.Framework.Rectangle aboutBtnRect = new Microsoft.Xna.Framework.Rectangle(310, 378, 180, 64);

		public Microsoft.Xna.Framework.Rectangle goInGameRect = new Microsoft.Xna.Framework.Rectangle(30, 69, 180, 64);

		public Microsoft.Xna.Framework.Rectangle gowBtnRect = new Microsoft.Xna.Framework.Rectangle(310, 378, 180, 64);

		public Microsoft.Xna.Framework.Rectangle BackToTitleRect = new Microsoft.Xna.Framework.Rectangle(30, 69, 180, 64);

		public Microsoft.Xna.Framework.Rectangle textBoxRect = new Microsoft.Xna.Framework.Rectangle(30, 30, 200, 30);

		public Microsoft.Xna.Framework.Rectangle FullScreenButtonRect = new Microsoft.Xna.Framework.Rectangle(10, 100, 24, 24);

		public Microsoft.Xna.Framework.Rectangle ShowFancyGfxButtonRect = new Microsoft.Xna.Framework.Rectangle(10, 150, 24, 24);

		public Microsoft.Xna.Framework.Rectangle devPage0R = new Microsoft.Xna.Framework.Rectangle(700, 40, 90, 32);

		public Microsoft.Xna.Framework.Rectangle devPage1R = new Microsoft.Xna.Framework.Rectangle(700, 80, 90, 32);

		public Microsoft.Xna.Framework.Rectangle GrowaloneLogoRect = new Microsoft.Xna.Framework.Rectangle(16, 20, 768, 256);

		private int blockX;

		private int blockY;

		public ScreenType Screen;

		public SpriteFont defaultFont;

		public SpriteFont defaultFont2;

		public bool typingOnLogin;

		public string nameInTextBox = "";

		public bool keyPressedOnWN;

		public bool keyPressedOnIB;

		public bool keyPressedF11;

		public bool keyPressedEnCr;

		public bool keyPressedScSh;

		public GraphicsDeviceManager graphics;

		public SpriteBatch spriteBatch;

		public World world;

		public Item[] Inventory = new Item[20];

		public Item[] oldInventory;

		public int FramesPerSecond;

		public int frameCounter;

		public float elapseTime;

		public int guyX;

		public int guyY;

		public int motionX;

		public int motionY;

		public int cameraX;

		public int cameraY;

		public int speed;

		public byte[] collided = new byte[200];

		public bool[] wrenchable = new bool[100];

		public int selectedItem;

		public int handleY;

		public bool handleMove;

		public bool keyDownChangeInv;

		public bool keyDownEsc;

		public bool KeyDown;

		public bool MouseDownCauseEnterDoor;

		public Microsoft.Xna.Framework.Rectangle[,] slotRectangles = new Microsoft.Xna.Framework.Rectangle[10, 8];

		public Microsoft.Xna.Framework.Rectangle[] craftRectangles = new Microsoft.Xna.Framework.Rectangle[20];

		public bool jumps;

		public int blocksJumped;

		public bool WorldLocked;

		public bool facesLeft;

		public bool mountsEnabled = true;

		public bool DebugInfo;

		public bool warningShown;

		public string warningText;

		public string gamerName;

		public string dialogBoxMessage;

		public bool dialogBoxShown;

		public int dialogBoxTimeout;

		public Microsoft.Xna.Framework.Color dialogBoxColor;

		public string dialogBoxMessage2;

		public bool dialogBoxShown2;

		public int dialogBoxTimeout2;

		public int[] validMonthsForWinter = new int[]
		{
			12,
			1,
			2
		};

		public PlayerData playerData = new PlayerData();

		public SoundEffect BreakEffect;

		public SoundEffect BuyItemEffect;

		public SoundEffect ClickEffect;

		public SoundEffect JumpEffect;

		public SoundEffect PickupEffect;

		public SoundEffect WalkEffect;

		public SoundEffect ExplosionEffect;

		public SoundEffectInstance WalkEffectInstance;

		public Microsoft.Xna.Framework.Point VirtualCursorPosition = new Microsoft.Xna.Framework.Point(640, 360);

		public Texture2D flatPanel;

		private int e;

		private int g;

		private int e321;

		private int j321;

		private bool JumpEffPlay;

		private int CursorPointY;

		private bool hasStartedDragging;

		public Texture2D spaceBackground;

		private GamePadState prevGPState = default(GamePadState);

		public void DrawUI()
		{
			if ((int)Math.Floor((double)(this.Health / 256)) != 8)
			{
				this.spriteBatch.Draw(this.HealthMeterTex, this.HealthBarDrawDestRect, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarMainSrcRect), Microsoft.Xna.Framework.Color.White);
			}
			Microsoft.Xna.Framework.Rectangle destinationRectangle = new Microsoft.Xna.Framework.Rectangle(this.HealthBarDrawDestRect.X, this.HealthBarDrawDestRect.Y + 24, 200, 25);
			switch ((int)Math.Floor((double)(this.Health / 256)))
			{
			case 1:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP1SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			case 2:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP2SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			case 3:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP3SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			case 4:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP4SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			case 5:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP5SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			case 6:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP6SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			case 7:
				this.spriteBatch.Draw(this.HealthMeterTex, destinationRectangle, new Microsoft.Xna.Framework.Rectangle?(this.HealthBarHP7SrcRect), Microsoft.Xna.Framework.Color.White);
				break;
			}
		}

		public void GetKeyPressOnPlayGround()
		{
			KeyboardState state = Keyboard.GetState();
			this.charSprite.Update();
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.NumPad1))
			{
				this.world.weatherMachine = WeatherMachine.Sunny;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.NumPad2))
			{
				this.world.weatherMachine = WeatherMachine.Night;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.NumPad3))
			{
				this.world.weatherMachine = WeatherMachine.Space;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.F6))
			{
				this.world.ClearAllItems();
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.F12))
			{
				this.ShowInputBox(new ExecuteCommandAction(this), "Enter a command to execute.", ">_", "OK");
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.G))
			{
				if (ItemData.IsRemovable(this.Inventory[this.selectedItem].ID))
				{
					string s = InputBoxGrowalone.ShowInputBox("How many to drop?", "Drop " + ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID), this);
					int num;
					if (int.TryParse(s, out num))
					{
						if (num > 0 && num <= this.Inventory[this.selectedItem].Amount)
						{
							if (!this.facesLeft)
							{
								this.world.DropItem(this.Inventory[this.selectedItem].ID, (byte)num, this.guyX + 40, this.guyY - 24, this);
							}
							else
							{
								this.world.DropItem(this.Inventory[this.selectedItem].ID, (byte)num, this.guyX - 40, this.guyY - 24, this);
							}
							this.DrainItem(this.selectedItem, num);
						}
						else if (num < this.Inventory[this.selectedItem].Amount && num < 1)
						{
							this.ShowDialog("number.isNegative() returned TRUE. Does not compute.", 200);
						}
						else
						{
							this.ShowDialog("I can't drop more than I have.", 200);
						}
					}
					else
					{
						this.ShowDialog("Type in a NUMBER of items to drop. Not a sentence.", 200);
					}
				}
				else
				{
					this.ShowDialog2("This item cannot be dropped!");
				}
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.W) || state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Space))
			{
				if (!this.isDead)
				{
					this.Jump();
					if (!this.JumpEffPlay)
					{
						this.JumpEffect.Play();
						this.JumpEffPlay = true;
					}
					if (this.charSprite.mode == CharacterAnimatedSpriteMode.Walking || this.charSprite.mode == CharacterAnimatedSpriteMode.Still)
					{
						this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Jumping);
					}
				}
			}
			else
			{
				this.Fall();
				this.JumpEffPlay = false;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.L))
			{
				this.ManageMap(Growalone.MapRequestType.Load);
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.K))
			{
				this.ManageMap(Growalone.MapRequestType.Save);
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.R))
			{
				if (!this.isDead)
				{
					this.Health = 255;
				}
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Scroll))
			{
				this.InitializeDevInventory(1);
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.X))
			{
				string text = InputBoxGrowalone.ShowInputBox("What would you like to say?", "Say Something", this);
				if (text != "")
				{
					this.ShowDialog(text, 200);
				}
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.I))
			{
				this.ShowMsgBox(new DefaultMsgAction(), ItemData.ReturnItemInfo(this.Inventory[this.selectedItem].ID), "About " + ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID));
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.H))
			{
				this.playerData.WingCloth = 0;
				this.playerData.PetsCloth = 0;
				this.MaximumPixelsJumped = 128;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Pause))
			{
				string a = InputBoxGrowalone.ShowInputBox("verification required to prevent fraudulent access, click 'ok' to analyze, all caps", "COHERENCE INVIOLATE. REDIRECT CARTOGRAPHY. SECURE DIRECTIVE", this);
				if (a == string.Concat(new object[]
				{
					'K',
					'I',
					'L',
					'I',
					'M',
					'A'
				}))
				{
					MessageBox.Show("ANALYSIS COMPLETE.\r\n. . . . .\r\n\r\nDATA FILE ACCESSED: file.txt (content:\r\n\r\n'\r\nyou have just been given six amazing items in amounts of 999. by breaking them you get others. as a bonus. it's dangerous to go alone so take these with you. - iProgramInCpp\r\n'\r\n\r\n. . . . . .\r\n\r\nFURTHER PROCESSING REQUIRED.", "COHERENCE INVIOLATE. REDIRECT CARTOGRAPHY. SECURE DIRECTIVE");
					this.AddItem(32, 999);
					this.AddItem(33, 999);
					this.AddItem(34, 999);
					this.AddItem(35, 999);
					this.AddItem(36, 999);
					this.AddItem(37, 999);
				}
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.T))
			{
				if (ItemData.IsRemovable(this.Inventory[this.selectedItem].ID))
				{
					this.ShowMsgBox(new TrashItemAction(this.Inventory, this.selectedItem), string.Concat(new object[]
					{
						"Are you sure you want to trash ",
						this.Inventory[this.selectedItem].Amount,
						" ",
						ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID),
						"? You will not be able to get them back ever again!"
					}), "Trash " + ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID));
				}
				else
				{
					this.ShowDialog2("This item cannot be trashed!");
				}
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Escape))
			{
				if (this.inputBoxShown && !this.keyDownEsc)
				{
					this.inputBoxShown = false;
					this.keyDownEsc = true;
				}
				if (this.gazetteDlgShown && !this.keyDownEsc)
				{
					this.gazetteDlgShown = false;
					this.keyDownEsc = true;
				}
				else if (!this.keyDownEsc && this.Screen != ScreenType.TitleScreen)
				{
					this.Screen = ScreenType.TitleScreen;
					this.keyDownEsc = true;
					DataHandler.SaveMap(this.world, "C:\\growalone_maps\\worlds\\" + this.TheWorldName + ".gaw");
				}
				else if (!this.keyDownEsc)
				{
					Application.Exit();
				}
				this.splashSel = new Random().Next(0, this.splashes.Length);
			}
			else
			{
				this.keyDownEsc = false;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.A))
			{
				if (!this.isDead)
				{
					try
					{
						if (this.charSprite.mode != CharacterAnimatedSpriteMode.Jumping && this.charSprite.mode != CharacterAnimatedSpriteMode.Falling && this.charSprite.mode != CharacterAnimatedSpriteMode.Walking)
						{
							this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Walking);
						}
						int num2 = (int)Math.Floor((double)this.e / 32.0);
						int num3 = (int)Math.Floor((double)this.g / 32.0);
						num3--;
						if (this.world.Map[this.e321, this.j321, 0].ID == 86)
						{
							this.cameraX -= 3;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 0 || this.collided[this.world.Map[num2, num3, 0].ID] == 2)
						{
							this.cameraX -= 5;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 3)
						{
							if (!this.isDead)
							{
								this.tickWhenWasKilled = this.globalTimer;
								this.isDead = true;
							}
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 4)
						{
							if (!this.IsStunning)
							{
								this.tickWhenWasHurt = this.globalTimer;
								this.HEALTH_DEC = 12;
								this.IsStunning = true;
							}
						}
						this.facesLeft = true;
					}
					catch (Exception ex)
					{
						string message = ex.Message;
					}
					this.WalkEffectInstance.Play();
				}
			}
			else if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.D))
			{
				if (!this.isDead)
				{
					try
					{
						if (this.charSprite.mode != CharacterAnimatedSpriteMode.Jumping && this.charSprite.mode != CharacterAnimatedSpriteMode.Falling && this.charSprite.mode != CharacterAnimatedSpriteMode.Walking)
						{
							this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Walking);
						}
						int num2 = (int)Math.Floor((double)this.e / 32.0);
						int num3 = (int)Math.Floor((double)this.g / 32.0);
						num2++;
						num3--;
						if (this.world.Map[this.e321, this.j321, 0].ID == 86)
						{
							this.cameraX += 3;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 0 || this.collided[this.world.Map[num2, num3, 0].ID] == 2)
						{
							this.cameraX += 5;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 3)
						{
							this.tickWhenWasKilled = this.globalTimer;
							this.isDead = true;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 4)
						{
							if (!this.IsStunning)
							{
								this.tickWhenWasHurt = this.globalTimer;
								this.HEALTH_DEC = 12;
								this.IsStunning = true;
							}
						}
						this.facesLeft = false;
					}
					catch (Exception ex)
					{
						string message = ex.Message;
					}
					this.WalkEffectInstance.Play();
				}
			}
			else
			{
				this.speed = 1;
				this.keyDownChangeInv = false;
				this.jumps = false;
				this.WalkEffectInstance.Stop();
				if (this.charSprite.mode == CharacterAnimatedSpriteMode.Walking && this.charSprite.mode != CharacterAnimatedSpriteMode.Still)
				{
					this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Still);
				}
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.C))
			{
				if (!this.keyPressedEnCr)
				{
					this.keyPressedEnCr = true;
					if (this.Screen != ScreenType.ShopScreen)
					{
						this.Screen = ScreenType.ShopScreen;
					}
					else
					{
						this.Screen = ScreenType.Playground;
					}
				}
			}
			else
			{
				this.keyPressedEnCr = false;
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.P))
			{
				Vector2 vector = new Vector2((float)(base.GraphicsDevice.Viewport.Width / 2), (float)(base.GraphicsDevice.Viewport.Height / 2));
				Vector2 vector2 = vector;
				if (this.facesLeft)
				{
					vector2 = new Vector2(vector.X - 32f, vector.Y);
				}
				else
				{
					vector2 = new Vector2(vector.X + 32f, vector.Y);
				}
				this.PlaceBlock(new MouseState((int)vector2.X, (int)vector2.Y, 0, Microsoft.Xna.Framework.Input.ButtonState.Pressed, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released));
			}
			if (state.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.S))
			{
				this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Crouching);
			}
		}

		public void TakeCheckpoint()
		{
			this.SpawnPointX = this.guyX;
			this.SpawnPointY = this.guyY;
		}

		public void InitializeWorldButtons()
		{
			string[] files = Directory.GetFiles("C:\\growalone_maps\\worlds\\");
			int num = files.Length;
			int num2 = 30;
			int num3 = 0;
			int num4 = num;
			this.worldBtns = new World.WorldButton[num4];
			for (int i = 0; i < num4; i++)
			{
				files[i] = files[i].Replace(".gaw", "");
				files[i] = files[i].Replace("C:\\growalone_maps\\worlds\\", "");
				Vector2 vector = this.defaultFont2.MeasureString(files[i]);
				if ((float)num2 >= 800f - vector.X)
				{
					num2 = 30;
					num3 += (int)vector.Y + 12;
				}
				this.worldBtns[i] = new World.WorldButton(this, files[i], new Microsoft.Xna.Framework.Rectangle(num2, 69 + num3, (int)vector.X + 6, (int)vector.Y + 6));
				num2 += (int)vector.X + 12;
			}
		}

		public Growalone()
		{
			this.graphics = new GraphicsDeviceManager(this);
			base.Content.RootDirectory = "Content";
		}

		public void UpgradeBackpack()
		{
			this.playerData.BackPackSlotsUpgraded++;
			this.oldInventory = this.Inventory;
			this.Inventory = new Item[this.playerData.BackPackSlotsUpgraded * 10];
			for (int i = 0; i < this.Inventory.Length; i++)
			{
				this.Inventory[i] = new Item();
			}
			for (int i = 0; i < this.oldInventory.Length; i++)
			{
				this.Inventory[i] = this.oldInventory[i];
			}
		}

		public void InitializeDevInventory(int DeveloperItemPage)
		{
			if (this.isDeveloper)
			{
				for (int i = 2; i < this.Inventory.Length; i++)
				{
					this.Inventory[i] = new Item();
				}
				if (DeveloperItemPage == 0)
				{
					for (int j = 2; j < 82; j++)
					{
						this.AddItem(j, 200);
					}
				}
				else if (DeveloperItemPage == 1)
				{
					for (int j = 82; j < 152; j++)
					{
						if ((j != 90 && j != 91) || this.isDeveloper)
						{
							this.AddItem(j, 200);
						}
					}
				}
				this.playerData.Gems = 1000000000;
			}
		}

		public void teleportToMainDoor()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].ID == 10)
					{
						num = i;
						num2 = j;
						break;
					}
				}
			}
			num *= 32;
			num2 *= 32;
			num2 += 32;
			this.SpawnPointX = num;
			this.SpawnPointY = num2;
			num -= 384;
			num2 -= 256;
			this.cameraX = num;
			this.cameraY = num2;
		}

		public void teleportToBlockWithID(int id)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].ID == id)
					{
						num = i;
						num2 = j;
						break;
					}
				}
			}
			num *= 32;
			num2 *= 32;
			num -= 384;
			num2 -= 256;
			this.cameraX = num;
			this.cameraY = num2 + 31;
		}

		public void InitialiseMap()
		{
			for (int i = 0; i < this.world.worldItems.Length; i++)
			{
				this.world.worldItems[i] = null;
			}
			for (int j = 0; j < 100; j++)
			{
				for (int k = 0; k < 60; k++)
				{
					this.world.Map[j, k, 0] = new Block();
					this.world.Map[j, k, 1] = new Block();
					this.world.Cracks[j, k] = 0;
					this.world.Locked[j, k] = 0;
				}
			}
			for (int j = 0; j < 100; j++)
			{
				for (int k = 26; k < 57; k++)
				{
					this.world.Map[j, k, 0].ID = 2;
					this.world.Map[j, k, 1] = new Block(6);
				}
				Thread.Sleep(5);
				this.world.Map[j, 26, 0].ID = 2;
				this.world.Map[j, 57, 0].ID = 8;
				this.world.Map[j, 58, 0].ID = 8;
				this.world.Map[j, 59, 0].ID = 8;
				this.world.Map[j, 26, 1] = new Block(6);
				this.world.Map[j, 57, 1] = new Block(6);
				this.world.Map[j, 58, 1] = new Block(6);
				this.world.Map[j, 59, 1] = new Block(6);
			}
			Random random = new Random();
			int num = random.Next(0, 100);
			this.world.Map[num, 25, 0].ID = 10;
			this.world.Map[num, 26, 0].ID = 8;
			this.world.Cracks = new byte[100, 60];
			this.world.Timeout = new byte[100, 60];
			this.teleportToMainDoor();
		}

		protected override void Initialize()
		{
			this.Screen = ScreenType.TitleScreen;
			base.GraphicsDevice.Viewport = new Viewport(0, 0, 800, 480);
			this.refreshSlotRects();
			this.starSprite = new StarSprite(this);
			this.gazetteDlgShown = true;
			try
			{
				this.splashes = File.ReadAllLines(base.Content.RootDirectory + "\\splashes.txt");
			}
			catch
			{
				this.splashes = new string[]
				{
					"Missing file. Please create \"splashes.txt\" in the \"Content\" folder."
				};
			}
			this.localizer = new Localizer("us", base.Content.RootDirectory);
			this.world = new World();
			this.scaleOfLogo = 1f;
			this.posOnTheWayToCursor = this.center;
			this.splashSel = new Random().Next(0, this.splashes.Length);
			this.Inventory[0] = new Item(0, 255);
			this.Inventory[1] = new Item(30, 255);
			if (DateTime.Now.Hour == 3)
			{
				this.ShowMsgBox(new DefaultMsgAction(), "Seriously.", "Don't be afraid, nothing will happen!");
			}
			this.flatPanel = new Texture2D(this.graphics.GraphicsDevice, 80, 30);
			this.goInGameRect = new Microsoft.Xna.Framework.Rectangle(0, 0, 0, 0);
			base.Window.Title = "Growalone: The Game";
			base.Window.AllowUserResizing = false;
			this.graphics.ApplyChanges();
			this.InitialiseMap();
			this.collided[2] = 1;
			this.collided[4] = 1;
			this.collided[6] = 1;
			this.collided[8] = 1;
			this.collided[12] = 1;
			this.collided[24] = 1;
			this.collided[26] = 1;
			this.collided[28] = 1;
			this.collided[30] = 1;
			this.collided[38] = 1;
			this.collided[130] = 1;
			this.collided[132] = 1;
			this.collided[134] = 1;
			this.collided[48] = 3;
			this.collided[44] = 3;
			this.collided[72] = 1;
			this.collided[16] = 2;
			this.collided[78] = 1;
			this.collided[80] = 1;
			this.collided[82] = 1;
			this.collided[84] = 1;
			this.collided[86] = 0;
			this.collided[140] = 1;
			this.collided[48] = 4;
			this.wrenchable[46] = true;
			this.wrenchable[70] = true;
			this.wrenchable[76] = true;
			this.refreshSlotRects();
			this.handleY = base.GraphicsDevice.Viewport.Height - 23;
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].ID == 16)
					{
						this.WorldLocked = true;
					}
				}
			}
			for (int i = 0; i < 20; i++)
			{
				this.Inventory[i] = new Item(0, 0);
			}
			if (!Directory.Exists("C:\\growalone_maps\\worlds"))
			{
				Directory.CreateDirectory("C:\\growalone_maps\\worlds");
			}
			try
			{
				this.Inventory = (Item[])DataHandler.LoadMap("C:\\growalone_maps\\inventory.gai");
				this.playerData = (PlayerData)DataHandler.LoadMap("C:\\growalone_maps\\playerdata.gai");
				if (!Directory.Exists("C:\\growalone_maps\\worlds"))
				{
					Directory.CreateDirectory("C:\\growalone_maps\\worlds");
				}
			}
			catch
			{
				if (!Directory.Exists("C:\\growalone_maps"))
				{
					Directory.CreateDirectory("C:\\growalone_maps");
					this.playerData.PlayerName = "";
					this.playerData.BackPackSlotsUpgraded = 2;
					DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
					DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
					this.playerData.firstStarted = true;
				}
				else
				{
					this.Inventory[2] = new Item(31, 1);
					this.playerData.PlayerName = "";
					this.playerData.BackPackSlotsUpgraded = 2;
					DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
					DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
					this.playerData.firstStarted = true;
				}
			}
			Microsoft.Xna.Framework.Color[] array = new Microsoft.Xna.Framework.Color[2400];
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = Microsoft.Xna.Framework.Color.White;
			}
			this.flatPanel.SetData<Microsoft.Xna.Framework.Color>(array);
			base.Initialize();
			if (this.playerData.WingCloth == 88)
			{
				this.MaximumPixelsJumped = 256;
			}
			else if (this.playerData.WingCloth == 90)
			{
				this.MaximumPixelsJumped = 1024;
			}
			Console.WriteLine("[" + DateTime.Now.ToShortTimeString() + "] Welcome to Growalone, " + this.playerData.PlayerName);
		}

		private void LoadCursors()
		{
			this.cursors[0] = base.Content.Load<Texture2D>("Cursors\\Main Cursor");
			this.cursors[1] = base.Content.Load<Texture2D>("Cursors\\Breaking Cursor");
			this.cursors[2] = base.Content.Load<Texture2D>("Cursors\\Building Cursor");
			this.cursors[3] = base.Content.Load<Texture2D>("Cursors\\Planting Cursor");
			this.cursors[4] = base.Content.Load<Texture2D>("Cursors\\Wrenching Cursor");
		}

		private void LoadSeeds()
		{
			this.seedTexture = base.Content.Load<Texture2D>("Seeds\\Seed");
		}

		private void LoadPreviewSeeds()
		{
			this.tilePreviewTextures[1, 0] = base.Content.Load<Texture2D>("Seeds\\Seed Template");
			this.tilePreviewTextures[3, 0] = base.Content.Load<Texture2D>("Seeds\\Dirt Seed");
			this.tilePreviewTextures[5, 0] = base.Content.Load<Texture2D>("Seeds\\Granite Seed");
			this.tilePreviewTextures[7, 0] = base.Content.Load<Texture2D>("Seeds\\Grassy Dirt Seed");
			this.tilePreviewTextures[9, 0] = base.Content.Load<Texture2D>("Seeds\\Bedrock Seed");
			this.tilePreviewTextures[11, 0] = base.Content.Load<Texture2D>("Seeds\\Main Door Seed");
			this.tilePreviewTextures[13, 0] = base.Content.Load<Texture2D>("Seeds\\Wooden Planks Seed");
			this.tilePreviewTextures[15, 0] = base.Content.Load<Texture2D>("Seeds\\Rose Seed");
			this.tilePreviewTextures[17, 0] = base.Content.Load<Texture2D>("Seeds\\Wooden Platform Seed");
			this.tilePreviewTextures[19, 0] = base.Content.Load<Texture2D>("Seeds\\Chest Seed");
			this.tilePreviewTextures[21, 0] = base.Content.Load<Texture2D>("Seeds\\Grass Seed");
			this.tilePreviewTextures[23, 0] = base.Content.Load<Texture2D>("Seeds\\Door Seed");
			this.tilePreviewTextures[25, 0] = base.Content.Load<Texture2D>("Seeds\\Iron Block Seed");
			this.tilePreviewTextures[27, 0] = base.Content.Load<Texture2D>("Seeds\\Small Lock Seed");
			this.tilePreviewTextures[29, 0] = base.Content.Load<Texture2D>("Seeds\\Medium Lock Seed");
			this.tilePreviewTextures[25, 1] = base.Content.Load<Texture2D>("Seeds\\Small Lock Seed");
			this.tilePreviewTextures[27, 1] = base.Content.Load<Texture2D>("Seeds\\Medium Lock Seed");
			this.tilePreviewTextures[31, 1] = base.Content.Load<Texture2D>("Seeds\\Large Lock Seed");
			this.tilePreviewTextures[31, 0] = base.Content.Load<Texture2D>("Seeds\\Large Lock Seed");
			this.tilePreviewTextures[39, 0] = base.Content.Load<Texture2D>("Seeds\\World Lock Seed");
			this.tilePreviewTextures[41, 0] = base.Content.Load<Texture2D>("Seeds\\Wooden Chair Seed");
			this.tilePreviewTextures[43, 0] = base.Content.Load<Texture2D>("Seeds\\Wooden Table Seed");
			this.tilePreviewTextures[45, 0] = base.Content.Load<Texture2D>("Seeds\\Death Spike Seed");
			this.tilePreviewTextures[47, 0] = base.Content.Load<Texture2D>("Seeds\\Sign Seed");
			this.tilePreviewTextures[49, 0] = base.Content.Load<Texture2D>("Seeds\\Lava Seed");
			this.tilePreviewTextures[51, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[53, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[55, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[57, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[59, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[61, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[63, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[65, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[67, 0] = base.Content.Load<Texture2D>("Seeds\\Wrench Seed");
			this.tilePreviewTextures[69, 0] = base.Content.Load<Texture2D>("Seeds\\MysticMaxi's Kitten Mask Seed");
			this.tilePreviewTextures[71, 0] = base.Content.Load<Texture2D>("Seeds\\Teleporter Door Seed");
			this.tilePreviewTextures[73, 0] = base.Content.Load<Texture2D>("Seeds\\Bricks Seed");
			this.tilePreviewTextures[75, 0] = base.Content.Load<Texture2D>("Seeds\\Seed Template");
			this.tilePreviewTextures[77, 0] = base.Content.Load<Texture2D>("Seeds\\Gamer NPC Seed");
			this.tilePreviewTextures[79, 0] = base.Content.Load<Texture2D>("Seeds\\Wooden Planks Seed");
			this.tilePreviewTextures[81, 0] = base.Content.Load<Texture2D>("Seeds\\Golden Block Seed");
			this.tilePreviewTextures[83, 0] = base.Content.Load<Texture2D>("Seeds\\Crystal Block Seed");
			this.tilePreviewTextures[85, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[87, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[89, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[91, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[93, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[95, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[97, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[99, 0] = base.Content.Load<Texture2D>("Seeds\\Holographic Sign Seed");
			this.tilePreviewTextures[101, 0] = base.Content.Load<Texture2D>("Seeds\\Sapling Seed");
			this.tilePreviewTextures[103, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[105, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[107, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[109, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[111, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[113, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[115, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[117, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[119, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[121, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[123, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[125, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[127, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[129, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[131, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[133, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[135, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[137, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
			this.tilePreviewTextures[139, 0] = base.Content.Load<Texture2D>("Seeds\\Cloth Seed");
		}

		private void LoadPreviewTiles()
		{
			this.tilePreviewTextures[0, 0] = base.Content.Load<Texture2D>("Tiles\\Air");
			this.tilePreviewTextures[2, 0] = base.Content.Load<Texture2D>("Tile Previews\\Dirt");
			this.tilePreviewTextures[4, 0] = base.Content.Load<Texture2D>("Tile Previews\\Granite");
			this.tilePreviewTextures[6, 0] = base.Content.Load<Texture2D>("Tile Previews\\Cave Wall");
			this.tilePreviewTextures[8, 0] = base.Content.Load<Texture2D>("Tile Previews\\Bedrock");
			this.tilePreviewTextures[10, 0] = base.Content.Load<Texture2D>("Tile Previews\\White Door");
			this.tilePreviewTextures[12, 0] = base.Content.Load<Texture2D>("Tile Previews\\Wooden Planks");
			this.tilePreviewTextures[14, 0] = base.Content.Load<Texture2D>("Tile Previews\\Rose");
			this.tilePreviewTextures[16, 0] = base.Content.Load<Texture2D>("Tile Previews\\Wooden Platform");
			this.tilePreviewTextures[18, 0] = base.Content.Load<Texture2D>("Tile Previews\\Chest");
			this.tilePreviewTextures[20, 0] = base.Content.Load<Texture2D>("Tile Previews\\Grass");
			this.tilePreviewTextures[22, 0] = base.Content.Load<Texture2D>("Tile Previews\\Door");
			this.tilePreviewTextures[24, 0] = base.Content.Load<Texture2D>("Tile Previews\\Iron Block");
			this.tilePreviewTextures[26, 0] = base.Content.Load<Texture2D>("Tile Previews\\Small Lock");
			this.tilePreviewTextures[28, 0] = base.Content.Load<Texture2D>("Tile Previews\\Medium Lock");
			this.tilePreviewTextures[30, 0] = base.Content.Load<Texture2D>("Tile Previews\\Large Lock");
			this.tilePreviewTextures[26, 1] = base.Content.Load<Texture2D>("Tiles\\Small Lock UnLocked");
			this.tilePreviewTextures[28, 1] = base.Content.Load<Texture2D>("Tiles\\Medium Lock UnLocked");
			this.tilePreviewTextures[30, 1] = base.Content.Load<Texture2D>("Tiles\\Large Lock UnLocked");
			this.tilePreviewTextures[32, 0] = base.Content.Load<Texture2D>("Tiles\\debugtile");
			this.tilePreviewTextures[33, 0] = base.Content.Load<Texture2D>("Tiles\\debugtile2");
			this.tilePreviewTextures[34, 0] = base.Content.Load<Texture2D>("Tiles\\debugtile3");
			this.tilePreviewTextures[35, 0] = base.Content.Load<Texture2D>("Moon");
			this.tilePreviewTextures[36, 0] = base.Content.Load<Texture2D>("Sun");
			this.tilePreviewTextures[37, 0] = base.Content.Load<Texture2D>("Pickaxe");
			this.tilePreviewTextures[38, 0] = base.Content.Load<Texture2D>("Tile Previews\\World Lock");
			this.tilePreviewTextures[40, 0] = base.Content.Load<Texture2D>("Tile Previews\\Wooden Chair");
			this.tilePreviewTextures[42, 0] = base.Content.Load<Texture2D>("Tile Previews\\Wooden Table");
			this.tilePreviewTextures[44, 0] = base.Content.Load<Texture2D>("Tile Previews\\Spike");
			this.tilePreviewTextures[46, 0] = base.Content.Load<Texture2D>("Tile Previews\\Sign");
			this.tilePreviewTextures[48, 0] = base.Content.Load<Texture2D>("Tile Previews\\Lava");
			this.tilePreviewTextures[50, 0] = base.Content.Load<Texture2D>("Clothes\\Default hair");
			this.tilePreviewTextures[52, 0] = base.Content.Load<Texture2D>("Clothes\\Brown hair");
			this.tilePreviewTextures[54, 0] = base.Content.Load<Texture2D>("Clothes\\Default shoes");
			this.tilePreviewTextures[56, 0] = base.Content.Load<Texture2D>("Clothes\\Blue shoes");
			this.tilePreviewTextures[58, 0] = base.Content.Load<Texture2D>("Clothes\\Default Shirt");
			this.tilePreviewTextures[60, 0] = base.Content.Load<Texture2D>("Clothes\\Yellow T-Shirt");
			this.tilePreviewTextures[62, 0] = base.Content.Load<Texture2D>("Clothes\\Black Jeans");
			this.tilePreviewTextures[64, 0] = base.Content.Load<Texture2D>("Clothes\\Default Pants");
			this.tilePreviewTextures[66, 0] = base.Content.Load<Texture2D>("Wrench");
			this.tilePreviewTextures[68, 0] = base.Content.Load<Texture2D>("Clothes\\MysticMaxis Kitten Mask");
			this.tilePreviewTextures[70, 0] = base.Content.Load<Texture2D>("Tile Previews\\Teleporter Door");
			this.tilePreviewTextures[72, 0] = base.Content.Load<Texture2D>("Tile Previews\\Bricks");
			this.tilePreviewTextures[74, 0] = base.Content.Load<Texture2D>("Tiles\\Tree");
			this.tilePreviewTextures[76, 0] = base.Content.Load<Texture2D>("Tiles\\Gamer NPC");
			this.tilePreviewTextures[78, 0] = base.Content.Load<Texture2D>("Tile Previews\\1 Meter Cube Crate");
			this.tilePreviewTextures[80, 0] = base.Content.Load<Texture2D>("Tile Previews\\Golden Block");
			this.tilePreviewTextures[82, 0] = base.Content.Load<Texture2D>("Tile Previews\\Crystal Block");
			this.tilePreviewTextures[84, 0] = base.Content.Load<Texture2D>("Tile Previews\\Ice");
			this.tilePreviewTextures[86, 0] = base.Content.Load<Texture2D>("Tile Previews\\water");
			this.tilePreviewTextures[88, 0] = base.Content.Load<Texture2D>("Clothes\\Demon Wings");
			this.tilePreviewTextures[90, 0] = base.Content.Load<Texture2D>("Clothes\\iProgramMCs Code Wings");
			this.tilePreviewTextures[92, 0] = base.Content.Load<Texture2D>("Clothes\\stripey_cat");
			this.tilePreviewTextures[94, 0] = base.Content.Load<Texture2D>("Clothes\\Chick Leash");
			this.tilePreviewTextures[96, 0] = base.Content.Load<Texture2D>("Tiles\\Cake");
			this.tilePreviewTextures[98, 0] = base.Content.Load<Texture2D>("Tiles\\Holographic Sign");
			this.tilePreviewTextures[100, 0] = base.Content.Load<Texture2D>("Tiles\\Sapling");
			this.tilePreviewTextures[102, 0] = base.Content.Load<Texture2D>("Clothes\\Crown");
			this.tilePreviewTextures[104, 0] = base.Content.Load<Texture2D>("Clothes\\Pickaxe");
			this.tilePreviewTextures[106, 0] = base.Content.Load<Texture2D>("Clothes\\Shades");
			this.tilePreviewTextures[108, 0] = base.Content.Load<Texture2D>("Tiles\\boombox");
			this.tilePreviewTextures[110, 0] = base.Content.Load<Texture2D>("Tiles\\Checkpoint");
			this.tilePreviewTextures[112, 0] = base.Content.Load<Texture2D>("Tiles\\Coinbox");
			this.tilePreviewTextures[114, 0] = base.Content.Load<Texture2D>("Tiles\\Beachy Painting");
			this.tilePreviewTextures[116, 0] = base.Content.Load<Texture2D>("Tiles\\Dandelion");
			this.tilePreviewTextures[118, 0] = base.Content.Load<Texture2D>("Tiles\\Desktop PC");
			this.tilePreviewTextures[120, 0] = base.Content.Load<Texture2D>("Tiles\\Arrow Sign");
			this.tilePreviewTextures[122, 0] = base.Content.Load<Texture2D>("Tiles\\Death Warning Sign");
			this.tilePreviewTextures[124, 0] = base.Content.Load<Texture2D>("Tiles\\Fence");
			this.tilePreviewTextures[126, 0] = base.Content.Load<Texture2D>("Tiles\\Dynamite");
			this.tilePreviewTextures[128, 0] = base.Content.Load<Texture2D>("Tiles\\Bush");
			this.tilePreviewTextures[130, 0] = base.Content.Load<Texture2D>("Tiles\\Note Block");
			this.tilePreviewTextures[132, 0] = base.Content.Load<Texture2D>("Tiles\\Mystery Block");
			this.tilePreviewTextures[134, 0] = base.Content.Load<Texture2D>("Tiles\\Used Mystery Block");
			this.tilePreviewTextures[136, 0] = base.Content.Load<Texture2D>("Tiles\\Im Happy Plaque");
			this.tilePreviewTextures[138, 0] = base.Content.Load<Texture2D>("Tiles\\Im Sad Plaque");
			this.tilePreviewTextures[140, 0] = base.Content.Load<Texture2D>("Tiles\\Heart Block");
			this.tilePreviewTextures[142, 0] = base.Content.Load<Texture2D>("Items\\Love Letter_closed");
			this.tilePreviewTextures[144, 0] = base.Content.Load<Texture2D>("Items\\Love Letter");
			this.tilePreviewTextures[146, 0] = base.Content.Load<Texture2D>("Tiles\\Cupid");
			this.tilePreviewTextures[148, 0] = base.Content.Load<Texture2D>("Tiles\\CloudsBackground");
			this.tilePreviewTextures[150, 0] = base.Content.Load<Texture2D>("Tiles\\MountainsBackground");
		}

		private void LoadTiles()
		{
			this.tileTextures[0, 0] = base.Content.Load<Texture2D>("Tiles\\Air");
			this.tileTextures[2, 0] = base.Content.Load<Texture2D>("Tiles\\Dirt");
			if (this.validMonthsForWinter.Contains(DateTime.Now.Month))
			{
				this.tileTextures[2, 1] = base.Content.Load<Texture2D>("Tiles\\Grassy Dirt.winter");
			}
			else
			{
				this.tileTextures[2, 1] = base.Content.Load<Texture2D>("Tiles\\Grassy Dirt");
			}
			this.tileTextures[4, 0] = base.Content.Load<Texture2D>("Tiles\\Granite");
			this.tileTextures[6, 0] = base.Content.Load<Texture2D>("Tiles\\Cave Wall");
			this.tileTextures[8, 0] = base.Content.Load<Texture2D>("Tiles\\Bedrock");
			this.tileTextures[10, 0] = base.Content.Load<Texture2D>("Tiles\\White Door");
			this.tileTextures[12, 0] = base.Content.Load<Texture2D>("Tiles\\Wooden Planks");
			this.tileTextures[14, 0] = base.Content.Load<Texture2D>("Tiles\\Rose");
			this.tileTextures[16, 0] = base.Content.Load<Texture2D>("Tiles\\Wooden Platform");
			this.tileTextures[18, 0] = base.Content.Load<Texture2D>("Tiles\\Chest");
			this.tileTextures[20, 0] = base.Content.Load<Texture2D>("Tiles\\Grass");
			this.tileTextures[22, 0] = base.Content.Load<Texture2D>("Tiles\\Door");
			this.tileTextures[24, 0] = base.Content.Load<Texture2D>("Tiles\\Iron Block");
			this.tileTextures[26, 0] = base.Content.Load<Texture2D>("Tiles\\Small Lock");
			this.tileTextures[28, 0] = base.Content.Load<Texture2D>("Tiles\\Medium Lock");
			this.tileTextures[30, 0] = base.Content.Load<Texture2D>("Tiles\\Large Lock");
			this.tileTextures[26, 1] = base.Content.Load<Texture2D>("Tiles\\Small Lock UnLocked");
			this.tileTextures[28, 1] = base.Content.Load<Texture2D>("Tiles\\Medium Lock UnLocked");
			this.tileTextures[30, 1] = base.Content.Load<Texture2D>("Tiles\\Large Lock UnLocked");
			this.tileTextures[32, 0] = base.Content.Load<Texture2D>("Tiles\\debugtile");
			this.tileTextures[33, 0] = base.Content.Load<Texture2D>("Tiles\\debugtile2");
			this.tileTextures[34, 0] = base.Content.Load<Texture2D>("Tiles\\debugtile3");
			this.tileTextures[35, 0] = base.Content.Load<Texture2D>("Moon");
			this.tileTextures[36, 0] = base.Content.Load<Texture2D>("Sun");
			this.tileTextures[37, 0] = base.Content.Load<Texture2D>("Pickaxe");
			this.tileTextures[38, 0] = base.Content.Load<Texture2D>("Tiles\\World Lock");
			this.tileTextures[40, 0] = base.Content.Load<Texture2D>("Tiles\\Wooden Chair");
			this.tileTextures[42, 0] = base.Content.Load<Texture2D>("Tiles\\Wooden Table");
			this.tileTextures[44, 0] = base.Content.Load<Texture2D>("Tiles\\Spike");
			this.tileTextures[46, 0] = base.Content.Load<Texture2D>("Tiles\\Sign");
			this.tileTextures[48, 0] = base.Content.Load<Texture2D>("Tiles\\Lava");
			this.tileTextures[50, 0] = base.Content.Load<Texture2D>("Clothes\\Default hair");
			this.tileTextures[52, 0] = base.Content.Load<Texture2D>("Clothes\\Brown hair");
			this.tileTextures[54, 0] = base.Content.Load<Texture2D>("Clothes\\Default shoes");
			this.tileTextures[56, 0] = base.Content.Load<Texture2D>("Clothes\\Blue shoes");
			this.tileTextures[58, 0] = base.Content.Load<Texture2D>("Clothes\\Default Shirt");
			this.tileTextures[60, 0] = base.Content.Load<Texture2D>("Clothes\\Yellow T-Shirt");
			this.tileTextures[62, 0] = base.Content.Load<Texture2D>("Clothes\\Black Jeans");
			this.tileTextures[64, 0] = base.Content.Load<Texture2D>("Clothes\\Default Pants");
			this.tileTextures[66, 0] = base.Content.Load<Texture2D>("Wrench");
			this.tileTextures[68, 0] = base.Content.Load<Texture2D>("Clothes\\MysticMaxis Kitten Mask");
			this.tileTextures[70, 0] = base.Content.Load<Texture2D>("Tiles\\Teleporter Door");
			this.tileTextures[72, 0] = base.Content.Load<Texture2D>("Tiles\\Bricks");
			this.tileTextures[74, 0] = base.Content.Load<Texture2D>("Tiles\\Tree");
			this.tileTextures[76, 0] = base.Content.Load<Texture2D>("Tiles\\Gamer NPC");
			this.tileTextures[78, 0] = base.Content.Load<Texture2D>("Tiles\\1 Meter Cube Crate");
			this.tileTextures[80, 0] = base.Content.Load<Texture2D>("Tiles\\Golden Block");
			this.tileTextures[82, 0] = base.Content.Load<Texture2D>("Tiles\\Crystal Block");
			this.tileTextures[84, 0] = base.Content.Load<Texture2D>("Tiles\\Ice");
			this.tileTextures[86, 0] = base.Content.Load<Texture2D>("Tiles\\water");
			this.tileTextures[88, 0] = base.Content.Load<Texture2D>("Clothes\\Demon Wings");
			this.tileTextures[90, 0] = base.Content.Load<Texture2D>("Clothes\\iProgramMCs Code Wings");
			this.tileTextures[92, 0] = base.Content.Load<Texture2D>("Clothes\\stripey_cat");
			this.tileTextures[94, 0] = base.Content.Load<Texture2D>("Clothes\\Chick Leash");
			this.tileTextures[96, 0] = base.Content.Load<Texture2D>("Items\\Cake");
			this.tileTextures[98, 0] = base.Content.Load<Texture2D>("Tiles\\Holographic Sign");
			this.tileTextures[100, 0] = base.Content.Load<Texture2D>("Tiles\\Sapling");
			this.tileTextures[102, 0] = base.Content.Load<Texture2D>("Clothes\\Crown");
			this.tileTextures[104, 0] = base.Content.Load<Texture2D>("Clothes\\Pickaxe");
			this.tileTextures[106, 0] = base.Content.Load<Texture2D>("Clothes\\Shades");
			this.tileTextures[108, 0] = base.Content.Load<Texture2D>("Tiles\\boombox");
			this.tileTextures[110, 0] = base.Content.Load<Texture2D>("Tiles\\Checkpoint");
			this.tileTextures[112, 0] = base.Content.Load<Texture2D>("Tiles\\Coinbox");
			this.tileTextures[114, 0] = base.Content.Load<Texture2D>("Tiles\\Beachy Painting");
			this.tileTextures[116, 0] = base.Content.Load<Texture2D>("Tiles\\Dandelion");
			this.tileTextures[118, 0] = base.Content.Load<Texture2D>("Tiles\\Desktop PC");
			this.tileTextures[120, 0] = base.Content.Load<Texture2D>("Tiles\\Arrow Sign");
			this.tileTextures[122, 0] = base.Content.Load<Texture2D>("Tiles\\Death Warning Sign");
			this.tileTextures[124, 0] = base.Content.Load<Texture2D>("Tiles\\Fence");
			this.tileTextures[126, 0] = base.Content.Load<Texture2D>("Tiles\\Dynamite");
			this.tileTextures[128, 0] = base.Content.Load<Texture2D>("Tiles\\Bush");
			this.tileTextures[130, 0] = base.Content.Load<Texture2D>("Tiles\\Note Block");
			this.tileTextures[132, 0] = base.Content.Load<Texture2D>("Tiles\\Mystery Block");
			this.tileTextures[134, 0] = base.Content.Load<Texture2D>("Tiles\\Used Mystery Block");
			this.tileTextures[136, 0] = base.Content.Load<Texture2D>("Tiles\\Im Happy Plaque");
			this.tileTextures[138, 0] = base.Content.Load<Texture2D>("Tiles\\Im Sad Plaque");
			this.tileTextures[140, 0] = base.Content.Load<Texture2D>("Tiles\\Heart Block");
			this.tileTextures[142, 0] = base.Content.Load<Texture2D>("Items\\Love Letter_closed");
			this.tileTextures[144, 0] = base.Content.Load<Texture2D>("Items\\Love Letter");
			this.tileTextures[146, 0] = base.Content.Load<Texture2D>("Tiles\\Cupid");
			this.tileTextures[148, 0] = base.Content.Load<Texture2D>("Tiles\\CloudsBackground");
			this.tileTextures[150, 0] = base.Content.Load<Texture2D>("Tiles\\MountainsBackground");
		}

		public void refreshSlotRects()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					this.slotRectangles[i, j] = new Microsoft.Xna.Framework.Rectangle(20 + 50 * i + 48 + 20 + (base.GraphicsDevice.Viewport.Width - 640) / 2, this.handleY + 24 + 20 + 50 * j, 42, 42);
				}
			}
			this.craftRectangles[1] = new Microsoft.Xna.Framework.Rectangle(20, 120, 256, 64);
			this.craftRectangles[2] = new Microsoft.Xna.Framework.Rectangle(290, 120, 256, 64);
			this.craftRectangles[3] = new Microsoft.Xna.Framework.Rectangle(20, 190, 256, 64);
			this.craftRectangles[4] = new Microsoft.Xna.Framework.Rectangle(290, 190, 256, 64);
			this.craftRectangles[0] = new Microsoft.Xna.Framework.Rectangle(20, 260, 256, 64);
			this.craftRectangles[6] = new Microsoft.Xna.Framework.Rectangle(290, 260, 256, 64);
			this.craftRectangles[7] = new Microsoft.Xna.Framework.Rectangle(20, 330, 256, 64);
			this.craftRectangles[8] = new Microsoft.Xna.Framework.Rectangle(290, 330, 256, 64);
			this.craftRectangles[9] = new Microsoft.Xna.Framework.Rectangle(20, 400, 256, 64);
			this.craftRectangles[10] = new Microsoft.Xna.Framework.Rectangle(290, 400, 256, 64);
			this.craftRectangles[11] = new Microsoft.Xna.Framework.Rectangle(20, 470, 256, 64);
			this.craftRectangles[12] = new Microsoft.Xna.Framework.Rectangle(290, 470, 256, 64);
			this.craftRectangles[13] = new Microsoft.Xna.Framework.Rectangle(20, 540, 256, 64);
			this.craftRectangles[14] = new Microsoft.Xna.Framework.Rectangle(290, 540, 256, 64);
			this.craftRectangles[15] = new Microsoft.Xna.Framework.Rectangle(20, 610, 256, 64);
			this.HealthBarDrawDestRect = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 200) / 2, 50, 200, 49);
			this.craftRectangles[5] = new Microsoft.Xna.Framework.Rectangle(560, 160, 256, 64);
			try
			{
				this.startBtnRect = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 360) / 2, 250, 180, 64);
				this.exitBtnRect = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 360) / 2, 314, 180, 64);
				this.optionsBtnRect = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 360) / 2 + 180, 250, 180, 64);
				this.aboutBtnRect = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 360) / 2 + 180, 314, 180, 64);
				this.goInGameRect = new Microsoft.Xna.Framework.Rectangle(base.GraphicsDevice.Viewport.Width - 10 - this.enterWorldTex.Width, base.GraphicsDevice.Viewport.Height - 10 - this.enterWorldTex.Height, this.enterWorldTex.Width, this.enterWorldTex.Height);
				this.BackToTitleRect = new Microsoft.Xna.Framework.Rectangle(30, base.GraphicsDevice.Viewport.Height - 10 - this.enterWorldTex.Height, 180, 64);
				this.textBoxRect = new Microsoft.Xna.Framework.Rectangle(150, 30, base.GraphicsDevice.Viewport.Width - 200, 30);
			}
			catch
			{
			}
			if (this.GrowaloneLogo != null)
			{
				this.GrowaloneLogoRect = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 768) / 2 + this.GrowaloneLogo.Width / 2, 10 + this.GrowaloneLogo.Height / 2, 768, 256);
			}
			this.infoRectangle = new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 800) / 2 + 100, (base.GraphicsDevice.Viewport.Height - 480) / 2 + 40, 600, 400);
		}

		public void LoadShopItems()
		{
			this.shopItemSprites[0] = base.Content.Load<Texture2D>("Shop Items\\Inventory Upgrade");
			this.shopItemSprites[1] = base.Content.Load<Texture2D>("Shop Items\\Small Lock");
			this.shopItemSprites[2] = base.Content.Load<Texture2D>("Shop Items\\Medium Lock");
			this.shopItemSprites[3] = base.Content.Load<Texture2D>("Shop Items\\Large Lock");
			this.shopItemSprites[4] = base.Content.Load<Texture2D>("Shop Items\\World Lock");
			this.shopItemSprites[5] = base.Content.Load<Texture2D>("Shop Items\\Cake");
			this.shopItemSprites[6] = base.Content.Load<Texture2D>("Shop Items\\Crown");
			this.shopItemSprites[7] = base.Content.Load<Texture2D>("Shop Items\\Demon Wings");
			this.shopItemSprites[8] = base.Content.Load<Texture2D>("Shop Items\\Nature Pack");
			this.shopItemSprites[9] = base.Content.Load<Texture2D>("Shop Items\\Furniture Pack");
			this.shopItemSprites[10] = base.Content.Load<Texture2D>("Shop Items\\Dynamite");
		}

		public byte GetAmountOfFreeSlots()
		{
			byte b = 0;
			Item[] inventory = this.Inventory;
			for (int i = 0; i < inventory.Length; i++)
			{
				Item item = inventory[i];
				if (item.ID == 0 && item.Amount != 255)
				{
					b += 1;
				}
			}
			return b;
		}

		protected override void LoadContent()
		{
			this.spriteBatch = new SpriteBatch(base.GraphicsDevice);
			this.charSprite = new CharacterSprite(this);
			this.basicShapeEngine = new BasicShapes(this.graphics.GraphicsDevice, this.spriteBatch);
			try
			{
				this.fontEngine = new FontEngine(this.spriteBatch, base.Content);
			}
			catch
			{
			}
			this.defaultFont = base.Content.Load<SpriteFont>("Fonts\\Century Gothic Bold");
			this.defaultFont2 = base.Content.Load<SpriteFont>("Fonts\\Century Gothic Bold M");
			this.starSprite.LoadContent(this);
			try
			{
				this.LoadTiles();
				this.LoadSeeds();
				this.LoadCursors();
				this.LoadPreviewTiles();
				this.LoadPreviewSeeds();
				this.punchTexture = base.Content.Load<Texture2D>("Fist_draw");
				try
				{
					this.devPage0T = base.Content.Load<Texture2D>("Prev Page");
					this.devPage1T = base.Content.Load<Texture2D>("Next Page");
				}
				catch
				{
				}
				this.Load16SlicedBlocks();
				this.LoadShopItems();
				this.charTexture = base.Content.Load<Texture2D>("char");
				this.panel = base.Content.Load<Texture2D>("panel");
				this.slot = base.Content.Load<Texture2D>("bmp");
				this.handle = base.Content.Load<Texture2D>("Handle");
				this.HealthMeterTex = base.Content.Load<Texture2D>("HealthMeter");
				this.GOW_ButtonTex = base.Content.Load<Texture2D>("GalleryOfWorldsButton");
				this.mnt1 = base.Content.Load<Texture2D>("mountains1");
				if (this.validMonthsForWinter.Contains(DateTime.Now.Month))
				{
					this.mnt2 = base.Content.Load<Texture2D>("mountains2.winter");
				}
				else
				{
					this.mnt2 = base.Content.Load<Texture2D>("mountains2");
				}
				this.mnt3 = base.Content.Load<Texture2D>("mountains3");
				this.spaceBackground = base.Content.Load<Texture2D>("SPACE_BACKGROUND");
				this.sun = base.Content.Load<Texture2D>("sun");
				this.Moon = base.Content.Load<Texture2D>("Moon");
				this.UIBackground = base.Content.Load<Texture2D>("UIBackground");
				this.canPlaceTile = base.Content.Load<Texture2D>("canPlaceTile");
				this.selectedItemFrame = base.Content.Load<Texture2D>("Selected Item");
				this.coinTex = base.Content.Load<Texture2D>("Coins");
				this.checkmark = base.Content.Load<Texture2D>("checkmark");
				this.Checkbox = base.Content.Load<Texture2D>("Checkbox");
				this.startGameBtnTex = base.Content.Load<Texture2D>("Start Game");
				this.exitGameBtnTex = base.Content.Load<Texture2D>("Exit Game");
				this.aboutBtnTex = base.Content.Load<Texture2D>("AboutGrowalone");
				this.optionsBtnTex = base.Content.Load<Texture2D>("OptionsButton");
				this.textBoxTex = base.Content.Load<Texture2D>("Text box");
				this.enterWorldTex = base.Content.Load<Texture2D>("go in game");
				this.BackToTitleTex = base.Content.Load<Texture2D>("Back to title");
				this.Skies[0] = base.Content.Load<Texture2D>("Skies\\SunnySky");
				this.Skies[1] = base.Content.Load<Texture2D>("Skies\\NightSky");
				this.HorseTexture = base.Content.Load<Texture2D>("Enemies/horse");
				this.Skies[2] = base.Content.Load<Texture2D>("SPACE_BACKGROUND");
				this.iProgramMC_Logo = base.Content.Load<Texture2D>("logo_iProgramMC");
				if (this.validMonthsForWinter.Contains(DateTime.Now.Month))
				{
					this.GrowaloneLogo = base.Content.Load<Texture2D>("Growalone_logo.winter");
				}
				else
				{
					this.GrowaloneLogo = base.Content.Load<Texture2D>("Growalone_logo");
				}
				this.FistOFury = base.Content.Load<Texture2D>("Fist_Draw");
				this.crackTextures[0] = base.Content.Load<Texture2D>("Tiles\\Air");
				this.crackTextures[1] = base.Content.Load<Texture2D>("Cracks\\Crack_1");
				this.crackTextures[2] = base.Content.Load<Texture2D>("Cracks\\Crack_2");
				this.crackTextures[3] = base.Content.Load<Texture2D>("Cracks\\Crack_3");
				this.crackTextures[4] = base.Content.Load<Texture2D>("Cracks\\Crack_4");
				this.GazetteBadge = base.Content.Load<Texture2D>("Growalone Gazette Badge");
				try
				{
					object keyValue = Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Nls\\Language", "Default", "us");
					CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
					CultureInfo cultureInfo = cultures.FirstOrDefault((CultureInfo item) => item.LCID.ToString("X4").Contains(keyValue.ToString()));
					string text = cultureInfo.ToString();
					text = text.Split(new char[]
					{
						'-'
					}).Last<string>();
					this.theFlag = base.Content.Load<Texture2D>("Flags\\" + text);
				}
				catch
				{
					this.theFlag = new Texture2D(this.graphics.GraphicsDevice, 1, 1);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Sorry, but Growalone can't load its files!\r\n\r\nThe error code is here:\r\n\r\n" + ex.ToString() + "\r\nPlease screenshot this error message and report this bug by sending a message at growalonegame@gmail.com!\r\nThanks for playing Growalone!", "Whoops, Growalone can't load the files!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Microsoft.Xna.Framework.Color[] data = GraphicOptions.DrawMissingnoTexture();
				Texture2D texture2D = new Texture2D(this.graphics.GraphicsDevice, 75, 25);
				texture2D.SetData<Microsoft.Xna.Framework.Color>(data);
				for (int i = 0; i < 107; i++)
				{
					for (int j = 0; j < 15; j++)
					{
						this.tileTextures[i, j] = texture2D;
						this.tilePreviewTextures[i, j] = texture2D;
					}
				}
				this.punchTexture = texture2D;
				for (int k = 0; k < 16; k++)
				{
					this.LockedTile[k] = texture2D;
				}
				this.charTexture = texture2D;
				this.panel = texture2D;
				this.slot = texture2D;
				this.handle = texture2D;
				this.mnt1 = texture2D;
				this.mnt2 = texture2D;
				this.mnt3 = texture2D;
				this.spaceBackground = texture2D;
				this.sun = texture2D;
				this.Moon = texture2D;
				this.canPlaceTile = texture2D;
				this.selectedItemFrame = texture2D;
				this.coinTex = texture2D;
				this.checkmark = texture2D;
				this.startGameBtnTex = texture2D;
				this.exitGameBtnTex = texture2D;
				this.aboutBtnTex = texture2D;
				this.optionsBtnTex = texture2D;
				this.textBoxTex = texture2D;
				this.enterWorldTex = texture2D;
				this.BackToTitleTex = texture2D;
				this.iProgramMC_Logo = texture2D;
				this.GrowaloneLogo = texture2D;
				this.FistOFury = texture2D;
				this.crackTextures[0] = texture2D;
				this.crackTextures[1] = texture2D;
				this.crackTextures[2] = texture2D;
				this.crackTextures[3] = texture2D;
				this.crackTextures[4] = texture2D;
				this.shopItemSprites[0] = texture2D;
				this.shopItemSprites[1] = texture2D;
				this.shopItemSprites[2] = texture2D;
				this.shopItemSprites[3] = texture2D;
				this.shopItemSprites[4] = texture2D;
				this.shopItemSprites[5] = texture2D;
				this.shopItemSprites[6] = texture2D;
				this.shopItemSprites[7] = texture2D;
				this.shopItemSprites[8] = texture2D;
				this.shopItemSprites[9] = texture2D;
				this.shopItemSprites[10] = texture2D;
				this.cursors[0] = texture2D;
				this.cursors[1] = texture2D;
				this.cursors[2] = texture2D;
				this.Skies[0] = texture2D;
				this.Skies[1] = texture2D;
				this.Skies[2] = texture2D;
				this.cursors[3] = texture2D;
				this.cursors[4] = texture2D;
				this.GazetteBadge = texture2D;
				this.GOW_ButtonTex = texture2D;
				this.HealthMeterTex = texture2D;
			}
			this.InitializeWorldButtons();
			this.WalkEffect = base.Content.Load<SoundEffect>("Sound FX\\walk1");
			this.WalkEffectInstance = this.WalkEffect.CreateInstance();
			this.WalkEffectInstance.IsLooped = true;
			this.BreakEffect = base.Content.Load<SoundEffect>("Sound FX\\break");
			this.BuyItemEffect = base.Content.Load<SoundEffect>("Sound FX\\buy_item");
			this.ClickEffect = base.Content.Load<SoundEffect>("Sound FX\\click");
			this.JumpEffect = base.Content.Load<SoundEffect>("Sound FX\\jump");
			this.PickupEffect = base.Content.Load<SoundEffect>("Sound FX\\pickup");
			this.ExplosionEffect = base.Content.Load<SoundEffect>("Sound FX\\explosion_long");
			this.gow = new GalleryOfWorlds(this);
		}

		private void Jump()
		{
			this.jumps = true;
			try
			{
				int num = (this.e + 16) / 32;
				int num2 = (this.g - 32) / 32;
				int num3 = (this.e + 16) / 32;
				int num4 = (this.g - 16) / 32;
				if (this.world.Map[num3, num4, 0].ID == 86 && (this.collided[this.world.Map[num, num2, 0].ID] == 0 || this.collided[this.world.Map[num, num2, 0].ID] == 2 || this.collided[this.world.Map[num, num2, 0].ID] == 3))
				{
					this.cameraY -= 4;
					this.jumps = true;
				}
				else if (this.collided[this.world.Map[num, num2, 0].ID] == 3)
				{
					if (!this.isDead)
					{
						this.tickWhenWasKilled = this.globalTimer;
						this.isDead = true;
					}
				}
				else if (this.collided[this.world.Map[num, num2, 0].ID] == 4)
				{
					if (!this.IsStunning)
					{
						this.tickWhenWasHurt = this.globalTimer;
						this.HEALTH_DEC = 12;
						this.IsStunning = true;
					}
				}
				else if ((this.blocksJumped < this.MaximumPixelsJumped && (this.collided[this.world.Map[num, num2, 0].ID] == 0 || this.collided[this.world.Map[num, num2, 0].ID] == 2)) || this.collided[this.world.Map[num, num2, 0].ID] == 3)
				{
					this.cameraY -= 8;
					this.blocksJumped += 8;
					this.jumps = true;
				}
				else
				{
					this.Fall();
					this.jumps = false;
					this.blocksJumped = 256;
				}
			}
			catch (Exception ex)
			{
				this.warningText = ex.Message;
			}
		}

		private void Fall()
		{
			int num = (int)Math.Round((double)(this.e + 16) / 32.0);
			int num2 = (int)Math.Floor((double)(this.g + 3) / 32.0);
			try
			{
				if (this.world.Map[num, num2, 0].ID == 86)
				{
					this.cameraY += 4;
				}
				else if (this.collided[this.world.Map[num, num2, 0].ID] == 0)
				{
					this.cameraY += 8;
					if (this.charSprite.mode != CharacterAnimatedSpriteMode.Falling)
					{
						this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Falling);
					}
				}
				else if (this.collided[this.world.Map[num, num2, 0].ID] == 3)
				{
					if (!this.isDead)
					{
						this.tickWhenWasKilled = this.globalTimer;
						this.isDead = true;
					}
				}
				else if (this.collided[this.world.Map[num, num2, 0].ID] == 4)
				{
					if (!this.IsStunning)
					{
						this.tickWhenWasHurt = this.globalTimer;
						this.HEALTH_DEC = 12;
						this.IsStunning = true;
					}
				}
				else
				{
					this.blocksJumped = 0;
					if (this.charSprite.mode == CharacterAnimatedSpriteMode.Falling && this.charSprite.mode != CharacterAnimatedSpriteMode.Still)
					{
						this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Still);
					}
					if (this.charSprite.mode == CharacterAnimatedSpriteMode.Jumping)
					{
						this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Still);
					}
				}
			}
			catch (Exception ex)
			{
				this.warningShown = true;
				this.warningText = ex.ToString();
			}
		}

		public void LoadWorldInGOW(World world, string name)
		{
			this.world = world;
			this.TheWorldName = "Gallery of Worlds - " + name;
			this.teleportToMainDoor();
			this.Screen = ScreenType.Playground;
			this.Health = 2176;
		}

		public void ManageMap(Growalone.MapRequestType mrt)
		{
			if (mrt == Growalone.MapRequestType.Save)
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Filter = this.localizer.FindString("EXPORT_WORLD_FILTER_DESCRIPTION") + " (*.gaw)|*.gaw",
					FileName = "map.gaw",
					Title = this.localizer.FindString("EXPORT_WORLD_TITLE"),
					DefaultExt = "gaw"
				};
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					DataHandler.SaveMap(this.world, saveFileDialog.FileName);
				}
			}
			else if (mrt == Growalone.MapRequestType.Load)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog
				{
					Filter = this.localizer.FindString("IMPORT_WORLD_FILTER_DESCRIPTION") + " (*.gaw)|*.gaw",
					FileName = "map.gaw",
					Title = this.localizer.FindString("IMPORT_WORLD_TITLE"),
					DefaultExt = "gaw"
				};
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.world = (World)DataHandler.LoadMap(openFileDialog.FileName);
					this.TheWorldName = openFileDialog.SafeFileName;
					this.TheWorldName = this.TheWorldName.Replace(".gaw", "");
					DataHandler.SaveMap(this.world, "C:\\growalone_maps\\worlds\\" + this.TheWorldName + ".gaw");
					this.teleportToMainDoor();
				}
			}
		}

		protected override void UnloadContent()
		{
		}

		public void CreateExplosion(int explosionStartX, int explosionStartY, int radius, bool produceSoundEffect)
		{
			int num = explosionStartX - (radius - 1) / 2;
			int num2 = explosionStartY - (radius - 1) / 2;
			int num3 = explosionStartX + (radius + 1) / 2;
			int num4 = explosionStartY + (radius + 1) / 2;
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					if (i >= 1 && j >= 1 && i <= 98 && j <= 58)
					{
						if (this.world.Map[i, j, 0].ID != 10 && this.world.Map[i, j, 0].ID != 8 && this.world.Map[i, j, 0].ID != 26 && this.world.Map[i, j, 0].ID != 28 && this.world.Map[i, j, 0].ID != 30 && this.world.Map[i, j, 0].ID != 38 && this.world.Map[i, j, 0].ID != 126)
						{
							try
							{
								this.world.Map[i, j, 0] = new Block();
							}
							catch
							{
							}
						}
						else if (this.world.Map[i, j, 0].ID == 126 && i != explosionStartX && j != explosionStartY)
						{
							this.CreateExplosion(i, j, 7, true);
						}
						else if (this.world.Map[i, j, 0].ID == 126 && i == explosionStartX && j == explosionStartY)
						{
							try
							{
								this.world.Map[i, j, 0] = new Block();
							}
							catch
							{
							}
						}
					}
				}
			}
			if (produceSoundEffect)
			{
				this.ExplosionEffect.Play();
			}
		}

		public void LockAreaInWorld(int lockPosX, int lockPosY, int radius)
		{
			int num = lockPosX - (radius - 1) / 2;
			int num2 = lockPosY - (radius - 1) / 2;
			int num3 = lockPosX + (radius + 1) / 2;
			int num4 = lockPosY + (radius + 1) / 2;
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					if (i >= 1 && j >= 1 && i <= 98 && j <= 58)
					{
						try
						{
							this.world.Locked[i, j] = 1;
						}
						catch
						{
						}
					}
				}
			}
		}

		public int findItemIndex(int ID)
		{
			int result;
			for (int i = 0; i < this.Inventory.Length; i++)
			{
				if (this.Inventory[i].ID == ID)
				{
					result = i;
					return result;
				}
			}
			result = -1;
			return result;
		}

		public void ShowInputBox(InputBoxAction action, string message, string title)
		{
			this.inputBoxMessage = message;
			this.inputBoxResponse = "";
			this.inputBoxTitle = title;
			this.inputBoxShown = true;
			this.inputBoxAction = action;
		}

		public void ShowMsgBox(MessageBoxAction action, string message, string title)
		{
			this.msgBoxMessage = message;
			this.msgBoxTitle = title;
			this.msgBoxShown = true;
			this.msgBoxAction = action;
		}

		public void ShowInputBox(InputBoxAction action, string message, string title, string unused)
		{
			this.inputBoxMessage = message;
			this.inputBoxResponse = "";
			this.inputBoxTitle = title;
			this.inputBoxShown = true;
			this.inputBoxAction = action;
		}

		public void ShowDialog(string message)
		{
			this.dialogBoxMessage = message;
			this.dialogBoxTimeout = 20;
			this.dialogBoxShown = true;
			this.dialogBoxColor = Microsoft.Xna.Framework.Color.Blue;
		}

		public void ShowDialog(string message, int timeout)
		{
			this.dialogBoxMessage = message;
			this.dialogBoxTimeout = timeout;
			this.dialogBoxShown = true;
			this.dialogBoxColor = Microsoft.Xna.Framework.Color.Blue;
		}

		public void ShowDialog2(string message)
		{
			this.dialogBoxMessage2 = message;
			this.dialogBoxTimeout2 = 20;
			this.dialogBoxShown2 = true;
		}

		public void ShowDialog2(string message, int timeout)
		{
			this.dialogBoxMessage2 = message;
			this.dialogBoxTimeout2 = timeout;
			this.dialogBoxShown2 = true;
		}

		public void ShowDialog(string message, Microsoft.Xna.Framework.Color color)
		{
			this.dialogBoxMessage = message;
			this.dialogBoxTimeout = 20;
			this.dialogBoxShown = true;
			this.dialogBoxColor = color;
		}

		public void ShowDialog(string message, int timeout, Microsoft.Xna.Framework.Color color)
		{
			this.dialogBoxMessage = message;
			this.dialogBoxTimeout = timeout;
			this.dialogBoxShown = true;
			this.dialogBoxColor = color;
		}

		protected override void OnExiting(object sender, EventArgs args)
		{
			try
			{
				if (this.Screen != ScreenType.TitleScreen && this.Screen != ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
				{
					DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
					DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
				}
			}
			catch (Exception ex)
			{
				if (!Directory.Exists("C:\\growalone_maps"))
				{
					if (this.Screen != ScreenType.TitleScreen && this.Screen != ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
					{
						Directory.CreateDirectory("C:\\growalone_maps");
						DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
						DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
					}
				}
				else
				{
					this.ShowMsgBox(new DefaultMsgAction(), ex.Message, "");
				}
			}
			if (this.Screen != ScreenType.TitleScreen && this.Screen != ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
			{
				DataHandler.SaveMap(this.world, "C:\\growalone_maps\\worlds\\" + this.TheWorldName + ".gaw");
			}
			base.OnExiting(sender, args);
			if (this.isDeveloper)
			{
				try
				{
				}
				catch
				{
				}
			}
		}

		protected override void OnDeactivated(object sender, EventArgs e)
		{
			this.isRunning = false;
			try
			{
				if (this.Screen != ScreenType.TitleScreen && this.Screen != ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
				{
					DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
					DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
				}
			}
			catch (Exception ex)
			{
				if (!Directory.Exists("C:\\growalone_maps"))
				{
					if (this.Screen != ScreenType.TitleScreen && this.Screen != ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
					{
						Directory.CreateDirectory("C:\\growalone_maps");
						DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
						DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
					}
				}
				else
				{
					this.ShowMsgBox(new DefaultMsgAction(), ex.Message, "");
				}
			}
			if (this.Screen != ScreenType.TitleScreen && this.Screen != ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
			{
				DataHandler.SaveMap(this.world, "C:\\growalone_maps\\worlds\\" + this.TheWorldName + ".gaw");
			}
			base.OnDeactivated(sender, e);
		}

		protected override void OnActivated(object sender, EventArgs e)
		{
			this.isRunning = true;
		}

		public void SetupPlayer()
		{
			bool isFullScreen = this.graphics.IsFullScreen;
			if (!this.graphics.IsFullScreen)
			{
				this.graphics.IsFullScreen = false;
				this.graphics.ApplyChanges();
			}
			DialogResult dialogResult = MessageBox.Show("Do you agree with the beta testing of Growalone?", "Before we start,", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				string text = InputBoxGrowalone.ShowInputBox("What's your name?", "Welcome to Growalone!", this);
				MessageBox.Show("Welcome to Growalone, " + text + "!", "Welcome to Growalone");
				this.playerData.PlayerName = text;
				this.playerData.firstStarted = false;
			}
			else
			{
				MessageBox.Show("Goodbye then.", ":(");
				Application.Exit();
			}
			if (isFullScreen)
			{
				this.graphics.IsFullScreen = true;
				this.graphics.ApplyChanges();
			}
		}

		public void OnStepOnBlock()
		{
			this.e321 = (int)Math.Round((double)this.e / 32.0);
			this.j321 = (int)Math.Round((double)(this.g - 32) / 32.0);
			if (this.e321 >= 0 && this.e321 <= 99 && this.j321 >= 0 && this.j321 <= 59)
			{
				if (this.world.Map[this.e321, this.j321, 0].ID == 46)
				{
					this.ShowDialog(this.world.Map[this.e321, this.j321, 0].StringData[0], Microsoft.Xna.Framework.Color.Brown);
				}
				else if (this.world.Map[this.e321, this.j321, 0].ID == 70)
				{
					this.ShowDialog(this.world.Map[this.e321, this.j321, 0].StringData[0]);
				}
				else if (this.world.Map[this.e321, this.j321, 0].ID == 10)
				{
					this.ShowDialog("Exit World", Microsoft.Xna.Framework.Color.Purple);
				}
				else if (this.world.Map[this.e321, this.j321, 0].ID == 112)
				{
					this.ShowDialog("There are " + this.world.Map[this.e321, this.j321, 0].IntData[0] + " coins in this Coinbox.", Microsoft.Xna.Framework.Color.DarkGoldenrod);
				}
				else if (this.world.Map[this.e321, this.j321, 0].ID == 110)
				{
					this.TakeCheckpoint();
				}
				else if (this.world.Map[this.e321, this.j321, 0].ID == 74)
				{
					int num = (this.world.Map[this.e321, this.j321, 0].IntData[1] - this.world.Map[this.e321, this.j321, 0].IntData[2]) / 60;
					if (this.world.Map[this.e321, this.j321, 0].IntData[3] == 1)
					{
						this.ShowDialog(ItemData.ReturnItemName(this.world.Map[this.e321, this.j321, 0].IntData[0]) + " Tree\n(Punch to harvest)", Microsoft.Xna.Framework.Color.Green);
					}
					else
					{
						this.ShowDialog(ItemData.ReturnItemName(this.world.Map[this.e321, this.j321, 0].IntData[0]) + " Tree\n" + num.ToString() + " seconds to harvest", Microsoft.Xna.Framework.Color.Green);
					}
				}
				else if (this.world.Map[this.e321, this.j321, 0].ID == 76)
				{
					this.ShowDialog("Hello, " + this.playerData.PlayerName + ", Would you like to help me fix my PC? I broke it :(, I need your help! Please!!", Microsoft.Xna.Framework.Color.Black);
				}
			}
		}

		public void CheckAndFixIllegalClothes()
		{
			if (this.findItemIndex(this.playerData.WingCloth) == -1)
			{
				this.playerData.WingCloth = 0;
			}
			if (this.findItemIndex(this.playerData.PetsCloth) == -1)
			{
				this.playerData.PetsCloth = 0;
			}
		}

		protected override void Update(GameTime gameTime)
		{
			if (this.HEALTH_INC >= 0)
			{
				this.HEALTH_INC--;
				this.Health += 64;
				if (this.Health > 2176)
				{
					this.Health = 2176;
				}
			}
			if (this.HEALTH_DEC >= 0)
			{
				this.HEALTH_DEC--;
				this.Health -= 64;
			}
			if (this.Health <= 255)
			{
				this.Health = 255;
				if (!this.isDead)
				{
					this.tickWhenWasKilled = this.globalTimer;
					this.isDead = true;
				}
			}
			this.ActualCameraX = (int)MathHelper.Clamp((float)this.cameraX, 0f, (float)(3200 - base.GraphicsDevice.Viewport.Width));
			if (this.globalTimer - this.tickWhenWasKilled >= this.respawnDuration && this.isDead)
			{
				this.cameraX = this.SpawnPointX - 384;
				this.cameraY = this.SpawnPointY - 256;
				this.isDead = false;
				this.Health = 2176;
				this.HEALTH_INC = 64;
				this.IsStunning = false;
			}
			if (this.globalTimer - this.tickWhenWasHurt >= this.hitstunDuration && this.IsStunning)
			{
				this.IsStunning = false;
			}
			this.globalTimer++;
			if (this.directionOfLogoRot)
			{
				this.rotationOfLogo += 0.001f;
				if (this.rotationOfLogo >= 0.1f)
				{
					this.directionOfLogoRot = false;
				}
			}
			else
			{
				this.rotationOfLogo -= 0.001f;
				if (this.rotationOfLogo <= -0.1f)
				{
					this.directionOfLogoRot = true;
				}
			}
			if (this.directionOfLogoGrow)
			{
				this.scaleOfLogo += 0.001f;
				if (this.scaleOfLogo >= 1.05f)
				{
					this.directionOfLogoGrow = false;
				}
			}
			else
			{
				this.scaleOfLogo -= 0.001f;
				if (this.scaleOfLogo <= 0.95f)
				{
					this.directionOfLogoGrow = true;
				}
			}
			if (this.Screen == ScreenType.TitleScreen || this.Screen == ScreenType.WorldSelect)
			{
				this.Mnt1X++;
				this.Mnt2X += 2;
				if (this.Mnt1X >= 3000)
				{
					this.Mnt1X = 0;
				}
				if (this.Mnt2X >= 3000)
				{
					this.Mnt2X = 0;
				}
			}
			else
			{
				this.Mnt1X = 0;
				this.Mnt2X = 0;
				this.Mnt3X = 0;
			}
			if (this.isPunching)
			{
				float num;
				Vector2.Distance(ref this.mousecur, ref this.posOnTheWayToCursor, out num);
				float num2;
				Vector2.Distance(ref this.mousecur, ref this.center, out num2);
				num /= num2 / 20f;
				this.posOnTheWayToCursor += (this.mousecur - this.posOnTheWayToCursor) / num;
				this.PlaceBlock(Mouse.GetState());
				if (this.posOnTheWayToCursor.X <= this.mousecur.X + 10f && this.posOnTheWayToCursor.Y <= this.mousecur.Y + 10f && this.posOnTheWayToCursor.X >= this.mousecur.X - 10f && this.posOnTheWayToCursor.Y >= this.mousecur.Y - 10f)
				{
					if (this.Inventory[this.selectedItem].ID == 0 && this.posOnTheWayToCursor != this.center)
					{
					}
					this.posOnTheWayToCursor = this.center;
				}
			}
			else
			{
				this.posOnTheWayToCursor = this.center;
			}
			this.center = new Vector2((float)(this.guyX - this.ActualCameraX + 16), (float)(base.GraphicsDevice.Viewport.Height / 2));
			if (this.tSec != DateTime.Now.Second)
			{
				this.UpdateEverySecond();
				this.tSec = DateTime.Now.Second;
			}
			this.CheckAndFixIllegalClothes();
			this.UpdateTile();
			this.CheckForIllegalItems();
			this.OnStepOnBlock();
			if (this.playerData.achievements != null)
			{
				this.playerData.achievements.Update(this.playerData.statistics, this);
			}
			else
			{
				this.playerData.achievements = new Achievements();
			}
			if (this.playerData.statistics == null)
			{
				this.playerData.statistics = new Statistics();
			}
			if (this.isRunning)
			{
				if (this.Screen == ScreenType.GalleryOfWorlds)
				{
					this.gow.Update(this);
				}
				else
				{
					this.gow.MouseClicked = true;
				}
				if (this.Screen == ScreenType.TitleScreen || this.Screen == ScreenType.WorldSelect)
				{
					this.DebugInfo = false;
				}
				else
				{
					this.DebugInfo = true;
				}
				this.Inventory[0] = new Item(0, 255);
				this.Inventory[1] = new Item(66, 255);
				this.guyX = this.cameraX + 400 - 16;
				this.guyY = this.cameraY + 240 + 16;
				this.e = this.guyX;
				this.g = this.guyY;
				this.refreshSlotRects();
				MouseState state = Mouse.GetState();
				this.blockX = (state.X - this.cameraX) / 32;
				this.blockY = (state.Y - this.cameraY) / 32;
				KeyboardState state2 = Keyboard.GetState();
				GamePadState state3 = GamePad.GetState(PlayerIndex.One);
				if (!this.inputBoxShown && !this.msgBoxShown)
				{
					if (this.Screen == ScreenType.Playground)
					{
						if (!this.playerData.UsesGamepad)
						{
							this.GetKeyPressOnPlayGround();
						}
						else
						{
							this.GetKeyPressOnPlayGround();
						}
					}
					else if (this.Screen == ScreenType.ShopScreen)
					{
						if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.C))
						{
							if (!this.keyPressedEnCr)
							{
								this.keyPressedEnCr = true;
								this.Screen = ScreenType.Playground;
							}
						}
						else
						{
							this.keyPressedEnCr = false;
						}
					}
					else if (this.Screen != ScreenType.TitleScreen && this.Screen == ScreenType.WorldSelect && this.Screen != ScreenType.ShopScreen)
					{
						if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Back))
						{
							if (!this.keyPressedOnWN)
							{
								this.keyPressedOnWN = true;
								if (this.nameInTextBox.Length > 0)
								{
									this.nameInTextBox = this.nameInTextBox.Remove(this.nameInTextBox.Length - 1, 1);
								}
							}
							if (this.worldSelectText != "Checking...")
							{
								this.worldSelectText = "Checking...";
							}
						}
						else if (!state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Back))
						{
							string text = TextBoxHelper.Convert(state2.GetPressedKeys());
							if (text != "")
							{
								if (!this.keyPressedOnWN)
								{
									this.nameInTextBox += text;
									this.keyPressedOnWN = true;
								}
								if (this.worldSelectText != "Checking...")
								{
									this.worldSelectText = "Checking...";
								}
							}
							else
							{
								this.keyPressedOnWN = false;
								if (File.Exists("C:\\growalone_maps\\worlds\\" + this.nameInTextBox + ".gaw"))
								{
									if (this.worldSelectText != "World exists." && this.nameInTextBox != "")
									{
										this.worldSelectText = "World exists.";
									}
									else if (this.worldSelectText != "Type in a world name then press 'Enter World'!" && this.nameInTextBox == "")
									{
										this.worldSelectText = "Type in a world name then press 'Enter World'!";
									}
								}
								else if (this.worldSelectText != "New world." && this.nameInTextBox != "")
								{
									this.worldSelectText = "New world.";
								}
								else if (this.worldSelectText != "Type in a world name then press 'Enter World'!" && this.nameInTextBox == "")
								{
									this.worldSelectText = "Type in a world name then press 'Enter World'!";
								}
							}
						}
						else
						{
							this.keyPressedOnWN = false;
						}
					}
					else if (this.Screen == ScreenType.TitleScreen)
					{
						if (state3.Buttons.Start == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
						{
							this.Screen = ScreenType.WorldSelect;
						}
						if (state3.Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
						{
							base.Exit();
						}
					}
				}
				else if (!this.inputBoxShown && this.msgBoxShown)
				{
					if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Enter))
					{
						this.msgBoxAction.Execute();
						this.msgBoxAction = null;
						this.msgBoxShown = false;
					}
					else if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Escape))
					{
						this.msgBoxAction = null;
						this.msgBoxShown = false;
						this.keyDownEsc = true;
					}
				}
				else if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Back))
				{
					if (!this.keyPressedOnIB)
					{
						this.keyPressedOnIB = true;
						if (this.inputBoxResponse.Length > 0)
						{
							this.inputBoxResponse = this.inputBoxResponse.Remove(this.inputBoxResponse.Length - 1, 1);
						}
					}
				}
				else if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Enter))
				{
					if (this.inputBoxAction is PlaceDoorAction || this.inputBoxAction is PlaceSignAction)
					{
						this.inputBoxAction.args[4] = new ActionArgument(this.inputBoxResponse);
					}
					if (this.inputBoxAction is ExecuteCommandAction)
					{
						this.inputBoxAction.args[0] = new ActionArgument(this.inputBoxResponse);
					}
					if (this.inputBoxAction is StoreCoinsAction)
					{
						this.inputBoxAction.args[0] = new ActionArgument(this.inputBoxResponse);
					}
					this.inputBoxAction.Execute();
					this.inputBoxAction = null;
					this.inputBoxShown = false;
				}
				else if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Escape))
				{
					this.inputBoxAction = null;
					this.inputBoxShown = false;
					this.keyDownEsc = true;
				}
				else if (!state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Back) && !state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Enter) && !state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Escape))
				{
					string text = TextBoxHelper.Convert(state2.GetPressedKeys());
					if (text != "")
					{
						if (!this.keyPressedOnIB)
						{
							this.inputBoxResponse += text;
							this.keyPressedOnIB = true;
						}
					}
					else
					{
						this.keyPressedOnIB = false;
					}
				}
				else
				{
					this.keyPressedOnIB = false;
					this.keyDownEsc = false;
				}
				if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.F11))
				{
					if (!this.keyPressedF11)
					{
						if (!this.keyPressedF11)
						{
							double aspectRatio = this.GetAspectRatio();
							if (aspectRatio >= 1.2 && aspectRatio <= 1.4)
							{
								this.graphics.PreferredBackBufferWidth = 800;
								this.graphics.PreferredBackBufferHeight = 600;
							}
							else if (aspectRatio >= 1.65 && aspectRatio <= 1.85)
							{
								this.graphics.PreferredBackBufferWidth = 800;
								this.graphics.PreferredBackBufferHeight = 480;
							}
							this.keyPressedF11 = true;
						}
						this.graphics.IsFullScreen = !this.graphics.IsFullScreen;
						this.graphics.ApplyChanges();
						this.keyPressedF11 = true;
					}
				}
				else
				{
					this.keyPressedF11 = false;
				}
				if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.F2))
				{
					this.keyPressedScSh = true;
					if (!this.graphics.IsFullScreen)
					{
						Bitmap bitmap = new Bitmap(base.GraphicsDevice.Viewport.Width, base.GraphicsDevice.Viewport.Height);
						using (Graphics graphics = Graphics.FromImage(bitmap))
						{
							graphics.CopyFromScreen(new System.Drawing.Point(base.Window.ClientBounds.Left, base.Window.ClientBounds.Top), System.Drawing.Point.Empty, bitmap.Size);
						}
						bitmap.Save("output.png", ImageFormat.Png);
					}
					else
					{
						this.graphics.IsFullScreen = false;
						this.graphics.ApplyChanges();
						Bitmap bitmap = new Bitmap(base.GraphicsDevice.Viewport.Width, base.GraphicsDevice.Viewport.Height);
						using (Graphics graphics = Graphics.FromImage(bitmap))
						{
							graphics.CopyFromScreen(new System.Drawing.Point(base.Window.ClientBounds.Left, base.Window.ClientBounds.Top), System.Drawing.Point.Empty, bitmap.Size);
						}
						bitmap.Save("output.png", ImageFormat.Png);
						this.graphics.IsFullScreen = true;
						this.graphics.ApplyChanges();
					}
				}
				else
				{
					this.keyPressedScSh = false;
				}
				base.Window.AllowUserResizing = false;
				this.mousecur = new Vector2((float)state.X, (float)state.Y);
				try
				{
					World.WorldButton[] array = this.worldBtns;
					for (int i = 0; i < array.Length; i++)
					{
						World.WorldButton worldButton = array[i];
						if (worldButton.Initialized)
						{
							worldButton.Update(state);
						}
					}
				}
				catch
				{
				}
				if (state.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					if (this.Screen == ScreenType.Playground)
					{
						if (state.Y < this.handleY && !this.handleMove)
						{
							if (!this.MouseDownCauseEnterDoor)
							{
								this.isPunching = true;
								if (this.Inventory[this.selectedItem].ID != 0)
								{
									if (this.isRunning)
									{
										this.PlaceBlock(state);
									}
									else
									{
										this.DontEditBackgrounds = true;
										this.MouseDownCauseEnterDoor = true;
									}
								}
							}
						}
						else if ((state.Y > this.handleY - 1 && state.Y < this.handleY + 23) || this.handleMove)
						{
							this.handleMove = true;
							if (this.handleMove)
							{
								this.handleY = state.Y;
							}
						}
						else
						{
							for (int j = 0; j < 10; j++)
							{
								for (int k = 0; k < this.playerData.BackPackSlotsUpgraded; k++)
								{
									if (this.slotRectangles[j, k].Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
									{
										this.selectedItem = 10 * k + j;
										if (ItemData.GetTier(this.Inventory[this.selectedItem].ID) != 0)
										{
											this.ShowDialog2(string.Concat(new object[]
											{
												ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID),
												" (Tier: ",
												ItemData.GetTier(this.Inventory[this.selectedItem].ID),
												")"
											}));
										}
										else
										{
											this.ShowDialog2(ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID));
										}
									}
								}
							}
						}
					}
					else if (this.Screen == ScreenType.ShopScreen)
					{
						Shop.BuyItem(this.playerData, this.Inventory, this.craftRectangles, state, this);
						if (this.devPage0R.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.InitializeDevInventory(0);
						}
						if (this.devPage1R.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.InitializeDevInventory(1);
						}
					}
					else if (this.Screen == ScreenType.TitleScreen)
					{
						if (this.startBtnRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							if (this.playerData.firstStarted)
							{
								this.SetupPlayer();
							}
							this.Screen = ScreenType.WorldSelect;
						}
						else if (this.exitBtnRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							Application.Exit();
							DataHandler.SaveMap(this.Inventory, "C:\\growalone_maps\\inventory.gai");
							DataHandler.SaveMap(this.playerData, "C:\\growalone_maps\\playerdata.gai");
						}
						else if (this.optionsBtnRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.OptionsMenu;
						}
						else if (this.aboutBtnRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.AboutScreen;
						}
						else if (this.gowBtnRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.GalleryOfWorlds;
						}
					}
					else if (ScreenType.WorldSelect == this.Screen)
					{
						if (this.goInGameRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.Playground;
							this.GoToWorld(this.nameInTextBox);
							this.nameInTextBox = "";
						}
						else if (this.BackToTitleRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.TitleScreen;
						}
						else if (this.textBoxRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.typingOnLogin = !this.typingOnLogin;
						}
					}
					else if (this.Screen == ScreenType.OptionsMenu)
					{
						if (this.BackToTitleRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.TitleScreen;
						}
						else if (this.FullScreenButtonRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.graphics.IsFullScreen = !this.graphics.IsFullScreen;
							if (this.graphics.IsFullScreen)
							{
								if (base.GraphicsDevice.Viewport.AspectRatio > 1.2f && base.GraphicsDevice.Viewport.AspectRatio < 1.4f)
								{
									this.graphics.PreferredBackBufferWidth = 800;
									this.graphics.PreferredBackBufferHeight = 600;
								}
								if (base.GraphicsDevice.Viewport.AspectRatio > 1.6f && base.GraphicsDevice.Viewport.AspectRatio < 1.8f)
								{
									this.graphics.PreferredBackBufferWidth = 800;
									this.graphics.PreferredBackBufferHeight = 480;
								}
							}
							else
							{
								this.graphics.PreferredBackBufferWidth = 800;
								this.graphics.PreferredBackBufferHeight = 480;
							}
						}
						if (this.ShowFancyGfxButtonRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							if (!this.OptionsShowGfxClicked)
							{
								this.playerData.DoesShowFancyGraphics = !this.playerData.DoesShowFancyGraphics;
							}
							this.OptionsShowGfxClicked = true;
						}
						else
						{
							this.OptionsShowGfxClicked = false;
						}
					}
					else if (this.Screen == ScreenType.AboutScreen)
					{
						if (this.BackToTitleRect.Contains(new Microsoft.Xna.Framework.Point(state.X, state.Y)))
						{
							this.Screen = ScreenType.TitleScreen;
						}
						else
						{
							if (!this.hasStartedDragging)
							{
								this.hasStartedDragging = true;
								this.CursorPointY = state.Y;
							}
							this.AboutScreenPosition = state.Y - this.CursorPointY;
						}
					}
				}
				else
				{
					this.hasStartedDragging = false;
					this.OptionsShowGfxClicked = false;
					if (this.AboutScreenPosition < 10)
					{
						this.AboutScreenPosition += 10;
					}
					if (this.AboutScreenPosition > 10)
					{
						this.AboutScreenPosition -= 10;
					}
					if (this.handleY < 20 + base.GraphicsDevice.Viewport.Height - 480)
					{
						this.handleY = 20 + base.GraphicsDevice.Viewport.Height - 480;
					}
					else if (this.handleY > base.GraphicsDevice.Viewport.Height - 23)
					{
						this.handleY = base.GraphicsDevice.Viewport.Height - 23;
					}
					this.handleMove = false;
					this.MouseDownCauseEnterDoor = false;
					this.isPunching = false;
					this.DontEditBackgrounds = false;
				}
				if (this.handleY < 20 + base.GraphicsDevice.Viewport.Height - 480)
				{
					this.handleY = 20 + base.GraphicsDevice.Viewport.Height - 480;
				}
				if (this.handleY > base.GraphicsDevice.Viewport.Height - 23)
				{
					this.handleY = base.GraphicsDevice.Viewport.Height - 23;
				}
				this.prevGPState = state3;
			}
			if (this.selectedItem != 0 && this.Inventory[this.selectedItem].ID == 0)
			{
				this.selectedItem = 0;
			}
			base.Update(gameTime);
		}

		public void GoToWorld(string WorldName)
		{
			if (WorldName == "")
			{
				this.ShowMsgBox(new DefaultMsgAction(), "You will need to insert a world name before you can actually start playing! If the world is not created then this will create it for you, but if it is then it will load from there!", "Warning!");
				this.Screen = ScreenType.WorldSelect;
			}
			else
			{
				try
				{
					if (!File.Exists("C:\\growalone_maps\\worlds\\" + WorldName + ".gaw"))
					{
						this.InitialiseMap();
						DataHandler.SaveMap(this.world, "C:\\growalone_maps\\worlds\\" + WorldName + ".gaw");
						this.teleportToMainDoor();
						if (this.world.Cracks == null)
						{
							this.world.Cracks = new byte[100, 60];
						}
						if (this.world.Timeout == null)
						{
							this.world.Timeout = new byte[100, 60];
						}
					}
					else
					{
						this.world = (World)DataHandler.LoadMap("C:\\growalone_maps\\worlds\\" + WorldName + ".gaw");
						this.teleportToMainDoor();
						if (this.world.Cracks == null)
						{
							this.world.Cracks = new byte[100, 60];
						}
						if (this.world.Timeout == null)
						{
							this.world.Timeout = new byte[100, 60];
						}
					}
					this.gazetteDlgShown = true;
					this.Screen = ScreenType.Playground;
					this.TheWorldName = WorldName;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Could not enter or create world!\r\n\r\nThe error code is here:\r\n\r\n" + ex.ToString() + "\r\n\r\nPlease screenshot this error message and report this bug by sending a message at growalonegame@gmail.com!\r\nThanks for playing Growalone!", "Whoops, Growalone messed up!");
					this.Screen = ScreenType.WorldSelect;
				}
			}
			this.Health = 2176;
		}

		public void UpdateTile()
		{
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].ID == 74)
					{
						if (this.world.Map[i, j, 0].IntData[2] < this.world.Map[i, j, 0].IntData[1])
						{
							this.world.Map[i, j, 0].IntData[2]++;
						}
						else
						{
							this.world.Map[i, j, 0].IntData[3] = 1;
						}
						if (this.world.Timeout[i, j] != 255 || this.world.Cracks[i, j] != 0)
						{
							if (this.world.Timeout[i, j] >= 100)
							{
								this.world.Timeout[i, j] = 255;
								this.world.Cracks[i, j] = 0;
							}
							else
							{
								this.world.Timeout[i, j] += 1;
							}
						}
					}
				}
			}
		}

		public void UpdateLocks()
		{
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].ID == 38)
					{
						for (int k = 0; k < 100; k++)
						{
							for (int l = 0; l < 60; l++)
							{
								this.world.Locked[k, l] = 2;
								this.WorldLocked = true;
							}
						}
					}
				}
			}
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].ID == 26)
					{
						this.LockAreaInWorld(i, j, 3);
					}
					else if (this.world.Map[i, j, 0].ID == 28)
					{
						this.LockAreaInWorld(i, j, 7);
					}
					else if (this.world.Map[i, j, 0].ID == 30)
					{
						this.LockAreaInWorld(i, j, 11);
					}
				}
			}
		}

		public void WarpToTpDoor(string DoorID)
		{
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					if (this.world.Map[i, j, 0].StringData[2] == DoorID && this.world.Map[i, j, 0].ID == 70 && this.world.Map[i, j, 0].StringData[2] != "")
					{
						int num = i;
						int num2 = j;
						num *= 32;
						num2 *= 32;
						num -= 384;
						num2 -= 256;
						this.cameraX = num;
						this.cameraY = num2 + 32;
						this.MouseDownCauseEnterDoor = true;
						this.MouseDownCauseEnterDoor = true;
						this.MouseDownCauseEnterDoor = true;
						this.MouseDownCauseEnterDoor = true;
						return;
					}
				}
			}
			this.teleportToMainDoor();
		}

		public void PlaceBlock(MouseState mouseState)
		{
			if (mouseState.Y < this.handleY)
			{
				int num = (mouseState.X + this.ActualCameraX - (base.Window.ClientBounds.Width - 800) / 2) / 32;
				int num2 = (mouseState.Y + this.cameraY - (base.Window.ClientBounds.Height - 480) / 2) / 32;
				if ((num >= 0 && num <= 99 && num2 >= 0 && num2 <= 59) || !this.MouseDownCauseEnterDoor)
				{
					if (num >= 0 && num <= 99 && num2 >= 0 && num2 <= 59 && !this.MouseDownCauseEnterDoor)
					{
						int num3 = (int)Math.Round((double)this.e / 32.0);
						int num4 = (int)Math.Floor((double)this.g / 32.0) - 1;
						if (num != num3 || num2 != num4 || this.world.Map[num, num2, 0].ID == 70 || this.world.Map[num, num2, 0].ID == 0 || this.world.Map[num, num2, 0].ID == 10)
						{
							if (this.world.Map[num, num2, 0].ID != 0)
							{
								this.DontEditBackgrounds = true;
							}
							if (!ItemData.IsPlantable(this.Inventory[this.selectedItem].ID))
							{
								if (num == this.e321 && num2 == this.j321 && this.world.Map[num, num2, 0].ID == 70)
								{
									this.WarpToTpDoor(this.world.Map[num, num2, 0].StringData[1]);
									this.MouseDownCauseEnterDoor = true;
								}
								else if (num == this.e321 && num2 == this.j321 && this.world.Map[num, num2, 0].ID == 10)
								{
									this.ShowDialog("Later, this would exit to the main menu...");
								}
								else if (this.Inventory[this.selectedItem].ID == 66 && (this.world.Locked[num, num2] == 0 || (this.WorldLocked && this.world.Locked[num, num2] == 1)))
								{
									if (this.world.Map[num, num2, 0].ID == 46)
									{
										this.world.Map[num, num2, 0] = new Block(46, "");
										this.ShowInputBox(new PlaceSignAction(this.world, new ActionArgument[]
										{
											new ActionArgument(num),
											new ActionArgument(num2),
											new ActionArgument(0),
											new ActionArgument(46),
											new ActionArgument("")
										}), "What would you like to write on this sign?", "Edit Sign", "OK");
									}
									else if (this.world.Map[num, num2, 0].ID == 98)
									{
										this.world.Map[num, num2, 0] = new Block(98, "");
										this.ShowInputBox(new PlaceSignAction(this.world, new ActionArgument[]
										{
											new ActionArgument(num),
											new ActionArgument(num2),
											new ActionArgument(0),
											new ActionArgument(98),
											new ActionArgument("")
										}), "What would you like to write on this sign?", "Edit Holographic Sign", "OK");
									}
									else if (this.world.Map[num, num2, 0].ID == 70)
									{
										this.world.Map[num, num2, 0] = new Block(70, "");
										this.ShowInputBox(new PlaceDoorAction(this.world, new ActionArgument[]
										{
											new ActionArgument(num),
											new ActionArgument(num2),
											new ActionArgument(0),
											new ActionArgument(70),
											new ActionArgument("")
										}), "What would you like to code this door to? Type the code like this: DESTINATION:DOORID:LABEL", "Edit Door", "OK");
									}
									else if (this.world.Map[num, num2, 0].ID == 112)
									{
										this.ShowInputBox(new StoreCoinsAction(this, this.world.Map[num, num2, 0]), "Please insert a number of coins to store. Put a minus to withdraw coins, or don't to deposit them.", "Store coins within Coinbox. You have " + this.world.Map[num, num2, 0].IntData[0] + " coins.");
									}
									else if (this.world.Map[num, num2, 0].ID == 76)
									{
										bool isFullScreen = this.graphics.IsFullScreen;
										this.graphics.IsFullScreen = false;
										this.graphics.ApplyChanges();
										DialogResult dialogResult = MessageBox.Show("Are you sure you want to help me repair my PC?", "Quest Onward!", MessageBoxButtons.YesNo);
										if (dialogResult == DialogResult.Yes)
										{
											MessageBox.Show("Thank you, my son!", "Gamer's Quest");
											MessageBox.Show("You went to eBay and bought the components needed. (Not actual coins spent)", "Gamer's Quest");
											MessageBox.Show("You built a PC 50%.", "Gamer's Quest");
											MessageBox.Show("You finished building the PC.", "Gamer's Quest");
											MessageBox.Show("You have installed Windows 10 on this gamer's PC.", "Gamer's Quest");
											MessageBox.Show("Thank you, my son! I shall reward you 1,000 Coins!", "Gamer's Quest Finished!");
											this.playerData.Gems += 1000;
											this.world.Map[num, num2, 0] = new Block();
										}
										if (isFullScreen)
										{
											this.graphics.IsFullScreen = true;
											this.graphics.ApplyChanges();
										}
									}
									if (this.Inventory[this.selectedItem].Amount == 0)
									{
										this.Inventory[this.selectedItem] = new Item(0, 0);
									}
								}
								else if (this.Inventory[this.selectedItem].Amount > 0 && this.Inventory[this.selectedItem].ID == 118)
								{
									this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID, this.facesLeft);
									this.DrainItem(this.selectedItem, 1);
									if (this.Inventory[this.selectedItem].Amount == 0)
									{
										this.Inventory[this.selectedItem] = new Item(0, 0);
									}
									this.playerData.statistics.BlocksPlaced++;
								}
								else if (this.Inventory[this.selectedItem].Amount > 0 && this.Inventory[this.selectedItem].ID == 120)
								{
									this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID, this.facesLeft);
									this.DrainItem(this.selectedItem, 1);
									if (this.Inventory[this.selectedItem].Amount == 0)
									{
										this.Inventory[this.selectedItem] = new Item(0, 0);
									}
									this.playerData.statistics.BlocksPlaced++;
								}
								else if (this.Inventory[this.selectedItem].ID == 50 || this.Inventory[this.selectedItem].ID == 52 || this.Inventory[this.selectedItem].ID == 54 || this.Inventory[this.selectedItem].ID == 56 || this.Inventory[this.selectedItem].ID == 58 || this.Inventory[this.selectedItem].ID == 60 || this.Inventory[this.selectedItem].ID == 62 || this.Inventory[this.selectedItem].ID == 64 || this.Inventory[this.selectedItem].ID == 68 || this.Inventory[this.selectedItem].ID == 88 || this.Inventory[this.selectedItem].ID == 90 || this.Inventory[this.selectedItem].ID == 92 || this.Inventory[this.selectedItem].ID == 94 || this.Inventory[this.selectedItem].ID == 102 || this.Inventory[this.selectedItem].ID == 104 || this.Inventory[this.selectedItem].ID == 106)
								{
									int iD = this.Inventory[this.selectedItem].ID;
									if (iD <= 68)
									{
										switch (iD)
										{
										case 50:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 51:
										case 53:
										case 55:
										case 57:
										case 59:
										case 61:
										case 63:
											break;
										case 52:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 54:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 56:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 58:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 60:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 62:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										case 64:
											this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
											break;
										default:
											if (iD == 68)
											{
												this.playerData.MaskCloth = 68;
											}
											break;
										}
									}
									else
									{
										switch (iD)
										{
										case 88:
											this.playerData.WingCloth = 88;
											this.MaximumPixelsJumped = 256;
											break;
										case 89:
										case 91:
										case 93:
											break;
										case 90:
											this.playerData.WingCloth = 90;
											this.MaximumPixelsJumped = 1024;
											break;
										case 92:
											this.playerData.PetsCloth = 92;
											break;
										case 94:
											this.playerData.PetsCloth = 94;
											break;
										default:
											switch (iD)
											{
											case 102:
												this.playerData.MaskCloth = 102;
												break;
											case 104:
												this.ShowMsgBox(new DefaultMsgAction(), "Clothes are deprecated now, sorry.", "");
												break;
											case 106:
												this.playerData.MaskCloth = 106;
												break;
											}
											break;
										}
									}
								}
								else if (this.Inventory[this.selectedItem].Amount > 0 && this.Inventory[this.selectedItem].ID == 6)
								{
									if ((this.world.Locked[num, num2] == 0 || (this.WorldLocked && this.world.Locked[num, num2] == 1)) && this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30)
									{
										if (this.Inventory[this.selectedItem].ID == 6 && this.world.Map[num, num2, 1].ID != 6)
										{
											this.world.Map[num, num2, 1] = new Block(this.Inventory[this.selectedItem].ID);
											this.DrainItem(this.selectedItem, 1);
											if (this.Inventory[this.selectedItem].Amount == 0)
											{
												this.Inventory[this.selectedItem] = new Item(0, 0);
											}
											this.playerData.statistics.BlocksPlaced++;
										}
									}
								}
								else if (this.Inventory[this.selectedItem].Amount > 0 && (this.world.Map[num, num2, 0].ID == 0 || this.Inventory[this.selectedItem].ID == 0))
								{
									if ((this.world.Locked[num, num2] == 0 || (this.WorldLocked && this.world.Locked[num, num2] == 1)) && this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30)
									{
										if (this.Inventory[this.selectedItem].ID > 25 && this.Inventory[this.selectedItem].ID < 40 && this.WorldLocked)
										{
											this.ShowMsgBox(new DefaultMsgAction(), "Cannot place lock because world has World Lock.", "Lock Error");
										}
										else if (this.Inventory[this.selectedItem].ID == 38)
										{
											this.ShowMsgBox(new DefaultMsgAction(), "Please exit full screen mode!", "");
											DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to place the world lock in this world?! The world will never be editable again, so be careful.", "Lock Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
											if (dialogResult2 == DialogResult.Yes)
											{
												for (int i = 0; i < 100; i++)
												{
													for (int j = 0; j < 60; j++)
													{
														this.world.Locked[i, j] = 2;
													}
												}
												this.WorldLocked = true;
												this.UpdateLocks();
												this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID);
												this.DrainItem(this.selectedItem, 1);
												if (this.Inventory[this.selectedItem].Amount == 0)
												{
													this.Inventory[this.selectedItem] = new Item(0, 0);
												}
												this.playerData.statistics.BlocksPlaced++;
											}
										}
										else if ((this.Inventory[this.selectedItem].ID == 26 || this.Inventory[this.selectedItem].ID == 28 || this.Inventory[this.selectedItem].ID == 30) && this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30)
										{
											this.ShowMsgBox(new DefaultMsgAction(), "Please exit full screen mode!", "");
											DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to place the lock? It won't be breakable so be careful.", "Lock Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
											if (dialogResult2 == DialogResult.Yes)
											{
												switch (this.Inventory[this.selectedItem].ID)
												{
												case 26:
													if (num > 1 && num2 > 1 && num < 98 && num2 < 58)
													{
														this.LockAreaInWorld(num, num2, 3);
														this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID);
														this.DrainItem(this.selectedItem, 1);
														if (this.Inventory[this.selectedItem].Amount == 0)
														{
															this.Inventory[this.selectedItem] = new Item(0, 0);
														}
														this.playerData.statistics.BlocksPlaced++;
													}
													else
													{
														this.ShowMsgBox(new DefaultMsgAction(), string.Concat(new string[]
														{
															"Can not place lock at X:",
															num.ToString(),
															",Y:",
															num2.ToString(),
															" for crash prevention."
														}), "Lock Place Error");
													}
													break;
												case 28:
													if (num > 2 && num2 > 2 && num < 97 && num2 < 57)
													{
														this.LockAreaInWorld(num, num2, 7);
														this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID);
														this.DrainItem(this.selectedItem, 1);
														if (this.Inventory[this.selectedItem].Amount == 0)
														{
															this.Inventory[this.selectedItem] = new Item(0, 0);
														}
														this.playerData.statistics.BlocksPlaced++;
													}
													else
													{
														this.ShowMsgBox(new DefaultMsgAction(), string.Concat(new string[]
														{
															"Can not place lock at X:",
															num.ToString(),
															",Y:",
															num2.ToString(),
															" for crash prevention."
														}), "Lock Place Error");
													}
													break;
												case 30:
													if (num > 3 && num2 > 3 && num < 96 && num2 < 56)
													{
														this.LockAreaInWorld(num, num2, 11);
														this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID);
														this.DrainItem(this.selectedItem, 1);
														if (this.Inventory[this.selectedItem].Amount == 0)
														{
															this.Inventory[this.selectedItem] = new Item(0, 0);
														}
														this.playerData.statistics.BlocksPlaced++;
													}
													else
													{
														this.ShowMsgBox(new DefaultMsgAction(), string.Concat(new string[]
														{
															"Can not place lock at X:",
															num.ToString(),
															",Y:",
															num2.ToString(),
															" for crash prevention."
														}), "Lock Place Error");
													}
													break;
												}
											}
										}
										else if (this.Inventory[this.selectedItem].ID == 37)
										{
											if (this.DontEditBackgrounds)
											{
												if (this.world.Map[num, num2, 0].ID != 0 && this.world.Map[num, num2, 0].ID != 126)
												{
													if ((int)this.world.Cracks[num, num2] >= this.MaxDurability)
													{
														this.world.Timeout[num, num2] = 0;
														this.world.Cracks[num, num2] = 0;
														if (this.world.Map[num, num2, 0].ID == 112)
														{
															this.playerData.Gems += this.world.Map[num, num2, 0].IntData[0];
															int num5 = new Random().Next(0, 100);
															if (num5 <= 30)
															{
																this.playerData.Gems++;
															}
															else if (num5 >= 70)
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
															else
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID + 1, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
														}
														else if (this.world.Map[num, num2, 0].ID != 0 && this.world.Map[num, num2, 0].ID != 112)
														{
															int num5 = new Random().Next(0, 100);
															if (num5 <= 30)
															{
																this.playerData.Gems++;
															}
															else if (num5 >= 70)
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
															else
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID + 1, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
														}
														this.world.Map[num, num2, 0] = new Block();
														this.DontEditBackgrounds = true;
														this.BreakEffect.Play();
													}
													else
													{
														this.world.Cracks[num, num2]+= 1;
														this.world.Timeout[num, num2] += 1;
													}
												}
												else if (this.world.Map[num, num2, 0].ID == 126)
												{
													this.CreateExplosion(num, num2, 3, true);
												}
											}
											else if (this.world.Map[num, num2, 1].ID != 0)
											{
												int num5 = new Random().Next(0, 100);
												if (num5 <= 30)
												{
													this.playerData.Gems++;
												}
												else if (num5 >= 70)
												{
													this.world.DropItem(this.world.Map[num, num2, 1].ID, 1, num * 32 + 8, num2 * 32 + 8, this);
												}
												else
												{
													this.world.DropItem(this.world.Map[num, num2, 1].ID + 1, 1, num * 32 + 8, num2 * 32 + 8, this);
												}
												this.world.Map[num, num2, 1] = new Block();
											}
										}
										else if (this.Inventory[this.selectedItem].ID == 96)
										{
											this.ShowDialog("YUM!", 200, Microsoft.Xna.Framework.Color.Blue);
											this.DrainItem(this.selectedItem, 1);
											this.MouseDownCauseEnterDoor = true;
										}
										else if (this.Inventory[this.selectedItem].ID == 0 && this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10)
										{
											if (this.world.Map[num, num2, 0].ID == 74)
											{
												if (this.world.Map[num, num2, 0].IntData[3] == 1)
												{
													bool flag = this.AddMultipleItems(this.world.Map[num, num2, 0].IntData[0], new Random().Next(1, 13));
													if (flag && this.world.Map[num, num2, 0].ID != 0)
													{
														this.world.Map[num, num2, 0] = new Block(0);
													}
													else if (this.world.Map[num, num2, 0].ID != 0 && !flag)
													{
														this.ShowMsgBox(new DefaultMsgAction(), "Backpack Full! Trash any item or upgrade it from the Shop!", "Harvesting has Failed!");
													}
												}
												else
												{
													this.ShowMsgBox(new DefaultMsgAction(), "Cannot smash trees while they are growing!", "Tree Warning");
												}
											}
											else if (this.DontEditBackgrounds)
											{
												if (this.world.Map[num, num2, 0].ID != 0 && this.world.Map[num, num2, 0].ID != 126)
												{
													if ((int)this.world.Cracks[num, num2] >= this.MaxDurability)
													{
														this.world.Timeout[num, num2] = 0;
														this.world.Cracks[num, num2] = 0;
														if (this.world.Map[num, num2, 0].ID == 112)
														{
															this.playerData.Gems += this.world.Map[num, num2, 0].IntData[0];
															int num5 = new Random().Next(0, 100);
															if (num5 <= 30)
															{
																this.playerData.Gems++;
															}
															else if (num5 >= 70)
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
															else
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID + 1, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
															this.playerData.statistics.BlocksBroken++;
														}
														else if (this.world.Map[num, num2, 0].ID != 0 && this.world.Map[num, num2, 0].ID != 112)
														{
															int num5 = new Random().Next(0, 100);
															if (num5 <= 30)
															{
																this.playerData.Gems++;
															}
															else if (num5 >= 70)
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
															else
															{
																this.world.DropItem(this.world.Map[num, num2, 0].ID + 1, 1, num * 32 + 8, num2 * 32 + 8, this);
															}
															this.playerData.statistics.BlocksBroken++;
														}
														this.world.Map[num, num2, 0] = new Block();
														this.DontEditBackgrounds = true;
														this.BreakEffect.Play();
													}
													else
													{
														this.world.Cracks[num, num2] += 1;
														this.world.Timeout[num, num2] += 1;
													}
												}
												else if (this.world.Map[num, num2, 0].ID == 126)
												{
													this.CreateExplosion(num, num2, 7, true);
													this.playerData.statistics.BlocksBroken += 49;
													this.playerData.statistics.HowManyDynamitesThePlayerBlewUp++;
												}
											}
											else if (this.world.Map[num, num2, 1].ID != 0)
											{
												int num5 = new Random().Next(0, 100);
												if (num5 <= 30)
												{
													this.playerData.Gems++;
												}
												else if (num5 >= 70)
												{
													this.world.DropItem(this.world.Map[num, num2, 1].ID, 1, num * 32 + 8, num2 * 32 + 8, this);
												}
												else
												{
													this.world.DropItem(this.world.Map[num, num2, 1].ID + 1, 1, num * 32 + 8, num2 * 32 + 8, this);
												}
												this.playerData.statistics.BlocksBroken++;
												this.world.Map[num, num2, 1] = new Block();
											}
										}
										else if (this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30 && this.world.Map[num, num2, 0].ID == 0)
										{
											if (this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30 && this.world.Map[num, num2, 0].ID == 0 && this.Inventory[this.selectedItem].ID == 74)
											{
												this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID, 1000, 74);
												this.playerData.statistics.BlocksPlaced++;
											}
											else if (this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30 && this.world.Map[num, num2, 0].ID == 0 && this.Inventory[this.selectedItem].ID != 20 && this.Inventory[this.selectedItem].ID != 0 && this.Inventory[this.selectedItem].ID != 6)
											{
												this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID);
												this.DrainItem(this.selectedItem, 1);
												if (this.Inventory[this.selectedItem].Amount == 0)
												{
													this.Inventory[this.selectedItem] = new Item(0, 0);
												}
												this.playerData.statistics.BlocksPlaced++;
											}
											else if (this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30 && this.world.Map[num, num2, 0].ID == 0 && this.Inventory[this.selectedItem].ID == 32)
											{
												this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID, "");
												this.KeyDown = true;
												this.DrainItem(this.selectedItem, 1);
												if (this.Inventory[this.selectedItem].Amount == 0)
												{
													this.Inventory[this.selectedItem] = new Item(0, 0);
												}
												this.playerData.statistics.BlocksPlaced++;
											}
											else if (this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30 && this.world.Map[num, num2, 0].ID == 0 && this.Inventory[this.selectedItem].ID == 20)
											{
												this.world.Map[num, num2, 0] = new Block(this.Inventory[this.selectedItem].ID, "");
												this.DrainItem(this.selectedItem, 1);
												this.playerData.statistics.BlocksPlaced++;
											}
											else if (this.world.Map[num, num2, 0].ID != 8 && this.world.Map[num, num2, 0].ID != 10 && this.world.Map[num, num2, 0].ID != 26 && this.world.Map[num, num2, 0].ID != 28 && this.world.Map[num, num2, 0].ID != 30 && this.Inventory[this.selectedItem].ID == 0)
											{
												this.world.RegisterHit(num, num2, this);
											}
										}
									}
									else
									{
										this.ShowDialog("The area is Locked", 200);
									}
								}
							}
							else if (this.world.Locked[num, num2] == 0 || (this.WorldLocked && this.world.Locked[num, num2] == 1))
							{
								if (this.world.Map[num, num2, 0].ID == 0 && this.collided[this.world.Map[num, num2 + 1, 0].ID] != 0)
								{
									this.world.Map[num, num2, 0] = new Block(74, 1000, this.Inventory[this.selectedItem].ID - 1);
									this.DrainItem(this.selectedItem, 1);
									if (this.Inventory[this.selectedItem].Amount <= 0)
									{
										this.Inventory[this.selectedItem] = new Item();
									}
									this.playerData.statistics.TreesPlanted++;
								}
								else if (this.collided[this.world.Map[num, num2 + 1, 0].ID] == 0)
								{
									this.ShowDialog("(can't plant tree in mid-air)", 1000);
								}
								else if (this.world.Map[num, num2, 0].IntData[4] == 0)
								{
									Splicing.SpliceItem(this.Inventory[this.selectedItem].ID, this.world.Map[num, num2, 0], this);
									this.DrainItem(this.selectedItem, 1);
									if (this.Inventory[this.selectedItem].Amount <= 0)
									{
										this.Inventory[this.selectedItem] = new Item();
									}
									this.playerData.statistics.TreesPlanted++;
								}
							}
							else
							{
								this.ShowMsgBox(new DefaultMsgAction(), "The area is Locked. You can't place seeds in here.", "Locked!");
							}
						}
					}
				}
			}
		}

		public void Load16SlicedBlocks()
		{
			for (int i = 0; i < 16; i++)
			{
				this.LockedTile[i] = base.Content.Load<Texture2D>("Tiles\\Locked Border " + i.ToString());
			}
		}

		public void DrawMap(SpriteBatch sb, Vector2 position)
		{
			int width = base.GraphicsDevice.Viewport.Width;
			int height = base.GraphicsDevice.Viewport.Height;
			int num = (int)((float)width / (32f * this.worldDrawScale));
			int num2 = (int)((float)height / (32f * this.worldDrawScale));
			int num3 = (int)((float)this.ActualCameraX / (32f * this.worldDrawScale) - 8f);
			int num4 = (int)((float)this.cameraY / (32f * this.worldDrawScale) - 8f);
			int num5 = (int)((float)this.ActualCameraX / (32f * this.worldDrawScale) + (float)num + 8f);
			int num6 = (int)((float)this.cameraY / (32f * this.worldDrawScale) + (float)num2 + 8f);
			for (int i = num3; i < num5; i++)
			{
				for (int j = num4; j < num6; j++)
				{
					if (i > -1 && i < 100 && j > -1 && j < 60)
					{
						int actualCameraX = this.ActualCameraX;
						int num7 = (int)position.Y;
						if (this.world.Map[i, j, 1].ID != 0 && this.collided[this.world.Map[i, j, 0].ID] != 1)
						{
							sb.Draw(this.tileTextures[this.world.Map[i, j, 1].ID, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, 32, 32), Microsoft.Xna.Framework.Color.White);
						}
						if (this.world.Map[i, j, 0].ID != 0)
						{
							if (this.world.Map[i, j, 0].ID != 26 && this.world.Map[i, j, 0].ID != 28 && this.world.Map[i, j, 0].ID != 30)
							{
								if (this.world.Map[i, j, 0].ID == 0)
								{
									if (this.Inventory[this.selectedItem].ID != 0 && this.Inventory[this.selectedItem].ID != 60)
									{
										sb.Draw(this.canPlaceTile, new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, 32, 32), Microsoft.Xna.Framework.Color.White);
									}
								}
								else if (this.world.Map[i, j, 0].ID == 74)
								{
									sb.Draw(this.tileTextures[this.world.Map[i, j, 0].ID, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[this.world.Map[i, j, 0].ID, 0].Width, this.tileTextures[this.world.Map[i, j, 0].ID, 0].Height), Microsoft.Xna.Framework.Color.White);
									if (this.world.Map[i, j, 0].IntData[3] == 1)
									{
										int num8 = this.world.Map[i, j, 0].IntData[0];
										if (num8 >= 0)
										{
											Texture2D texture = this.tileTextures[num8, 0];
											sb.Draw(texture, new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2 + 8, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2 + 8, 16, 16), Microsoft.Xna.Framework.Color.White);
										}
									}
								}
								else if (this.world.Map[i, j, 0].ID == 120)
								{
									SpriteEffects effects;
									if (this.world.Map[i, j, 0].facingLeft)
									{
										effects = SpriteEffects.FlipHorizontally;
									}
									else
									{
										effects = SpriteEffects.None;
									}
									sb.Draw(this.tileTextures[this.world.Map[i, j, 0].ID, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, 32, 32), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, effects, 0f);
								}
								else if (this.world.Map[i, j, 0].ID == 2)
								{
									if (j - 1 > -1)
									{
										if (this.world.Map[i, j - 1, 0].ID == 2)
										{
											sb.Draw(this.tileTextures[2, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[2, 0].Width, this.tileTextures[2, 0].Height), Microsoft.Xna.Framework.Color.White);
										}
										else
										{
											sb.Draw(this.tileTextures[2, 1], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[2, 1].Width, this.tileTextures[2, 1].Height), Microsoft.Xna.Framework.Color.White);
										}
									}
									else
									{
										sb.Draw(this.tileTextures[2, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[2, 0].Width, this.tileTextures[2, 0].Height), Microsoft.Xna.Framework.Color.White);
									}
								}
								else if (this.world.Map[i, j, 0].ID == 98)
								{
									sb.Draw(this.tileTextures[98, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[98, 0].Width, this.tileTextures[98, 0].Height), Microsoft.Xna.Framework.Color.White);
								}
								else if (this.world.Map[i, j, 0].ID != 118)
								{
									if (this.world.Map[i, j, 0].ID != 0 && this.world.Map[i, j, 0].ID != 1)
									{
										int iD = this.world.Map[i, j, 0].ID;
										if (iD >= 0)
										{
											sb.Draw(this.tileTextures[iD, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[iD, 0].Width, this.tileTextures[iD, 0].Height), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
										}
									}
								}
							}
							else if (!this.WorldLocked)
							{
								sb.Draw(this.tileTextures[this.world.Map[i, j, 0].ID, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[this.world.Map[i, j, 0].ID, 0].Width, this.tileTextures[this.world.Map[i, j, 0].ID, 0].Height), Microsoft.Xna.Framework.Color.White);
							}
							else
							{
								sb.Draw(this.tileTextures[this.world.Map[i, j, 0].ID, 1], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[this.world.Map[i, j, 0].ID, 0].Width, this.tileTextures[this.world.Map[i, j, 0].ID, 0].Height), Microsoft.Xna.Framework.Color.White);
							}
							if (this.world.Cracks[i, j] != 0)
							{
								sb.Draw(this.crackTextures[(int)this.world.Cracks[i, j] / (this.MaxDurability / 3)], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, 32, 32), Microsoft.Xna.Framework.Color.White);
							}
						}
						if (this.world.Locked[i, j] == 1)
						{
							if (!this.WorldLocked)
							{
								sb.Draw(BlockConnection.ConnectLocked(this.world.Locked, 1, this, i, j), new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, 32, 32), Microsoft.Xna.Framework.Color.Red);
							}
							else
							{
								sb.Draw(BlockConnection.ConnectLocked(this.world.Locked, 1, this, i, j), new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, 32, 32), Microsoft.Xna.Framework.Color.Yellow);
							}
						}
					}
				}
			}
			for (int i = num3; i < num5; i++)
			{
				for (int j = num4; j < num6; j++)
				{
					int actualCameraX = this.ActualCameraX;
					int num7 = (int)position.Y;
					if (i > -1 && i < 100 && j > -1 && j < 60)
					{
						if (this.world.Map[i, j, 0].ID == 98)
						{
							int num9 = i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2;
							int num10 = j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2;
							Vector2 vector = this.defaultFont.MeasureString(this.world.Map[i, j, 0].StringData[0]);
							num9 += 16;
							num10 += 16;
							num10 -= 52;
							num9 -= (int)vector.X / 4;
							sb.DrawString(this.defaultFont, this.world.Map[i, j, 0].StringData[0], new Vector2((float)num9, (float)num10), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize * 2f, SpriteEffects.None, 0f);
						}
						else if (this.world.Map[i, j, 0].ID == 118)
						{
							SpriteEffects effects;
							if (this.world.Map[i, j, 0].facingLeft)
							{
								effects = SpriteEffects.FlipHorizontally;
							}
							else
							{
								effects = SpriteEffects.None;
							}
							if (this.world.Map[i, j + 1, 0].ID == 42)
							{
								sb.Draw(this.tileTextures[118, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2 + 14, this.tileTextures[118, 0].Width, this.tileTextures[118, 0].Height), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, effects, 0f);
							}
							else
							{
								sb.Draw(this.tileTextures[118, 0], new Microsoft.Xna.Framework.Rectangle(i * 32 - actualCameraX + (base.GraphicsDevice.Viewport.Width - 800) / 2, j * 32 - num7 + (base.GraphicsDevice.Viewport.Height - 480) / 2, this.tileTextures[118, 0].Width, this.tileTextures[118, 0].Height), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, effects, 0f);
							}
						}
					}
				}
			}
			WorldItem[] worldItems = this.world.worldItems;
			for (int k = 0; k < worldItems.Length; k++)
			{
				WorldItem worldItem = worldItems[k];
				if (worldItem != null && worldItem != new WorldItem(0, 0, -100, -100) && worldItem != null)
				{
					worldItem.Draw(this.spriteBatch, this, new Vector2((float)this.cameraX, (float)this.cameraY), this.ActualCameraX);
					worldItem.Update(this.guyX, this.guyY, this);
				}
			}
		}

		public bool AddDroppedItem(int ID, int amount)
		{
			int i = 0;
			bool result;
			while (i < this.Inventory.Length)
			{
				if (this.Inventory[i].ID == 0 && i != 0)
				{
					this.Inventory[i] = new Item(ID, amount);
					result = true;
				}
				else
				{
					if (this.Inventory[i].ID != ID || this.Inventory[i].Amount >= 200)
					{
						i++;
						continue;
					}
					this.Inventory[i] = new Item(ID, amount + this.Inventory[i].Amount);
					result = true;
				}
				return result;
			}
			result = false;
			return result;
		}

		public bool AddItem(int ID, int amount)
		{
			int i = 0;
			bool result;
			while (i < this.Inventory.Length)
			{
				if (this.Inventory[i].ID == 0 && i != 0)
				{
					this.Inventory[i] = new Item(ID, amount);
					result = true;
				}
				else
				{
					if (this.Inventory[i].ID != ID || this.Inventory[i].Amount >= 200)
					{
						i++;
						continue;
					}
					this.Inventory[i] = new Item(ID, amount + this.Inventory[i].Amount);
					result = true;
				}
				return result;
			}
			result = false;
			return result;
		}

		public bool AddItem(int ID)
		{
			int i = 0;
			bool result;
			while (i < this.Inventory.Length)
			{
				if (this.Inventory[i].ID == 0)
				{
					this.Inventory[i] = new Item(ID, 1);
					result = true;
				}
				else
				{
					if (this.Inventory[i].ID != ID || this.Inventory[i].Amount >= 200)
					{
						i++;
						continue;
					}
					this.Inventory[i] = new Item(ID, 1 + this.Inventory[i].Amount);
					result = true;
				}
				return result;
			}
			result = false;
			return result;
		}

		public bool AddMultipleItems(int ID, int amount)
		{
			int i = 0;
			bool result;
			while (i < this.Inventory.Length)
			{
				if (this.Inventory[i].ID == 0)
				{
					this.Inventory[i] = new Item(ID, amount);
					result = true;
				}
				else
				{
					if (this.Inventory[i].ID != ID || this.Inventory[i].Amount >= 200)
					{
						i++;
						continue;
					}
					this.Inventory[i] = new Item(ID, amount + this.Inventory[i].Amount);
					result = true;
				}
				return result;
			}
			result = false;
			return result;
		}

		public void DrainItem(int x, int amount)
		{
			this.Inventory[x] = new Item(this.Inventory[x].ID, this.Inventory[x].Amount - amount);
		}

		public float MeasureAngle(Vector2 p1, Vector2 p2)
		{
			return (float)Math.Atan2((double)(p2.Y - p1.Y), (double)(p2.X - p1.X));
		}

		public void DrawPlaygroundShadows(int ShadowOffset)
		{
			if (this.facesLeft)
			{
				SpriteEffects effects = SpriteEffects.FlipHorizontally;
				this.spriteBatch.Draw(this.tileTextures[this.playerData.WingCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX + ShadowOffset, (base.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127), 0f, new Vector2(0f, 0f), effects, 0f);
				this.spriteBatch.Draw(this.tileTextures[this.playerData.PetsCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX + 32 + ShadowOffset, (base.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127), 0f, new Vector2(0f, 0f), effects, 0f);
				this.charSprite.Draw(this.ActualCameraX, this.guyX, true, ShadowOffset);
				this.spriteBatch.Draw(this.tileTextures[this.playerData.MaskCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX + ShadowOffset, (base.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127), 0f, new Vector2(0f, 0f), effects, 0f);
			}
			else
			{
				this.spriteBatch.Draw(this.tileTextures[this.playerData.WingCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX + ShadowOffset, (base.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127));
				this.spriteBatch.Draw(this.tileTextures[this.playerData.PetsCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX - 32 + ShadowOffset, (base.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127));
				this.charSprite.Draw(this.ActualCameraX, this.guyX, true, ShadowOffset);
				this.spriteBatch.Draw(this.tileTextures[this.playerData.MaskCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX + ShadowOffset, (base.GraphicsDevice.Viewport.Height - 32) / 2 + ShadowOffset, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127));
			}
		}

		public void DrawPlayground()
		{
			this.DrawMap(this.spriteBatch, new Vector2((float)this.cameraX, (float)this.cameraY));
			Enemy[] enemies = this.world.enemies;
			for (int i = 0; i < enemies.Length; i++)
			{
				Enemy enemy = enemies[i];
				if (enemy != null)
				{
					enemy.Draw(this);
					enemy.Update(this);
				}
			}
			if (this.facesLeft)
			{
				SpriteEffects effects = SpriteEffects.FlipHorizontally;
				this.spriteBatch.Draw(this.tileTextures[this.playerData.PetsCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX + 32, (base.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.White, 0f, new Vector2(0f, 0f), effects, 0f);
				if (!this.isDead)
				{
					this.spriteBatch.Draw(this.tileTextures[this.playerData.WingCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX, (base.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.White, 0f, new Vector2(0f, 0f), effects, 0f);
				}
				if (this.IsStunning)
				{
					if (this.globalTimer % 2 == 0)
					{
						this.charSprite.Draw(this.ActualCameraX, this.guyX);
					}
				}
				else
				{
					this.charSprite.Draw(this.ActualCameraX, this.guyX);
				}
				if (!this.isDead)
				{
					this.spriteBatch.Draw(this.tileTextures[this.playerData.MaskCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX, (base.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.White, 0f, new Vector2(0f, 0f), effects, 0f);
				}
			}
			else
			{
				this.spriteBatch.Draw(this.tileTextures[this.playerData.PetsCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX - 32, (base.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.White);
				if (!this.isDead)
				{
					this.spriteBatch.Draw(this.tileTextures[this.playerData.WingCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX, (base.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.White);
				}
				if (this.IsStunning)
				{
					if (this.globalTimer % 2 == 0)
					{
						this.charSprite.Draw(this.ActualCameraX, this.guyX);
					}
				}
				else
				{
					this.charSprite.Draw(this.ActualCameraX, this.guyX);
				}
				if (!this.isDead)
				{
					this.spriteBatch.Draw(this.tileTextures[this.playerData.MaskCloth, 0], new Microsoft.Xna.Framework.Rectangle(this.guyX - this.ActualCameraX, (base.GraphicsDevice.Viewport.Height - 32) / 2, 32, 32), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, 32, 32)), Microsoft.Xna.Framework.Color.White);
				}
			}
			Vector2 vector = this.defaultFont2.MeasureString(this.playerData.PlayerName);
			if (this.theFlag != null)
			{
				this.spriteBatch.DrawString(this.defaultFont, this.playerData.PlayerName, new Vector2((float)((int)Math.Floor((double)(((float)((this.guyX - this.ActualCameraX) * 2) - vector.X - (float)this.theFlag.Width - 10f) / 2f + (float)this.theFlag.Width + 5f + 20f)) + 1), (float)((int)Math.Floor((double)(base.GraphicsDevice.Viewport.Height - 32) / 2.0 - 32.0) + 1)), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				if (this.playerData.PlayerName.StartsWith("@"))
				{
					this.spriteBatch.DrawString(this.defaultFont, this.playerData.PlayerName, new Vector2((float)((int)Math.Floor((double)(((float)((this.guyX - this.ActualCameraX) * 2) - vector.X - (float)this.theFlag.Width - 10f) / 2f + (float)this.theFlag.Width + 5f + 20f))), (float)((int)Math.Floor((double)(base.GraphicsDevice.Viewport.Height - 32) / 2.0 - 32.0))), Microsoft.Xna.Framework.Color.Goldenrod, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				}
				else
				{
					this.spriteBatch.DrawString(this.defaultFont, this.playerData.PlayerName, new Vector2((float)((int)Math.Floor((double)(((float)((this.guyX - this.ActualCameraX) * 2) - vector.X - (float)this.theFlag.Width - 10f) / 2f + (float)this.theFlag.Width + 5f + 20f))), (float)((int)Math.Floor((double)(base.GraphicsDevice.Viewport.Height - 32) / 2.0 - 32.0))), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				}
				this.spriteBatch.Draw(this.theFlag, new Microsoft.Xna.Framework.Rectangle((int)Math.Floor((double)(((float)((this.guyX - this.ActualCameraX) * 2) - vector.X - (float)this.theFlag.Width - 5f) / 2f + 20f)), (int)Math.Floor((double)(base.GraphicsDevice.Viewport.Height - 32) / 2.0 - 32.0), this.theFlag.Width, this.theFlag.Height), Microsoft.Xna.Framework.Color.White);
			}
			if (this.isPunching)
			{
				this.basicShapeEngine.DrawLinedTexture(this.center, this.posOnTheWayToCursor, this.FistOFury, 32);
			}
			if (this.dialogBoxShown)
			{
				Vector2 vector2 = this.defaultFont2.MeasureString(this.dialogBoxMessage);
				this.spriteBatch.Draw(this.flatPanel, new Microsoft.Xna.Framework.Rectangle((int)(((float)base.GraphicsDevice.Viewport.Width - (vector2.X + 5f)) / 2f), (int)((float)base.GraphicsDevice.Viewport.Height - (vector2.Y + 5f)) / 2 - 40, (int)vector2.X + 5, (int)vector2.Y + 5), this.dialogBoxColor);
				this.spriteBatch.DrawString(this.defaultFont, this.dialogBoxMessage, new Vector2((float)Math.Floor((double)(((float)base.GraphicsDevice.Viewport.Width - vector2.X) / 2f)), (float)Math.Floor((double)(((float)base.GraphicsDevice.Viewport.Height - vector2.Y) / 2f - 40f))), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				this.dialogBoxTimeout--;
				if (this.dialogBoxTimeout < 0)
				{
					this.dialogBoxShown = false;
					this.dialogBoxTimeout = 20;
				}
			}
			this.spriteBatch.Draw(this.handle, new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 86) / 2, this.handleY, 86, 24), Microsoft.Xna.Framework.Color.White);
			this.spriteBatch.Draw(this.panel, new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 640) / 2, this.handleY + 24, 640, 480), Microsoft.Xna.Framework.Color.White);
			this.DrawUI();
			for (int j = 0; j < 10; j++)
			{
				for (int k = 0; k < this.playerData.BackPackSlotsUpgraded; k++)
				{
					if (10 * k + j < this.Inventory.Length)
					{
						this.spriteBatch.Draw(this.slot, this.slotRectangles[j, k], ItemType.ItemTypeToColor(this.Inventory[10 * k + j].ID));
						if (this.Inventory[10 * k + j].ID == 0 && this.Inventory[10 * k + j].Amount >= 250)
						{
							this.spriteBatch.Draw(this.punchTexture, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5, this.slotRectangles[j, k].Y + 5, this.punchTexture.Width, this.punchTexture.Height), Microsoft.Xna.Framework.Color.White);
							if (this.selectedItem == 0)
							{
								this.spriteBatch.Draw(this.selectedItemFrame, this.slotRectangles[j, k], Microsoft.Xna.Framework.Color.White);
							}
						}
						else
						{
							int iD = this.Inventory[10 * k + j].ID;
							try
							{
								if (ItemData.IsPlantable(iD))
								{
									Microsoft.Xna.Framework.Color[] array = new Microsoft.Xna.Framework.Color[this.tileTextures[iD - 1, 0].Width * this.tileTextures[iD - 1, 0].Height];
									this.tileTextures[iD - 1, 0].GetData<Microsoft.Xna.Framework.Color>(array);
									if (array[this.colorIndex1].A > 254 && array[this.colorIndex2].A > 254)
									{
										this.spriteBatch.Draw(this.seedTexture, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5 + 8, this.slotRectangles[j, k].Y + 5 + 9, this.seedWidth, this.seedHeight), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, this.seedWidth, this.seedHeight)), array[this.colorIndex1]);
										this.spriteBatch.Draw(this.seedTexture, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5 + 8, this.slotRectangles[j, k].Y + 5 + 9, this.seedWidth, this.seedHeight), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(this.seedWidth, 0, this.seedWidth, this.seedHeight)), array[this.colorIndex2]);
									}
									else
									{
										int num = 0;
										int num2 = 0;
										int num3 = 0;
										bool flag = false;
										while (array[num].A > 254 && array[num2].A > 254)
										{
											for (int l = 0; l < array.Length; l++)
											{
												if (array[l].A > 254 && !flag)
												{
													num = l;
													l += 100;
													flag = true;
												}
												else if (array[l].A > 254 && flag)
												{
													num2 = l;
													break;
												}
											}
											if (num3 == 1)
											{
												break;
											}
											num3++;
										}
										if (num == 0)
										{
											num = 500;
										}
										if (num2 == 0)
										{
											num2 = 1000;
										}
										this.spriteBatch.Draw(this.seedTexture, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5 + 8, this.slotRectangles[j, k].Y + 5 + 9, this.seedWidth, this.seedHeight), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, 0, this.seedWidth, this.seedHeight)), array[num]);
										this.spriteBatch.Draw(this.seedTexture, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5 + 8, this.slotRectangles[j, k].Y + 5 + 9, this.seedWidth, this.seedHeight), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(this.seedWidth, 0, this.seedWidth, this.seedHeight)), array[num2]);
									}
								}
								else
								{
									Texture2D texture2D = this.tilePreviewTextures[iD, 0];
									this.spriteBatch.Draw(texture2D, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5, this.slotRectangles[j, k].Y + 5, texture2D.Width, texture2D.Height), Microsoft.Xna.Framework.Color.White);
								}
							}
							catch
							{
							}
							Vector2 vector3 = this.defaultFont2.MeasureString(this.Inventory[j + k * j].Amount.ToString());
							if (10 * k + j == this.selectedItem)
							{
								this.spriteBatch.Draw(this.selectedItemFrame, this.slotRectangles[j, k], Microsoft.Xna.Framework.Color.White);
							}
							if (this.Inventory[10 * k + j].ID != 0 && this.Inventory[10 * k + j].ID != 66)
							{
								this.spriteBatch.DrawString(this.defaultFont, this.Inventory[10 * k + j].Amount.ToString(), new Vector2((float)(this.slotRectangles[j, k].X + 42) - vector3.Y + 1f, (float)(this.slotRectangles[j, k].Y + 42) - vector3.Y + 1f), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
								this.spriteBatch.DrawString(this.defaultFont, this.Inventory[10 * k + j].Amount.ToString(), new Vector2((float)(this.slotRectangles[j, k].X + 42) - vector3.Y, (float)(this.slotRectangles[j, k].Y + 42) - vector3.Y), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
							}
							if ((this.playerData.WingCloth == iD || this.playerData.PetsCloth == iD) && iD != 0)
							{
								this.spriteBatch.Draw(this.checkmark, new Microsoft.Xna.Framework.Rectangle(this.slotRectangles[j, k].X + 5, this.slotRectangles[j, k].Y + 5, 32, 32), Microsoft.Xna.Framework.Color.White);
							}
						}
					}
				}
			}
			if (this.inputBoxShown)
			{
				this.spriteBatch.Draw(this.flatPanel, new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - 780) / 2, (base.GraphicsDevice.Viewport.Height - 125) / 2, 780, 125), Microsoft.Xna.Framework.Color.Blue);
				this.spriteBatch.DrawString(this.defaultFont, this.inputBoxTitle, new Vector2((float)((base.GraphicsDevice.Viewport.Width - 780) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - 125) / 2 + 15)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize * 2f, SpriteEffects.None, 1f);
				this.spriteBatch.DrawString(this.defaultFont, this.inputBoxResponse, new Vector2((float)((base.GraphicsDevice.Viewport.Width - 780) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - 125) / 2 + 70)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				this.spriteBatch.DrawString(this.defaultFont, this.inputBoxMessage, new Vector2((float)((base.GraphicsDevice.Viewport.Width - 780) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - 125) / 2 + 50)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				this.spriteBatch.DrawString(this.defaultFont, "Press ENTER to confirm action, or ESCAPE to cancel.", new Vector2((float)((base.GraphicsDevice.Viewport.Width - 780) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - 125) / 2 + 90)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
			}
			if (this.dialogBoxShown2)
			{
				Vector2 vector2 = this.defaultFont2.MeasureString(this.dialogBoxMessage2);
				vector2.X -= 20f;
				vector2.Y -= 20f;
				this.spriteBatch.Draw(this.panel, new Microsoft.Xna.Framework.Rectangle((int)(((float)base.GraphicsDevice.Viewport.Width - (vector2.X + 15f)) / 2f), (int)((float)base.GraphicsDevice.Viewport.Height - (vector2.Y + 15f)) / 2, (int)vector2.X + 40, (int)vector2.Y + 40), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 100));
				this.spriteBatch.DrawString(this.defaultFont, this.dialogBoxMessage2, new Vector2(((float)base.GraphicsDevice.Viewport.Width - vector2.X) / 2f, ((float)base.GraphicsDevice.Viewport.Height - vector2.Y) / 2f), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				this.dialogBoxTimeout2--;
				if (this.dialogBoxTimeout2 < 0)
				{
					this.dialogBoxShown2 = false;
					this.dialogBoxTimeout2 = 20;
				}
			}
			if (this.gazetteDlgShown)
			{
				this.spriteBatch.Draw(this.flatPanel, this.infoRectangle, Microsoft.Xna.Framework.Color.Blue);
				this.spriteBatch.Draw(this.FistOFury, new Vector2((float)(this.infoRectangle.X + 10), (float)(this.infoRectangle.Y + 10)), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.DrawString(this.defaultFont, "The Growalone Gazette", new Vector2((float)(this.infoRectangle.X + 50), (float)(this.infoRectangle.Y + 10)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize * 2f, SpriteEffects.None, 0f);
				this.spriteBatch.Draw(this.GazetteBadge, new Vector2((float)(this.infoRectangle.X + 10), (float)(this.infoRectangle.Y + 60)), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.DrawString(this.defaultFont, TheGrowaloneGazette.Text, new Vector2((float)(this.infoRectangle.X + 10), (float)(this.infoRectangle.Y + 70 + this.GazetteBadge.Height)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
				this.spriteBatch.DrawString(this.defaultFont, "Press ESC to exit.", new Vector2((float)(this.infoRectangle.X + 10), (float)(this.infoRectangle.Y + 420 - 40)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
			}
		}

		protected override void Draw(GameTime gameTime)
		{
			this.starSprite.Update();
			if (this.Screen == ScreenType.Playground)
			{
				switch (this.world.weatherMachine)
				{
				case WeatherMachine.Sunny:
					base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.FromNonPremultiplied(129, 203, 255, 255));
					break;
				case WeatherMachine.Night:
					base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 41, 100, 255));
					break;
				case WeatherMachine.Space:
					base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 255));
					break;
				}
			}
			else
			{
				ScreenType screen = this.Screen;
				if (screen != ScreenType.WorldSelect)
				{
					switch (screen)
					{
					case ScreenType.OptionsMenu:
					case ScreenType.AboutScreen:
						goto IL_D7;
					case ScreenType.GalleryOfWorlds:
						base.GraphicsDevice.Clear(this.gow.clearColor);
						goto IL_13B;
					}
					base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.FromNonPremultiplied(129, 203, 255, 255));
					goto IL_13B;
				}
				IL_D7:
				base.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.FromNonPremultiplied(64, 128, 230, 255));
				IL_13B:;
			}
			this.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);
			if (this.Screen == ScreenType.Playground)
			{
				if (this.playerData.DoesShowFancyGraphics)
				{
					switch (this.world.weatherMachine)
					{
					case WeatherMachine.Sunny:
						this.spriteBatch.Draw(this.Skies[0], new Microsoft.Xna.Framework.Rectangle(0, 0, base.GraphicsDevice.Viewport.Width, base.GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.sun, new Microsoft.Xna.Framework.Rectangle(50, 50, 128, 128), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.mnt1, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4, -this.cameraY / 32, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4 * 2 + -2048, -this.cameraY / 32 * 2, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4 * 2, -this.cameraY / 32 * 2, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4 * 2 + 2048, -this.cameraY / 32 * 2, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.White);
						break;
					case WeatherMachine.Night:
						this.spriteBatch.Draw(this.Skies[1], new Microsoft.Xna.Framework.Rectangle(0, 0, base.GraphicsDevice.Viewport.Width, base.GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.Moon, new Microsoft.Xna.Framework.Rectangle(50, 50, 128, 128), Microsoft.Xna.Framework.Color.White);
						this.spriteBatch.Draw(this.mnt1, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4, -this.cameraY / 32, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.Gray);
						this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4 * 2 + -2048, -this.cameraY / 32 * 2, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.Gray);
						this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4 * 2, -this.cameraY / 32 * 2, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.Gray);
						this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.ActualCameraX / 4 * 2 + 2048, -this.cameraY / 32 * 2, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), (int)((float)base.GraphicsDevice.Viewport.Height * 1.5f)), Microsoft.Xna.Framework.Color.Gray);
						break;
					case WeatherMachine.Space:
						this.spriteBatch.Draw(this.spaceBackground, new Microsoft.Xna.Framework.Rectangle(0, 0, 2048, 1536), Microsoft.Xna.Framework.Color.White);
						break;
					}
				}
				if (this.playerData.DoesShowFancyGraphics)
				{
					this.DrawPlaygroundShadows(3);
				}
				this.DrawPlayground();
				this.fontEngine.DrawString(string.Concat(new string[]
				{
					"CAMX ",
					this.ActualCameraX.ToString(),
					"\nPOSX ",
					this.cameraX.ToString(),
					"\nPOSY ",
					this.cameraY.ToString(),
					"\nSTAT ",
					this.charSprite.ToString(),
					"\nOBJC ",
					this.GetObjNo().ToString()
				}), 3f, new Vector2(10f, 100f));
				Vector2 vector = this.defaultFont2.MeasureString(this.playerData.Gems.ToString("#,###,###,##0"));
				this.fontEngine.DrawString("X" + this.playerData.Gems.ToString("#,###,###,##0"), 3f, new Vector2((float)(base.GraphicsDevice.Viewport.Width - 700 + 40), 17f));
				this.spriteBatch.Draw(this.coinTex, new Microsoft.Xna.Framework.Rectangle(base.GraphicsDevice.Viewport.Width - 700 + 3, 13, 32, 32), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127));
				this.spriteBatch.Draw(this.coinTex, new Microsoft.Xna.Framework.Rectangle(base.GraphicsDevice.Viewport.Width - 700, 10, 32, 32), Microsoft.Xna.Framework.Color.White);
				this.starSprite.Draw(base.GraphicsDevice.Viewport.Width - 230, 10, 3);
				this.starSprite.Draw(base.GraphicsDevice.Viewport.Width - 230, 10);
				this.fontEngine.DrawString("X" + this.playerData.Stars.ToString(), 3f, new Vector2((float)(base.GraphicsDevice.Viewport.Width - 190), 17f));
			}
			else if (this.Screen == ScreenType.TitleScreen)
			{
				this.spriteBatch.Draw(this.sun, new Microsoft.Xna.Framework.Rectangle(50, 50, 128, 128), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.mnt1, new Microsoft.Xna.Framework.Rectangle(-this.Mnt1X, 0, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), base.GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.mnt1, new Microsoft.Xna.Framework.Rectangle(-this.Mnt1X + 3000, 0, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), base.GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.Mnt2X, 0, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), base.GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.mnt2, new Microsoft.Xna.Framework.Rectangle(-this.Mnt2X + 3000, 0, (int)((float)base.GraphicsDevice.Viewport.Width * 3.75f), base.GraphicsDevice.Viewport.Height), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.startGameBtnTex, this.startBtnRect, Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.exitGameBtnTex, this.exitBtnRect, Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.optionsBtnTex, this.optionsBtnRect, Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.GOW_ButtonTex, this.gowBtnRect, Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.aboutBtnTex, this.aboutBtnRect, Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.iProgramMC_Logo, new Microsoft.Xna.Framework.Rectangle(base.GraphicsDevice.Viewport.Width - 10 - 128, base.GraphicsDevice.Viewport.Height - 32 - 10, 128, 32), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.GrowaloneLogo, new Vector2((float)this.GrowaloneLogoRect.X, (float)this.GrowaloneLogoRect.Y), null, Microsoft.Xna.Framework.Color.White, this.rotationOfLogo, new Vector2((float)(this.GrowaloneLogo.Width / 2), (float)(this.GrowaloneLogo.Height / 2)), this.scaleOfLogo, SpriteEffects.None, 0f);
				if (this.currentTime.Day == 5 && this.currentTime.Month == 10)
				{
					Vector2 vector2 = this.defaultFont2.MeasureString("Happy Birthday, iProgramMC!");
					this.spriteBatch.DrawString(this.defaultFont, "Happy Birthday, iProgramMC!", new Vector2((float)Math.Floor((double)(((float)base.GraphicsDevice.Viewport.Width - vector2.X) / 2f)), (float)(base.GraphicsDevice.Viewport.Height - 20)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				}
				else
				{
					Vector2 vector2 = this.defaultFont2.MeasureString(this.splashes[this.splashSel]);
					this.spriteBatch.DrawString(this.defaultFont, this.splashes[this.splashSel], new Vector2((float)Math.Floor((double)(((float)base.GraphicsDevice.Viewport.Width - vector2.X) / 2f)), (float)(base.GraphicsDevice.Viewport.Height - 20)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				}
				if (this.worldSelectText != "Type in a world name then press 'Enter World'!")
				{
					this.worldSelectText = "Type in a world name then press 'Enter World'!";
				}
				if (this.isDeveloper)
				{
					this.spriteBatch.DrawString(this.defaultFont2, "UNFINISHED!!! (Just adding this watermark)", new Vector2(300f, 300f), Microsoft.Xna.Framework.Color.DarkRed);
				}
			}
			else if (this.Screen == ScreenType.WorldSelect)
			{
				float num = MathHelper.Max((float)base.GraphicsDevice.Viewport.Height, (float)base.GraphicsDevice.Viewport.Width) / 330f;
				this.spriteBatch.Draw(this.UIBackground, new Microsoft.Xna.Framework.Rectangle((int)(((float)base.GraphicsDevice.Viewport.Width - (float)this.UIBackground.Width * num) / 2f), (int)(((float)base.GraphicsDevice.Viewport.Height - (float)this.UIBackground.Height * num) / 2f), (int)((float)this.UIBackground.Width * num), (int)((float)this.UIBackground.Height * num)), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.DrawString(this.defaultFont, this.worldSelectText, new Vector2(150f, 10f), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
				this.basicShapeEngine.DrawRectangle(this.textBoxRect, Microsoft.Xna.Framework.Color.Black);
				if (this.nameInTextBox == null)
				{
					this.nameInTextBox = "";
				}
				else
				{
					this.spriteBatch.DrawString(this.defaultFont, this.nameInTextBox, new Vector2(152f, 32f), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				}
				this.spriteBatch.DrawString(this.defaultFont, "World Name: ", new Vector2(32f, 32f), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				this.spriteBatch.Draw(this.enterWorldTex, this.goInGameRect, Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.BackToTitleTex, this.BackToTitleRect, Microsoft.Xna.Framework.Color.White);
				int num2 = 0;
				World.WorldButton[] array = this.worldBtns;
				for (int i = 0; i < array.Length; i++)
				{
					World.WorldButton worldButton = array[i];
					if (worldButton != null)
					{
						if (worldButton.Initialized)
						{
							worldButton.Draw();
							num2++;
						}
					}
				}
				if (num2 == 0)
				{
					this.spriteBatch.DrawString(this.defaultFont, "You currently don't have a world. Create one by typing the world name. You can always type a new world name to create a world...", new Vector2(40f, 69f), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
				}
			}
			else if (this.Screen == ScreenType.ShopScreen)
			{
				float num = MathHelper.Max((float)base.GraphicsDevice.Viewport.Height, (float)base.GraphicsDevice.Viewport.Width) / 330f;
				this.spriteBatch.Draw(this.UIBackground, new Microsoft.Xna.Framework.Rectangle((int)(((float)base.GraphicsDevice.Viewport.Width - (float)this.UIBackground.Width * num) / 2f), (int)(((float)base.GraphicsDevice.Viewport.Height - (float)this.UIBackground.Height * num) / 2f), (int)((float)this.UIBackground.Width * num), (int)((float)this.UIBackground.Height * num)), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[1], this.craftRectangles[1], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[2], this.craftRectangles[2], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[3], this.craftRectangles[3], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[4], this.craftRectangles[4], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[0], this.craftRectangles[0], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[6], this.craftRectangles[6], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[7], this.craftRectangles[7], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[8], this.craftRectangles[8], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[9], this.craftRectangles[9], Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.shopItemSprites[10], this.craftRectangles[10], Microsoft.Xna.Framework.Color.White);
				if (this.currentTime.Month == 10 && this.currentTime.Day == 5)
				{
					this.spriteBatch.Draw(this.shopItemSprites[5], this.craftRectangles[5], Microsoft.Xna.Framework.Color.White);
				}
				Vector2 vector = this.defaultFont2.MeasureString(this.playerData.Gems.ToString("#,###,###,##0"));
				this.fontEngine.DrawString("X" + this.playerData.Gems.ToString("#,###,###,##0"), 2f, new Vector2((float)(base.GraphicsDevice.Viewport.Width - 300 + 30), 17f));
				this.spriteBatch.Draw(this.coinTex, new Microsoft.Xna.Framework.Rectangle(base.GraphicsDevice.Viewport.Width - 300 + 3, 13, 24, 24), Microsoft.Xna.Framework.Color.FromNonPremultiplied(0, 0, 0, 127));
				this.spriteBatch.Draw(this.coinTex, new Microsoft.Xna.Framework.Rectangle(base.GraphicsDevice.Viewport.Width - 300, 10, 24, 24), Microsoft.Xna.Framework.Color.White);
				this.fontEngine.DrawString("Playername: " + this.playerData.PlayerName, 2f, new Vector2(10f, 13f));
				if (this.isDeveloper)
				{
					this.spriteBatch.Draw(this.devPage0T, this.devPage0R, Microsoft.Xna.Framework.Color.White);
					this.spriteBatch.Draw(this.devPage1T, this.devPage1R, Microsoft.Xna.Framework.Color.White);
				}
			}
			else if (this.Screen == ScreenType.AboutScreen)
			{
				float num = MathHelper.Max((float)base.GraphicsDevice.Viewport.Height, (float)base.GraphicsDevice.Viewport.Width) / 330f;
				this.spriteBatch.Draw(this.UIBackground, new Microsoft.Xna.Framework.Rectangle((int)(((float)base.GraphicsDevice.Viewport.Width - (float)this.UIBackground.Width * num) / 2f), (int)(((float)base.GraphicsDevice.Viewport.Height - (float)this.UIBackground.Height * num) / 2f), (int)((float)this.UIBackground.Width * num), (int)((float)this.UIBackground.Height * num)), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.DrawString(this.defaultFont, AboutScreen.Title, new Vector2(10f, (float)this.AboutScreenPosition), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize * 2.5f, SpriteEffects.None, 0f);
				this.spriteBatch.DrawString(this.defaultFont, AboutScreen.Text, new Vector2(10f, (float)(this.AboutScreenPosition + 40)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
				this.spriteBatch.Draw(this.BackToTitleTex, this.BackToTitleRect, Microsoft.Xna.Framework.Color.White);
			}
			else if (this.Screen == ScreenType.OptionsMenu)
			{
				float num = MathHelper.Max((float)base.GraphicsDevice.Viewport.Height, (float)base.GraphicsDevice.Viewport.Width) / 330f;
				this.spriteBatch.Draw(this.UIBackground, new Microsoft.Xna.Framework.Rectangle((int)(((float)base.GraphicsDevice.Viewport.Width - (float)this.UIBackground.Width * num) / 2f), (int)(((float)base.GraphicsDevice.Viewport.Height - (float)this.UIBackground.Height * num) / 2f), (int)((float)this.UIBackground.Width * num), (int)((float)this.UIBackground.Height * num)), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.DrawString(this.defaultFont, "Options Menu", new Vector2(10f, 10f), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize * 2f, SpriteEffects.None, 0f);
				this.spriteBatch.Draw(this.Checkbox, this.FullScreenButtonRect, Microsoft.Xna.Framework.Color.White);
				if (this.graphics.IsFullScreen)
				{
					this.spriteBatch.Draw(this.checkmark, new Microsoft.Xna.Framework.Rectangle(-2, 88, 32, 32), Microsoft.Xna.Framework.Color.White);
				}
				this.spriteBatch.Draw(this.Checkbox, this.ShowFancyGfxButtonRect, Microsoft.Xna.Framework.Color.White);
				if (this.playerData.DoesShowFancyGraphics)
				{
					this.spriteBatch.Draw(this.checkmark, new Microsoft.Xna.Framework.Rectangle(-2, 138, 32, 32), Microsoft.Xna.Framework.Color.White);
				}
				this.spriteBatch.DrawString(this.defaultFont, "Enable fullscreen mode", new Vector2(50f, 100f), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
				this.spriteBatch.DrawString(this.defaultFont, "Enable fancy graphic details", new Vector2(50f, 150f), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 0f);
				this.spriteBatch.Draw(this.BackToTitleTex, this.BackToTitleRect, Microsoft.Xna.Framework.Color.White);
			}
			else if (this.Screen != ScreenType.Achievements)
			{
				if (this.Screen == ScreenType.GalleryOfWorlds)
				{
					this.gow.Draw(this);
				}
			}
			if (this.msgBoxShown)
			{
				Vector2 value = this.defaultFont.MeasureString(this.msgBoxTitle);
				Vector2 vector3 = this.defaultFont2.MeasureString(this.msgBoxMessage);
				Vector2 vector4 = this.defaultFont2.MeasureString("Press ENTER to confirm action, or ESCAPE to cancel it.");
				int num3 = (int)Math.Max(Math.Max(value.X / 2f + 30f, vector3.X + 30f), vector4.X + 30f);
				int num4 = (int)(value.Y / 2f + vector3.Y + vector4.Y + 30f);
				this.spriteBatch.Draw(this.flatPanel, new Microsoft.Xna.Framework.Rectangle((base.GraphicsDevice.Viewport.Width - num3) / 2, (base.GraphicsDevice.Viewport.Height - num4) / 2, num3, num4), Microsoft.Xna.Framework.Color.Blue);
				this.spriteBatch.DrawString(this.defaultFont, this.msgBoxTitle, new Vector2((float)((base.GraphicsDevice.Viewport.Width - num3) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - num4) / 2 + 15)), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize * 2f, SpriteEffects.None, 1f);
				this.spriteBatch.DrawString(this.defaultFont, this.msgBoxMessage, new Vector2((float)((base.GraphicsDevice.Viewport.Width - num3) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - num4) / 2 + 15) + value.Y / 2f + 10f), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
				this.spriteBatch.DrawString(this.defaultFont, "Press ENTER to confirm action, or ESCAPE to cancel it.", new Vector2((float)((base.GraphicsDevice.Viewport.Width - num3) / 2 + 15), (float)((base.GraphicsDevice.Viewport.Height - num4) / 2 + 15) + (value / 2f).Y + 10f + vector3.Y), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
			}
			MouseState state = Mouse.GetState();
			if (this.Screen == ScreenType.TitleScreen || this.Screen == ScreenType.ShopScreen || this.Screen == ScreenType.WorldSelect)
			{
				this.spriteBatch.Draw(this.cursors[0], new Microsoft.Xna.Framework.Rectangle(state.X, state.Y, 35, 35), Microsoft.Xna.Framework.Color.White);
			}
			else if (this.Inventory[this.selectedItem].ID == 0)
			{
				this.spriteBatch.Draw(this.cursors[1], new Microsoft.Xna.Framework.Rectangle(state.X, state.Y, 35, 35), Microsoft.Xna.Framework.Color.White);
			}
			else if (this.Inventory[this.selectedItem].ID == 66)
			{
				this.spriteBatch.Draw(this.cursors[4], new Microsoft.Xna.Framework.Rectangle(state.X, state.Y, 35, 35), Microsoft.Xna.Framework.Color.White);
			}
			else if (!ItemData.IsPlantable(this.Inventory[this.selectedItem].ID))
			{
				this.spriteBatch.Draw(this.cursors[2], new Microsoft.Xna.Framework.Rectangle(state.X, state.Y, 35, 35), Microsoft.Xna.Framework.Color.White);
				this.spriteBatch.Draw(this.tileTextures[this.Inventory[this.selectedItem].ID, 0], new Microsoft.Xna.Framework.Rectangle(state.X + 25, state.Y + 25, this.tileTextures[this.Inventory[this.selectedItem].ID, 0].Width, this.tileTextures[this.Inventory[this.selectedItem].ID, 0].Height), Microsoft.Xna.Framework.Color.White);
			}
			else if (ItemData.IsPlantable(this.Inventory[this.selectedItem].ID))
			{
				this.spriteBatch.Draw(this.cursors[3], new Microsoft.Xna.Framework.Rectangle(state.X, state.Y, 35, 35), Microsoft.Xna.Framework.Color.White);
				if (this.tileTextures[this.Inventory[this.selectedItem].ID, 0] != null)
				{
					this.spriteBatch.Draw(this.tileTextures[this.Inventory[this.selectedItem].ID, 0], new Microsoft.Xna.Framework.Rectangle(state.X + 25, state.Y + 25, this.tileTextures[this.Inventory[this.selectedItem].ID, 0].Width, this.tileTextures[this.Inventory[this.selectedItem].ID, 0].Height), Microsoft.Xna.Framework.Color.White);
				}
			}
			if (this.fpsShown)
			{
				this.spriteBatch.DrawString(this.defaultFont, this.FPS.ToString() + " fps (Experimental, only shows how many draws have occured in one second)", new Vector2(10f, 10f), Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, this.fontSize, SpriteEffects.None, 1f);
			}
			this.spriteBatch.End();
			base.Draw(gameTime);
			this.calcFPS++;
		}

		public void CheckForIllegalItems()
		{
			for (int i = 0; i < this.Inventory.Length; i++)
			{
				if (ItemData.ReturnItemName(this.Inventory[i].ID) == " Seed" || ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID) == "" || ItemData.ReturnItemName(this.Inventory[i].ID) == "Bedrock" || ItemData.ReturnItemName(this.Inventory[i].ID) == "Bedrock Seed" || ItemData.ReturnItemName(this.Inventory[i].ID) == "Main Door" || ItemData.ReturnItemName(this.Inventory[i].ID) == "Main Door Seed" || ItemData.ReturnItemName(this.Inventory[i].ID) == "Unknown item" || ItemData.ReturnItemName(this.Inventory[i].ID) == "Unknown item Seed")
				{
					this.Inventory[i] = new Item();
				}
				if (this.Inventory[i].Amount == 0)
				{
					this.Inventory[i] = new Item();
				}
				if (ItemData.ReturnItemName(this.Inventory[i].ID) == "iProgramMC's Code Wings Seed" || ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID) == "iProgramMC's Code Wings")
				{
					this.Inventory[i] = new Item();
				}
			}
		}

		public void UpdateEverySecond()
		{
			this.FPS = this.calcFPS;
			this.calcFPS = 0;
			this.timeout++;
			if (this.timeout % this.GamerNPCTimeout == 0 && this.timeout > 0)
			{
				int num = new Random().Next(0, 100);
				int num2 = new Random().Next(0, 57);
				while (this.world.Map[num, num2, 0].ID != 0 || this.world.Map[num, num2 + 1, 0].ID == 0)
				{
					num = new Random().Next(0, 100);
					num2 = new Random().Next(0, 57);
				}
				this.world.Map[num, num2, 0].ID = 76;
				this.ShowDialog2("A Gamer has appeared! He's asking you to help him fix his PC for a thousand gems. Doesn't it sound great?!", 100);
			}
		}

		public void GetButtonPressOnPlayground()
		{
			GamePadState state = GamePad.GetState(PlayerIndex.One);
			KeyboardState state2 = Keyboard.GetState();
			this.charSprite.Update();
			if (state.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed && state.Buttons.X == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevGPState.Buttons.X != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				this.ShowInputBox(new ExecuteCommandAction(this), "Enter a command to execute.", ">_", "OK");
			}
			if (state.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed && state.Buttons.Y == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevGPState.Buttons.Y != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				if (ItemData.IsRemovable(this.Inventory[this.selectedItem].ID))
				{
					string s = InputBoxGrowalone.ShowInputBox("How many to drop?", "Drop " + ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID), this);
					int num;
					if (int.TryParse(s, out num))
					{
						if (num > 0 && num <= this.Inventory[this.selectedItem].Amount)
						{
							if (!this.facesLeft)
							{
								this.world.DropItem(this.Inventory[this.selectedItem].ID, (byte)num, this.guyX + 40, this.guyY - 24, this);
							}
							else
							{
								this.world.DropItem(this.Inventory[this.selectedItem].ID, (byte)num, this.guyX - 40, this.guyY - 24, this);
							}
							this.DrainItem(this.selectedItem, num);
						}
						else if (num < this.Inventory[this.selectedItem].Amount && num < 1)
						{
							this.ShowDialog("number.isNegative() returned TRUE. Does not compute.", 200);
						}
						else
						{
							this.ShowDialog("I can't drop more than I have.", 200);
						}
					}
					else
					{
						this.ShowDialog("Type in a NUMBER of items to drop. Not a sentence.", 200);
					}
				}
				else
				{
					this.ShowDialog2("This item cannot be dropped!");
				}
			}
			if (state.Buttons.RightShoulder != Microsoft.Xna.Framework.Input.ButtonState.Pressed && state.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				if (!this.isDead)
				{
					this.Jump();
					if (!this.JumpEffPlay)
					{
						this.JumpEffect.Play();
						this.JumpEffPlay = true;
					}
					if (this.charSprite.mode == CharacterAnimatedSpriteMode.Walking || this.charSprite.mode == CharacterAnimatedSpriteMode.Still)
					{
						this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Jumping);
					}
				}
			}
			else
			{
				this.Fall();
				this.JumpEffPlay = false;
			}
			if (state.Buttons.RightShoulder != Microsoft.Xna.Framework.Input.ButtonState.Pressed && state.Buttons.Y == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevGPState.Buttons.Y != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				if (this.handleY < base.GraphicsDevice.Viewport.Height - 100)
				{
					this.handleY = base.GraphicsDevice.Viewport.Height - 100;
				}
				else
				{
					this.handleY = base.GraphicsDevice.Viewport.Height - 600;
				}
			}
			if (state.Buttons.X == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				string text = InputBoxGrowalone.ShowInputBox("What would you like to say?", "Say Something", this);
				if (text != "")
				{
					this.ShowDialog(text, 200);
				}
			}
			if (state.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed && state.Buttons.B == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevGPState.Buttons.B != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				this.ShowMsgBox(new DefaultMsgAction(), ItemData.ReturnItemInfo(this.Inventory[this.selectedItem].ID), "About " + ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID));
			}
			if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Pause))
			{
				string a = InputBoxGrowalone.ShowInputBox("verification required to prevent fraudulent access, click 'ok' to analyze, all caps", "COHERENCE INVIOLATE. REDIRECT CARTOGRAPHY. SECURE DIRECTIVE", this);
				if (a == string.Concat(new object[]
				{
					'K',
					'I',
					'L',
					'I',
					'M',
					'A'
				}))
				{
					MessageBox.Show("ANALYSIS COMPLETE.\r\n. . . . .\r\n\r\nDATA FILE ACCESSED: file.txt (content:\r\n\r\n'\r\nyou have just been given four amazing items in amounts of 999. by breaking them you get others. as a bonus. it's dangerous to go alone so take these with you. - iProgramInCpp\r\n'\r\n\r\n. . . . . .\r\n\r\nFURTHER PROCESSING REQUIRED.", "COHERENCE INVIOLATE. REDIRECT CARTOGRAPHY. SECURE DIRECTIVE");
					this.AddItem(32, 999);
					this.AddItem(33, 999);
					this.AddItem(34, 999);
					this.AddItem(35, 999);
					this.AddItem(36, 999);
					this.AddItem(37, 999);
				}
			}
			if (state.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed && state.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed && this.prevGPState.Buttons.A != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				if (ItemData.IsRemovable(this.Inventory[this.selectedItem].ID))
				{
					this.ShowMsgBox(new TrashItemAction(this.Inventory, this.selectedItem), string.Concat(new object[]
					{
						"Are you sure you want to trash ",
						this.Inventory[this.selectedItem].Amount,
						" ",
						ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID),
						"? You will not be able to get them back ever again!"
					}), "Trash " + ItemData.ReturnItemName(this.Inventory[this.selectedItem].ID));
				}
				else
				{
					this.ShowDialog2("This item cannot be trashed!");
				}
			}
			if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.Escape))
			{
				if (this.inputBoxShown && !this.keyDownEsc)
				{
					this.inputBoxShown = false;
					this.keyDownEsc = true;
				}
				if (this.gazetteDlgShown && !this.keyDownEsc)
				{
					this.gazetteDlgShown = false;
					this.keyDownEsc = true;
				}
				else if (!this.keyDownEsc && this.Screen != ScreenType.TitleScreen)
				{
					this.Screen = ScreenType.TitleScreen;
					this.keyDownEsc = true;
					DataHandler.SaveMap(this.world, "C:\\growalone_maps\\worlds\\" + this.TheWorldName + ".gaw");
				}
				else if (!this.keyDownEsc)
				{
					Application.Exit();
				}
				this.splashSel = new Random().Next(0, this.splashes.Length);
			}
			else
			{
				this.keyDownEsc = false;
			}
			if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.A))
			{
				if (!this.isDead)
				{
					try
					{
						if (this.charSprite.mode != CharacterAnimatedSpriteMode.Jumping && this.charSprite.mode != CharacterAnimatedSpriteMode.Falling && this.charSprite.mode != CharacterAnimatedSpriteMode.Walking)
						{
							this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Walking);
						}
						int num2 = (int)Math.Floor((double)this.e / 32.0);
						int num3 = (int)Math.Floor((double)this.g / 32.0);
						num3--;
						if (this.world.Map[this.e321, this.j321, 0].ID == 86)
						{
							this.cameraX -= 3;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 0 || this.collided[this.world.Map[num2, num3, 0].ID] == 2)
						{
							this.cameraX -= 5;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 3)
						{
							this.tickWhenWasKilled = this.globalTimer;
							this.isDead = true;
						}
						this.facesLeft = true;
					}
					catch (Exception ex)
					{
						string message = ex.Message;
					}
					this.WalkEffectInstance.Play();
				}
			}
			else if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.D))
			{
				if (!this.isDead)
				{
					try
					{
						if (this.charSprite.mode != CharacterAnimatedSpriteMode.Jumping && this.charSprite.mode != CharacterAnimatedSpriteMode.Falling && this.charSprite.mode != CharacterAnimatedSpriteMode.Walking)
						{
							this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Walking);
						}
						int num2 = (int)Math.Floor((double)this.e / 32.0);
						int num3 = (int)Math.Floor((double)this.g / 32.0);
						num2++;
						num3--;
						if (this.world.Map[this.e321, this.j321, 0].ID == 86)
						{
							this.cameraX += 3;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 0 || this.collided[this.world.Map[num2, num3, 0].ID] == 2)
						{
							this.cameraX += 5;
						}
						else if (this.collided[this.world.Map[num2, num3, 0].ID] == 3)
						{
							this.tickWhenWasKilled = this.globalTimer;
							this.isDead = true;
						}
						this.facesLeft = false;
					}
					catch (Exception ex)
					{
						string message = ex.Message;
					}
					this.WalkEffectInstance.Play();
				}
			}
			else
			{
				this.speed = 1;
				this.keyDownChangeInv = false;
				this.jumps = false;
				this.WalkEffectInstance.Stop();
				if (this.charSprite.mode == CharacterAnimatedSpriteMode.Walking && this.charSprite.mode != CharacterAnimatedSpriteMode.Still)
				{
					this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Still);
				}
			}
			if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.C))
			{
				if (!this.keyPressedEnCr)
				{
					this.keyPressedEnCr = true;
					if (this.Screen != ScreenType.ShopScreen)
					{
						this.Screen = ScreenType.ShopScreen;
					}
					else
					{
						this.Screen = ScreenType.Playground;
					}
				}
			}
			else
			{
				this.keyPressedEnCr = false;
			}
			if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.P))
			{
				Vector2 vector = new Vector2((float)(base.GraphicsDevice.Viewport.Width / 2), (float)(base.GraphicsDevice.Viewport.Height / 2));
				Vector2 vector2 = vector;
				if (this.facesLeft)
				{
					vector2 = new Vector2(vector.X - 32f, vector.Y);
				}
				else
				{
					vector2 = new Vector2(vector.X + 32f, vector.Y);
				}
				this.PlaceBlock(new MouseState((int)vector2.X, (int)vector2.Y, 0, Microsoft.Xna.Framework.Input.ButtonState.Pressed, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released));
			}
			if (state2.GetPressedKeys().Contains(Microsoft.Xna.Framework.Input.Keys.S))
			{
				this.charSprite.SetAnimation(CharacterAnimatedSpriteMode.Crouching);
			}
		}

		public double GetAspectRatio()
		{
			return (double)base.GraphicsDevice.DisplayMode.AspectRatio;
		}

		public int GetObjNo()
		{
			int num = 0;
			WorldItem[] worldItems = this.world.worldItems;
			for (int i = 0; i < worldItems.Length; i++)
			{
				WorldItem worldItem = worldItems[i];
				if (worldItem == null || (worldItem.PosX == -100 && worldItem.PosY == -100))
				{
					num++;
				}
			}
			return 1024 - num;
		}
	}
}
