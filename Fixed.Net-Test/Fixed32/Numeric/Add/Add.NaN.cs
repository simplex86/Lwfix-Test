using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 加法 - NaN
    /// </summary>
    public class TAdd_NaN
    {
        private const int LOOP_TIMES = 100;

        [Fact]
        public void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var k = Random.Shared.Next(int.MinValue, int.MaxValue);
                var w = new Fixed32(k * d);

                // NaN加上任何数，都等于NaN
                Assert.True(Fixed32.IsNaN(Fixed32.NaN + k));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN + w));

                // 正无穷加上负无穷，等于NaN
                Assert.True(double.IsNaN(double.PositiveInfinity + double.NegativeInfinity));
                Assert.True(Fixed32.IsNaN(Fixed32.PositiveInfinity + Fixed32.NegativeInfinity));
            }
        }
    }
}
