using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;

namespace WicGames.GameEngine.Physics.Collision
{
	class Detection
	{
		//Broad Phase
		public static void BroadPhase(List<Rectangle> bodies)
		{
			int length = bodies.Count();
			Rectangle a, b;

			for (int i = 0; i < length; i++)
			{
				// if we are on the last Body in the array just quit since every other body already compared its self with it
				a = bodies.ElementAt(i);
				//a.touching.clear();
				if (i == length - 1) break;

				if (a.canCollide)
				{
					for (int j = i + 1; j < length; j++)
					{
						b = bodies.ElementAt(j);
						//b.touching.clear();
						
						if (b.canCollide)
							detect(a, b); //Checks whether they are colliding, if they are it generates the manifold
					}//Second Loop
				}

			}// First Loop
		}

		//Narrow Phase
		//Rectangle, Rectangle
		public static void detect(Rectangle a, Rectangle b)
		{

			Vector3 minA, minB, maxA, maxB;
			minA = a.position; maxA = minA + a.size;
			minB = b.position; maxB = minB + b.size;

			if (maxA.x + 1 < minB.x || minA.x - 1 > maxB.x) return;
			if (maxA.y + 1 < minB.y || minA.y - 1 > maxB.y) return;
			//return true;

			//Collision is happening so generate manifold
			Manifold m = new Manifold(a, b);
			m.restitution = 0.25;

			Vector3 halfExtentsA = a.size / 2;
			Vector3 halfExtentsB = b.size / 2;
			Vector3 centerA = a.position + halfExtentsA;
			Vector3 centerB = b.position + halfExtentsB;

			double hX = halfExtentsA.x + halfExtentsB.x;
			double hY = halfExtentsA.y + halfExtentsB.y;
			double dX = Math.Abs(centerA.x - centerB.x);
			double dY = Math.Abs(centerA.y - centerB.y);
			double oX = Math.Abs(dX - hX);
			double oY = Math.Abs(dY - hY);
			
			if (oX < oY)
			{
				m.penetration = oX - 1;
				if (centerA.x > centerB.x)
					m.normal = new Vector2(-1, 0);
				else
					m.normal = new Vector2(1, 0);
			}
			else
			{
				m.penetration = oY - 1;
				if (centerA.y > centerB.y)
					m.normal = new Vector2(0, -1);
				else
					m.normal = new Vector2(0, 1);
			}
		}
	}
}
