﻿using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TReciprocal
    {
        private const int LOOP_TIMES = 100;
        private const int NEGATIVE_MIN_NUMBER = -1000000;
        private const int POSITIVE_MAX_NUMBER = 1000000;
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.NextDouble() * Random.Shared.Next(1, POSITIVE_MAX_NUMBER);
                var n2 = Random.Shared.NextDouble() * Random.Shared.Next(NEGATIVE_MIN_NUMBER, 0);
                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);

                Assert.Equal(1.0 / n1, Fixed32.Reciprocal(f1).ToDouble(), TOLERANCE);
                Assert.Equal(1.0 / n2, Fixed32.Reciprocal(f2).ToDouble(), TOLERANCE);
            }
        }
    }
}
