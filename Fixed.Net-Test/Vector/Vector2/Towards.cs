using Lwkit.Fixed;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector2
    {
        private const double MOVETOWARDS_TOLERANCE = 10e-5;

        [Fact]
        public void MoveTowards()
        {
            for (int i = 0; i < DataSource.Vector2.Count - 1; i += 2)
            {
                var v = DataSource.Vector2[i];
                var u = DataSource.Vector2[i + 1];

                var vector1 = new Vector2((float)v[0], (float)v[1]);
                var vector2 = new Vector2((float)u[0], (float)u[1]);
                var scale = Vector2.MoveTowards(vector1, vector2, 100);

                var fvector1 = new FVector2<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]));
                var fvector2 = new FVector2<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]));
                var fscale = FVector2<Fixed32>.MoveTowards(fvector1, fvector2, 100);

                Assert.Equal(scale.x, fscale.X.ToFloat(), MOVETOWARDS_TOLERANCE);
                Assert.Equal(scale.y, fscale.Y.ToFloat(), MOVETOWARDS_TOLERANCE);
            }
        }
    }
}
