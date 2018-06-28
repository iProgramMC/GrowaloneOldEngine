using System;

namespace GrowaloneXNAEdition
{
	public class ActionArgument
	{
		public int IntParam;

		public string StringParam;

		public bool BoolParam;

		public ActionArgument(int param)
		{
			this.IntParam = param;
		}

		public ActionArgument(string param)
		{
			this.StringParam = param;
		}

		public ActionArgument(bool param)
		{
			this.BoolParam = param;
		}

		public ActionArgument(int param, string param2)
		{
			this.IntParam = param;
			this.StringParam = param2;
		}
	}
}
