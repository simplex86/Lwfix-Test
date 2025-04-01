using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TExp
    {
        private const int LOOP_TIMES = 100;

        private const int SMALL_MIN_NUMBER = 1;
        private const int SMALL_MAX_NUMBER = 10;
        private const double SMALL_TOLERANCE = 10e-4;

        [Fact]
        public void NormalSmall()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var b1 = Random.Shared.Next(SMALL_MIN_NUMBER, SMALL_MAX_NUMBER);
                var b2 = Random.Shared.NextDouble() * b1;

                var f1 = new Fixed32(b1);
                var f2 = new Fixed32(b2);

                Assert.Equal(Math.Exp(b1), Fixed32.Exp(f1).ToDouble(), SMALL_TOLERANCE);
                Assert.Equal(Math.Exp(b2), Fixed32.Exp(f2).ToDouble(), SMALL_TOLERANCE);
            }
        }
    }
}
