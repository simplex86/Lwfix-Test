using Lwfix;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector2
    {
        private const double PERPENDICULAR_TOLERANCE = 10e-7;

        [Fact]
        public void Perpendicular()
        {
            foreach (var v in DataSource.Vector2)
            {
                var vector = new Vector2((float)v[0], (float)v[1]);
                var lerp = Vector2.Perpendicular(vector);

                var fvector = new FVector2<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]));
                var flerp = FVector2<Fixed32>.Perpendicular(fvector);

                Assert.Equal(lerp.x, flerp.X.ToFloat(), LERP_TOLERANCE);
                Assert.Equal(lerp.y, flerp.Y.ToFloat(), LERP_TOLERANCE);
            }
        }
    }
}