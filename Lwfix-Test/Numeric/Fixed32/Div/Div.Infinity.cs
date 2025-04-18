﻿using Xunit;
using Lwfix;

namespace Test.Numerics
{
    /// <summary>
    /// 除法 - 极值
    /// </summary>
    public partial class TDiv
    {
        [Fact]
        public void Infinity()
        {
            var p = System.Random.Shared.NextDouble() * System.Random.Shared.Next(1, int.MaxValue); // 正整数
            var n = System.Random.Shared.NextDouble() * System.Random.Shared.Next(int.MinValue, 0); // 负整数

            var u = new Fixed32(p); // 正
            var v = new Fixed32(n); // 负

            // 正无穷除以零，等于正无穷
            Assert.True(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / 0));
            // 正无穷除以正数，等于正无穷
            Assert.True(Fixed32.IsPositiveInfinity(Fixed32.PositiveInfinity / u));
            // 正无穷除以负数，等于负无穷
            Assert.True(Fixed32.IsNegativeInfinity(Fixed32.PositiveInfinity / v));
            // 负无穷除以零，等于负无穷
            Assert.True(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity / 0));
            // 负无穷除以正数，等于负无穷
            Assert.True(Fixed32.IsNegativeInfinity(Fixed32.NegativeInfinity / u));
            // 负无穷除以负数，等于正无穷
            Assert.True(Fixed32.IsPositiveInfinity(Fixed32.NegativeInfinity / v));
        }
    }
}
