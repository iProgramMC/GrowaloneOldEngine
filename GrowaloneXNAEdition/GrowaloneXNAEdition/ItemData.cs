using System;

namespace GrowaloneXNAEdition
{
	public class ItemData
	{
		public static bool IsPlantable(int itemID)
		{
			bool result;
			if (itemID % 2 == 0)
			{
				result = false;
			}
			else
			{
				switch (itemID)
				{
				case 31:
				case 32:
				case 33:
				case 34:
				case 35:
				case 36:
				case 37:
					result = false;
					break;
				default:
					result = true;
					break;
				}
			}
			return result;
		}

		public static int GetTier(int itemID)
		{
			int result;
			if (itemID <= 46)
			{
				switch (itemID)
				{
				case 2:
				case 6:
					result = 1;
					return result;
				case 3:
				case 5:
					break;
				case 4:
					result = 2;
					return result;
				default:
					switch (itemID)
					{
					case 12:
					case 16:
						result = 4;
						return result;
					case 13:
					case 15:
					case 17:
					case 19:
					case 21:
					case 23:
						break;
					case 14:
						result = 5;
						return result;
					case 18:
					case 22:
						result = 7;
						return result;
					case 20:
						result = 3;
						return result;
					case 24:
						result = 9;
						return result;
					default:
						switch (itemID)
						{
						case 40:
						case 46:
							result = 11;
							return result;
						case 42:
						case 44:
							result = 12;
							return result;
						}
						break;
					}
					break;
				}
			}
			else
			{
				switch (itemID)
				{
				case 50:
					result = 13;
					return result;
				case 51:
				case 53:
				case 55:
				case 57:
					break;
				case 52:
				case 56:
					result = 14;
					return result;
				case 54:
					result = 6;
					return result;
				case 58:
					result = 10;
					return result;
				default:
					if (itemID == 64 || itemID == 70)
					{
						result = 16;
						return result;
					}
					break;
				}
			}
			result = 0;
			return result;
		}

		public static bool IsRemovable(int itemID)
		{
			return itemID != 0 && itemID != 66;
		}

