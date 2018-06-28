using System;
using System.Runtime.InteropServices;

namespace ConsoleManagement
{
	public class Window
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AllocConsole();

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeConsole();
	}
}
