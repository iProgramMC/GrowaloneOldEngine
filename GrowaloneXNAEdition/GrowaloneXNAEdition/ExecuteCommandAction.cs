using System;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	public class ExecuteCommandAction : InputBoxAction
	{
		public Growalone growalone;

		public ExecuteCommandAction(Growalone growalone) : base(new ActionArgument[0])
		{
			this.growalone = growalone;
			this.args = new ActionArgument[1];
		}

		public override void Execute()
		{
			if (this.args[0].StringParam.ToLower().StartsWith("show-fps"))
			{
				this.growalone.fpsShown = true;
			}
			else if (this.args[0].StringParam.ToLower().StartsWith("hide-fps"))
			{
				this.growalone.fpsShown = false;
			}
			else if (this.args[0].StringParam.ToLower().StartsWith("force-save-level"))
			{
				DataHandler.SaveMap(this.growalone.world, "C:\\growalone_maps\\worlds\\" + this.growalone.TheWorldName + ".gaw");
				this.growalone.ShowMsgBox(new DefaultMsgAction(), "Successfully saved world...", "Saved!");
			}
			else if (this.args[0].StringParam.ToLower().StartsWith("exit-without-saving"))
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit before saving?", "Sure to do that?");
				if (dialogResult == DialogResult.OK)
				{
					this.growalone.TheWorldName = "";
					this.growalone.Screen = ScreenType.WorldSelect;
				}
			}
			else if (this.args[0].StringParam.ToLower().StartsWith("help"))
			{
				MessageBox.Show("The available commands are:\r\n\r\nexit-without-saving\r\nshow-fps\r\nhide-fps\r\nhelp\r\nforce-save-level\r\n\r\nNote that the commands are case insensitive, so HiDe-FpS or SHow-FPs or hide-fpsbefhbefhh also works. It just has to start with the hide-fps or show-fps or something else.", "Command help");
			}
			else
			{
				this.growalone.ShowMsgBox(new DefaultMsgAction(), "The command you typed in ('" + this.args[0].StringParam + "') is invalid. Type 'help' for a list of debug commands.", "Command invalid!");
			}
		}
	}
}
