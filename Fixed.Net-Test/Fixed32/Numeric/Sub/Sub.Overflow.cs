using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 减法 - 溢出
    /// </summary>
    public class TSub_Overflow
    {
        private const int LOOP_TIMES = 100;

        [Fact]
        public void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue); // 正整数
                var n = Random.Shared.Next(int.MinValue, 0); // 负整数

                var u = new Fixed32(p * d); // 正
                var v = new Fixed32(n * d); // 负

                // 负数减去正数后溢出，得负无穷
                var a1 = Fixed32.MinValue / 2;
                var a2 = Fixed32.MaxValue / 2 + u;
                Assert.True(Fixed32.IsNegativeInfinity(a1 - a2));

                // 正数减去负数后溢出，得正无穷
                var a3 = Fixed32.MaxValue / 2;
                var a4 = Fixed32.MinValue / 2 + v;
                Assert.True(Fixed32.IsPositiveInfinity(a3 - a4));
            }
        }
    }
}
