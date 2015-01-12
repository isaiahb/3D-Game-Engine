using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.GameEngine.Main;
using WicGames.WICLibrary;

namespace WicGames.GameEngine.Physics.Forces
{
	class Force
	{
        public delegate void Apply(Vector2 force, Particle b);
        private Apply apply;
        public Force(Vector2 force,Apply apply)
		{
			this.force = force;
            this.apply = apply;
		}
		public static void update(List<Force> forces)
		{
			for (int i = 0; i < forces.Count(); i++)
			{
				forces[i].update();
			}
		}
		public Vector2 force;
		public List<Body> bodies = new List<Body>();
		public void add(Body body) { bodies.Add(body); }
		public void remove(Body body) { bodies.Remove(body); }
		public void updateForce(Body body)
		{
			body.addForce(force);
		}

		public void update()
		{
			for (int i = 0; i < bodies.Count(); i++)
			{
                if (i < bodies.Count())
                    apply.Invoke(force, bodies[i]);
			}
		}
	}
}
