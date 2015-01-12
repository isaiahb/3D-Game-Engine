using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;

namespace WicGames.GameEngine.Physics
{
	class Particle
	{
		public Vector3 position = new Vector3();
		public Vector3 size = new Vector3(1, 1, 1);
		public Vector3 velocity = new Vector3();
		public Vector3 acceleration = new Vector3();
		public Vector3 force = new Vector3();
		public double mass = 1;
		public double inverseMass = 1;
		public double delta = 0;
		public double time = 0;

		public Particle() {}
		public Particle(int x, int y, int z)
		{
			position.set(x, y, z);
		}
		public Particle(Vector3 vector)
		{
			position.set(vector);//
		}

		public void setMass(double m)
		{
			mass = m;
			inverseMass = mass != 0 ? mass : 0;
		}
	
		public void addForce(Vector3 force)
		{
			this.force += force;
		}
		public void update(double delta)
		{
			if (mass == 0) return;
			this.delta = delta;
			time += delta;
			acceleration = force * inverseMass;
			velocity += acceleration * delta;
			position += velocity * delta;
			force.clear();
			
		}

		public void draw(Graphics2D g)
		{
			g.fillRect(g.toScreen(position), new Vector2(3,3));
		}
	}
}
