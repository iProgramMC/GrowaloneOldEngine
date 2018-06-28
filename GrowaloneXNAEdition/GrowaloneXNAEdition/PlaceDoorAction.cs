using System;

namespace GrowaloneXNAEdition
{
	public class PlaceDoorAction : InputBoxAction
	{
		public World world;

		public PlaceDoorAction(World world, params ActionArgument[] args) : base(new ActionArgument[0])
		{
			this.args = args;
			this.world = world;
		}

		public override void Execute()
		{
			try
			{
				string[] array = this.args[4].StringParam.Split(new char[]
				{
					':'
				});
				string destination = array[0];
				string iD = array[1];
				string displayLabel = array[2];
				DoorData doorData = new DoorData(iD, destination, displayLabel);
				this.world.Map[this.args[0].IntParam, this.args[1].IntParam, this.args[2].IntParam] = new Block(this.args[3].IntParam, doorData);
			}
			catch
			{
			}
		}
	}
}
