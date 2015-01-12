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
		public Body a, b;
		public Vector2 normal;
		public double penetration, restitution;
		public bool isConstraint = false;
		// Constructor
		public Manifold(Body a, Body b)
		{
			this.a = a;
			this.b = b;
		}

	}
}
