using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;


namespace WicGames.GameEngine.Physics
{
	class Rectangle:Particle
	{
		public bool canCollide = true;

		//Constructrs
		public Rectangle(int x, int y, int z, int width, int height, int depth)
		{
			size.set(width, height, depth);
			position.set(x, y, z);

		}
		public Rectangle(Vector3 position, Vector3 size)
		{
			this.position.set(position);
			this.size.set(size);
		}
		public static void update(List<Rectangle> bodies, double delta)
		{
			for (int i = 0; i < bodies.Count(); i++)
			{
				bodies[i].update(delta);
			}
		}
        public Vector3 center()
        {
            return (position + size) / 2;
        }
	}
}
