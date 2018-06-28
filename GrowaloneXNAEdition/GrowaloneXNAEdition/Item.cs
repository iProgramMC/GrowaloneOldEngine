using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class Item
	{
		public int ID;

		public int Amount;

		public string Unit = "kg";

		public Item()
		{
			this.ID = 0;
			this.Amount = 0;
		}

		public Item(int id, int amount)
		{
			this.ID = id;
			this.Amount = amount;
		}
	}
}
