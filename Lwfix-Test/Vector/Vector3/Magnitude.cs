﻿using Lwfix;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector3
    {
        private const double MAGNITUDE_TOLERANCE = 10e-3;

        [Fact]
        public void Magnitude()
        {
            foreach (var v in DataSource.Vector3)
            {
                var vector = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector_magnitude = vector.magnitude;

                var fvector = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector_magnitude = fvector.Magnitude;

                Assert.Equal(vector_magnitude, fvector_magnitude.ToFloat(), MAGNITUDE_TOLERANCE);
            }
        }
    }
}