		public static string ReturnItemInfo(int itemID)
		{
			string text;
			switch (itemID)
			{
			case 0:
				text = "Allows breaking around yourself.\r\n\r\nThis item cannot be trashed nor dropped.";
				goto IL_5F4;
			case 2:
				text = "Yep, it is dirt.";
				goto IL_5F4;
			case 4:
				text = "This is a hard rock.";
				goto IL_5F4;
			case 6:
				text = "Yep, it is dirt! But it's farther away!";
				goto IL_5F4;
			case 8:
				text = "You should not see this! Report to us to get a reward.";
				goto IL_5F4;
			case 10:
				text = "You should not see this! Report to us to get a reward.";
				goto IL_5F4;
			case 12:
				text = "Wooden planks are made from classic oak.";
				goto IL_5F4;
			case 14:
				text = "This smells so sweet!";
				goto IL_5F4;
			case 16:
				text = "You can jump through them with ease, but you can not fall through!";
				goto IL_5F4;
			case 18:
				text = "Store items inside! Unfortunately, in Growalone it doesn't work.";
				goto IL_5F4;
			case 20:
			{
				string str;
				if (DateTime.Now.Hour >= 14)
				{
					str = "night";
				}
				else
				{
					str = "morning";
				}
				text = "Ahh, I love the smell of the freshly punched grass in the " + str + "!";
				goto IL_5F4;
			}
			case 22:
				text = "The great thing about Doors is that they open automatically!";
				goto IL_5F4;
			case 24:
				text = "This is the sturdiest block in all games!";
				goto IL_5F4;
			case 26:
				text = "Locks a 3x3 area around itself. Upon placing it can not be broken so be careful.";
				goto IL_5F4;
			case 28:
				text = "Locks a 7x7 area around itself. Upon placing it can not be broken so be careful.";
				goto IL_5F4;
			case 30:
				text = "Locks an 11x11 area around itself. Upon placing it can not be broken so be careful.";
				goto IL_5F4;
			case 32:
				text = "Debug tile #1. Please don't recycle.";
				goto IL_5F4;
			case 33:
				text = "Debug tile #2. Please don't recycle.";
				goto IL_5F4;
			case 34:
				text = "Debug tile #3. Please don't recycle.";
				goto IL_5F4;
			case 35:
				text = "Get the moon in your hands with this new item!";
				goto IL_5F4;
			case 36:
				text = "Get THE FRICKING SUN in your HANDS! How's that even possible? I don't know.";
				goto IL_5F4;
			case 37:
				text = "You used to have a pickaxe instead of a fist in the beta. Like, come on!";
				goto IL_5F4;
			case 38:
				text = "Locks the whole world and at the same time makes all the other locks public. Upon placing it can not be broken so be careful.";
				goto IL_5F4;
			case 40:
				text = "Nice and cheap chair you can sit on.";
				goto IL_5F4;
			case 42:
				text = "Nice and cheap table you can put something on. You can put a PC in here, but nothing else.";
				goto IL_5F4;
			case 44:
				text = "The deadliest kind of spike available. DO NOT TOUCH!";
				goto IL_5F4;
			case 46:
				text = "Write messages to tell map players a message! Like \"Welcome\" or \"GET OUT!\".";
				goto IL_5F4;
			case 48:
				text = "The legend says this is a piece of the sun.";
				goto IL_5F4;
			case 50:
				text = "This is the default hair that the Growalonian used to wear. But it's cut off.";
				goto IL_5F4;
			case 52:
				text = "This is the Growalonian's hair, but combed. It's cut off so you can't put it on.";
				goto IL_5F4;
			case 54:
				text = "This is the Growalonian's shoes. Useless because they don't fit your big feet. And I don't mean that you're fat.";
				goto IL_5F4;
			case 56:
				text = "Blue shoes that are blue. They don't fit your feet so it's kindaaa useless. Do ya no da wae tho?";
				goto IL_5F4;
			case 58:
				text = "This is the Growalonian's shirt. But it's too large!";
				goto IL_5F4;
			case 60:
				text = "This yellow shirt is for kids. So you can't wear it.";
				goto IL_5F4;
			case 62:
				text = "Black pants fit very well with school suits. But school suits are outdated.";
				goto IL_5F4;
			case 64:
				text = "These were the Growalonian's jeans. You got them but you can't wear them, since they don't fit.";
				goto IL_5F4;
			case 66:
				text = "Use this on an object that is wrenchable to modify its data.\r\n\r\nThis item cannot be trashed nor dropped.";
				goto IL_5F4;
			case 68:
				text = "The one and only! Sponsored by Maxiify.";
				goto IL_5F4;
			case 70:
				text = "Teleporter doors allow you to go through and find yourself somewhere else.";
				goto IL_5F4;
			case 72:
				text = "Bricks are used to make tough buildings and such.";
				goto IL_5F4;
			case 74:
				text = "You should not see this! Report to us to get a reward.";
				goto IL_5F4;
			case 76:
				text = "This gamer broke his PC. Please fix his PC for a reward.";
				goto IL_5F4;
			case 78:
				text = "This is exactly a 1 meter cube crate.";
				goto IL_5F4;
			case 80:
				text = "You have to be rich to use these as a building material.";
				goto IL_5F4;
			case 82:
				text = "You have to be rich to use these as a building material.";
				goto IL_5F4;
			case 84:
				text = "Slippery, cold to the touch, but strangely not melting.";
				goto IL_5F4;
			case 86:
				text = "Hope you can swim because that's how you move in water.";
				goto IL_5F4;
			case 88:
				text = "Jump twice as high now!";
				goto IL_5F4;
			case 90:
				text = "Fly with ease! Sponsored by iProgramMC.";
				goto IL_5F4;
			case 92:
				text = "This pet follows you around wherever you go. Sponsored by Maxiify.";
				goto IL_5F4;
			case 94:
				text = "This pet follows you around wherever you go.";
				goto IL_5F4;
			case 96:
				text = "Celebrate the holidays with this awesome cake! You can eat infinite cake! Only available on 5th of October in the Coin Shop.";
				goto IL_5F4;
			case 98:
				text = "This amazing sign has the power to tell you what it says without standing on it!";
				goto IL_5F4;
			case 100:
				text = "This sapling looks cool...";
				goto IL_5F4;
			case 102:
				text = "This crown makes the character a king. It does NOT make YOU, the player, a king.";
				goto IL_5F4;
			case 104:
				text = "Break stuff faster with this cool thing!";
				goto IL_5F4;
			case 106:
				text = "The future is so bright, you need these...";
				goto IL_5F4;
			case 108:
				text = "Ahhh, I love dubstep!";
				goto IL_5F4;
			case 110:
				text = "Walk on it and set your spawnpoint.";
				goto IL_5F4;
			case 112:
				text = "You can store coins in this, to either giveaway, store, or whatever else.";
				goto IL_5F4;
			case 114:
				text = "Painting inspired by August 27th.";
				goto IL_5F4;
			case 116:
				text = "A rose, just yellow.";
				goto IL_5F4;
			case 118:
				text = "State-of-the-art PC, with the latest hardware and software. If only you could play Growalone on this (You can't.)";
				goto IL_5F4;
			case 120:
				text = "You can show that something's going on in the direction the sign's facing. However, you can't write anything on it.";
				goto IL_5F4;
			case 122:
				text = "You can show that something's deadly in the direction the sign's facing. However, you can't write anything on it.";
				goto IL_5F4;
			case 124:
				text = "A standard, wooden fence.";
				goto IL_5F4;
			case 126:
				text = "Blow up stuff with this!";
				goto IL_5F4;
			case 128:
				text = "A standard, leafy bush.";
				goto IL_5F4;
			case 130:
				text = "A note block that plays music when tapped.";
				goto IL_5F4;
			case 132:
				text = "A mystery block that can be opened by hitting it from the top.";
				goto IL_5F4;
			case 134:
				text = "A used mystery block.";
				goto IL_5F4;
			case 136:
				text = "Place this down whenever you feel happy.";
				goto IL_5F4;
			case 138:
				text = "Place this down whenever you feel sad.";
				goto IL_5F4;
			}
			if (ItemData.IsPlantable(itemID))
			{
				if (ItemData.ReturnItemName2(itemID - 1) == "MISSING_ITEM")
				{
					text = "You should not see this! Report to us to get a reward.";
				}
				else
				{
					text = "Plant this seed to grow a " + ItemData.ReturnItemName2(itemID - 1) + " tree";
				}
			}
			else
			{
				text = "can't find desc for null_item" + itemID.ToString();
			}
			IL_5F4:
			int tier = ItemData.GetTier(itemID);
			if (tier != 0)
			{
				text = text + "\r\n\r\nTier: " + tier.ToString();
			}
			return text;
		}

