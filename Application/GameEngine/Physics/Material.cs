using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WicGames.GameEngine.Physics
{
	class Material
	{
		public double density, restitution, friction, staticFriction;

		public Material(double density, double restitution, double friction)
		{
			this.density = density;
			this.restitution = restitution;
			this.friction = friction;
			this.staticFriction = 1;
		}
	}
}
