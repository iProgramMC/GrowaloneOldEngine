using System;

namespace GrowaloneXNAEdition
{
	public class PlaceSignAction : InputBoxAction
	{
		public World world;

		public PlaceSignAction(World world, params ActionArgument[] args) : base(new ActionArgument[0])
		{
			this.args = args;
			this.world = world;
		}

		public override void Execute()
		{
			this.world.Map[this.args[0].IntParam, this.args[1].IntParam, this.args[2].IntParam] = new Block(this.args[3].IntParam, this.args[4].StringParam);
		}
	}
}
