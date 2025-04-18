using Lwfix;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector3
    {
        private const double NORMALIZE_TOLERANCE = 10e-5;

        [Fact]
        public void Normalize()
        {
            foreach (var v in DataSource.Vector3)
            {
                var vector = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector_normalized = vector.normalized;

                var fvector = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector_normalized = fvector.Normalized;

                Assert.Equal(vector_normalized.x, fvector_normalized.X.ToFloat(), NORMALIZE_TOLERANCE);
                Assert.Equal(vector_normalized.y, fvector_normalized.Y.ToFloat(), NORMALIZE_TOLERANCE);
            }
        }
    }
}
