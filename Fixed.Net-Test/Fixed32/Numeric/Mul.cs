using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TMul : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES =  100;
        private const int MIN_NUMBER = -10000;
        private const int MAX_NUMBER =  10000;

        public override void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n2 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n3 = Random.Shared.NextSingle() * n1;
                var n4 = Random.Shared.NextSingle() * n2;
                var n5 = Random.Shared.NextDouble() * n1;
                var n6 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);
                var f5 = new Fixed32(n5);
                var f6 = new Fixed32(n6);

                Assert(f1 * f2, n1 * n2);
                Assert(f3 * f4, n3 * n4);
                Assert(f5 * f6, n5 * n6);
            }
        }
    }
}
