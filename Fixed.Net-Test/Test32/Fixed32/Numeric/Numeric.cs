using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class Numeric : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES = 100;

        public override void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var a = Random.Shared.Next();
                var x = new Fixed32(a);
                var b = Random.Shared.NextSingle() * a;
                var y = new Fixed32(b);
                var c = Random.Shared.NextDouble() * a;
                var z = new Fixed32(c);

                Assert(x, a);
                Assert(y, b);
                Assert(z, c);
            }
        }
    }
}
