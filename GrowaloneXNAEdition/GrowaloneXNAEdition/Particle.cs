using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class Particle
	{
		public int X;

		public int Y;

		public virtual void Draw(Growalone game)
		{
		}

		public virtual void Update(Growalone game)
		{
		}

		public Particle()
		{
		}

		public Particle(int X, int Y)
		{
		}
	}
}
