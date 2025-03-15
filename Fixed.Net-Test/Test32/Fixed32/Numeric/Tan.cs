using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TTan : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES =  100;
        private const int MIN_NUMBER = -3600;
        private const int MAX_NUMBER =  3600;

        public override void Run()
        {
            //for (int i = 0; i < LOOP_TIMES; i++)
            {
                var n1 = 626.572266;// Random.Shared.NextSingle() * Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
                var f1 = new Fixed32(n1);
                var r1 = (n1 / 180.0) * Math.PI;
                var r2 = Mathf.DegreeToRadian(f1);

                var s1 = Math.Tan(r1);
                var s2 = Mathf.Tan(r2);
                var s3 = Mathf.FastTan(r2);

                //Assert(s2, s1);
                //Assert(s3, s1);
                Console.WriteLine($"{n1:F1} -> Abs({s1} - {s2}) = {Math.Abs(s1 - s2.ToDouble()):F7}");
            }
        }
    }
}
