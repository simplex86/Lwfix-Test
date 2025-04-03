using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TCos
    {
        [Fact]
        public void NaN()
        {
            Assert.True(double.IsNaN(Math.Cos(double.NaN)));
            Assert.True(Fixed32.IsNaN(Fixed32.Cos(Fixed32.NaN)));
            Assert.True(Fixed32.IsNaN(Fixed32.FastCos(Fixed32.NaN)));
        }
    }
}
