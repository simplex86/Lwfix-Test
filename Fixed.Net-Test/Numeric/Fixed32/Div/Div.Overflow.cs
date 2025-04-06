using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 除法 - 溢出
    /// </summary>
    public partial class TDiv
    {
        [Fact]
        public void Overflow()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var f = new Fixed32(d);

                // 溢出
                Assert.True(double.IsPositiveInfinity(double.MaxValue / d));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.MaxValue / f));
                Assert.True(double.IsNegativeInfinity(double.MinValue / d));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.MinValue / f));
            }
        }
    }
}
