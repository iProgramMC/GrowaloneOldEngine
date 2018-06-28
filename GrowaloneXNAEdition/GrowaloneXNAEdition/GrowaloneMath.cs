using System;

namespace GrowaloneXNAEdition
{
	public class GrowaloneMath
	{
		public static float MoveTowards(float current, float target, float speed)
		{
			float result;
			if (current < target)
			{
				result = current + speed;
			}
			else
			{
				result = target;
			}
			return result;
		}
	}
}
