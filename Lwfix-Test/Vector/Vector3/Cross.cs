using Lwfix;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector3
    {
        private const double CROSS_TOLERANCE = 10e-2;

        [Fact]
        public void Cross()
        {
            for (int i = 0; i < DataSource.Vector3.Count - 1; i += 2)
            {
                var v = DataSource.Vector3[i];
                var u = DataSource.Vector3[i + 1];

                var vector1 = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector2 = new Vector3((float)u[0], (float)u[1], (float)u[2]);
                var cross_vector = Vector3.Cross(vector1, vector2);

                var fvector1 = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector2 = new FVector3<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]), new Fixed32(u[2]));
                var fcross_vector = FVector3<Fixed32>.Cross(fvector1, fvector2);

                Assert.Equal(cross_vector.x, fcross_vector.X.ToFloat(), CROSS_TOLERANCE);
                Assert.Equal(cross_vector.y, fcross_vector.Y.ToFloat(), CROSS_TOLERANCE);
                Assert.Equal(cross_vector.z, fcross_vector.Z.ToFloat(), CROSS_TOLERANCE);
            }
        }
    }
}
