using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WicGames.GameEngine.Main;

namespace WicGames.WICLibrary
{
    class Graphics2D
    {
        public Graphics graphics;
        public SolidBrush solidBrush = new SolidBrush(Color.Black);
        public Pen pen = new Pen(Color.Black);
		public Vector2 size;

        public Graphics2D(Graphics g)
        {
			size = new Vector2(Game.window.ClientSize.Width, Game.window.ClientSize.Height);
            graphics = g;
        }

        public void setColor(Color color)
        {
            solidBrush.Color = color;
            pen.Color = color;
        }

        //Rectangle
        public void fillRect(int x, int y, int width, int height)
        {
            graphics.FillRectangle(solidBrush, x, y, width, height);
        }
        public void fillRect(double x, double y, double width, double height)
        {
            graphics.FillRectangle(solidBrush, (int)x, (int)y, (int)width, (int)height);
        }
        public void fillRect(params Vector2[] vectors)
        {
            Vector2 position = vectors[0];
            Vector2 size = vectors.Length > 1 ? vectors[1] : new Vector2(3, 3);
            graphics.FillRectangle(solidBrush, (int)position.x, (int)position.y, (int)size.x, (int)size.y);
        }

        //Polygon
        public void fillPolygon(int[] xPoints, int[] yPoints)
        {
            graphics.FillPolygon(solidBrush, Wic.toPointArray(xPoints, yPoints));
        }
        public void fillPolygon(Vector2[] vectors)
        {
            graphics.FillPolygon(solidBrush, Wic.toPointArray(vectors));
        }
        public void DrawArc(Rectangle rect, float startAngle, float sweepAngle)
        {
            graphics.DrawArc(pen, rect, startAngle, sweepAngle);
        }
        public void DrawArc(RectangleF rect, float startAngle, float sweepAngle)
        {
            graphics.DrawArc(pen, rect, startAngle, sweepAngle);
        }
        public void DrawArc(int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            graphics.DrawArc(pen,x,y,width,height,startAngle,sweepAngle);
        }
        public void DrawArc(Vector2 pos, Vector2 size, int startAngle, int sweepAngle)
        {
            graphics.DrawArc(pen, (int)pos.x, (int)pos.y, (int)size.x, (int)size.y, startAngle, sweepAngle);
        }
        public void DrawEllipse(Rectangle rect)
        {
            graphics.DrawEllipse(pen, rect);
        }
        public void DrawEllipse(RectangleF rect)
        {
            graphics.DrawEllipse(pen, rect);
        }
        public void DrawEllipse(int x, int y, int width, int height)
        {
            graphics.DrawEllipse(pen, x, y, width, height);
        }
        public void DrawEllipse(Vector2 pos, Vector2 size)
        {
            graphics.DrawEllipse(pen, (float)pos.x, (float)pos.y, (float)size.x, (float)size.y);
        }
        public void DrawImage(Image i, int x, int y)
        {
            graphics.DrawImage(i, x, y);
        }
        public void DrawImage(Image i, Vector2 position)
        {
            graphics.DrawImage(i,(float)position.x,(float)position.y);
        }
        public void DrawImage(Image i,Rectangle rect)
        {
            graphics.DrawImage(i, rect);
        }
        public void DrawLine(Point a, Point b)
        {
            graphics.DrawLine(pen, a, b);
        }
		

		//////////////////
		//3D stuff		//
		//////////////////
		public Vector2 toScreen(Vector3 vector)
		{
			double x = vector.x / -vector.z;
			double y = vector.y / -vector.z * -1;
			x = (size.x/2) + x*(size.x/2);
 			y = (size.y/2) + y*(size.x/2);
			return new Vector2(x,y);
		}



    }
}
