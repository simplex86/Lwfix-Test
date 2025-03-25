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

                Assert(f1 / f2, n1 / (float)n2);
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
                Assert(Fixed32.IsNaN(Fixed32.NaN / Fixed32.NaN), float.IsNaN(float.NaN / float.NaN));
                // NaN除以任何数，都等于NaN
                Assert(Fixed32.IsNaN(Fixed32.NaN / 0), float.IsNaN(float.NaN / 0));
                Assert(Fixed32.IsNaN(Fixed32.NaN / k), float.IsNaN(float.NaN / k));
                Assert(Fixed32.IsNaN(Fixed32.NaN / w), float.IsNaN(float.NaN / k));
                // 任何数除以NaN，都等于NaN
                Assert(Fixed32.IsNaN(0 / Fixed32.NaN), float.IsNaN(0 / float.NaN));
                Assert(Fixed32.IsNaN(k / Fixed32.NaN), float.IsNaN(k / float.NaN));
                Assert(Fixed32.IsNaN(w / Fixed32.NaN), float.IsNaN(k / float.NaN));
                // 任意极值相除，都等于NaN
                Assert(Fixed32.IsNaN(Fixed32.PositiveInfinity / Fixed32.PositiveInfinity), float.IsNaN(float.PositiveInfinity / float.PositiveInfinity));
                Assert(Fixed32.IsNaN(Fixed32.PositiveInfinity / Fixed32.NegativeInfinity), float.IsNaN(float.PositiveInfinity / float.NegativeInfinity));
                Assert(Fixed32.IsNaN(Fixed32.NegativeInfinity / Fixed32.PositiveInfinity), float.IsNaN(float.NegativeInfinity / float.PositiveInfinity));
                Assert(Fixed32.IsNaN(Fixed32.NegativeInfinity / Fixed32.NegativeInfinity), float.IsNaN(float.NegativeInfinity / float.NegativeInfinity));

                // 正无穷除以零，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / 0), float.IsPositiveInfinity(float.PositiveInfinity / 0));
                // 正无穷除以正数，等于正无穷
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / p), float.IsPositiveInfinity(float.PositiveInfinity / p));
                Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / u), float.IsPositiveInfinity(float.PositiveInfinity / p));
                // 正无穷除以负数，等于负无穷
                Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity / n), float.IsNegativeInfinity(float.PositiveInfinity / n));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity / v), float.IsNegativeInfinity(float.PositiveInfinity / n));

                // 溢出
                Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue / f), float.IsPositiveInfinity(float.MaxValue / (float)d));
                Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue / f), float.IsNegativeInfinity(float.MinValue / (float)d));
            }
        }
    }
}
