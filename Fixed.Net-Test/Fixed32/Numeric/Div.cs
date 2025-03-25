using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TDiv : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES = 100;
        private const int MIN_NUMBER = int.MinValue;
        private const int MAX_NUMBER = int.MaxValue;

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

                Assert(f1 / f2, n1 / (double)n2);
                Assert(f1 / f3, n1 / n3);
                Assert(f3 / f1, n3 / n1);
                Assert(f3 / f4, n3 / n4);
            }

            // 边界检验 - NaN、最值、极值
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue); // 正整数
                var n = Random.Shared.Next(int.MinValue, 0); // 负整数
                var k = Random.Shared.Next(int.MinValue, int.MaxValue); // 任意整数

                var f = new Fixed32(d);
                var u = new Fixed32(p * d); // 正
                var v = new Fixed32(n * d); // 负
                var w = new Fixed32(k * d); // 任意

                // NaN除以NaN，等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NaN / Fixed32.NaN), double.IsNaN(double.NaN / double.NaN));
                // NaN除以任何数，都等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NaN / 0), double.IsNaN(double.NaN / 0));
                Assert(Fixed32.IsNaN(Fixed32.NaN / k), double.IsNaN(double.NaN / k));
                Assert(Fixed32.IsNaN(Fixed32.NaN / w), double.IsNaN(double.NaN / k));
                // 任何数除以NaN，都等于NaN
                Assert(Fixed32.IsNaN(0 / Fixed32.NaN), double.IsNaN(0 / double.NaN));
                Assert(Fixed32.IsNaN(k / Fixed32.NaN), double.IsNaN(k / double.NaN));
                Assert(Fixed32.IsNaN(w / Fixed32.NaN), double.IsNaN(k / double.NaN));
                // 任意极值相除，都等于NaN
                Assert(Fixed32.IsNaN(Fixed32.PositiveInfinity / Fixed32.PositiveInfinity), double.IsNaN(double.PositiveInfinity / double.PositiveInfinity));
                Assert(Fixed32.IsNaN(Fixed32.PositiveInfinity / Fixed32.NegativeInfinity), double.IsNaN(double.PositiveInfinity / double.NegativeInfinity));
                Assert(Fixed32.IsNaN(Fixed32.NegativeInfinity / Fixed32.PositiveInfinity), double.IsNaN(double.NegativeInfinity / double.PositiveInfinity));
                Assert(Fixed32.IsNaN(Fixed32.NegativeInfinity / Fixed32.NegativeInfinity), double.IsNaN(double.NegativeInfinity / double.NegativeInfinity));

                // 正无穷除以零，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / 0), double.IsPositiveInfinity(double.PositiveInfinity / 0));
                // 正无穷除以正数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / p), double.IsPositiveInfinity(double.PositiveInfinity / p));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / u), double.IsPositiveInfinity(double.PositiveInfinity / p));
                // 正无穷除以负数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity / n), double.IsNegativeInfinity(double.PositiveInfinity / n));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity / v), double.IsNegativeInfinity(double.PositiveInfinity / n));
                // 负无穷除以零，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity / 0), double.IsNegativeInfinity(double.NegativeInfinity / 0));
                // 负无穷除以正数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity / p), double.IsNegativeInfinity(double.NegativeInfinity / p));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity / u), double.IsNegativeInfinity(double.NegativeInfinity / p));
                // 负无穷除以负数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity / n), double.IsPositiveInfinity(double.NegativeInfinity / n));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity / v), double.IsPositiveInfinity(double.NegativeInfinity / n));

                // 溢出
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue / f), double.IsPositiveInfinity(double.MaxValue / (double)d));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue / f), double.IsNegativeInfinity(double.MinValue / (double)d));
            }
        }
    }
}
