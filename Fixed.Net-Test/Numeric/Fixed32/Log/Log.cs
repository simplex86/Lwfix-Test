using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 对数 - 常规，检验计算精度
    /// </summary>
    public partial class TLog
    {
        private readonly static List<double> normal_numbers =
        [
            31.23479409344165,
            86.05775761556997,
            906813.7862607994,
            979026.3581211731,
            100909.43195481248,
        ];
        private const double TOLERANCE = 10e-5;

        [Fact]
        public void Normal()
        {
            foreach (var n in normal_numbers)
            {
                var f = new Fixed32(n);

                Assert.Equal(Math.Log(n),   Fixed32.Log(f).ToDouble(),   TOLERANCE);
                Assert.Equal(Math.Log2(n),  Fixed32.Log2(f).ToDouble(),  TOLERANCE);
                Assert.Equal(Math.Log10(n), Fixed32.Log10(f).ToDouble(), TOLERANCE);
            }
        }
    }
}
