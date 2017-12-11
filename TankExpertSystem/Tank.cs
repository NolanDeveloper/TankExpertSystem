using System;
using System.Drawing;
using TankExpertSystem.Properties;

namespace TankExpertSystem
{
    class Tank
    {
        private static readonly Pen PEN = new Pen(Color.DarkGreen, 2);
        private static readonly Bitmap TANK_IMAGE = Resources.tank;

        private double angle = 3 * Math.PI / 4; // Угол в радианах от OX по часовой
        private double speed = 0.05;

        private static double Clip(double x, double min, double max)
        {
            return Math.Max(min, Math.Min(max, x));
        }

        public Vector Position { get; set; }
        public double Angle { get { return angle; } set { angle = value; } } 
        public double Speed { get { return speed; } set { speed = Clip(value, 0, 0.05); } } 
        public double SensorDistance { get; set; } = 150;

        public Vector Forward {
            get {
                return new Vector(Math.Cos(Angle), Math.Sin(Angle));
            }
        }

        /*
         * Sensors' direction:
         * 0. Forward
         * 1. Forward right
         * 2. Right
         * 3. Backward right
         * 4. Backward
         * 5. Backward left
         * 6. Left
         * 7. Forward left
         */
        public Segment[] Sensors {
            get {
                var result = new Segment[8];
                for (int i = 0; i < 8; ++i)
                    result[i] = new Segment(
                        Position,
                        new Vector(
                            Position.X + SensorDistance * Math.Cos(Angle + i * Math.PI / 4),
                            Position.Y + SensorDistance * Math.Sin(Angle + i * Math.PI / 4)));
                return result;
            }
        }

        public Tank(Vector position)
        {
            Position = position;
        }

        public void TurnRight(double delta)
        {
            Angle = (Angle + delta) % (2 * Math.PI);
        }

        public void Move(double time)
        {
            var distance = time * Speed;
            Position.X += distance * Math.Cos(Angle);
            Position.Y += distance * Math.Sin(Angle);
        }

        public void Draw(Graphics g)
        {
            g.TranslateTransform((float)Position.X, (float)Position.Y);
            g.RotateTransform((float)(Angle * 180 / Math.PI));
            g.DrawImage(TANK_IMAGE, 
                -TANK_IMAGE.Width / 4, -TANK_IMAGE.Height / 4, 
                TANK_IMAGE.Width / 2, TANK_IMAGE.Height/ 2);
            g.ResetTransform();
        }
    }
}
