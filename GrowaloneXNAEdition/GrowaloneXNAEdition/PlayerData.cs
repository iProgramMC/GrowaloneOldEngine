using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class PlayerData
	{
		public Achievements achievements = new Achievements();

		public Statistics statistics = new Statistics();

		public int WingCloth;

		public int PetsCloth;

		public int MaskCloth;

		public byte TotalExperience;

		public string PlayerName;

		public int Gems;

		public int BackPackSlotsUpgraded;

		public bool firstStarted;

		public byte Stars;

		public PlayerType playerType;

		public DateTime JoinDate;

		public bool DoesShowFancyGraphics = true;

		public bool UsesGamepad = false;
	}
}
