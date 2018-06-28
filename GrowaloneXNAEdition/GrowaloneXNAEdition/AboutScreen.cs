using System;

namespace GrowaloneXNAEdition
{
	public class AboutScreen
	{
		public static string Title = "About Growalone";

		public static string Text = string.Concat(new string[]
		{
			"\r\nGrowalone has been brought to you by:\r\n\r\n- iProgramMC\r\n\r\nSprites: iProgramMC\r\nDevelopment: iProgramMC\r\nSoundtrack:\r\nSuper Mario Brothers by Nintendo\r\niProgramMC\r\nPrograms used:\r\nBosca Ceoil\r\nMicrosoft Visual C# 2010 Express\r\nPaint.net\r\nIsoPix\r\nXNA Game Studio / Framework 4.0 (four point zero)\r\n\r\nGrowalone version ",
			Growalone.versionID,
			".\r\n",
			Growalone.CopyrightText,
			"\r\n\r\nThanks for playing!\r\n"
		});
	}
}
