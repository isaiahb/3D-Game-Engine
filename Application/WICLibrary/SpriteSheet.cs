using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WicGames.WICLibrary
{	
	class SpriteSheet
	{
		private Vector2 spriteSize;
		private Vector2 numSprites;
		private Bitmap sheet;
		private Image[,] spriteSheet;
		private int borderSize;
		private int offset;
		private int numSpritesTotal = 0;
		public SpriteSheet(String path, int x, int y, int borderSize, int offset)
		{
			spriteSize = new Vector2(x, y);
			sheet = (Bitmap)Image.FromFile(path);
			this.borderSize = borderSize;
			this.offset = offset;
			numSprites = new Vector2((sheet.Width - offset) / (spriteSize.x + borderSize), (sheet.Height - offset) / (spriteSize.y + borderSize));
			spriteSheet = new Image[x,y];
			loadSprites();
		}
		public Vector2 getNumSprites()
		{
			return new Vector2(numSprites.x,numSprites.y);
		}
		public int getNumSpritesTotal()
		{
			return numSpritesTotal;
		}
		private Image getSprite(int x, int y)
		{
			if (x > numSprites.x || y > numSprites.y)throw new IndexOutOfRangeException();
			
				Vector2 spritePosition = new Vector2(x * spriteSize.x + offset, y * spriteSize.y + offset);
				Bitmap sprite = new Bitmap(sheet,(int)spriteSize.x, (int)spriteSize.y);
				for (int i = 0; i < spriteSize.x;i++ )
				{
					for (int j = 0; j < spriteSize.y; j++)
					{
						sprite.SetPixel(i, j, sheet.GetPixel(i + (int)spritePosition.x, j + (int)spritePosition.y));
					}
				}
				return sprite;
			
		}
		private void loadSprites()
		{
			for (int x = 0; x < numSprites.x; x++)
			{
				for (int y = 0; y < numSprites.y; y++)
				{
					spriteSheet[x,y] = getSprite(x, y);
				}
			}
			sheet = null;
		}
		public Image getImage(int x, int y) { return spriteSheet[x, y]; }
		public Image getImage(int i){return spriteSheet[(int)(i % numSprites.x),(int)(i / numSprites.x)];}
	}
}
