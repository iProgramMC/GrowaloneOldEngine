using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace iProgramMC
{
	public class iProgramMC_FontEngine
	{
		public Rectangle[,] CharRectangles = new Rectangle[12, 10];

		public Texture2D fontSheet;

		public iProgramMC_FontEngine(Texture2D fontSheet)
		{
			this.fontSheet = fontSheet;
			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					this.CharRectangles[i, j] = new Rectangle(128 * i, 128 * j, 128, 128);
				}
			}
		}

		public Rectangle getCharRectangle(char character)
		{
			byte b = Convert.ToByte(character);
			Rectangle result;
			if (b > 48 && b < 58)
			{
				result = this.CharRectangles[(int)(b - 49), 9];
			}
			else if (b == 48)
			{
				result = this.CharRectangles[9, 10];
			}
			else if (b == 81)
			{
				result = this.CharRectangles[0, 3];
			}
			else if (b == 87)
			{
				result = this.CharRectangles[1, 3];
			}
			else if (b == 69)
			{
				result = this.CharRectangles[2, 3];
			}
			else if (b == 82)
			{
				result = this.CharRectangles[3, 3];
			}
			else if (b == 84)
			{
				result = this.CharRectangles[4, 3];
			}
			else if (b == 89)
			{
				result = this.CharRectangles[5, 3];
			}
			else if (b == 85)
			{
				result = this.CharRectangles[6, 3];
			}
			else if (b == 73)
			{
				result = this.CharRectangles[7, 3];
			}
			else if (b == 79)
			{
				result = this.CharRectangles[8, 3];
			}
			else if (b == 80)
			{
				result = this.CharRectangles[9, 3];
			}
			else if (b == 65)
			{
				result = this.CharRectangles[10, 3];
			}
			else if (b == 83)
			{
				result = this.CharRectangles[11, 3];
			}
			else if (b == 68)
			{
				result = this.CharRectangles[0, 4];
			}
			else if (b == 70)
			{
				result = this.CharRectangles[1, 4];
			}
			else if (b == 71)
			{
				result = this.CharRectangles[2, 4];
			}
			else if (b == 72)
			{
				result = this.CharRectangles[3, 4];
			}
			else if (b == 74)
			{
				result = this.CharRectangles[4, 4];
			}
			else if (b == 75)
			{
				result = this.CharRectangles[5, 4];
			}
			else if (b == 76)
			{
				result = this.CharRectangles[6, 4];
			}
			else if (b == 90)
			{
				result = this.CharRectangles[7, 4];
			}
			else if (b == 88)
			{
				result = this.CharRectangles[8, 4];
			}
			else if (b == 67)
			{
				result = this.CharRectangles[9, 4];
			}
			else if (b == 86)
			{
				result = this.CharRectangles[10, 4];
			}
			else if (b == 66)
			{
				result = this.CharRectangles[11, 4];
			}
			else if (b == 78)
			{
				result = this.CharRectangles[0, 5];
			}
			else if (b == 77)
			{
				result = this.CharRectangles[1, 5];
			}
			else if (b == 113)
			{
				result = this.CharRectangles[0, 6];
			}
			else if (b == 119)
			{
				result = this.CharRectangles[1, 6];
			}
			else if (b == 101)
			{
				result = this.CharRectangles[2, 6];
			}
			else if (b == 114)
			{
				result = this.CharRectangles[3, 6];
			}
			else if (b == 116)
			{
				result = this.CharRectangles[4, 6];
			}
			else if (b == 121)
			{
				result = this.CharRectangles[5, 6];
			}
			else if (b == 117)
			{
				result = this.CharRectangles[6, 6];
			}
			else if (b == 105)
			{
				result = this.CharRectangles[7, 6];
			}
			else if (b == 111)
			{
				result = this.CharRectangles[8, 6];
			}
			else if (b == 112)
			{
				result = this.CharRectangles[9, 6];
			}
			else if (b == 97)
			{
				result = this.CharRectangles[10, 6];
			}
			else if (b == 115)
			{
				result = this.CharRectangles[11, 6];
			}
			else if (b == 100)
			{
				result = this.CharRectangles[0, 7];
			}
			else if (b == 102)
			{
				result = this.CharRectangles[1, 7];
			}
			else if (b == 103)
			{
				result = this.CharRectangles[2, 7];
			}
			else if (b == 104)
			{
				result = this.CharRectangles[3, 7];
			}
			else if (b == 106)
			{
				result = this.CharRectangles[4, 7];
			}
			else if (b == 107)
			{
				result = this.CharRectangles[5, 7];
			}
			else if (b == 108)
			{
				result = this.CharRectangles[6, 7];
			}
			else if (b == 122)
			{
				result = this.CharRectangles[7, 7];
			}
			else if (b == 120)
			{
				result = this.CharRectangles[8, 7];
			}
			else if (b == 99)
			{
				result = this.CharRectangles[9, 7];
			}
			else if (b == 118)
			{
				result = this.CharRectangles[10, 7];
			}
			else if (b == 98)
			{
				result = this.CharRectangles[11, 7];
			}
			else if (b == 110)
			{
				result = this.CharRectangles[0, 8];
			}
			else if (b == 109)
			{
				result = this.CharRectangles[1, 8];
			}
			else
			{
				result = new Rectangle(0, 0, 0, 0);
			}
			return result;
		}

		public void DrawString(SpriteBatch sb, string text, float emSize, Vector2 position, Color color)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (c != '\n' && c != ' ')
				{
					float scale = emSize / 72f;
					sb.Draw(this.fontSheet, new Vector2((float)((int)position.X + num), (float)((int)position.Y + num2)), new Rectangle?(this.getCharRectangle(c)), color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
					num += (int)(64f * (emSize / 72f));
				}
				else if (c == ' ')
				{
					num += (int)(64f * (emSize / 72f));
				}
				else
				{
					num = 0;
					num2 += (int)(128f * (emSize / 72f));
				}
			}
		}
	}
}
