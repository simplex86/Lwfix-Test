using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 减法 - 最值
    /// </summary>
    public partial class TSub
    {
        [Fact]
        public void MinMax()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue); // 正整数
                var n = Random.Shared.Next(int.MinValue, 0); // 负整数

                var u = new Fixed32(p * d); // 正
                var v = new Fixed32(n * d); // 负
                
                // 最大值减去任何负数，等于正无穷
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.MaxValue - n));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.MaxValue - v));
                // 最大值减去任何正数，不等于正无穷
                Assert.False(Fixed32.IsPositiveInfinity(Fixed32.MaxValue - p));
                Assert.False(Fixed32.IsPositiveInfinity(Fixed32.MaxValue - u));
                // 最小值减去任何正数，等于负无穷
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.MinValue - p));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.MinValue - u));
                // 最小值减去任何负数，不等于负无穷
                Assert.False(Fixed32.IsNegativeInfinity(Fixed32.MinValue - n));
                Assert.False(Fixed32.IsNegativeInfinity(Fixed32.MinValue - v));
            }
        }
    }
}
