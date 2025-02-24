using Lwkit.Fixed;

namespace Test
{
    internal class ConstTest32 : BaseTest<Fixed32>
    {
        private static int Zero = 0;
        private static int One = 1;
        private static int NegativeOne = -1;
        private static double Half = 0.5;
        private static int MaxValue = int.MaxValue;
        private static int MinValue = int.MinValue;
        private static double PI = MathF.PI;
        private static double E = MathF.E;
        private static double LN2 = MathF.Log(2);
        private static double LN10 = MathF.Log(10);

        public override void Run()
        {
            Assert(Fixed32.Zero, Zero);
            Assert(Fixed32.One, One);
            Assert(Fixed32.NegativeOne, NegativeOne);
            Assert(Fixed32.Half, Half);
            Assert(Fixed32.MaxValue, MaxValue);
            Assert(Fixed32.MinValue, MinValue);
            Assert(Fixed32.PI, PI);
            Assert(Fixed32.E, E);
            Assert(Fixed32.LN2, LN2);
            Assert(Fixed32.LN10, LN10);
        }
    }
}
