using System;

namespace GrowaloneXNAEdition
{
	public class AddGemAction : MessageBoxAction
	{
		private int tg;

		private int ga;

		public AddGemAction(int totalGems, int gemToAdd) : base(new MessageActionArgument[0])
		{
			this.tg = totalGems;
			this.ga = gemToAdd;
		}

		public override void Execute()
		{
			this.tg += this.ga;
		}
	}
}
