using Microsoft.Xna.Framework;
using System;

namespace GrowaloneXNAEdition
{
	public class ItemType
	{
		public static Color ItemTypeToColor(int ItemID)
		{
			Color result;
			if (ItemID % 2 == 1)
			{
				result = Color.Lime;
			}
			else if (ItemID > 0 && ItemID % 2 == 0 && ItemID < 26)
			{
				result = Color.Blue;
			}
			else if (ItemID > 25 && ItemID % 2 == 0 && ItemID < 39)
			{
				result = Color.Orange;
			}
			else if (ItemID > 39 && ItemID % 2 == 0 && ItemID < 49)
			{
				result = Color.Blue;
			}
			else if (ItemID > 49 && ItemID % 2 == 0 && ItemID < 65)
			{
				result = Color.White;
			}
			else if (ItemID == 66 || ItemID == 0)
			{
				result = Color.Gray;
			}
			else if (ItemID == 68)
			{
				result = Color.White;
			}
			else if (ItemID > 69 && ItemID < 77)
			{
				result = Color.Blue;
			}
			else if (ItemID > 87 && ItemID < 95)
			{
				result = Color.White;
			}
			else if (ItemID == 96)
			{
				result = Color.Purple;
			}
			else if (ItemID > 97)
			{
				result = Color.Blue;
			}
			else
			{
				result = Color.Black;
			}
			return result;
		}
	}
}
