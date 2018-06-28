using System;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	public class MessageBoxAction
	{
		public static string sdasasdadsasdadsadsadsa = "If you see this then congratulations!";

		public MessageActionArgument[] args;

		public virtual void Execute()
		{
			MessageBox.Show("Invalid action");
		}

		public MessageBoxAction(params MessageActionArgument[] args)
		{
			this.args = args;
		}
	}
}
