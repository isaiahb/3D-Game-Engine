using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;

namespace WicGames.GameEngine.Physics.Collision
{
	class Resolution
	{
		public static double getSeparatingVelocity(Manifold m)
		{
			Vector2 relativeVelocity = m.b.velocity - m.a.velocity;
			return Vector2.dotProduct(relativeVelocity, m.normal);
		}

		public static void resolveVelocity(Manifold m, bool friction)
		{
			Rectangle a = m.a;
			Rectangle b = m.b;

			// Trigger Hit Methods or w/e;
			/*
			if (!a.touching.contains(b))
			{
				a.hit.trigger(b);
				a.touching.add(b);
				b.hit.trigger(a);
				b.touching.add(a);
			}
			 */

			double separatingVelocity = getSeparatingVelocity(m);
			double totalInverseMass = a.inverseMass + b.inverseMass;

			// Do not resolve if velocities are separating
			// Do not resolve if both objects have infinite mass
			if (separatingVelocity > 0 || totalInverseMass <= 0)
			{
				return;
			}

			double restitution = m.restitution;

			// Calculates the new separating velocity
			double newSeparatingVelocity = -separatingVelocity * restitution;

			// Check velocity build up due to acceleration only
			Vector2 accCausedVelocity = a.acceleration + b.acceleration;
			double accCausedSepVelocity = Vector2.dotProduct(accCausedVelocity, m.normal);
			accCausedSepVelocity *= a.delta;

			// If we’ve got a closing velocity due to acceleration buildup,
			// remove it from the new separating velocity.
			if (accCausedSepVelocity < 0)
			{
				newSeparatingVelocity += restitution * accCausedSepVelocity;

				// Make sure we haven’t removed more than was there to remove.
				if (newSeparatingVelocity < 0)
					newSeparatingVelocity = 0;
			}

			double deltaVelocity = separatingVelocity - newSeparatingVelocity; // Calculates
			// the
			// change
			// in
			// velocity
			double impulse = deltaVelocity / totalInverseMass; // Calculates the
			// impulse
			// scalar/length
			Vector2 impulsePerMass = m.normal * impulse; // Calculates
			// the
			// impulse

			// vector/direction

			//Calculates the impulses for the bodies
			Vector2 impulseA = impulsePerMass * a.inverseMass;
			Vector2 impulseB = impulsePerMass * b.inverseMass;
			// Apply impulse
			a.velocity += impulseA;
			b.velocity -= impulseB;
		}

		public static void resolvePenetration(Manifold m)
		{
			Rectangle a = m.a;
			Rectangle b = m.b;

			double totalIMass = a.inverseMass + b.inverseMass;

			// Do not resolve if objects are not penetrating or both have infinite mass
			if (totalIMass <= 0 || m.penetration <= 0) return;

			Vector2 movePerIMass = m.normal * (m.penetration / totalIMass);

			a.position -= (movePerIMass * a.inverseMass);
			b.position += (movePerIMass * b.inverseMass);

		}

		public static void resolve(Manifold m)
		{
			if (m != null)
			{
				resolvePenetration(m);
				resolveVelocity(m, false); // Change second parameter to true or
				// false if you want the friction or not
			}
		}

		public static void update(List<Manifold> manifolds)
		{
			for (int i = 0; i < manifolds.Count(); i++)
				Resolution.resolve(manifolds[i]);
			
		}
	}
}
