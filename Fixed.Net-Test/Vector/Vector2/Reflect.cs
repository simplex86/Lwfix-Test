using Lwkit.Fixed;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector2
    {
        private const double REFLECT_TOLERANCE = 10e-1;

        [Fact]
        public void Reflect()
        {
            for (int i = 0; i < DataSource.Vector2.Count - 1; i += 2)
            {
                var v = DataSource.Vector2[i];
                var u = DataSource.Vector2[i + 1];

                var vector1 = new Vector2((float)v[0], (float)v[1]);
                var vector2 = new Vector2((float)u[0], (float)u[1]);
                var vector_reflect = Vector2.Reflect(vector1, vector2.normalized);

                var fvector1 = new FVector2<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]));
                var fvector2 = new FVector2<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]));
                var fvector_reflect = FVector2<Fixed32>.Reflect(fvector1, fvector2.Normalized);

                Assert.Equal(vector_reflect.x, fvector_reflect.X.ToFloat(), REFLECT_TOLERANCE);
                Assert.Equal(vector_reflect.y, fvector_reflect.Y.ToFloat(), REFLECT_TOLERANCE);
            }
        }
    }
}
