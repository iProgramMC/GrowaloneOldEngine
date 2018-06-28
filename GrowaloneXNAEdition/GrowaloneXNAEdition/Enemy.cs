using System;

namespace GrowaloneXNAEdition
{
	[Serializable]
	public class Enemy
	{
		public int X;

		public int Y;

		public bool isPlayerRiding;

		public bool facingLeft;

		public virtual void Draw(Growalone game)
		{
		}

		public virtual void Update(Growalone game)
		{
		}

		public Enemy()
		{
		}

		public Enemy(int X, int Y)
		{
		}
	}
}
