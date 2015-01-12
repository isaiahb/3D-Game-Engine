using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WicGames.WICLibrary
{
	class IVector2
	{
		public int x;
		public int y;
        public Vector2 leftover;
		//Constructors
		public IVector2()
		{
			this.x = 0;
			this.y = 0;
		}
		public IVector2(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public double magnitude()
		{
			return Math.Sqrt((x * x) + (y * y));
		}
		public int magnitudeSquared()
		{
			return (x * x) + (y * y);
		}
		public void normalize()
		{
			double mag = magnitude();
			x = (int)(x / mag);
			y = (int)(y / mag);
		}
		public IVector2 normal()
		{
			double mag = magnitude();
			return new IVector2((int)(x / mag),(int)(y / mag));
		}
        public static implicit operator Point(IVector2 v)
        {
            return new Point(v.x, v.y);
        }
		//Math with operator overloading
		//add
		public static IVector2 operator +(IVector2 left, IVector2 right)
		{
			return new IVector2(left.x + right.x, left.y + right.y);
		}
        public static IVector2 operator +(IVector2 left, Vector2 right)
        {
            left.leftover += new Vector2(right.x - (int)right.x,right.y - (int)right.y);
            return new IVector2(left.x + (int)right.x, left.y + (int)right.y);
        }
        public static IVector2 operator +(Vector2 left, IVector2 right)
        {
            right.leftover += new Vector2(right.x - (int)right.x,right.x - (int)right.y);
            return new IVector2(right.x + (int)left.x, right.y + (int)left.y);
        }
		//sub
		public static IVector2 operator -(IVector2 left, IVector2 right)
		{	
			return new IVector2(left.x - right.x, left.y - right.y);
		}
        public static IVector2 operator -(IVector2 left, Vector2 right)
        {
            left.leftover -= new Vector2(right.x - (int)right.x, right.y - (int)right.y);
            return new IVector2(left.x - (int)right.x, left.y - (int)right.y);
        }
        public static IVector2 operator -(Vector2 left, IVector2 right)
        {
            right.leftover -= new Vector2(right.x - (int)right.x, right.x - (int)right.y);
            return new IVector2(right.x - (int)left.x, right.y - (int)left.y);
        }
		//mul
		public static IVector2 operator *(IVector2 vector, int scalar)
		{
			return new IVector2(vector.x * scalar, vector.y * scalar);
		}
		public static IVector2 operator *(int scalar, IVector2 vector)
		{
			return new IVector2(vector.x * scalar, vector.y * scalar);
		}

		//div
		public static IVector2 operator /(IVector2 vector, int scalar)
		{
			return new IVector2(vector.x / scalar, vector.y / scalar);
		}
		public static IVector2 operator /(int scalar, IVector2 vector)
		{
			return new IVector2(vector.x / scalar, vector.y / scalar);
		}
		public static int dotProduct(IVector2 left, IVector2 right)
		{
			return right.x * left.x + right.y * left.y;
		}

		// end of math methods
		public void set(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public void set(IVector2 vector)
		{
			this.x = vector.x;
			this.y = vector.y;
		}
		public void print()
		{
			System.Console.WriteLine("(" + x + ", " + y + ")");
		}

	}
}
