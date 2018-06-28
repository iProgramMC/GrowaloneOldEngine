using Microsoft.Xna.Framework.Graphics;
using System;

namespace GrowaloneXNAEdition
{
	public class BlockConnection
	{
		public static Texture2D connectTile(Block[,,] Map2, int BlockX, int BlockY, int ID, Growalone ga)
		{
			int[,,] array = new int[100, 60, 5];
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					for (int k = 0; k < 5; k++)
					{
					}
				}
			}
			int num = 0;
			Texture2D result;
			if (num != 1)
			{
				Texture2D texture2D;
				if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 1];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 2];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 3];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 4];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 5];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 6];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 7];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 8];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 9];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 10];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 11];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] == ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 12];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] == ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 13];
				}
				else if (array[BlockX, BlockY - 1, num] == ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] != ID)
				{
					texture2D = ga.tileTextures[ID, 14];
				}
				else if (array[BlockX, BlockY - 1, num] != ID & array[BlockX - 1, BlockY, num] != ID & array[BlockX + 1, BlockY, num] != ID & array[BlockX, BlockY + 1, num] == ID)
				{
					texture2D = ga.tileTextures[ID, 15];
				}
				else
				{
					texture2D = ga.tileTextures[ID, num];
				}
				result = texture2D;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static Texture2D ConnectLocked(byte[,] Map, int ID, Growalone ga, int BlockX, int BlockY)
		{
			Texture2D result;
			if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[1];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[2];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[3];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[4];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[5];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[6];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[7];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[8];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[9];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[10];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[11];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] == ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[12];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] == ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[13];
			}
			else if ((int)Map[BlockX, BlockY - 1] == ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] != ID)
			{
				result = ga.LockedTile[14];
			}
			else if ((int)Map[BlockX, BlockY - 1] != ID & (int)Map[BlockX - 1, BlockY] != ID & (int)Map[BlockX + 1, BlockY] != ID & (int)Map[BlockX, BlockY + 1] == ID)
			{
				result = ga.LockedTile[15];
			}
			else
			{
				result = ga.LockedTile[0];
			}
			return result;
		}
	}
}
