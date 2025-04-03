﻿using Xunit;
using Lwkit.Fixed;

namespace Test
{
    public partial class TSin
    {
        [Fact]
        public void NaN()
        {
            Assert.True(double.IsNaN(Math.Sin(double.NaN)));
            Assert.True(Fixed32.IsNaN(Fixed32.Sin(Fixed32.NaN)));
            Assert.True(Fixed32.IsNaN(Fixed32.FastSin(Fixed32.NaN)));
        }
    }
}
