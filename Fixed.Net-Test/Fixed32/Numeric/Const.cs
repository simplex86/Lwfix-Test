using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TConst : BaseTest<Fixed32>
    {
        private static readonly int Zero = 0;
        private static readonly int One = 1;
        private static readonly int NegativeOne = -1;
        private static readonly double Half = 0.5;
        private static readonly int MaxValue = int.MaxValue;
        private static readonly int MinValue = int.MinValue;
        private static readonly double PI = MathF.PI;
        private static readonly double E = MathF.E;
        private static readonly double LN2 = MathF.Log(2);
        private static readonly double LN10 = MathF.Log(10);

        public override void Run()
        {
            Assert(Fixed32.Zero, Zero);
            Assert(Fixed32.One, One);
            Assert(Fixed32.NegativeOne, NegativeOne);
            Assert(Fixed32.Half, Half);
            Assert(Fixed32.MaxValue, MaxValue);
            Assert(Fixed32.MinValue, MinValue);
            Assert(Fixed32.PI, PI);
            Assert(Fixed32.Half_PI, PI / 2);
            Assert(Fixed32.Two_PI, PI * 2);
            Assert(Fixed32.E, E);
            Assert(Fixed32.LN2, LN2);
            Assert(Fixed32.LN10, LN10);
        }
    }
}
