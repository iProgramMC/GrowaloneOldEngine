using System;
using System.Collections.Generic;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class Achievements
	{
		public Dictionary<string, bool> AchievementsEarned = new Dictionary<string, bool>();

		public Dictionary<string, string> AchievementDescriptions = new Dictionary<string, string>();

		public Dictionary<string, byte> AchievementPointsGet = new Dictionary<string, byte>();

		public int AchievementPoints;

		public Achievements()
		{
			this.AchievementPointsGet["Builder"] = 20;
			this.AchievementPointsGet["Smasher"] = 20;
			this.AchievementPointsGet["Farmer"] = 20;
			this.AchievementPointsGet["Garbageman"] = 20;
			this.AchievementPointsGet["Passionate of Reading Infos"] = 20;
			this.AchievementPointsGet["Long Time Shop Client"] = 20;
			this.AchievementPointsGet["Bought a new Backpack"] = 20;
			this.AchievementPointsGet["Strong Builder"] = 100;
			this.AchievementPointsGet["Awesome Smasher"] = 100;
			this.AchievementPointsGet["Experienced Farmer"] = 100;
			this.AchievementPointsGet["Long-time Garbageman"] = 100;
			this.AchievementPointsGet["Info Addicted"] = 100;
			this.AchievementPointsGet["Old-school Client"] = 100;
			this.AchievementPointsGet["A ton of Space"] = 100;
			this.AchievementPointsGet["Expert Builder"] = 200;
			this.AchievementPointsGet["A Wrecking Ball"] = 200;
			this.AchievementPointsGet["Farmer in the Dell"] = 200;
			this.AchievementPointsGet["Garbageman Extraordinaire"] = 200;
			this.AchievementPointsGet["Infos, infos and infos"] = 200;
			this.AchievementPointsGet["Buying from the Shop Too Often"] = 200;
			this.AchievementPointsGet["Biggest Backpack in the World"] = 200;
			this.AchievementsEarned["Builder"] = false;
			this.AchievementsEarned["Smasher"] = false;
			this.AchievementsEarned["Farmer"] = false;
			this.AchievementsEarned["Garbageman"] = false;
			this.AchievementsEarned["Passionate of Reading Infos"] = false;
			this.AchievementsEarned["Long Time Shop Client"] = false;
			this.AchievementsEarned["Bought a new Backpack"] = false;
			this.AchievementsEarned["Strong Builder"] = false;
			this.AchievementsEarned["Awesome Smasher"] = false;
			this.AchievementsEarned["Experienced Farmer"] = false;
			this.AchievementsEarned["Long-time Garbageman"] = false;
			this.AchievementsEarned["Info Addicted"] = false;
			this.AchievementsEarned["Old-school Client"] = false;
			this.AchievementsEarned["A ton of Space"] = false;
			this.AchievementsEarned["Expert Builder"] = false;
			this.AchievementsEarned["A Wrecking Ball"] = false;
			this.AchievementsEarned["Farmer in the Dell"] = false;
			this.AchievementsEarned["Garbageman Extraordinaire"] = false;
			this.AchievementsEarned["Item Dictionary Reader"] = false;
			this.AchievementsEarned["Too Rich, Need to Spend"] = false;
			this.AchievementsEarned["Biggest Backpack in the World"] = false;
			this.AchievementDescriptions["Builder"] = "Place 100 blocks.";
			this.AchievementDescriptions["Smasher"] = "Smash 100 blocks.";
			this.AchievementDescriptions["Farmer"] = "Plant 100 trees.";
			this.AchievementDescriptions["Garbageman"] = "Trash 100 items for good.";
			this.AchievementDescriptions["Passionate of Reading Infos"] = "Read the info of 100 items.";
			this.AchievementDescriptions["Long Time Shop Client"] = "Buy 50 items from the Shop.";
			this.AchievementDescriptions["Bought a new Backpack"] = "Upgrade your backpack to 30 slots.";
			this.AchievementDescriptions["Strong Builder"] = "Place 500 blocks.";
			this.AchievementDescriptions["Awesome Smasher"] = "Break 500 blocks.";
			this.AchievementDescriptions["Experienced Farmer"] = "Plant 500 trees.";
			this.AchievementDescriptions["Long-time Garbageman"] = "Trash 500 items just for the sake of it.";
			this.AchievementDescriptions["Info Addicted"] = "Read the info of 500 items.";
			this.AchievementDescriptions["Old-school Client"] = "Buy 100 items from the Shop.";
			this.AchievementDescriptions["A ton of Space"] = "Upgrade your backpack to 50 Slots.";
			this.AchievementDescriptions["Expert Builder"] = "Place 1000 blocks.";
			this.AchievementDescriptions["A Wrecking Ball"] = "Smash 1000 blocks.";
			this.AchievementDescriptions["Farmer in the Dell"] = "Plant 1000 trees.";
			this.AchievementDescriptions["Garbageman Extraordinaire"] = "Trash 1000 items.";
			this.AchievementDescriptions["Item Dictionary Reader"] = "Read the info of 1000 items. Just because you can.";
			this.AchievementDescriptions["Too Rich, Need to Spend"] = "Buy 300 items from the Shop.";
			this.AchievementDescriptions["Biggest Backpack in the World"] = "Upgrade the Backpack 'till the limit.";
		}

		public void AddAchievement(string Achievement, Growalone game)
		{
			if (!this.AchievementsEarned[Achievement])
			{
				this.AchievementsEarned[Achievement] = true;
				this.AchievementPoints += (int)this.AchievementPointsGet[Achievement];
				game.StarCollected = Achievement;
				PlayerData expr_46 = game.playerData;
				expr_46.Stars += 1;
				game.ShowMsgBox(new DefaultMsgAction(), Achievement.ToUpper() + " CLEAR!\n\n\nDo you want to Save?", "You Got a Star!");
			}
		}

		public void Update(Statistics stats, Growalone game)
		{
			if (stats.BlocksBroken >= 100)
			{
				this.AddAchievement("Smasher", game);
			}
			if (stats.BlocksBroken >= 500)
			{
				this.AddAchievement("Awesome Smasher", game);
			}
			if (stats.BlocksBroken >= 1000)
			{
				this.AddAchievement("A Wrecking Ball", game);
			}
			if (stats.BlocksPlaced >= 100)
			{
				this.AddAchievement("Builder", game);
			}
			if (stats.BlocksPlaced >= 500)
			{
				this.AddAchievement("Strong Builder", game);
			}
			if (stats.BlocksPlaced >= 1000)
			{
				this.AddAchievement("Expert Builder", game);
			}
			if (stats.TreesPlanted >= 100)
			{
				this.AddAchievement("Farmer", game);
			}
			if (stats.TreesPlanted >= 500)
			{
				this.AddAchievement("Experienced Farmer", game);
			}
			if (stats.TreesPlanted >= 1000)
			{
				this.AddAchievement("Farmer in the Dell", game);
			}
		}
	}
}
