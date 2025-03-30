using Lwkit.Fixed;

namespace Test
{
    //[Test]
    //internal class TMul : BaseTest<Fixed32>
    //{
    //    private const int LOOP_TIMES = 100;
    //    private readonly static int NUMBER_A = 100000;
    //    private readonly static int NUMBER_B = Fixed32.MaxValue.ToInt() / NUMBER_A;
    //    private const double PRECISION = 0.0001;

    //    public override void Run()
    //    {
    //        // 常规计算（不会溢出），检验准确性
    //        for (int i = 0; i < LOOP_TIMES; i++)
    //        {
    //            var n1 = Random.Shared.Next(1, NUMBER_A);
    //            var n2 = Random.Shared.Next(-NUMBER_B, NUMBER_B);
    //            var n3 = Random.Shared.NextDouble() * n1;
    //            var n4 = Random.Shared.NextDouble() * n2;

    //            var f1 = new Fixed32(n1);
    //            var f2 = new Fixed32(n2);
    //            var f3 = new Fixed32(n3);
    //            var f4 = new Fixed32(n4);

    //            Assert(f1 * f2, n1 * n2, PRECISION);
    //            Assert(f1 * f4, n1 * n4, PRECISION);
    //            Assert(f3 * f4, n3 * n4, PRECISION);
    //        }

    //        // 边界检验 - NaN、最值、极值
    //        for (int i = 0; i < LOOP_TIMES; i++)
    //        {
    //            var d = Random.Shared.NextDouble();
    //            var p = Random.Shared.Next(1, int.MaxValue); // 正整数
    //            var n = Random.Shared.Next(int.MinValue, 0); // 负整数
    //            var k = Random.Shared.Next(int.MinValue, int.MaxValue); // 任意整数

    //            var u = new Fixed32(p * d); // 正
    //            var v = new Fixed32(n * d); // 负
    //            var w = new Fixed32(k * d); // 任意

    //            // NaN乘以任何书，等于NaN
    //            Assert(Fixed32.IsNaN(Fixed32.NaN * k), double.IsNaN(double.NaN * k));
    //            Assert(Fixed32.IsNaN(Fixed32.NaN * w), double.IsNaN(double.NaN * k));

    //            // 正无穷乘以任何正数，等于正无穷
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * p), double.IsPositiveInfinity(double.PositiveInfinity * p));
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * u), double.IsPositiveInfinity(double.PositiveInfinity * p));
    //            // 正无穷乘以零，等于正无穷
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * 0), double.IsPositiveInfinity(double.PositiveInfinity * 0));
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * Fixed32.Zero), double.IsPositiveInfinity(double.PositiveInfinity * 0));
    //            // 正无穷乘以任何负数，等于负无穷
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity * n), double.IsNegativeInfinity(double.PositiveInfinity * n));
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity * v), double.IsNegativeInfinity(double.PositiveInfinity * n));
    //            // 负无穷乘以任何正数，等于负无穷
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * p), double.IsNegativeInfinity(double.NegativeInfinity * p));
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * u), double.IsNegativeInfinity(double.NegativeInfinity * p));
    //            // 负无穷乘以零，等于正无穷
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * 0), double.IsNegativeInfinity(double.NegativeInfinity * 0));
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * Fixed32.Zero), double.IsNegativeInfinity(double.NegativeInfinity * 0));
    //            // 负无穷乘以任何正数，等于正无穷
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity * n), double.IsPositiveInfinity(double.NegativeInfinity * n));
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity * v), double.IsPositiveInfinity(double.NegativeInfinity * n));

    //            // 最大值乘以任何正整数，等于正无穷
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue * p), double.IsPositiveInfinity(double.MaxValue * p));
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.MaxValue * u), double.IsPositiveInfinity(double.MaxValue * p));
    //            // 最大值乘以零，等于零
    //            Assert(Fixed32.IsZero(Fixed32.MaxValue * 0), double.MaxValue * 0 == 0);
    //            Assert(Fixed32.IsZero(Fixed32.MaxValue * Fixed32.Zero), double.MaxValue * 0 == 0);
    //            // 最大值乘以任何负整数，等于负无穷
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.MaxValue * n), double.IsNegativeInfinity(double.MaxValue * n));
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.MaxValue * v), double.IsNegativeInfinity(double.MaxValue * n));
    //            // 最小值乘以任何正整数，等于负无穷
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue * p), double.IsNegativeInfinity(double.MinValue * p));
    //            Assert(Fixed32.IsNegativeInfinity(Fixed32.MinValue * u), double.IsNegativeInfinity(double.MinValue * p));
    //            // 最小值乘以零，等于零
    //            Assert(Fixed32.IsZero(Fixed32.MinValue * 0), double.MinValue * 0 == 0);
    //            Assert(Fixed32.IsZero(Fixed32.MinValue * Fixed32.Zero), double.MinValue * 0 == 0);
    //            // 最小值乘以任何负整数，等于正无穷
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.MinValue * n), double.IsPositiveInfinity(double.MinValue * n));
    //            Assert(Fixed32.IsPositiveInfinity(Fixed32.MinValue * v), double.IsPositiveInfinity(double.MinValue * n));
    //        }
    //    }
    //}
}
