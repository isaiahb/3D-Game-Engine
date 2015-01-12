using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WicGames.WICLibrary
{
	class Vector3
	{
		public double x;
		public double y;
		public double z;

		//Constructors
		public Vector3()
		{
			this.x = 0;
			this.y = 0;
		}
        public static implicit operator Point(Vector3 v)
        {
            return new Point((int)v.x,(int)v.y);
        }
		public Vector3(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public double magnitude()
		{
			return Math.Sqrt((x * x) + (y * y) + (z * z));
		}
		public double magnitudeSquared()
		{
			return (x * x) + (y * y) + (z * z);
		}
		public void normalize()
		{
			double mag = magnitude();
			x /= mag;
			y /= mag;
			z /= mag;
		}
		public Vector3 normal()
		{
			double mag = magnitude();
			return new Vector3(x/mag, y/mag, z/mag);
		}
		//Math with operator overloading
		//add
		public static Vector3 operator +(Vector3 left, Vector3 right)
		{
			return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
		}
		//sub
		public static Vector3 operator -(Vector3 left, Vector3 right)
		{	
			return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
		}
		//mul
		public static Vector3 operator *(Vector3 vector, double scalar)
		{
			return new Vector3(vector.x * scalar, vector.y * scalar, vector.z * scalar);
		}
		public static Vector3 operator *(double scalar, Vector3 vector)
		{
			return new Vector3(vector.x * scalar, vector.y * scalar, vector.z * scalar);
		}

		//div
		public static Vector3 operator /(Vector3 vector, double scalar)
		{
			return new Vector3(vector.x / scalar, vector.y / scalar, vector.z /scalar);
		}
		public static Vector3 operator /(double scalar, Vector3 vector)
		{
			return new Vector3(vector.x / scalar, vector.y / scalar, vector.z /scalar);
		}
		public static double dotProduct(Vector3 left, Vector3 right)
		{
			return right.x * left.x + right.y * left.y + right.z * left.z;
		}

		// end of math methods
		public void set(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public void set(Vector3 vector)
		{
			this.x = vector.x;
			this.y = vector.y;
			this.z = vector.z;
		}
		public void clear()
		{
			x = y = z = 0;
		}
		public void print()
		{
			System.Console.WriteLine("(" + x + ", " + y + ", " + z + ")");
		}
	}
}
