using System;

namespace GrowaloneXNAEdition
{
	public class DefaultMsgAction : MessageBoxAction
	{
		public override void Execute()
		{
		}

		public DefaultMsgAction() : base(new MessageActionArgument[0])
		{
		}
	}
}
