using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 加法 - 最值
    /// </summary>
    public partial class TAdd
    {
        [Fact]
        public void MinMax()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue);
                var n = Random.Shared.Next(int.MinValue, 0);
                var u = new Fixed32(p * d);
                var v = new Fixed32(n * d);

                // 最大值加上任何正数，等于正无穷
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + p));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + u));
                // 最大值加上任何负数，不等于正无穷
                Assert.False(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + n));
                Assert.False(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + v));
                // 最小值加上任何正数，不等于负无穷
                Assert.False(Fixed32.IsNegativeInfinity(Fixed32.MinValue + p));
                Assert.False(Fixed32.IsNegativeInfinity(Fixed32.MinValue + u));
                // 最小值加上任何负数，等于负无穷
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.MinValue + n));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.MinValue + v));
            }
        }
    }
}
