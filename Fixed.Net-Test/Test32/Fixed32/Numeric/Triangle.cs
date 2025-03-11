﻿using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class Triangle : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES =  100;
        private const int MIN_NUMBER = -10000;
        private const int MAX_NUMBER =  10000;

        public override void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.NextSingle() * Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var f1 = new Fixed32(n1);
                var r1 = (n1 / 180) * Math.PI;
                var r2 = Mathf.DegreeToRadian(f1);

                Assert(r2, r1);
            }
        }
    }
}
