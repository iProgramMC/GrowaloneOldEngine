using System;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	public class InputBoxAction
	{
		public static string sdasasdadsasdadsadsadsa = "If you see this then my password is *********************************!";

		public ActionArgument[] args;

		public virtual void Execute()
		{
			MessageBox.Show("Invalid action");
		}

		public InputBoxAction(params ActionArgument[] args)
		{
			this.args = args;
		}
	}
}