		public static string ReturnItemName2(int itemID)
		{
			string result;
			switch (itemID)
			{
			case 0:
				result = "Fist";
				return result;
			case 2:
				result = "Dirt";
				return result;
			case 4:
				result = "Granite";
				return result;
			case 6:
				result = "Cave Wall";
				return result;
			case 8:
				result = "Bedrock";
				return result;
			case 10:
				result = "Main Door";
				return result;
			case 12:
				result = "Wooden Planks";
				return result;
			case 14:
				result = "Rose";
				return result;
			case 16:
				result = "Wooden Platform";
				return result;
			case 18:
				result = "Chest";
				return result;
			case 20:
				result = "Grass";
				return result;
			case 22:
				result = "Door";
				return result;
			case 24:
				result = "Iron Block";
				return result;
			case 26:
				result = "Small Lock";
				return result;
			case 28:
				result = "Medium Lock";
				return result;
			case 30:
				result = "Large Lock";
				return result;
			case 32:
				result = "Debug Tile #1";
				return result;
			case 33:
				result = "Debug Tile #2";
				return result;
			case 34:
				result = "Debug Tile #3";
				return result;
			case 35:
				result = "Moon";
				return result;
			case 36:
				result = "Sun";
				return result;
			case 37:
				result = "The Good Ol' Pickaxe";
				return result;
			case 38:
				result = "World Lock";
				return result;
			case 40:
				result = "Wooden Chair";
				return result;
			case 42:
				result = "Wooden Table";
				return result;
			case 44:
				result = "Death Spikes";
				return result;
			case 46:
				result = "Sign";
				return result;
			case 48:
				result = "Lava";
				return result;
			case 50:
				result = "Default hair";
				return result;
			case 52:
				result = "Brown hair";
				return result;
			case 54:
				result = "Default shoes";
				return result;
			case 56:
				result = "Blue shoes";
				return result;
			case 58:
				result = "Default shirt";
				return result;
			case 60:
				result = "Yellow T-Shirt";
				return result;
			case 62:
				result = "Black jeans";
				return result;
			case 64:
				result = "Default pants";
				return result;
			case 66:
				result = "Wrench";
				return result;
			case 68:
				result = "Maxiify's Kitten Mask";
				return result;
			case 70:
				result = "Teleporter Door";
				return result;
			case 72:
				result = "Bricks";
				return result;
			case 74:
				result = "Item Tree";
				return result;
			case 76:
				result = "Gamer NPC";
				return result;
			case 78:
				result = "1 Meter Cube Crate";
				return result;
			case 80:
				result = "Golden Block";
				return result;
			case 82:
				result = "Crystal Block";
				return result;
			case 84:
				result = "Ice";
				return result;
			case 86:
				result = "Water";
				return result;
			case 88:
				result = "Demon Wings";
				return result;
			case 90:
				result = "iProgramMC's Code Wings";
				return result;
			case 92:
				result = "Stripey Cat";
				return result;
			case 94:
				result = "Pet Chick";
				return result;
			case 96:
				result = "Cake";
				return result;
			case 98:
				result = "Holographic Sign";
				return result;
			case 100:
				result = "Sapling";
				return result;
			case 102:
				result = "Crown";
				return result;
			case 104:
				result = "Pickaxe";
				return result;
			case 106:
				result = "Shades";
				return result;
			case 108:
				result = "Boombox";
				return result;
			case 110:
				result = "Checkpoint";
				return result;
			case 112:
				result = "Coin Box";
				return result;
			case 114:
				result = "Beachy Painting";
				return result;
			case 116:
				result = "Dandelion";
				return result;
			case 118:
				result = "Desktop PC";
				return result;
			case 120:
				result = "Arrow Sign";
				return result;
			case 122:
				result = "Death Warning Sign";
				return result;
			case 124:
				result = "Fence";
				return result;
			case 126:
				result = "Dynamite";
				return result;
			case 128:
				result = "Bush";
				return result;
			case 130:
				result = "Note Block";
				return result;
			case 132:
				result = "Mystery Block";
				return result;
			case 134:
				result = "Used Mystery Block";
				return result;
			case 136:
				result = "Happy Plaque";
				return result;
			case 138:
				result = "Sad Plaque";
				return result;
			}
			result = "null_item" + itemID.ToString();
			return result;
		}

