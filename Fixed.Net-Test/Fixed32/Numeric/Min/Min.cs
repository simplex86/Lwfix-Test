using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TMin
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
                var n1 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var n2 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var n3 = Random.Shared.NextDouble() * n1;
                var n4 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);

                Assert.Equal(Math.Min(n1, n2), Fixed32.Min(f1, f2).ToInt());
                Assert.Equal(Math.Min(n3, n4), Fixed32.Min(f3, f4).ToDouble(), TOLERANCE);
            }
        }
    }
}
