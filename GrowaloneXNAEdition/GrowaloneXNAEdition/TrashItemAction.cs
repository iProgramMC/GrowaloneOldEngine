using System;

namespace GrowaloneXNAEdition
{
	public class TrashItemAction : MessageBoxAction
	{
		public Item[] inventory;

		public TrashItemAction(Item[] inventory1, int ItemIndex) : base(new MessageActionArgument[0])
		{
			this.args = new MessageActionArgument[1];
			this.args[0] = new MessageActionArgument(ItemIndex);
			this.inventory = inventory1;
		}

		public override void Execute()
		{
			this.inventory[this.args[0].IntParam] = new Item(0, 0);
		}
	}
}
