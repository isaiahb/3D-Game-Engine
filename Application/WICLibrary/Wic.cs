using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace WicGames.WICLibrary
{
	class Wic
	{
		public static int combineIntegers(int byteLength, params int[] n)
		{
			if (n.Length > 32 / byteLength)
			{
				throw new ArgumentOutOfRangeException("Too many nibbles max " + 32 / byteLength);
			}
			int res = 0;
			for (int i = 0; i < n.Length; i++)
			{
				res = (res << byteLength) | (n[i]);
			}
			return res;
		}
		public static long combineIntegersL(int byteLength, params int[] n)
		{
			if (n.Length > 64 / byteLength)
			{
				throw new ArgumentOutOfRangeException("Too many nibbles max " + 64 / byteLength);
			}
			long res = 0;
			for (int i = 0; i < n.Length; i++)
			{
				res = (res << byteLength) | ((byte)n[i]);
			}
			return res;
		}
		public static int combineNibbles(params int[] n)
		{
			if (n.Length > 8)
			{
				throw new ArgumentOutOfRangeException("Too many nibbles max 8");
			}
			int res = 0;
			for (int i = 0; i < n.Length; i++)
			{
				res = (res << 4) | (n[i]);
			}
			return res;
		}
		public static long combineNibblesL(params int[] n)
		{
			if (n.Length > 16)
			{
				throw new ArgumentOutOfRangeException("Too many nibbles max 16");
			}
			long res = 0;
			for (int i = 0; i < n.Length; i++)
			{
				res = (res << 4) | ((byte)n[i]);
			}
			return res;
		}
		public static int combineBytes(params int[] b)
		{
			if (b.Length > 4)
			{
				throw new ArgumentOutOfRangeException("Too many bytes max 4");
			}
			int res = 0;
			for (int i = 0; i < b.Length; i++)
			{
				res = (res << 8) | (b[i]);
			}
			return res;
		}
		public static long combineBytesL(params int[] b)
		{
			if (b.Length > 8)
			{
				throw new ArgumentOutOfRangeException("Too many bytes max 8");
			}
			long res = 0;
			for (int i = 0; i < b.Length; i++)
			{
				res = (res << 8) | ((byte)b[i]);
			}
			return res;
		}
		public static int getColor(int r, int g, int b, int a)
		{
			return (combineBytes(r, g, b, a));
		}
		public static int getColor(int r, int g, int b, double a)
		{
			return (combineBytes(r, g, b, (int)(255*a) ));
		}
		public static int getColor(params int[] values)
		{
			int r, g, b, a;
			int length = values.Length;
			r = length >= 1 ? values[0] : 0;
			g = length >= 2 ? values[1] : 0;
			b = length >= 3 ? values[2] : 0;
			a = length >= 4 ? values[3] : 255;

			return (combineBytes(r, g, b, a));
		}

		public static Vector2 getUnitVector(int direction)
		{
			return new Vector2(Math.Sin(toRadians(direction)), Math.Cos(toRadians(direction)));
		}
		public static double toRadians(double degrees)
		{
			return degrees * (Math.PI / 180);
		}
		public static int getBinVal(String binS)
		{
			char[] binChars = binS.ToCharArray();
			int res = 0;
			for (int i = 0; i < binS.Length; i++)
			{
				res = (res << 1) | ((int)char.GetNumericValue(binChars[i]));
			}
			return res;
		}
		public static String getBinString(int n){
			bool leadingZeros = false;
			String res = "";
			for (int i = 31; i >= 0; i--)
			{
				int bit = n >> i;
				if (!leadingZeros && bit == 0)
				{
					continue;
				}
				res += Convert.ToString(bit);
				leadingZeros = true;
			}
			return res;
		}
		public static String getBinString(int n, bool leadingZeros)
		{
			String res = "";
			for (int i = 31; i >= 0; i--)
			{
				int bit = n >> i;
				if (!leadingZeros && bit == 0)
				{
					continue;
				}
				res += Convert.ToString(bit);
				leadingZeros = true;
			}
			return res;
		}
		public static String getBinString(long n)
		{
			bool leadingZeros = false;
			String res = "";
			for (int i = 63; i >= 0; i--)
			{
				long bit = n >> i;
				if (!leadingZeros && bit == 0)
				{
					continue;
				}
				res += Convert.ToString(bit);
				leadingZeros = true;
			}
			return res;
		}
		public static String getBinString(long n, bool leadingZeros)
		{
			String res = "";
			for (int i = 31; i >= 0; i--)
			{
				long bit = n >> i;
				if (!leadingZeros && bit == 0)
				{
					continue;
				}
				res += Convert.ToString(bit);
				leadingZeros = true;
			}
			return res;
		}
		public static String getBinString(byte n)
		{
			bool leadingZeros = false;
			String res = "";
			for (byte i = 7; i >= 0; i--)
			{
				byte bit = (byte)(n >> i);
				if (!leadingZeros && bit == 0)
				{
					continue;
				}
				res += Convert.ToString(bit);
				leadingZeros = true;
			}
			return res;
		}
		public static String getBinString(byte n, bool leadingZeros)
		{
			String res = "";
			for (byte i = 7; i >= 0; i--)
			{
				byte bit = (byte)(n >> i);
				if (!leadingZeros && bit == 0)
				{
					continue;
				}
				res += Convert.ToString(bit);
				leadingZeros = true;
			}
			return res;
		}
		public static bool wait(double timeout)
		{
			Thread.Sleep((int)(timeout * 1000));
			return true;
		}
        public static Vector2 toVector(Point p)
        {
            return new Vector2(p.X, p.Y);
        }
        public static Point toPoint(Vector2 v)
        {
            return new Point((int)v.x,(int)v.y);
        }
		public static Point[] toPointArray(int[] xPoints, int[] yPoints) 
		{
			int length = xPoints.Length;
			Point[] points = new Point[length];
			for (int i = 0; i < length; i++)
			{
				points[i] = new Point(xPoints[i], yPoints[i]);
			}
			return points;
		}
		public static Point[] toPointArray(Vector2[] vectors)
		{
			int length = vectors.Length;
			Point[] points = new Point[length];
			for (int i = 0; i < length; i++)
			{
				points[i] = new Point((int)vectors[i].x, (int)vectors[i].y);
			}
			return points;
		}
        public static long getEpochTime()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (int)t.TotalMilliseconds;
        }
	}
}
