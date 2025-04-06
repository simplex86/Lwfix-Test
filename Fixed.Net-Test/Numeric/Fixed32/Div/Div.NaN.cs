using Xunit;
using Lwkit.Fixed;

namespace Test.Numerics
{
    /// <summary>
    /// 除法 - 常规，检验准确性
    /// </summary>
    public partial class TDiv
    {
        [Fact]
        public void NaN()
        {
            for (int i = 0; i < LOOP_TIMES; i++)
            {
                var d = Random.Shared.NextDouble();
                var k = Random.Shared.Next(int.MinValue, int.MaxValue); // 任意整数
                var w = new Fixed32(k * d); // 任意

                // NaN除以NaN，等于NaN
                Assert.True(double.IsNaN(double.NaN / double.NaN));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN / Fixed32.NaN));
                // NaN除以任何数，都等于NaN
                Assert.True(double.IsNaN(double.NaN / 0));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN / 0));
                Assert.True(double.IsNaN(double.NaN / k));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN / k));
                Assert.True(Fixed32.IsNaN(Fixed32.NaN / w));
                // 任何数除以NaN，都等于NaN
                Assert.True(double.IsNaN(0 / double.NaN));
                Assert.True(Fixed32.IsNaN(0 / Fixed32.NaN));
                Assert.True(double.IsNaN(k / double.NaN));
                Assert.True(Fixed32.IsNaN(k / Fixed32.NaN));
                Assert.True(Fixed32.IsNaN(w / Fixed32.NaN));
                // 任意极值相除，都等于NaN
                Assert.True(double.IsNaN(double.PositiveInfinity / double.PositiveInfinity));
                Assert.True(Fixed32.IsNaN(Fixed32.PositiveInfinity / Fixed32.PositiveInfinity));
                Assert.True(double.IsNaN(double.PositiveInfinity / double.NegativeInfinity));
                Assert.True(Fixed32.IsNaN(Fixed32.PositiveInfinity / Fixed32.NegativeInfinity));
                Assert.True(double.IsNaN(double.NegativeInfinity / double.PositiveInfinity));
                Assert.True(Fixed32.IsNaN(Fixed32.NegativeInfinity / Fixed32.PositiveInfinity));
                Assert.True(double.IsNaN(double.NegativeInfinity / double.NegativeInfinity));
                Assert.True(Fixed32.IsNaN(Fixed32.NegativeInfinity / Fixed32.NegativeInfinity));
            }
        }
    }
}
