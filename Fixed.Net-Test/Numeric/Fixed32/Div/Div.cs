using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 除法 - 常规，检验准确性
    /// </summary>
    public partial class TDiv
    {
        private const int LOOP_TIMES = 10000;
        private const int MIN_NUMBER = int.MinValue;
        private const int MAX_NUMBER = int.MaxValue;
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n2 = Random.Shared.NextDouble() * n1;
                var n4 = Random.Shared.NextDouble() * n1;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n4);

                Assert.Equal(n1 / n2, (f1 / f2).ToDouble(), TOLERANCE);
                Assert.Equal(n2 / n1, (f2 / f1).ToDouble(), TOLERANCE);
                Assert.Equal(n2 / n4, (f2 / f3).ToDouble(), TOLERANCE);
            }
        }
    }
}
