namespace RPBUtilities.calc
{
    public static class Calc
    {
        public static bool InRange(int x, int a, int b)
        {
            return x >= a && x <= b;
        }

        public static bool OutOfRange(int x, int a, int b)
        {
            return x < a && x > b;
        }
    }
}