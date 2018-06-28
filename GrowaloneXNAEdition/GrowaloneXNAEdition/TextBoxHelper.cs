using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace GrowaloneXNAEdition
{
	public class TextBoxHelper
	{
		public static string Convert(Keys[] keys)
		{
			string text = "";
			bool flag = keys.Contains(Keys.LeftShift) || keys.Contains(Keys.RightShift);
			for (int i = 0; i < keys.Length; i++)
			{
				Keys keys2 = keys[i];
				if (keys2 == Keys.Back)
				{
					if (text.Length > 0)
					{
						char[] array = text.ToCharArray();
						text = "";
						array[array.Length] = ' ';
						char[] array2 = array;
						for (int j = 0; j < array2.Length; j++)
						{
							char c = array2[j];
							text += c;
						}
					}
				}
				else if (keys2 >= Keys.A && keys2 <= Keys.Z)
				{
					text += keys2.ToString();
				}
				else if (keys2 >= Keys.NumPad0 && keys2 <= Keys.NumPad9)
				{
					string arg_F1_0 = text;
					int num = keys2 - Keys.NumPad0;
					text = arg_F1_0 + num.ToString();
				}
				else if (keys2 >= Keys.D0 && keys2 <= Keys.D9)
				{
					int num = keys2 - Keys.D0;
					string text2 = num.ToString();
					if (flag)
					{
						string text3 = text2;
						switch (text3)
						{
						case "1":
							text2 = "!";
							break;
						case "2":
							text2 = "@";
							break;
						case "3":
							text2 = "#";
							break;
						case "4":
							text2 = "$";
							break;
						case "5":
							text2 = "%";
							break;
						case "6":
							text2 = "^";
							break;
						case "7":
							text2 = "&";
							break;
						case "8":
							text2 = "*";
							break;
						case "9":
							text2 = "(";
							break;
						case "0":
							text2 = ")";
							break;
						}
					}
					text += text2;
				}
				else if (keys2 == Keys.OemPeriod)
				{
					text += ".";
				}
				else if (keys2 == Keys.OemTilde)
				{
					text += "'";
				}
				else if (keys2 == Keys.Space)
				{
					text += " ";
				}
				else if (keys2 == Keys.OemMinus)
				{
					text += "-";
				}
				else if (keys2 == Keys.OemPlus)
				{
					text += "+";
				}
				else if (keys2 == Keys.OemQuestion)
				{
					text += "/";
				}
				else if (keys2 == Keys.OemQuestion && flag)
				{
					text += "?";
				}
				else if (keys2 == Keys.OemSemicolon && flag)
				{
					text += ":";
				}
				else if (keys2 == Keys.OemSemicolon)
				{
					text += ";";
				}
				else if (keys2 == Keys.OemQuotes && flag)
				{
					text += "\"";
				}
				else if (keys2 == Keys.OemQuotes && flag)
				{
					text += "'";
				}
				else if (keys2 == Keys.OemBackslash && flag)
				{
					text += "|";
				}
				else if (keys2 == Keys.OemBackslash)
				{
					text += "\\";
				}
				else if (keys2 == Keys.OemCloseBrackets && flag)
				{
					text += "}";
				}
				else if (keys2 == Keys.OemCloseBrackets)
				{
					text += "]";
				}
				else if (keys2 == Keys.OemOpenBrackets && flag)
				{
					text += "{";
				}
				else if (keys2 == Keys.OemOpenBrackets)
				{
					text += "[";
				}
				if (!flag)
				{
					text = text.ToLower();
				}
			}
			return text;
		}
	}
}
