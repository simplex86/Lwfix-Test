using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 加法 - 常规，检验准确性
    /// </summary>
    public partial class TAdd
    {
        private const int LOOP_TIMES = 10000;
        private readonly static int MIN_NUMBER = Fixed32.MinValue.ToInt() / 2;
        private readonly static int MAX_NUMBER = Fixed32.MaxValue.ToInt() / 2;
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            // 常规计算（不会溢出），检验准确性
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n2 = Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var n3 = Random.Shared.NextDouble() * n1;
                var n4 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);

                Assert.Equal(n1 + n2, (f1 + f2).ToInt());
                Assert.Equal(n1 + n3, (f1 + f3).ToDouble(), TOLERANCE);
                Assert.Equal(n3 + n4, (f3 + f4).ToDouble(), TOLERANCE);
            }
        }
    }
}
