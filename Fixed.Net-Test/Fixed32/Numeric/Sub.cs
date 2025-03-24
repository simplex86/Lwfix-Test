using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TSub : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES =  100;
        private readonly static int MIN_NUMBER = Fixed32.MinValue.ToInt() / 2;
        private readonly static int MAX_NUMBER = Fixed32.MaxValue.ToInt() / 2;

        public override void Run()
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

                Assert(f1 - f2, n1 - n2);
                Assert(f1 - f3, n1 - n3);
                Assert(f3 - f4, n3 - n4);
            }

            // 边界检验 - NaN、最值、极值
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var p = Random.Shared.Next(1, int.MaxValue); // 正
                var n = Random.Shared.Next(int.MinValue, 0); // 负
                var k = Random.Shared.Next(int.MinValue, int.MaxValue); // 任意

                // NaN减去任何数，等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NaN - k), float.IsNaN(float.NaN - k));
                // 任何数减去NaN，等于NaN
                Assert(Fixed32.IsNaN(k - Fixed32.NaN), float.IsNaN(k - float.NaN));
                // 正无穷减去正无穷，等于NaN
                Assert(Fixed32.IsNaN(Fixed32.PositiveInfinity - Fixed32.PositiveInfinity), float.IsNaN(float.PositiveInfinity - float.PositiveInfinity));
                // 负无穷减去负无穷，等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NegativeInfinity - Fixed32.NegativeInfinity), float.IsNaN(float.NegativeInfinity - float.NegativeInfinity));

                // 负无穷减去任何数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity - k), float.IsNegativeInfinity(float.NegativeInfinity - k));
                // 任何数减去负无穷，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(k - Fixed32.NegativeInfinity), float.IsPositiveInfinity(k - float.NegativeInfinity));
                // 正无穷减去任何数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity - k), float.IsPositiveInfinity(float.PositiveInfinity - k));
                // 任何数减去正无穷，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(k - Fixed32.PositiveInfinity), float.IsNegativeInfinity(k - float.PositiveInfinity));

                // 最大值减去任何负数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue - n), true);
                // 最大值减去任何正数，不等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue - p), false);
                // 最小值减去任何正数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue - p), true);
                // 最小值减去任何负数，不等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue - n), false);

                // 负数减去正数后溢出，得负无穷
                var a1 = Fixed32.MinValue / 2;
                var a2 = Fixed32.MaxValue / 2 + p;
                Assert(Fixed32.IsNegativeInfinity(a1 - a2), true);

                // 正数减去负数后溢出，得正无穷
                var a3 = Fixed32.MaxValue / 2;
                var a4 = Fixed32.MinValue / 2 + n;
                Assert(Fixed32.IsPositiveInfinity(a3 - a4), true);
            }
        }
    }
}
