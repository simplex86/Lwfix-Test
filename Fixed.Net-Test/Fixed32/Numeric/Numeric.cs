using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TNumeric : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES = 100;

        public override void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var a = Random.Shared.Next();
                var x = new Fixed32(a); // 整数
                var b = Random.Shared.NextSingle() * a;
                var y = new Fixed32(b); // 单精度
                var c = Random.Shared.NextDouble() * a;
                var z = new Fixed32(c); // 双精度

                Assert(x, a);
                Assert(y, b);
                Assert(z, c);
            }
        }
    }
}
