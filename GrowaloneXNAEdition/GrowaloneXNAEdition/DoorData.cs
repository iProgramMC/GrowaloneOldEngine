using System;

namespace GrowaloneXNAEdition
{
	public class DoorData
	{
		public string ID;

		public string destination;

		public string displayLabel;

		public DoorData(string ID, string Destination, string DisplayLabel)
		{
			this.ID = ID;
			this.destination = Destination;
			this.displayLabel = DisplayLabel;
		}
	}
}
