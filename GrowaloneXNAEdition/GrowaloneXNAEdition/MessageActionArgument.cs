using System;

namespace GrowaloneXNAEdition
{
	public class MessageActionArgument
	{
		public int IntParam;

		public string StringParam;

		public bool BoolParam;

		public MessageActionArgument(int param)
		{
			this.IntParam = param;
		}

		public MessageActionArgument(string param)
		{
			this.StringParam = param;
		}

		public MessageActionArgument(bool param)
		{
			this.BoolParam = param;
		}
	}
}
