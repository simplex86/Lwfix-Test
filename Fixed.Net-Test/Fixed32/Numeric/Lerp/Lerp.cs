using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TLerp
    {
        private const int LOOP_TIMES = 10000;
        private const int MIN_NUMBER = -100000;
        private const int MAX_NUMBER =  100000;
        private const double TOLERANCE = 10e-5;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.NextDouble() * Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n2 = Random.Shared.NextDouble() * Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n3 = Random.Shared.NextDouble();

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);

                var p1 = double.Lerp(n1, n2, n3);
                var p2 = Fixed32.Lerp(f1, f2, f3);

                Assert.Equal(p1, p2.ToDouble(), TOLERANCE);
            }
        }
    }
}
