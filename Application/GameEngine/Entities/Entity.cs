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
		public Rectangle body;

		public Entity(int maxHealth, int attack, int defense)
		{
			this.attack = attack;
			this.defense = defense;
			this.maxHealth = maxHealth;
		}
        public Entity(){}

		public void walkLeft()
		{
		}
		public void walkRight()
		{
		}
		public void jump()
		{
		}


	}
}
