using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TSqrt
    {
        private const int LOOP_TIMES = 100;
        private const int MAX_NUMBER = 1000000;
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(1, MAX_NUMBER);
                var n2 = Random.Shared.NextDouble() * n1;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);

                Assert.Equal(Math.Sqrt(n1), Fixed32.Sqrt(f1).ToDouble(), TOLERANCE);
                Assert.Equal(Math.Sqrt(n2), Fixed32.Sqrt(f2).ToDouble(), TOLERANCE);
            }
        }
    }
}
