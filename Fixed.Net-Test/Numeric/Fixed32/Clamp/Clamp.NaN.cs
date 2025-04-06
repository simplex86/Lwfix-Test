using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    public partial class TClamp
    {
        [Fact]
        public void NaN()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n = Random.Shared.NextDouble() * Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var f = new Fixed32(n);

                Assert.True(double.IsNaN(Math.Clamp(double.NaN, double.MinValue, double.MaxValue)));
                Assert.True(Fixed32.IsNaN(Fixed32.Clamp(Fixed32.NaN, Fixed32.MinValue, Fixed32.MaxValue)));

                Assert.Equal(Math.Clamp(n, double.NaN, double.MaxValue), Fixed32.Clamp(f, Fixed32.NaN, Fixed32.MaxValue).ToDouble(), TOLERANCE);
                Assert.Equal(Math.Clamp(n, double.MinValue, double.NaN), Fixed32.Clamp(f, Fixed32.MinValue, Fixed32.NaN).ToDouble(), TOLERANCE);
            }
        }
    }
}
