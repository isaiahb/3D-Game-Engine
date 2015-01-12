using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WicGames.WICLibrary;
using WicGames.GameEngine.Main;

namespace WicGames.GameEngine.Input
{
	class Key
	{
		public static Event[] pressed = new Event[127];
		public static Event[] released = new Event[127];
		public static bool[] down = new bool[127];

		public static void init()
		{
			for (int i = 0; i < 127; i++)
			{
				pressed[i] = new Event();
				released[i] = new Event();
				down[i] = false;
			}
			Game.window.KeyDown += new KeyEventHandler(keyDownHandler);
			Game.window.KeyUp += new KeyEventHandler(keyUpHandler);

		}
		public static void keyDownHandler(object sender, KeyEventArgs e)
		{
			pressed[e.KeyValue].trigger();
			down[e.KeyValue] = true;
			System.Console.Out.WriteLine(e.KeyValue + "DOWN");
		}
		public static void keyUpHandler(object sender, KeyEventArgs e)
		{
			released[e.KeyValue].trigger();
			down[e.KeyValue] = false;
			System.Console.Out.WriteLine(e.KeyValue + "UP");
			
		}
	}
}
