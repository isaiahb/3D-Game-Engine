using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WicGames.WICLibrary;
using WicGames.GameEngine.Main;

namespace WicGames.GameEngine.Input
{
	class Mouse
	{
		public static Vector2 position = new Vector2();
		public static Event moved = new Event();
		public static Event dragged = new Event();
		public static Event wheeled = new Event();

		public static class button1
		{
			public static Boolean Down = false;
			public static Event pressed = new Event();
			public static Event Released = new Event();
		}
		public static class Button2
		{
			public static Boolean Down = false;
			public static Event Pressed = new Event();
			public static Event Released = new Event();
		}
		public static void init()
		{
			Game.window.MouseUp += new MouseEventHandler(released);
			Game.window.MouseDown += new MouseEventHandler(pressed);
			Game.window.MouseMove += new MouseEventHandler(move);
		}

		public static void pressed(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Mouse.button1.Down = true;
				Console.Out.WriteLine(Mouse.position.x + " " + Mouse.position.y);
				button1.pressed.trigger();
			}
			if (e.Button == MouseButtons.Right)
			{
				Mouse.Button2.Down = true;
				Button2.Pressed.trigger();
			}

		}
		public static void released(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Mouse.button1.Down = false;
				button1.Released.trigger();
			}
			if (e.Button == MouseButtons.Right)
			{
				Mouse.Button2.Down = false;
				Button2.Released.trigger();
			}
		}
		public static void move(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Mouse.position.set(e.X, e.Y);
		}
	}
}
