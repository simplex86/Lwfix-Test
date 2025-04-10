using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 乘法 - 常规
    /// </summary>
    public partial class TMul
    {
        private readonly static List<double[]> normal_numbers =
        [
            [0.506, 0.13],
            [-16.3083, -28.2577],
            [15.5667775, -11.09],
            [44.92, -98.7889],
            [-63129.896, 9095.5],
            [-66073.7668, -7882.62],
            [9526.552, 61031.5062],
            [2306.374, -84020.24]
        ];
        private const double TOLERANCE = 10e-5;

        [Fact]
        public void Normal()
        {
            foreach (var n in normal_numbers)
            {
                var u = n[0];
                var v = n[1];

                var t = new Fixed32(u);
                var w = new Fixed32(v);

                Assert.Equal(u * v, (t * w).ToDouble(), TOLERANCE);
            }
        }
    }
}
