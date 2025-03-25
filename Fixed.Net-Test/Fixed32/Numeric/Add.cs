using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TAdd : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES = 100;
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

                Assert(f1 + f2, n1 + n2);
                Assert(f1 + f3, n1 + n3);
                Assert(f3 + f4, n3 + n4);
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

                // NaN加上任何数，都等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NaN + k), double.IsNaN(double.NaN + k));
                Assert(Fixed32.IsNaN(Fixed32.NaN + w), double.IsNaN(double.NaN + k));
                // 正无穷加上负无穷，等于NaN
                Assert(Fixed32.IsNaN(Fixed32.PositiveInfinity + Fixed32.NegativeInfinity), double.IsNaN(double.PositiveInfinity + double.NegativeInfinity));

                // 正无穷加上任何数，都等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity + k), double.IsPositiveInfinity(double.PositiveInfinity + k));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity + w), double.IsPositiveInfinity(double.PositiveInfinity + k));
                // 负无穷加上任何数，都等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity + k), double.IsNegativeInfinity(double.NegativeInfinity + k));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity + w), double.IsNegativeInfinity(double.NegativeInfinity + k));

                // 最大值加上任何正数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + p), true);
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + u), true);
                // 最大值加上任何负数，不等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + n), false);
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue + v), false);
                // 最小值加上任何正数，不等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue + p), false);
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue + u), false);
                // 最小值加上任何负数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue + n), true);
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue + v), true);

                // 负数相加后溢出
                var a1 = Fixed32.MinValue / 2;
                var a2 = Fixed32.MinValue / 2 + v;
                Assert(Fixed32.IsNegativeInfinity(a1 + a2), true);
                // 正数相加后溢出
                var a3 = Fixed32.MaxValue / 2;
                var a4 = Fixed32.MaxValue / 2 + u;
                Assert(Fixed32.IsPositiveInfinity(a3 + a4), true);
            }
        }
    }
}
