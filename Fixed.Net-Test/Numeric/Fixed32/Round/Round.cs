using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    public partial class TRound
    {
        private const int LOOP_TIMES = 10000;
        private const int NEGATIVE_MIN_NUMBER = -1000000;
        private const int POSITIVE_MAX_NUMBER = 1000000;
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n = Random.Shared.NextDouble() * Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var f = new Fixed32(n);

                Assert.Equal(Math.Round(n), Fixed32.Round(f).ToDouble(), TOLERANCE);
            }
        }
    }
}
