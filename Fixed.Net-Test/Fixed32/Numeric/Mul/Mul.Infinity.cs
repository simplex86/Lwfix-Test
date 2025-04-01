﻿using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 乘法 - 极值
    /// </summary>
    public partial class TMul
    {
        [Fact]
        public void Infinity()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var p = Random.Shared.Next(1, int.MaxValue); // 正整数
                var n = Random.Shared.Next(int.MinValue, 0); // 负整数

                var u = new Fixed32(p * d); // 正
                var v = new Fixed32(n * d); // 负

                // 正无穷乘以任何正数，等于正无穷
                Assert.True(double.IsPositiveInfinity(double.PositiveInfinity * p));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * p));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity * u));
                // 正无穷乘以任何负数，等于负无穷
                Assert.True(double.IsNegativeInfinity(double.PositiveInfinity * n));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity * n));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity * v));
                // 负无穷乘以任何正数，等于负无穷
                Assert.True(double.IsNegativeInfinity(double.NegativeInfinity * p));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * p));
                Assert.True(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity * u));
                // 负无穷乘以任何正数，等于正无穷
                Assert.True(double.IsPositiveInfinity(double.NegativeInfinity * n));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity * n));
                Assert.True(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity * v));
            }
        }
    }
}
