using Microsoft.VisualBasic;
using System;

namespace GrowaloneXNAEdition
{
	public class InputBoxGrowalone
	{
		public static string ShowInputBox(string prompt, string title, Growalone game)
		{
			game.isRunning = false;
			string result = Interaction.InputBox(prompt, title, "", -1, -1);
			game.isRunning = true;
			return result;
		}

		public static string ShowInputBox(string prompt, string title, Growalone game, string DefaultResponse)
		{
			game.isRunning = false;
			string result = Interaction.InputBox(prompt, title, DefaultResponse, -1, -1);
			game.isRunning = true;
			return result;
		}
	}
}
