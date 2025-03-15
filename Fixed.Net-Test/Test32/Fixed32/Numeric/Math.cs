using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TMath : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES =  100;
        private const int NEGATIVE_MIN_NUMBER = -1000000;
        private const int POSITIVE_MAX_NUMBER =  1000000;

        public override void Run()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = Random.Shared.Next(NEGATIVE_MIN_NUMBER, 0);
                var n2 = Random.Shared.Next(1, POSITIVE_MAX_NUMBER);
                var n3 = Random.Shared.NextSingle() * n1;
                var n4 = Random.Shared.NextSingle() * n2;
                var n5 = Random.Shared.NextDouble() * n1;
                var n6 = Random.Shared.NextDouble() * n2;

                var f1 = new Fixed32(n1);
                var f2 = new Fixed32(n2);
                var f3 = new Fixed32(n3);
                var f4 = new Fixed32(n4);
                var f5 = new Fixed32(n5);
                var f6 = new Fixed32(n6);

                Assert(Mathf.Abs(f1), Math.Abs(n1));
                Assert(Mathf.Abs(f2), Math.Abs(n2));
                Assert(Mathf.Abs(f3), Math.Abs(n3));
                Assert(Mathf.Abs(f4), Math.Abs(n4));
                Assert(Mathf.Abs(f5), Math.Abs(n5));
                Assert(Mathf.Abs(f6), Math.Abs(n6));

                Assert(Mathf.Min(f1, f2), Math.Min(n1, n2));
                Assert(Mathf.Min(f3, f4), Math.Min(n3, n4));
                Assert(Mathf.Min(f5, f6), Math.Min(n5, n6));

                Assert(Mathf.Max(f1, f2), Math.Max(n1, n2));
                Assert(Mathf.Max(f3, f4), Math.Max(n3, n4));
                Assert(Mathf.Max(f5, f6), Math.Max(n5, n6));

                Assert(Mathf.Floor(f3), Math.Floor(n3));
                Assert(Mathf.Floor(f4), Math.Floor(n4));
                Assert(Mathf.Floor(f5), Math.Floor(n5));
                Assert(Mathf.Floor(f6), Math.Floor(n6));

                Assert(Mathf.Ceil(f3), Math.Ceiling(n3));
                Assert(Mathf.Ceil(f4), Math.Ceiling(n4));
                Assert(Mathf.Ceil(f5), Math.Ceiling(n5));
                Assert(Mathf.Ceil(f6), Math.Ceiling(n6));

                Assert(Mathf.Round(f3), Math.Round(n3));
                Assert(Mathf.Round(f4), Math.Round(n4));
                Assert(Mathf.Round(f5), Math.Round(n5));
                Assert(Mathf.Round(f6), Math.Round(n6));

                Assert(Mathf.Reciprocal(f3), 1 / n3);
                Assert(Mathf.Reciprocal(f4), 1 / n4);
                Assert(Mathf.Reciprocal(f5), 1 / n5);
                Assert(Mathf.Reciprocal(f6), 1 / n6);

                Assert(Mathf.Sqrt(f2), Math.Sqrt(n2));
                Assert(Mathf.Sqrt(f4), Math.Sqrt(n4));
                Assert(Mathf.Sqrt(f6), Math.Sqrt(n6));
            }
        }
    }
}
