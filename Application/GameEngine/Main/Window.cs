using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WicGames.WICLibrary;
using System.Threading;


namespace WicGames.GameEngine.Main
{
	class Window:Form
	{
		public bool running;
		public bool done = false;
		public Vector2 size = new Vector2();

		public void run()
		{
			double step = 1/Game.fps;
            double taken = 0;
			while (!done)
			{
				while (Wic.wait(step - taken) && running)
				{
                    taken = Wic.getEpochTime();
					Game.update(step);
					this.Invalidate();	//triggers the paint event, maybe...
                   // this.BeginInvoke(new MethodInvoker(() => { this.Update(); }));
                    taken = Wic.getEpochTime() - taken;
				}
				Wic.wait(step);
			}
			
		}
		public void init(int width, int height)
		{
			size.set(width, height);
			ClientSize = new Size(width, height);
			FormClosed += new FormClosedEventHandler(this.closing);
			Paint += new PaintEventHandler(Window.paint);
			running = true;
            DoubleBuffered = true;
			Thread loop = new Thread(new ThreadStart(run));
			loop.Start();
		}
		public static void paint(object sender, PaintEventArgs e)
		{
			Game.draw(new Graphics2D(e.Graphics));
		}
		public void closing(object sender, FormClosedEventArgs e)
		{
			running = false;
			done = true;
		}
	}
}
