namespace TankExpertSystem
{
    public static class Logic
    {
        public static double And(double a, double b)
        {
            return a * b;
        }

        public static double Or(double a, double b)
        {
            return a + b - a * b;
        }

        public static double Not(double a)
        {
            return 1 - a;
        }
    }
}
