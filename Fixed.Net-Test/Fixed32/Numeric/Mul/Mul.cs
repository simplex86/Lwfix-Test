﻿using Xunit;
using Lwkit.Fixed;

namespace Test
{
    /// <summary>
    /// 乘法 - 常规
    /// </summary>
    public partial class TMul
    {
        private const int LOOP_TIMES = 10000;

        private readonly static int SMALL_NUMBER_A =  1000;
        private readonly static int SMALL_NUMBER_B = -1000;
        private const double SMALL_TOLERANCE = 10e-7;

        private readonly static int BIG_NUMBER_A = 100000;
        private readonly static int BIG_NUMBER_B = Fixed32.MaxValue.ToInt() / BIG_NUMBER_A;
        private const double BIG_TOLERANCE = 10e-5;

        [Fact]
        public void NormalSmall()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(1, SMALL_NUMBER_A);
                var n2 = Random.Shared.Next(SMALL_NUMBER_B, SMALL_NUMBER_A);
                var n3 = Random.Shared.NextDouble() * n1;
                var n4 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);

                Assert.Equal(n1 * n2, (f1 * f2).ToInt());
                Assert.Equal(n1 * n4, (f1 * f4).ToDouble(), SMALL_TOLERANCE);
                Assert.Equal(n3 * n4, (f3 * f4).ToDouble(), SMALL_TOLERANCE);
            }
        }

        [Fact]
        public void NormalBig()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(SMALL_NUMBER_A, BIG_NUMBER_A);
                var n2 = Random.Shared.Next(-BIG_NUMBER_B, BIG_NUMBER_B);
                var n3 = Random.Shared.NextDouble() * n1;
                var n4 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);

                Assert.Equal(n1 * n2, (f1 * f2).ToInt());
                Assert.Equal(n1 * n4, (f1 * f4).ToDouble(), BIG_TOLERANCE);
                Assert.Equal(n3 * n4, (f3 * f4).ToDouble(), BIG_TOLERANCE);
            }
        }
    }
}
