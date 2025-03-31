using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 乘法 - 溢出
    /// </summary>
    public class TMul_Overflow
    {
        private const int LOOP_TIMES = 100;

        [Fact]
        public void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.Next(2, int.MaxValue) * Random.Shared.NextDouble();
                var f = new Fixed32(d);

                // 溢出
                Assert.True(double.IsPositiveInfinity(double.MaxValue * d));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.MaxValue * f));
                Assert.True(double.IsNegativeInfinity(double.MinValue * d));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.MinValue * f));
            }
        }
    }
}
