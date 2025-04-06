﻿using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    public partial class TAbs
    {
        private const int LOOP_TIMES = 10000;
        private const int NEGATIVE_MIN_NUMBER = int.MinValue;
        private const int POSITIVE_MAX_NUMBER = int.MaxValue;
        private const double TOLERANCE = 10e-7;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, POSITIVE_MAX_NUMBER);
                var n2 = Random.Shared.NextDouble() * n1;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);

                Assert.Equal(Math.Abs(n1), FMath.Abs(f1).ToInt());
                Assert.Equal(Math.Abs(n2), FMath.Abs(f2).ToDouble(), TOLERANCE);
            }
        }
    }
}
