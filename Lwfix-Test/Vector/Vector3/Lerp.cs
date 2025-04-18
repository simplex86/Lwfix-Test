using Lwfix;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector3
    {
        private const double LERP_TOLERANCE = 10e-3;

        [Fact]
        public void Lerp()
        {
            for (int i = 0; i < DataSource.Vector3.Count - 1; i += 2)
            {
                var v = DataSource.Vector3[i];
                var u = DataSource.Vector3[i + 1];
                var t = i / 10f;

                var vector1 = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector2 = new Vector3((float)u[0], (float)u[1], (float)u[2]);
                var lerp = Vector3.Lerp(vector1, vector2, t);

                var fvector1 = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector2 = new FVector3<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]), new Fixed32(u[2]));
                var ft = new Fixed32(t);
                var flerp = FVector3<Fixed32>.Lerp(fvector1, fvector2, ft);

                Assert.Equal(lerp.x, flerp.X.ToFloat(), LERP_TOLERANCE);
                Assert.Equal(lerp.y, flerp.Y.ToFloat(), LERP_TOLERANCE);
            }
        }
    }
}