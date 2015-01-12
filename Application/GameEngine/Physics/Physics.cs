using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.GameEngine.Physics.Collision;
using WicGames.GameEngine.Physics.Forces;
using WicGames.WICLibrary;
using WicGames.GameEngine.Physics.Constraints;
namespace WicGames.GameEngine.Physics
{
    class Physics
    {
        public static Physics currentPhysics;
        public List<Manifold> manifolds = new List<Manifold>();
        public List<Particle> particles = new List<Particle>(); //Holds all the particles and bodies
        public List<Rectangle> bodies = new List<Rectangle>();
        public List<Force> forces = new List<Force>();
        public List<Constraint> constraints = new List<Constraint>();
        public void update(double delta)
        {
            //Basic update method for physics
            manifolds.Clear();
            //Force.update(forces);
            Rectangle.update(bodies, delta);
            Constraint.updateConstraints(constraints);
            Force.update(forces);

            Detection.BroadPhase(bodies);
            Resolution.update(manifolds);
        }

        public void draw(Graphics2D g)
        {
            foreach (Particle p in particles)
            {
                p.draw(g);
            }
			foreach (Rectangle b in bodies)
			{
				b.draw(g);
			}
            foreach (Constraint c in constraints)
            {
                c.draw(g);
            }
        }
        public void init()
        {
            currentPhysics = this;
        }
    }
}
