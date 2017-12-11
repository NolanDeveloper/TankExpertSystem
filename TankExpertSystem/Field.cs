using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static TankExpertSystem.Logic;

namespace TankExpertSystem
{
    public partial class Field : UserControl
    {
        private const double POINT_SIZE = 4;

        private Tank tank = new Tank(new Vector(100, 100));
        private List<Segment> obstacles = new List<Segment>();
        private Vector target = new Vector(400, 400);

        public enum ActiveObject
        {
            TANK, TARGET, OBSTACLE
        }

        public ActiveObject Moveable { get; set; } = ActiveObject.TANK;

        public delegate void StopEventHandler();

        public event StopEventHandler StopEvent;

        public Field()
        {
            InitializeComponent();
            var flags = ControlStyles.AllPaintingInWmPaint
                      | ControlStyles.DoubleBuffer
                      | ControlStyles.UserPaint;
            SetStyle(flags, true);
            ResizeRedraw = true;
        }

        public void Start()
        {
            var timer = new Timer();
            timer.Tick += (s, e) =>
            {
                var distanceToTarget = (target - tank.Position).Length;
                if (distanceToTarget < 30)
                {
                    timer.Stop();
                    StopEvent();
                }

                var toTarget = (target - tank.Position).Normalized;
                var toForward = tank.Forward;
                var angle = Math.Atan2(Vector.Cross(toTarget, toForward), toTarget * toForward);

                // Логические переменные. Значения от 0 до 1.
                var targetIsBehind = Math.Abs(angle) / Math.PI;
                var targetIsFront = Not(targetIsBehind);
                targetIsFront *= targetIsFront;
                var targetIsRight = Math.Abs((angle + Math.PI + 3 * Math.PI / 2) % (2 * Math.PI) - Math.PI) / Math.PI;
                var targetIsLeft = Not(targetIsRight);
                var sensorData = tank
                    .Sensors
                    .Select(sensor =>
                        1 - obstacles
                            .SelectMany(obstacle => {
                                double t = 0, u = 0;
                                if (!Segment.Intersect(sensor, obstacle, ref t, ref u))
                                    return new double[0];
                                return new double[1] { t };
                            }).DefaultIfEmpty(1).Min()
                        ).ToArray();
                var leftObstacle = Or(Or(sensorData[5], sensorData[6]), sensorData[7]);
                var rightObstacle = Or(Or(sensorData[1], sensorData[2]), sensorData[3]);
                var frontObstacle = Or(Or(sensorData[7], sensorData[0]), sensorData[1]);
                var needToSpeedUp = And(Not(targetIsBehind), Not(sensorData[0]));
                var needToTurnLeft = And(targetIsLeft, Not(leftObstacle));
                var needToTurnRight = And(targetIsRight, Not(rightObstacle));
                var needToMoveForward = And(targetIsFront, Not(frontObstacle));
                if (needToTurnLeft < needToMoveForward && needToTurnRight < needToMoveForward)
                    tank.Angle += 0;
                else if (needToTurnLeft < needToTurnRight && needToMoveForward < needToTurnRight)
                    tank.Angle += 0.01;
                else
                    tank.Angle -= 0.01;
                tank.Speed = needToSpeedUp * 0.05;
                tank.Move(20);
                Refresh();
            };
            timer.Interval = 20;
            timer.Start();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            var mouseArguments = (MouseEventArgs)e;
            switch (Moveable)
            {
                case ActiveObject.TANK:
                    tank.Position = new Vector(mouseArguments.X, mouseArguments.Y);
                    break;
                case ActiveObject.TARGET:
                    target = new Vector(mouseArguments.X, mouseArguments.Y);
                    break;
                case ActiveObject.OBSTACLE:
                    NewObstacle(new Vector(mouseArguments.X, mouseArguments.Y));
                    break;
            }
            Refresh();
        }

        public void NewObstacle(Vector center)
        {
            var r = new Random();
            var n = 3 + r.Next(10);
            var points = new List<Vector>(n);
            for (int i = 0; i < n; ++i)
            {
                var d = r.NextDouble() * 50 + 25;
                var angle = i * 2 * Math.PI / n;
                points.Add(center + d * new Vector(Math.Cos(angle), Math.Sin(angle)));
            }
            for (int i = 0; i < n - 1; ++i)
                obstacles.Add(new Segment(points[i], points[i + 1]));
            obstacles.Add(new Segment(points[0], points[n - 1]));
            Refresh();
        }

        private static void DrawPoint(Graphics g, Vector point)
        {
            DrawPoint(g, point, Color.Black);
        }

        private static void DrawPoint(Graphics g, Vector point, Color color)
        {
            g.FillRectangle(new SolidBrush(color),
                (float)(point.X - POINT_SIZE / 2),
                (float)(point.Y - POINT_SIZE / 2),
                (float)POINT_SIZE, (float)POINT_SIZE);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clear(Color.White);
            tank.Draw(g);
            foreach (var s in tank.Sensors)
            {
                s.Draw(g);
                var f = obstacles
                    .SelectMany(obstacle =>
                    {
                        double t = 0, u = 0;
                        if (!Segment.Intersect(s, obstacle, ref t, ref u))
                            return new double[0];
                        return new double[1] { t };
                    }).DefaultIfEmpty(1).Min();
                DrawPoint(g, s.At(f), Color.Blue);
            }
            foreach (var o in obstacles)
                o.Draw(g);
            DrawPoint(g, target, Color.Red);
        }
    }
}