		public static string ReturnItemName(int itemID)
		{
			string result;
			switch (itemID)
			{
			case 0:
				result = "Fist";
				return result;
			case 2:
				result = "Dirt";
				return result;
			case 4:
				result = "Granite";
				return result;
			case 6:
				result = "Cave Wall";
				return result;
			case 8:
				result = "Bedrock";
				return result;
			case 10:
				result = "Main Door";
				return result;
			case 12:
				result = "Wooden Planks";
				return result;
			case 14:
				result = "Rose";
				return result;
			case 16:
				result = "Wooden Platform";
				return result;
			case 18:
				result = "Chest";
				return result;
			case 20:
				result = "Grass";
				return result;
			case 22:
				result = "Door";
				return result;
			case 24:
				result = "Iron Block";
				return result;
			case 26:
				result = "Small Lock";
				return result;
			case 28:
				result = "Medium Lock";
				return result;
			case 30:
				result = "Large Lock";
				return result;
			case 32:
				result = "Debug Tile #1";
				return result;
			case 33:
				result = "Debug Tile #2";
				return result;
			case 34:
				result = "Debug Tile #3";
				return result;
			case 35:
				result = "Moon";
				return result;
			case 36:
				result = "Sun";
				return result;
			case 37:
				result = "The Good Ol' Pickaxe";
				return result;
			case 38:
				result = "World Lock";
				return result;
			case 40:
				result = "Wooden Chair";
				return result;
			case 42:
				result = "Wooden Table";
				return result;
			case 44:
				result = "Death Spikes";
				return result;
			case 46:
				result = "Sign";
				return result;
			case 48:
				result = "Lava";
				return result;
			case 50:
				result = "Default hair";
				return result;
			case 52:
				result = "Brown hair";
				return result;
			case 54:
				result = "Default shoes";
				return result;
			case 56:
				result = "Blue shoes";
				return result;
			case 58:
				result = "Default shirt";
				return result;
			case 60:
				result = "Yellow T-Shirt";
				return result;
			case 62:
				result = "Black jeans";
				return result;
			case 64:
				result = "Default pants";
				return result;
			case 66:
				result = "Wrench";
				return result;
			case 68:
				result = "Maxiify's Kitten Mask";
				return result;
			case 70:
				result = "Teleporter Door";
				return result;
			case 72:
				result = "Bricks";
				return result;
			case 74:
				result = "Item Tree";
				return result;
			case 76:
				result = "Gamer NPC";
				return result;
			case 78:
				result = "1 Meter Cube Crate";
				return result;
			case 80:
				result = "Golden Block";
				return result;
			case 82:
				result = "Crystal Block";
				return result;
			case 84:
				result = "Ice";
				return result;
			case 86:
				result = "Water";
				return result;
			case 88:
				result = "Demon Wings";
				return result;
			case 90:
				result = "iProgramMC's Code Wings";
				return result;
			case 92:
				result = "Stripey Cat";
				return result;
			case 94:
				result = "Pet Chick";
				return result;
			case 96:
				result = "Cake";
				return result;
			case 98:
				result = "Holographic Sign";
				return result;
			case 100:
				result = "Sapling";
				return result;
			case 102:
				result = "Crown";
				return result;
			case 104:
				result = "Pickaxe";
				return result;
			case 106:
				result = "Shades";
				return result;
			case 108:
				result = "Boombox";
				return result;
			case 110:
				result = "Checkpoint";
				return result;
			case 112:
				result = "Coin Box";
				return result;
			case 114:
				result = "Beachy Painting";
				return result;
			case 116:
				result = "Dandelion";
				return result;
			case 118:
				result = "Desktop PC";
				return result;
			case 120:
				result = "Arrow Sign";
				return result;
			case 122:
				result = "Death Warning Sign";
				return result;
			case 124:
				result = "Fence";
				return result;
			case 126:
				result = "Dynamite";
				return result;
			case 128:
				result = "Bush";
				return result;
			case 130:
				result = "Note Block";
				return result;
			case 132:
				result = "Mystery Block";
				return result;
			case 134:
				result = "Used Mystery Block";
				return result;
			case 136:
				result = "Happy Plaque";
				return result;
			case 138:
				result = "Sad Plaque";
				return result;
			}
			if (itemID % 2 == 1)
			{
				result = ItemData.ReturnItemName2(itemID - 1) + " Seed";
			}
			else
			{
				result = "null_item" + itemID.ToString();
			}
			return result;
		}

