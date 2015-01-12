using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;
using WicGames.GameEngine.Physics.Collision;
namespace WicGames.GameEngine.Physics.Constraints
{
    abstract class Constraint
    {
        public abstract void update();
        public abstract void draw(Graphics2D graphics2D);
        public Body a, b;
        public double maxLength;
        public double currentLength() { return (a.center() - b.center()).magnitude(); }
        public bool vis = false;
        public class Link : Constraint{
            double restitution = 0;
			public Link()
			{

			}
            public Link(Body a, Body b, int length)
            {
                this.a = a;
                this.b = b;
                this.maxLength = length;
            }
            public override void update()
            {
                double length = currentLength();
                if (length < maxLength) return;
                Manifold m = new Manifold(a, b);
                m.normal = (a.center() - b.center()).normal();
                m.penetration = length - maxLength;
                m.restitution = restitution;
                m.isConstraint = true;
                Physics.currentPhysics.manifolds.Add(m);
            }
            public override void draw(Graphics2D graphics2D)
            {
                graphics2D.DrawLine(a.center(), b.center());
            }
        }
        public class Rod : Constraint
        {
			public Rod()
			{

			}
            public Rod(Body a, Body b, double length)
            {
                this.a = a;
                this.b = b;
                maxLength = length;
            }
            public override void update()
            {
                double length = currentLength();
                if (length == maxLength) return;

                //System.out.println(System.nanoTime());
                Manifold manifold = new Manifold(a, b);
                // Calculate the normal.
                Vector2 normal = b.center() - a.center();
                normal.normalize();

                if (length < maxLength)
                {
                    manifold.normal = normal;
                    manifold.penetration = length - maxLength;
                }
                else
                {
                    manifold.normal = -1 * normal;
                    manifold.penetration = maxLength - length;
                }
                manifold.isConstraint = true;
                manifold.restitution = 0;
                if (Physics.currentPhysics != null) { Physics.currentPhysics.manifolds.Add(manifold); }
                
            }
            public override void draw(Graphics2D graphics2D)
            {
                if(vis)
                    graphics2D.DrawLine(a.center(), b.center());
            }
        }
		public class Spring : Link
		{
			private Forces.Force springForce;
			double springConstant;
			public Spring(Body a, Body b, double length, double sCon)
			{
				this.a = a;
				this.b = b;
				this.maxLength = length;
				this.springConstant = sCon;
				springForce = new Forces.Force(null, (force,body) => {
					double scalar = (springConstant * (maxLength - currentLength()));
					Vector2 springPos = (a.position + b.position) / 2;
					Vector2 dir = (body.position - springPos).normal();
					body.force += dir * scalar;
				});
				Physics.currentPhysics.forces.Add(springForce);
				springForce.add(a);
				springForce.add(b);
			}
		}
        public static void updateConstraints(List<Constraint> l)
        {
            foreach (Constraint c in l)
            {
                c.update();
            }
        }
    }
}
