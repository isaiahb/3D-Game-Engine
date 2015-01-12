using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;
using System.Drawing;

namespace WicGames.GameEngine.Entities
{
	class Food : Entity
	{
		Image food = Image.FromFile("Assets/Images/Image1.jpg",true);


		public void draw(Graphics2D g)
		{
			g.DrawImage(food,0,0);
		}
	}
}
