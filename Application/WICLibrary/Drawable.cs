using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.WICLibrary;

namespace WicGames.WICLibrary
{
	interface Drawable
	{
		//Interface for objects that need to be drawn
		void draw(Graphics2D graphics2D);
		//void updateImage(Image texture);
		/**
		 *  Draws all objects in array
		 */
		/*void draw(Graphics2D graphics2D, List<Drawable> objects){
			foreach(Drawable draw in objects){
				draw.draw(graphics2D);
			}
		}*/
	}
}

