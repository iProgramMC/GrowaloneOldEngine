using System;

namespace GrowaloneXNAEdition
{
	public class StoreCoinsAction : InputBoxAction
	{
		public Block toEdit;

		public Growalone game;

		public StoreCoinsAction(Growalone that, Block tile) : base(new ActionArgument[0])
		{
			this.game = that;
			this.toEdit = tile;
			this.args = new ActionArgument[1];
		}

		public override void Execute()
		{
			int num;
			if (int.TryParse(this.args[0].StringParam, out num))
			{
				if (num == 0)
				{
					this.game.ShowMsgBox(new DefaultMsgAction(), "Cannot deposit zero coins.", "");
				}
				else if (num > 0 && this.game.playerData.Gems >= num)
				{
					this.toEdit.IntData[0] += num;
					this.game.playerData.Gems -= num;
				}
				else if (num < 0 && this.toEdit.IntData[0] >= Math.Abs(num))
				{
					this.toEdit.IntData[0] += num;
					this.game.playerData.Gems -= num;
				}
			}
			else
			{
				this.game.ShowMsgBox(new DefaultMsgAction(), this.args[0].StringParam + " is not a valid number, please choose a valid number", "");
			}
		}
	}
}
