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
		public Vector2 position = new Vector2();
		public Vector2 size = new Vector2(1, 1);
		public Vector2 velocity = new Vector2();
		public Vector2 acceleration = new Vector2();
		public Vector2 force = new Vector2();
		public double mass = 1;
		public double inverseMass = 1;
		public double delta = 0;
		public double time = 0;

		public Particle() {}
		public Particle(int x, int y)
		{
			position.set(x, y);
		}
		public Particle(Vector2 vector)
		{
			position.set(vector);//
		}

		public void setMass(double m)
		{
			mass = m;
			inverseMass = mass != 0 ? mass : 0;
		}
		public void edgeCheck()
		{
			if (position.x < 0)
			{
				position.x = 0;
				velocity.x = 0;
			}
			if (position.x + size.x > Main.Game.window.size.x)
			{
				position.x = Main.Game.window.size.x - size.x;
				velocity.x = 0;
			}


			if (position.y < 0)
			{
				position.y = 0;
				velocity.y = 0;
			}
			if (position.y + size.y > Main.Game.window.size.y)
			{
				position.y = Main.Game.window.size.y - size.y;
				velocity.y = 0;
			}
		}
		public void addForce(Vector2 force)
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
			edgeCheck();
		}

		public void draw(Graphics2D g)
		{
			g.fillRect(position, size);
		}
	}
}
