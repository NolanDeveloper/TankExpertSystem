using System.Drawing;

namespace TankExpertSystem
{
    class Segment
    {
        private Vector a;
        private Vector b;

        public Segment(Vector a, Vector b)
        {
            this.a = a;
            this.b = b;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(Pens.DarkGreen, (float)a.X, (float)a.Y, (float)b.X, (float)b.Y);
        }

        /* https://stackoverflow.com/a/565282/4626533 
         * Collinear segments are not considered intersecting.
         */
        public static bool Intersect(Segment v, Segment w, ref double t, ref double u)
        {
            var p = v.a;
            var r = v.b - v.a;
            var q = w.a;
            var s = w.b - w.a;
            var d = Vector.Cross(r, s);
            if (0 == d) return false;
            t = Vector.Cross(q - p, s) / d;
            u = Vector.Cross(q - p, r) / d;
            return 0 <= t && t <= 1 && 0 <= u && u <= 1;
        }

        public Vector At(double t)
        {
            return a + t * (b - a);
        }
    }
}
