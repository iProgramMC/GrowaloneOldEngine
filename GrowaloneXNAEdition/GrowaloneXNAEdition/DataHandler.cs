using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GrowaloneXNAEdition
{
	public class DataHandler
	{
		public static void SaveMap(object array, string path)
		{
			using (Stream stream = File.Open(path, FileMode.Create))
			{
				new BinaryFormatter().Serialize(stream, array);
			}
		}

		public static object LoadMap(string path)
		{
			object result;
			using (Stream stream = File.Open(path, FileMode.Open))
			{
				result = new BinaryFormatter().Deserialize(stream);
			}
			return result;
		}
	}
}
