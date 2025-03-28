using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TExp : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES = 100;
        private const int MIN_NUMBER = 1;
        private const int MAX_NUMBER = 10;

        public override void Run()
        {
            // 
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var b1 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var b2 = Random.Shared.NextDouble() * b1;

                var f1 = new Fixed32(b1);
                var f2 = new Fixed32(b2);

                Assert(Fixed32.Exp(f1), Math.Exp(b1));
                Assert(Fixed32.Exp(f2), Math.Exp(b2));
            }
        }
    }
}
