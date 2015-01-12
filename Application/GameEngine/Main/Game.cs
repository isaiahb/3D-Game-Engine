using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WicGames.GameEngine.Input;
using WicGames.WICLibrary;
using System.Drawing;
using WicGames.GameEngine.Physics;
using WicGames.GameEngine.Physics.Forces;
using WicGames.GameEngine.Entities;
using WicGames.GameEngine.Physics.Constraints;
namespace WicGames.GameEngine.Main
{
	class Game
	{
		
		public static Window window = new Window();
		public static double fps = 60;
		public static double time = 0;
		public static Rectangle particle = new Rectangle(1,1,1,1);
        public static Force gravity = new Force(new Vector2(0, 20), (force, particle) => {
            particle.force += force * particle.mass;
        });
		public static void Main()
		{
			Mouse.init();
			Key.init();
			window.init(500,500);
            gravity.add(particle);
            Scene.currentScene = new Scene();
            Scene.currentScene.init();
            Scene.currentScene.physics.forces.Add(gravity);
            Scene.currentScene.physics.bodies.Add(particle);
			Application.Run(window);
		}

		public static void update(double delta)
		{
            Scene.currentScene.update(delta);
		}
		public static void draw(Graphics2D g) 
		{
            Scene.currentScene.physics.draw(g);
		}
	}
}
