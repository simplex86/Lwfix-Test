using Lwfix;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector3
    {
        private const double DISTANCE_TOLERANCE = 10e-3;

        [Fact]
        public void Distance()
        {
            for (int i = 0; i < DataSource.Vector3.Count - 1; i += 2)
            {
                var v = DataSource.Vector3[i];
                var u = DataSource.Vector3[i + 1];

                var vector1 = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector2 = new Vector3((float)u[0], (float)u[1], (float)u[2]);
                var vector_distance = Vector3.Distance(vector1, vector2);

                var fvector1 = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector2 = new FVector3<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]), new Fixed32(u[2]));
                var fvector_distance = FVector3<Fixed32>.Distance(fvector1, fvector2);

                Assert.Equal(vector_distance, fvector_distance.ToFloat(), DISTANCE_TOLERANCE);
            }
        }
    }
}
