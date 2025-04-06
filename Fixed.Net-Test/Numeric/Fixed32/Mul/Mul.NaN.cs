using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 乘法 - NaN
    /// </summary>
    public partial class TMul
    {
        [Fact]
        public void NaN()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue); // 正整数
                var n = Random.Shared.Next(int.MinValue, 0); // 负整数
                var k = Random.Shared.Next(int.MinValue, int.MaxValue); // 任意整数

                var u = new Fixed32(p * d); // 正
                var v = new Fixed32(n * d); // 负
                var w = new Fixed32(k * d); // 任意

                // NaN乘以任何书，等于NaN
                Assert.True(double.IsNaN(double.NaN * k));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN * k));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN * w));

                // 正无穷乘以零，等于NaN
                Assert.True(double.IsNaN(double.PositiveInfinity * 0));
                Assert.True(Fixed32.IsNaN(Fixed32.PositiveInfinity * 0));
                Assert.True(Fixed32.IsNaN(Fixed32.PositiveInfinity * Fixed32.Zero));

                // 负无穷乘以零，等于NaN
                Assert.True(double.IsNaN(double.NegativeInfinity * 0));
                Assert.True(Fixed32.IsNaN(Fixed32.NegativeInfinity * 0));
                Assert.True(Fixed32.IsNaN(Fixed32.NegativeInfinity * Fixed32.Zero));
            }
        }
    }
}
