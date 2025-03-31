using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 除法 - 常规，检验准确性
    /// </summary>
    public class TDiv
    {
        private const int LOOP_TIMES = 100;
        private const int MIN_NUMBER = int.MinValue;
        private const int MAX_NUMBER = int.MaxValue;
        private const int PRECISION = 5;

        [Fact]
        public void Run()
        {
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

                Assert.Equal(n1 / n3, (f1 / f3).ToDouble(), PRECISION);
                Assert.Equal(n3 / n1, (f3 / f1).ToDouble(), PRECISION);
                Assert.Equal(n3 / n4, (f3 / f4).ToDouble(), PRECISION);
            }
        }
    }
}
