using System;

namespace GrowaloneXNAEdition
{
	public class Splicing
	{
		public static string ecode2147483647 = "rip antvenom kicked me from the discord server :( - 9/9/2017";

		public static string ecode2147483646 = "deucalion and extrund on the pw forums suck";

		public static void SpliceItem(int SeedToUse, Block tree, Growalone th)
		{
			if (SeedToUse == 3 && tree.IntData[0] == 6)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(4),
					" tree!"
				}), 1000);
				tree.IntData[0] = 4;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
			}
			else if (SeedToUse == 7 && tree.IntData[0] == 2)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(4),
					" tree!"
				}), 1000);
				tree.IntData[0] = 4;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 7 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(12),
					" tree!"
				}), 1000);
				tree.IntData[0] = 12;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 6)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(12),
					" tree!"
				}), 1000);
				tree.IntData[0] = 12;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 4)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(14),
					" tree!"
				}), 1000);
				tree.IntData[0] = 14;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 5 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(14),
					" tree!"
				}), 1000);
				tree.IntData[0] = 14;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 3 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(16),
					" tree!"
				}), 1000);
				tree.IntData[0] = 16;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 2)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(16),
					" tree!"
				}), 1000);
				tree.IntData[0] = 16;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 12)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(18),
					" tree!"
				}), 1000);
				tree.IntData[0] = 18;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 13 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(18),
					" tree!"
				}), 1000);
				tree.IntData[0] = 18;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 5 && tree.IntData[0] == 6)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(20),
					" tree!"
				}), 1000);
				tree.IntData[0] = 20;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 7 && tree.IntData[0] == 4)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(20),
					" tree!"
				}), 1000);
				tree.IntData[0] = 20;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 17 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(22),
					" tree!"
				}), 1000);
				tree.IntData[0] = 22;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 16)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(22),
					" tree!"
				}), 1000);
				tree.IntData[0] = 22;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 5 && tree.IntData[0] == 18)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(24),
					" tree!"
				}), 1000);
				tree.IntData[0] = 24;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 19 && tree.IntData[0] == 4)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(24),
					" tree!"
				}), 1000);
				tree.IntData[0] = 24;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 17 && tree.IntData[0] == 18)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(40),
					" tree!"
				}), 1000);
				tree.IntData[0] = 40;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 19 && tree.IntData[0] == 16)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(40),
					" tree!"
				}), 1000);
				tree.IntData[0] = 40;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 17 && tree.IntData[0] == 14)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(42),
					" tree!"
				}), 1000);
				tree.IntData[0] = 42;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 15 && tree.IntData[0] == 16)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(42),
					" tree!"
				}), 1000);
				tree.IntData[0] = 42;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 25 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(44),
					" tree!"
				}), 1000);
				tree.IntData[0] = 44;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 24)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(44),
					" tree!"
				}), 1000);
				tree.IntData[0] = 44;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 13 && tree.IntData[0] == 22)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(46),
					" tree!"
				}), 1000);
				tree.IntData[0] = 46;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 23 && tree.IntData[0] == 12)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(46),
					" tree!"
				}), 1000);
				tree.IntData[0] = 46;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 45 && tree.IntData[0] == 2)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(50),
					" tree!"
				}), 1000);
				tree.IntData[0] = 50;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 3 && tree.IntData[0] == 44)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(50),
					" tree!"
				}), 1000);
				tree.IntData[0] = 50;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 41 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(52),
					" tree!"
				}), 1000);
				tree.IntData[0] = 52;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 40)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(52),
					" tree!"
				}), 1000);
				tree.IntData[0] = 52;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 46)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(56),
					" tree!"
				}), 1000);
				tree.IntData[0] = 56;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 47 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(56),
					" tree!"
				}), 1000);
				tree.IntData[0] = 56;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 3 && tree.IntData[0] == 14)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(54),
					" tree!"
				}), 1000);
				tree.IntData[0] = 54;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 15 && tree.IntData[0] == 2)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(54),
					" tree!"
				}), 1000);
				tree.IntData[0] = 54;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 19 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(58),
					" tree!"
				}), 1000);
				tree.IntData[0] = 58;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 18)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(58),
					" tree!"
				}), 1000);
				tree.IntData[0] = 58;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 19 && tree.IntData[0] == 24)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(60),
					" tree!"
				}), 1000);
				tree.IntData[0] = 58;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 25 && tree.IntData[0] == 18)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(60),
					" tree!"
				}), 1000);
				tree.IntData[0] = 58;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 49 && tree.IntData[0] == 18)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(60),
					" tree!"
				}), 1000);
				tree.IntData[0] = 60;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 19 && tree.IntData[0] == 48)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(60),
					" tree!"
				}), 1000);
				tree.IntData[0] = 60;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 25 && tree.IntData[0] == 18)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(62),
					" tree!"
				}), 1000);
				tree.IntData[0] = 64;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 19 && tree.IntData[0] == 24)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(62),
					" tree!"
				}), 1000);
				tree.IntData[0] = 64;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 49 && tree.IntData[0] == 20)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(64),
					" tree!"
				}), 1000);
				tree.IntData[0] = 62;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 21 && tree.IntData[0] == 48)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(64),
					" tree!"
				}), 1000);
				tree.IntData[0] = 62;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 25 && tree.IntData[0] == 22)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(70),
					" tree!"
				}), 1000);
				tree.IntData[0] = 70;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 23 && tree.IntData[0] == 24)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(70),
					" tree!"
				}), 1000);
				tree.IntData[0] = 70;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 49 && tree.IntData[0] == 24)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(70),
					" tree!"
				}), 1000);
				tree.IntData[0] = 70;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else if (SeedToUse == 25 && tree.IntData[0] == 48)
			{
				th.ShowDialog(string.Concat(new string[]
				{
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed have\nbeen spliced to create a ",
					ItemData.ReturnItemName(72),
					" tree!"
				}), 1000);
				tree.IntData[0] = 72;
				tree.IntData[1] = 1000;
				tree.IntData[2] = 0;
				tree.IntData[4] = 1;
			}
			else
			{
				th.ShowDialog(string.Concat(new string[]
				{
					"Uhm, ",
					ItemData.ReturnItemName(SeedToUse),
					" and ",
					ItemData.ReturnItemName(tree.IntData[0]),
					" Seed can't be spliced."
				}), 1000);
				if (th.AddItem(SeedToUse))
				{
				}
			}
		}
	}
}
