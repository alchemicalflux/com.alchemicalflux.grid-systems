/*------------------------------------------------------------------------------
  File:           RhombicGridConverter.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Provides functionality to convert the unit coordinates of a
                    rhombic dodecahedron into local or world space.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-05 23:10:02 
------------------------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridConverter
    {
        #region Members

        public IReadOnlyList<Vector3> Verts, FaceCenters;
        public readonly Vector3 X, Y, Z;

        #endregion Members

        #region Methods

        #region Constructors

        public RhombicGridConverter(RhombicGridConfig config) : 
            this(config, Vector3.one) {}

        public RhombicGridConverter(RhombicGridConfig config, float scale) : 
            this(config, new Vector3(scale, scale, scale)) { }

        public RhombicGridConverter(RhombicGridConfig config, Vector3 scale)
        {
            Verts = Transform(RhombicConstants.Verts, config.Rotation, scale);
            FaceCenters = Transform(RhombicConstants.FaceCenters, config.Rotation, scale);

            X = Transform(2f * RhombicConstants.FaceCenters[config.XVectorIndex], config.Rotation, scale);
            Y = Transform(2f * RhombicConstants.FaceCenters[config.YVectorIndex], config.Rotation, scale);
            Z = Transform(2f * RhombicConstants.FaceCenters[config.ZVectorIndex], config.Rotation, scale);
        }

        #endregion Constructors

        public Vector3 CellPosition(Transform transform, int x, int y, int z) 
        { 
            return transform.TransformPoint(CellOffset(x, y, z));
        }

        public Vector3 CellOffset(int x, int y, int z)
        {
            return x * X + y * Y + z * Z;
        }

        //public (int x, int y, int z) WorldToGrid(Vector3 vec) { return (0, 0, 0); }

        #region Helpers

        private IReadOnlyList<Vector3> Transform(IReadOnlyList<Vector3> array, Quaternion rotation, Vector3 scale)
        {
            List<Vector3> result = new();
            for(var index = 0; index < array.Count; ++index)
            {
                result.Add(Transform(array[index], rotation, scale));
            }
            return result;
        }

        private Vector3 Transform(Vector3 vector, Quaternion rotation, Vector3 scale)
        {
            vector = Vector3.Scale(scale, vector);
            vector = rotation * vector;
            return vector;
        }

        #endregion Helpers

        #endregion Methods
    }
}