using ConsoleManagement;
using System;
using System.Windows.Forms;

namespace GrowaloneXNAEdition
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				using (Growalone growalone = new Growalone())
				{
					Window.FreeConsole();
					if (args.Length > 0)
					{
						if (args[0] == "-debug")
						{
							Window.AllocConsole();
							growalone.Run();
						}
						else
						{
							MessageBox.Show("The game didn't get the correct arguments! Please try running the game without any arguments!", "Error processing cmd arguments");
							growalone.Run();
						}
					}
					else
					{
						growalone.Run();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Whoops, Growalone crashed!\r\n\r\nThe error code is here:\r\n\r\n" + ex.ToString() + "\r\nPlease screenshot this error message and report this bug by sending a message at growalonegame@gmail.com!\r\nThanks for playing Growalone!", "Whoops, Growalone crashed!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
