using System;
using System.IO;

namespace GrowaloneXNAEdition
{
	public class Localizer
	{
		public string systemLocale;

		public string[,] arrayOfThings;

		private string[] lines;

		public Localizer(string loc, string con)
		{
			this.systemLocale = loc;
			this.lines = File.ReadAllLines(con + "\\" + this.systemLocale + ".txt");
			this.arrayOfThings = new string[this.lines.Length, 2];
			int num = 0;
			string[] array = this.lines;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				string[] array2 = text.Split(new char[]
				{
					'='
				});
				if (array2.Length > 1)
				{
					this.arrayOfThings[num, 0] = array2[0];
					this.arrayOfThings[num, 1] = array2[1];
				}
				else
				{
					this.arrayOfThings[num, 0] = "Just nothing";
					this.arrayOfThings[num, 1] = "Just nothing";
				}
				num++;
			}
		}

		public string FindString(string ID)
		{
			string result;
			for (int i = 0; i < this.arrayOfThings.GetUpperBound(0); i++)
			{
				if (this.arrayOfThings[i, 0] == ID)
				{
					result = this.arrayOfThings[i, 1];
					return result;
				}
			}
			result = ID;
			return result;
		}
	}
}
