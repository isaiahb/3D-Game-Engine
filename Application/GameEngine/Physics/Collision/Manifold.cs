using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;
namespace WicGames.GameEngine.Physics.Collision
{
	class Manifold
	{
		public Rectangle a, b;
		public Vector2 normal;
		public double penetration, restitution;
		public bool isConstraint = false;
		// Constructor
		public Manifold(Rectangle a, Rectangle b)
		{
			this.a = a;
			this.b = b;
		}

	}
}
