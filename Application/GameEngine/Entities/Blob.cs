using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WicGames.GameEngine.Physics;
using WicGames.GameEngine.Physics.Constraints;
using WicGames.GameEngine.Physics.Forces;
using WicGames.WICLibrary;
using System.Drawing;
namespace WicGames.GameEngine.Entities
{
	class Blob : Entity
	{
		/*
        private List<Rectangle> points = new List<Rectangle>();
        public Blob(int x, int y, Physics.Physics p)
        {
            int radius = 10;
            int i = 0;
            for (int xPos = -20; xPos < 20; xPos += 3)
            {
                int yPos = (int)Math.Sqrt(Math.Pow(radius * 2,2) - Math.Pow(xPos,2));
                points.Add(new Rectangle(xPos + x, yPos + y, 10, 10));
                p.bodies.Add(points[i]);
                i++;
            }
            for (int xPos = 20; xPos > -20; xPos -= 3)
            {
                int yPos = -(int)Math.Sqrt(Math.Pow(radius * 2, 2) - Math.Pow(xPos, 2));
                points.Add(new Rectangle(xPos + x, yPos + y, 10, 10));
                p.bodies.Add(points[i]);
                i++;
            }
            for (int j = 0; j < points.Count(); j++)
            {
                int nextP = (j + 1) % (points.Count() - 1);
                int lastP = j - 2 >= 0 ? j - 2 : points.Count() - Math.Abs(j - 2);
                int lastP3 = j - 3 >= 0 ? j - 3 : points.Count() - Math.Abs(j - 3);
                int lastP4 = j - 4 >= 0 ? j - 4 : points.Count() - Math.Abs(j - 4);
                int lastP5 = j - 5 >= 0 ? j - 5 : points.Count() - Math.Abs(j - 5); 
                int lastP6 = j - 6 >= 0 ? j - 6 : points.Count() - Math.Abs(j - 6);
                Constraint c = new Constraint.Spring(points[j], points[nextP], (int)(points[j].position - points[nextP].position).magnitude(),200);
                Constraint c2 = new Constraint.Spring(points[j], points[lastP], (int)(points[j].position - points[lastP].position).magnitude(),200);
                Constraint c3 = new Constraint.Spring(points[j], points[lastP3], (int)(points[j].position - points[lastP3].position).magnitude(),200);
                Constraint c4 = new Constraint.Spring(points[j], points[lastP4], (int)(points[j].position - points[lastP4].position).magnitude(),200);
                Constraint c5 = new Constraint.Spring(points[j], points[lastP5], (int)(points[j].position - points[lastP5].position).magnitude(),200);
                Constraint c6 = new Constraint.Spring(points[j], points[lastP6], (int)(points[j].position - points[lastP6].position).magnitude(),400);
                p.constraints.Add(c);
                p.constraints.Add(c2);
                p.constraints.Add(c3);
                p.constraints.Add(c4);
                p.constraints.Add(c5);
                p.constraints.Add(c6);
            }
            Constraint c7 = new Constraint.Spring(points[points.Count() / 4], points[points.Count() / 4 * 3], (int)(points[points.Count() / 4].position - points[points.Count() / 4 * 3].position).magnitude(),400);
            p.constraints.Add(c7);
        }
        public void addForce(Force f)
        {
            foreach (Rectangle p in points)
            {
                f.bodies.Add(p);
            }
        }
        public void draw(Graphics2D g)
        {
            Point[] pons = new Point[points.Count()];
            int i = 0;
            foreach (Rectangle p in points)
            {
                pons[i] = points[i].position;
                i++;
            }
            g.graphics.DrawClosedCurve(g.pen, pons);
        }
		 * 
		 */
	}
}
