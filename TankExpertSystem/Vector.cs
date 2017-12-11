using System;

namespace TankExpertSystem
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public static Vector operator *(double a, Vector b)
        {
            return b * a;
        }

        public static Vector operator /(Vector a, double b)
        {
            return a * (1 / b);
        }

        public static Vector operator /(double a, Vector b)
        {
            return new Vector(a / b.X, a / b.Y);
        }

        public static Vector operator -(Vector a)
        {
            return new Vector(-a.X, -a.Y);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return a + (-b);
        }

        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public static double Cross(Vector a, Vector b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public double Length {
            get {
                return Math.Sqrt(this * this);
            }
        }

        public Vector Normalized {
            get {
                return this / Length;
            }
        }
    }
}
