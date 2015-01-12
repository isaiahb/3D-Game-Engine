using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;


namespace WicGames.GameEngine.Physics
{
	class Body:Particle
	{
		public bool canCollide = true;

		//Constructrs
		public Body(int x, int y, int width, int height)
		{
			size.set(width, height);
			position.set(x, y);

		}
		public Body(Vector2 position, Vector2 size)
		{
			this.position.set(position);
			this.size.set(size);
		}
		public static void update(List<Body> bodies, double delta)
		{
			for (int i = 0; i < bodies.Count(); i++)
			{
				bodies[i].update(delta);
			}
		}
        public Vector2 center()
        {
            return (position + size) / 2;
        }
	}
}
