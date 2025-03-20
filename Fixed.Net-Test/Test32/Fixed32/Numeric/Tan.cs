using Lwkit.Fixed;

namespace Test
{
    [Test]
    internal class TTan : BaseTest<Fixed32>
    {
        private const int LOOP_TIMES =  100;
        private const int MIN_NUMBER = -180;
        private const int MAX_NUMBER =  180;

        public override void Run()
        {
            ////for (int i = 0; i < LOOP_TIMES; i++)
            //{
            //    var n1 = 89.9999;//Random.Shared.NextSingle() * Random.Shared.Next(MIN_NUMBER, MAX_NUMBER);
            //    var f1 = new Fixed32(n1);
            //    var r1 = (n1 / 180.0) * Math.PI;
            //    var r2 = Fixed32.DegreeToRadian(f1);

            //    var s1 = Math.Tan(r1);
            //    var s2 = Fixed32.Tan(r2);
            //    var s3 = Fixed32.FastTan(r2);

            //    //Assert(s2, s1);
            //    //Assert(s3, s1);
            //    Console.WriteLine($"{n1:F4} -> Abs({s1} - {s2}) = {Math.Abs(s1 - s2.ToDouble()):F7}");
            //    Console.WriteLine($"{n1:F4} -> Abs({s1} - {s3}) = {Math.Abs(s1 - s3.ToDouble()):F7}");
            //}
        }
    }
}
