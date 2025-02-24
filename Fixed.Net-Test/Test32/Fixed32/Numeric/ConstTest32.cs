using Lwkit.Fixed;

namespace Test
{
    internal class ConstTest32 : BaseTest<Fixed32>
    {
        public override void Run()
        {
            Assert(Fixed32.Zero, 0);
            Assert(Fixed32.One, 1);
            Assert(Fixed32.NegativeOne, -1);
            Assert(Fixed32.Half, 0.5);
            Assert(Fixed32.MaxValue, int.MaxValue);
            Assert(Fixed32.MinValue, int.MinValue);
            Assert(Fixed32.PI, MathF.PI);
            Assert(Fixed32.E, MathF.E);
            Assert(Fixed32.LN2, MathF.Log(2));
            Assert(Fixed32.LN10, MathF.Log(10));
        }
    }
}
