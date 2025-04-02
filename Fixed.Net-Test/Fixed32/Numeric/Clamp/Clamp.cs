using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TClamp
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
                var t1 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var t2 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var t3 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var dd = Random.Shared.NextDouble();

                var n1 = t1;
                var n2 = Math.Min(t2, t3);
                var n3 = Math.Max(t2, t3);
                var n4 = dd * n1;
                var n5 = dd * n2;
                var n6 = dd * n3;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);
                var f5 = new Fixed32(n5);
                var f6 = new Fixed32(n6);

                Assert.Equal(Math.Clamp(n1, n2, n3), Fixed32.Clamp(f1, f2, f3).ToInt());
                Assert.Equal(Math.Clamp(n4, n5, n6), Fixed32.Clamp(f4, f5, f6).ToDouble(), TOLERANCE);

                Assert.Equal(Math.Clamp(n1, 0, 1), Fixed32.Clamp01(f1).ToInt());
                Assert.Equal(Math.Clamp(n4, 0, 1), Fixed32.Clamp01(f4).ToDouble(), TOLERANCE);
            }
        }
    }
}
