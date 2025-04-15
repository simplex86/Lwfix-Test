﻿using Lwkit.Fixed;
//using System.Numerics;
using Xunit;
using UnityEngine;

namespace Test.Vectors
{
    public partial class TVector3
    {
        private const double PROJECT_TOLERANCE = 10e-3;

        [Fact]
        public void Project()
        {
            for (int i = 0; i < DataSource.Vector3.Count - 1; i += 2)
            {
                var v = DataSource.Vector3[i];
                var u = DataSource.Vector3[i + 1];

                var vector1 = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector2 = new Vector3((float)u[0], (float)u[1], (float)u[2]);
                var project_vector = Vector3.Project(vector1, vector2);

                var fvector1 = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector2 = new FVector3<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]), new Fixed32(u[2]));
                var fproject_vector = FVector3<Fixed32>.Project(fvector1, fvector2);

                Assert.Equal(project_vector.x, fproject_vector.X.ToFloat(), PROJECT_TOLERANCE);
                Assert.Equal(project_vector.y, fproject_vector.Y.ToFloat(), PROJECT_TOLERANCE);
                Assert.Equal(project_vector.z, fproject_vector.Z.ToFloat(), PROJECT_TOLERANCE);
            }
        }

        [Fact]
        public void ProjectOnPlane()
        {
            for (int i = 0; i < DataSource.Vector3.Count - 1; i += 2)
            {
                var v = DataSource.Vector3[i];
                var u = DataSource.Vector3[i + 1];

                var vector1 = new Vector3((float)v[0], (float)v[1], (float)v[2]);
                var vector2 = new Vector3((float)u[0], (float)u[1], (float)u[2]);
                var project_vector = Vector3.ProjectOnPlane(vector1, vector2);

                var fvector1 = new FVector3<Fixed32>(new Fixed32(v[0]), new Fixed32(v[1]), new Fixed32(v[2]));
                var fvector2 = new FVector3<Fixed32>(new Fixed32(u[0]), new Fixed32(u[1]), new Fixed32(u[2]));
                var fproject_vector = FVector3<Fixed32>.ProjectOnPlane(fvector1, fvector2);

                Assert.Equal(project_vector.x, fproject_vector.X.ToFloat(), PROJECT_TOLERANCE);
                Assert.Equal(project_vector.y, fproject_vector.Y.ToFloat(), PROJECT_TOLERANCE);
                Assert.Equal(project_vector.z, fproject_vector.Z.ToFloat(), PROJECT_TOLERANCE);
            }
        }
    }
}