		public static string ReturnItemNamePlural(int itemID)
		{
			string result;
			switch (itemID)
			{
			case 0:
				result = "Fists";
				return result;
			case 2:
				result = "Dirt Blocks";
				return result;
			case 4:
				result = "Granite Blocks";
				return result;
			case 6:
				result = "Cave Wall Tiles";
				return result;
			case 8:
				result = "Bedrock Blocks";
				return result;
			case 10:
				result = "Main Doors";
				return result;
			case 12:
				result = "Wooden Planks";
				return result;
			case 14:
				result = "Roses";
				return result;
			case 16:
				result = "Wooden Platforms";
				return result;
			case 18:
				result = "Chests";
				return result;
			case 20:
				result = "Grass Blocks";
				return result;
			case 22:
				result = "Doors";
				return result;
			case 24:
				result = "Iron Blocks";
				return result;
			case 26:
				result = "Small Locks";
				return result;
			case 28:
				result = "Medium Locks";
				return result;
			case 30:
				result = "Large Locks";
				return result;
			case 32:
				result = "Debug Tile #1";
				return result;
			case 33:
				result = "Debug Tile #2";
				return result;
			case 34:
				result = "Debug Tile #3";
				return result;
			case 35:
				result = "Moons";
				return result;
			case 36:
				result = "Suns";
				return result;
			case 37:
				result = "The Good Ol' Pickaxe";
				return result;
			case 38:
				result = "World Locks";
				return result;
			case 40:
				result = "Wooden Chairs";
				return result;
			case 42:
				result = "Wooden Tables";
				return result;
			case 44:
				result = "Death Spikes";
				return result;
			case 46:
				result = "Signs";
				return result;
			case 48:
				result = "Lava Blocks";
				return result;
			case 50:
				result = "Default hair";
				return result;
			case 52:
				result = "Brown hair";
				return result;
			case 54:
				result = "Default shoes";
				return result;
			case 56:
				result = "Blue shoes";
				return result;
			case 58:
				result = "Default shirt";
				return result;
			case 60:
				result = "Yellow T-Shirt";
				return result;
			case 62:
				result = "Black jeans";
				return result;
			case 64:
				result = "Default pants";
				return result;
			case 66:
				result = "Wrenches";
				return result;
			case 68:
				result = "Maxiify's Kitten Mask";
				return result;
			case 70:
				result = "Teleporter Doors";
				return result;
			case 72:
				result = "Bricks";
				return result;
			case 74:
				result = "Item Trees";
				return result;
			case 76:
				result = "Gamer NPCs";
				return result;
			case 78:
				result = "1 Meter Cube Crates";
				return result;
			case 80:
				result = "Golden Blocks";
				return result;
			case 82:
				result = "Crystal Blocks";
				return result;
			case 84:
				result = "Ice Blocks";
				return result;
			case 86:
				result = "Water Blocks";
				return result;
			case 88:
				result = "Demon Wings";
				return result;
			case 90:
				result = "iProgramMC's Code Wings";
				return result;
			case 92:
				result = "Stripey Cats";
				return result;
			case 94:
				result = "Pet Chicks";
				return result;
			case 96:
				result = "Cakes";
				return result;
			case 98:
				result = "Holographic Signs";
				return result;
			case 100:
				result = "Saplings";
				return result;
			case 102:
				result = "Crowns";
				return result;
			case 104:
				result = "Pickaxes";
				return result;
			case 106:
				result = "Shades";
				return result;
			case 108:
				result = "Boomboxes";
				return result;
			case 110:
				result = "Checkpoints";
				return result;
			case 112:
				result = "Coin Boxes";
				return result;
			case 114:
				result = "Beachy Paintings";
				return result;
			case 116:
				result = "Dandelions";
				return result;
			case 118:
				result = "Desktop PCs";
				return result;
			case 120:
				result = "Arrow Signs";
				return result;
			case 122:
				result = "Death Warning Signs";
				return result;
			case 124:
				result = "Fences";
				return result;
			case 126:
				result = "Dynamites";
				return result;
			case 128:
				result = "Bushes";
				return result;
			case 130:
				result = "Note Blocks";
				return result;
			case 132:
				result = "Mystery Blocks";
				return result;
			case 134:
				result = "Used Mystery Blocks";
				return result;
			case 136:
				result = "Happy Plaques";
				return result;
			case 138:
				result = "Sad Plaques";
				return result;
			}
			if (itemID % 2 == 1)
			{
				result = ItemData.ReturnItemName2(itemID - 1) + " Seed";
			}
			else
			{
				result = "null_item" + itemID.ToString();
			}
			return result;
		}
	}
}
