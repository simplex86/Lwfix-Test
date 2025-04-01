using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 加法 - 溢出
    /// </summary>
    public partial class TAdd
    {
        [Fact]
        public void Overflow()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue);
                var n = Random.Shared.Next(int.MinValue, 0);
                var u = new Fixed32(p * d);
                var v = new Fixed32(n * d);

                // 负数相加后溢出
                var a1 = Fixed32.MinValue / 2;
                var a2 = Fixed32.MinValue / 2 + v;
                Assert.True(Fixed32.IsNegativeInfinity(a1 + a2));
                // 正数相加后溢出
                var a3 = Fixed32.MaxValue / 2;
                var a4 = Fixed32.MaxValue / 2 + u;
                Assert.True(Fixed32.IsPositiveInfinity(a3 + a4));
            }
        }
    }
}
