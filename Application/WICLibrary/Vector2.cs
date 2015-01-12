using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WicGames.WICLibrary
{
	class Vector2
	{
		public double x;
		public double y;

		//Constructors
		public Vector2()
		{
			this.x = 0;
			this.y = 0;
		}
        public static implicit operator Point(Vector2 v)
        {
            return new Point((int)v.x,(int)v.y);
        }
		public Vector2(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
		public double magnitude()
		{
			return Math.Sqrt((x * x) + (y * y));
		}
		public double magnitudeSquared()
		{
			return (x * x) + (y * y);
		}
		public void normalize()
		{
			double mag = magnitude();
			x /= mag;
			y /= mag;
		}
		public Vector2 normal()
		{
			double mag = magnitude();
			return new Vector2(x / mag, y / mag);
		}
		//Math with operator overloading
		//add
		public static Vector2 operator +(Vector2 left, Vector2 right)
		{
			return new Vector2(left.x + right.x, left.y + right.y);
		}
        public static Vector2 operator +(Vector2 left, IVector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }
        public static Vector2 operator +(IVector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }
		//sub
		public static Vector2 operator -(Vector2 left, Vector2 right)
		{	
			return new Vector2(left.x - right.x, left.y - right.y);
		}
        public static Vector2 operator -(Vector2 left, IVector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }
        public static Vector2 operator -(IVector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }
		//mul
		public static Vector2 operator *(Vector2 vector, double scalar)
		{
			return new Vector2(vector.x * scalar, vector.y * scalar);
		}
		public static Vector2 operator *(double scalar, Vector2 vector)
		{
			return new Vector2(vector.x * scalar, vector.y * scalar);
		}

		//div
		public static Vector2 operator /(Vector2 vector, double scalar)
		{
			return new Vector2(vector.x / scalar, vector.y / scalar);
		}
		public static Vector2 operator /(double scalar, Vector2 vector)
		{
			return new Vector2(vector.x / scalar, vector.y / scalar);
		}
		public static double dotProduct(Vector2 left, Vector2 right)
		{
			return right.x * left.x + right.y * left.y;
		}

		// end of math methods
		public void set(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
		public void set(Vector2 vector)
		{
			this.x = vector.x;
			this.y = vector.y;
		}
		public void clear()
		{
			x = y = 0;
		}
		public void print()
		{
			System.Console.WriteLine("(" + x + ", " + y + ")");
		}

	}
}
