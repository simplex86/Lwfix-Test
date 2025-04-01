﻿using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public class TNumeric
    {
        private const int LOOP_TIMES = 100;
        private const int PRECISION = 6;

        [Fact]
        public void Normal()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                // 整数
                var a1 = Random.Shared.Next();
                var f1 = new Fixed32(a1);
                Assert.Equal(a1, f1.ToInt());

                // 单精度
                var a2 = Random.Shared.NextSingle();
                var f2 = new Fixed32(a2);
                Assert.Equal(a2, f2.ToDouble(), PRECISION);

                // 双精度
                var a3 = Random.Shared.NextDouble();
                var f3 = new Fixed32(a3);
                Assert.Equal(a3, f3.ToDouble(), PRECISION);
            }
        }
    }
}
