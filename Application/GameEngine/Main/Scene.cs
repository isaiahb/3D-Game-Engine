using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.GameEngine.Physics;
using WicGames.GameEngine.Physics.Forces;
using WicGames.WICLibrary;

namespace WicGames.GameEngine.Main
{
	class Scene
	{
		public static Scene currentScene;		//Holds the current scene, set this to a new scene when wanting to change the scene
		public Vector2 camera = new Vector2();	//The offset to draw things so the character is always drawn in the middle of the screen
		public Vector2 size = new Vector2();	//The TileSize of the current Scene, used to help determine the offset of the camera
		public Physics.Physics physics = new Physics.Physics();
		
		public Scene()
		{

		}
		public void init()
		{
            physics.init();
		}
		public void update(double delta)
		{
			physics.update(delta);
		}
	}
}
