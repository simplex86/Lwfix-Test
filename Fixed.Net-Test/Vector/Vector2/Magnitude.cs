using Lwkit.Fixed;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector2
    {
        private const double MAGNITUDE_TOLERANCE = 10e-3;

        [Fact]
        public void Magnitude()
        {
            foreach (var v in DataSource.Vector2)
            {
                var vector = new Vector2((float)v[0], (float)v[1]);
                var vector_magnitude = vector.magnitude;

                var fvector = new FVector2<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]));
                var fvector_magnitude = fvector.Magnitude;

                Assert.Equal(vector_magnitude, fvector_magnitude.ToFloat(), MAGNITUDE_TOLERANCE);
            }
        }
    }
}
