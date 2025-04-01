using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TFloor
    {
        private const int LOOP_TIMES = 100;
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

                Assert.Equal(Math.Floor(n), Fixed32.Floor(f).ToDouble(), TOLERANCE);
            }
        }
    }
}
