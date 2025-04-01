using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TTan
    {
        private const int LOOP_TIMES = 1000;
        private const int MIN_NUMBER = -180;
        private const int MAX_NUMBER = 180;
        private const double TOLERANCE = 10e-2;
        private const double FAST_TOLERANCE = 10e-2;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.NextSingle() * Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var f1 = new Fixed32(n1);
                var r1 = (n1 / 180.0) * Math.PI;
                var r2 = Fixed32.DegreeToRadian(f1);

                var s1 = Math.Tan(r1);
                var s2 = Fixed32.Tan(r2);
                var s3 = Fixed32.FastTan(r2);

                Assert.Equal(s1, s2.ToDouble(), TOLERANCE);
                Assert.Equal(s1, s3.ToDouble(), FAST_TOLERANCE);
            }
        }
    }
}
