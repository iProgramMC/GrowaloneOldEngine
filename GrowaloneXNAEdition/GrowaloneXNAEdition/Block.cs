using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class Block
	{
		public int ID;

		public string[] StringData = new string[5];

		public int[] IntData = new int[5];

		public bool facingLeft;

		public Block(int ID)
		{
			this.ID = ID;
			this.StringData[1] = "";
			this.StringData[0] = "";
			this.StringData[2] = "";
		}

		public Block(int ID, bool facesLeft)
		{
			this.ID = ID;
			this.facingLeft = facesLeft;
		}

		public Block(int ID, string signMessage)
		{
			this.ID = ID;
			this.StringData[0] = signMessage;
			this.StringData[1] = "";
			this.StringData[2] = "";
		}

		public Block(int ID, int growTimeInTicks, int GrownItemID)
		{
			this.ID = ID;
			this.IntData[0] = GrownItemID;
			this.IntData[1] = growTimeInTicks;
			this.IntData[2] = 0;
			this.IntData[3] = 0;
		}

		public Block(int ID, DoorData doorData)
		{
			this.ID = ID;
			this.StringData[0] = doorData.displayLabel;
			this.StringData[1] = doorData.destination;
			this.StringData[2] = doorData.ID;
		}

		public Block()
		{
			this.StringData[1] = "";
			this.StringData[0] = "";
			this.StringData[2] = "";
		}
	}
}
