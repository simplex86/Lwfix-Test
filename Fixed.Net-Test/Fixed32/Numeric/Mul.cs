using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TMul : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES = 100;
        private readonly static int NUMBER_A = 10000;
        private readonly static int NUMBER_B = Fixed32.MaxValue.ToInt() / NUMBER_A;

        public override void Run()
        {
            // 常规计算（不会溢出），检验准确性
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(1, NUMBER_A);
                var n2 = Random.Shared.Next(-NUMBER_B, NUMBER_B);
                var n3 = Random.Shared.NextDouble() * n1;
                var n4 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);

                Assert(f1 * f2, n1 * n2);
                Assert(f1 * f3, n1 * n3);
                Assert(f3 * f4, n3 * n4);
            }

            // 边界检验 - NaN、最值、极值
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue); // 正整数
                var n = Random.Shared.Next(int.MinValue, 0); // 负整数
                var k = Random.Shared.Next(int.MinValue, int.MaxValue); // 任意整数

                var u = new Fixed32(p * d); // 正
                var v = new Fixed32(n * d); // 负
                var w = new Fixed32(k * d); // 任意

                // NaN乘以任何书，等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NaN * k), float.IsNaN(float.NaN * k));
                Assert(Fixed32.IsNaN(Fixed32.NaN * w), float.IsNaN(float.NaN * k));

                // 正无穷乘以任何正数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * p), float.IsPositiveInfinity(float.PositiveInfinity * p));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * u), float.IsPositiveInfinity(float.PositiveInfinity * p));
                // 正无穷乘以零，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * 0), float.IsPositiveInfinity(float.PositiveInfinity * 0));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * Fixed32.Zero), float.IsPositiveInfinity(float.PositiveInfinity * 0));
                // 正无穷乘以任何负数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity * n), float.IsNegativeInfinity(float.PositiveInfinity * n));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity * v), float.IsNegativeInfinity(float.PositiveInfinity * n));
                // 负无穷乘以任何正数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * p), float.IsNegativeInfinity(float.NegativeInfinity * p));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * u), float.IsNegativeInfinity(float.NegativeInfinity * p));
                // 负无穷乘以零，等于正无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * 0), float.IsNegativeInfinity(float.NegativeInfinity * 0));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * Fixed32.Zero), float.IsNegativeInfinity(float.NegativeInfinity * 0));
                // 负无穷乘以任何正数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity * n), float.IsPositiveInfinity(float.NegativeInfinity * n));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity * v), float.IsPositiveInfinity(float.NegativeInfinity * n));

                // 最大值乘以任何正整数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue * p), float.IsPositiveInfinity(float.MaxValue * p));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue * u), float.IsPositiveInfinity(float.MaxValue * p));
                // 最大值乘以零，等于零
                Assert(Fixed32.IsZero(Fixed32.MaxValue * 0), float.MaxValue * 0 == 0);
                Assert(Fixed32.IsZero(Fixed32.MaxValue * Fixed32.Zero), float.MaxValue * 0 == 0);
                // 最大值乘以任何负整数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MaxValue * n), float.IsNegativeInfinity(float.MaxValue * n));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MaxValue * v), float.IsNegativeInfinity(float.MaxValue * n));
                // 最小值乘以任何正整数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue * p), float.IsNegativeInfinity(float.MinValue * p));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue * u), float.IsNegativeInfinity(float.MinValue * p));
                // 最小值乘以零，等于零
                Assert(Fixed32.IsZero(Fixed32.MinValue * 0), float.MinValue * 0 == 0);
                Assert(Fixed32.IsZero(Fixed32.MinValue * Fixed32.Zero), float.MinValue * 0 == 0);
                // 最小值乘以任何负整数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MinValue * n), float.IsPositiveInfinity(float.MinValue * n));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MinValue * v), float.IsPositiveInfinity(float.MinValue * n));
            }
        }
    }
}
