using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.GameEngine.Physics;

namespace WicGames.GameEngine.Entities
{
	abstract class Entity
	{
		public int maxHealth; 
		public int health;
		public int defense;
		public int attack;
		public bool canJump;
		public bool canAttack;
		public Body body;

		public void walkLeft()
		{
		}
		public void walkRight()
		{
		}
		public void jump()
		{
		}

		public Entity(Body body, int health, int attack, int defense)
		{
			this.health = health;
			this.attack = attack;
			this.defense = defense;
			this.body = body;
		}
        public Entity()
        {

        }
	}
}
