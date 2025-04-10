﻿using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    public partial class TReciprocal
    {
        private readonly static List<double> normal_numbers =
        [
            31.23479409344165,
            -86.05775761556997,
            -906813.7862607994,
            979026.3581211731,
            -100909.43195481248,
        ];
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            foreach (var n in normal_numbers)
            {
                var f = new Fixed32(n);
                Assert.Equal(1.0 / n, Fixed32.Reciprocal(f).ToDouble(), TOLERANCE);
            }
        }
    }
}
