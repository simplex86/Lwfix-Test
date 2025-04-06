using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 对数 - 常规，检验计算精度
    /// </summary>
    public partial class TLog
    {
        private const int LOOP_TIMES = 10000;
        private const int MIN_NUMBER = 0;
        private const int MAX_NUMBER = int.MaxValue;
        private const double TOLERANCE = 10e-5;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var b1 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var b2 = Random.Shared.NextDouble() * b1;

                var f1 = new Fixed32(b1);
                var f2 = new Fixed32(b2);

                Assert.Equal(Math.Log(b1),   Fixed32.Log(f1).ToDouble(),   TOLERANCE);
                Assert.Equal(Math.Log(b2),   Fixed32.Log(f2).ToDouble(),   TOLERANCE);
                Assert.Equal(Math.Log2(b1),  Fixed32.Log2(f1).ToDouble(),  TOLERANCE);
                Assert.Equal(Math.Log2(b2),  Fixed32.Log2(f2).ToDouble(),  TOLERANCE);
                Assert.Equal(Math.Log10(b1), Fixed32.Log10(f1).ToDouble(), TOLERANCE);
                Assert.Equal(Math.Log10(b2), Fixed32.Log10(f2).ToDouble(), TOLERANCE);
            }
        }
    }
}
