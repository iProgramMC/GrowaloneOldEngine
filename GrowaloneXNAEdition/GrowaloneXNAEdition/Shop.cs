using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	public class Shop
	{
		public static void UpgradeBackpack(Growalone growalone, PlayerData playerData)
		{
			Item[] array = new Item[growalone.Inventory.Length];
			playerData.BackPackSlotsUpgraded++;
			array = growalone.Inventory;
			growalone.Inventory = new Item[playerData.BackPackSlotsUpgraded * 10];
			for (int i = 0; i < growalone.Inventory.Length; i++)
			{
				growalone.Inventory[i] = new Item();
			}
			int num = Math.Min(array.Length, growalone.Inventory.Length);
			for (int i = 0; i < num; i++)
			{
				growalone.Inventory[i] = array[i];
			}
		}

		public static void BuyItem(PlayerData playerData, Item[] inventory, Rectangle[] craftRectangles, MouseState mouseState, Growalone growalone)
		{
			Point value = new Point(mouseState.X, mouseState.Y);
			if (craftRectangles[1].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a Small Lock costs 50 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 50)
					{
						if (!growalone.AddItem(26))
						{
							MessageBox.Show("You can't buy a Small Lock for 50 gems :(. You will need to trash some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 50;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Small Lock.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[2].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a Medium Lock costs 100 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 100)
					{
						if (!growalone.AddItem(28))
						{
							MessageBox.Show("You can't buy a Medium Lock for 100 Coins :(. You will need to trash some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 100;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Medium Lock.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[3].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a Large Lock costs 200 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 200)
					{
						if (!growalone.AddItem(30))
						{
							MessageBox.Show("You can't buy a Large Lock for 200 gems :(. You will need to trash some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 200;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Large Lock.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[4].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a World Lock costs 500 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 500)
					{
						if (!growalone.AddItem(38))
						{
							MessageBox.Show("You can't buy a World Lock for 500 Coins :(. You will need to trash some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 500;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 World Lock.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[0].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Getting an Inventory Upgrade costs 50 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 50 && playerData.BackPackSlotsUpgraded < 8)
					{
						Shop.UpgradeBackpack(growalone, playerData);
						playerData.Gems -= 50;
						MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Inventory Upgrade.", "Purchase Successful!");
					}
					else if (playerData.Gems >= 50 && playerData.BackPackSlotsUpgraded >= 8)
					{
						MessageBox.Show("You can't upgrade your backpack anymore! Why would you need more space in the first place?!", "Purchase Failed");
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[5].Contains(value))
			{
				if (DateTime.Now.Month == 10 && DateTime.Now.Day == 5)
				{
					DialogResult dialogResult = MessageBox.Show("Buying a Cake costs 1 Coin. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.Yes)
					{
						if (playerData.Gems >= 1)
						{
							if (!growalone.AddItem(96))
							{
								MessageBox.Show("You can't buy a Cake for 1 Coin :(. You will need to trash or drop some items before continuing.", "Not enough space!");
							}
							else
							{
								playerData.Gems--;
								MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Cake.", "Purchase Successful!");
							}
						}
						else
						{
							MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
						}
					}
				}
				else
				{
					MessageBox.Show("No more cakes! I guess you had enough! This shop is closed!", "Purchase Failed");
				}
			}
			else if (craftRectangles[6].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a Crown costs 600 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 600)
					{
						if (!growalone.AddItem(102))
						{
							MessageBox.Show("You can't buy a Crown for 600 Coins :(. You will need to trash or drop some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 600;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Crown.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[7].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a pair of devil wings costs 2,000 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 2000)
					{
						if (!growalone.AddItem(88))
						{
							MessageBox.Show("You can't buy a pair of devil wings for 2,000 Coins :(. You will need to trash or drop some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 2000;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Devil Wings.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[8].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying the Nature pack costs 50 Coins.\r\n\r\nThe pack contains:\r\n- 50 Roses\r\n- 50 Dandelions\r\n- 50 Bushes\r\n- 50 Saplings\r\n\r\nAre you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 50)
					{
						byte amountOfFreeSlots = growalone.GetAmountOfFreeSlots();
						if (amountOfFreeSlots < 4)
						{
							MessageBox.Show("You can't buy the Nature pack for 50 Coins :(. You will need to trash or drop some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 50;
							growalone.AddItem(14, 50);
							growalone.AddItem(100, 50);
							growalone.AddItem(128, 50);
							growalone.AddItem(116, 50);
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot: 50 Roses, 50 Dandelions, 50 Bushes and 50 Saplings.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[9].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying the Furniture pack costs 150 Coins. \r\n\r\nYou will get 4 random items in different amounts.\r\nThe items you can get are shown here:\r\n\r\n- Wooden Chair\r\n- Wooden Table\r\n- Sign\r\n- Holographic Sign\r\n- Desktop PC\r\n- Beachy Painting\r\n- Chest\r\n- Coinbox\r\n\r\nAre you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 100)
					{
						byte amountOfFreeSlots = growalone.GetAmountOfFreeSlots();
						if (amountOfFreeSlots < 4)
						{
							MessageBox.Show("You can't buy the Furniture pack for 150 Coins :(. You will need to trash or drop some items before continuing.", "Not enough space!");
						}
						else
						{
							int[] array = new int[]
							{
								40,
								42,
								46,
								98,
								118,
								114,
								18,
								112
							};
							int amount = 10;
							int[] array2 = new int[4];
							int[] array3 = array2;
							for (int i = 0; i < array3.Length; i++)
							{
								array3[i] = new Random().Next(0, array.Length);
								Thread.Sleep(20);
							}
							for (int i = 0; i < array3.Length; i++)
							{
								growalone.AddItem(array[array3[i]], amount);
							}
							playerData.Gems -= 100;
							MessageBox.Show(string.Concat(new string[]
							{
								"You now have ",
								playerData.Gems.ToString(),
								" Coins left.\r\nGot: ",
								amount.ToString(),
								" ",
								ItemData.ReturnItemNamePlural(array[array3[0]]),
								", \n",
								amount.ToString(),
								" ",
								ItemData.ReturnItemNamePlural(array[array3[1]]),
								", \n",
								amount.ToString(),
								" ",
								ItemData.ReturnItemNamePlural(array[array3[2]]),
								", \n",
								amount.ToString(),
								" ",
								ItemData.ReturnItemNamePlural(array[array3[3]]),
								", \n."
							}), "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
			else if (craftRectangles[10].Contains(value))
			{
				DialogResult dialogResult = MessageBox.Show("Buying a pair of devil wings costs 2,000 Coins. Are you sure you want to buy this?", "Purchase Confirmation", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					if (playerData.Gems >= 100)
					{
						if (!growalone.AddItem(126))
						{
							MessageBox.Show("You can't buy the Dynamite for 100 Coins :(. You will need to trash or drop some items before continuing.", "Not enough space!");
						}
						else
						{
							playerData.Gems -= 2000;
							MessageBox.Show("You now have " + playerData.Gems.ToString() + " Coins left.\nGot 1 Dynamite.", "Purchase Successful!");
						}
					}
					else
					{
						MessageBox.Show("You don't have enough Coins to buy this! Go get more by smashing some blocks!", "Purchase Failed");
					}
				}
			}
		}
	}
}
