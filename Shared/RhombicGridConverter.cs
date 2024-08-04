/*------------------------------------------------------------------------------
  File:           RhombicGridConverter.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Provides functionality to convert the unit coordinates of a
                    rhombic dodecahedron into local or world space.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-04 06:53:33 
------------------------------------------------------------------------------*/
using System.Linq;
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridConverter
    {
        #region Members

        public Vector3[] Verts, FaceCenters;
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
            Verts = RhombicConstants.Verts.ToArray();
            FaceCenters = RhombicConstants.FaceCenters.ToArray();
            Transform(Verts, config.Rotation, scale);
            Transform(FaceCenters, config.Rotation, scale);

            X = 2f * RhombicConstants.FaceCenters[config.XVectorIndex];
            Y = 2f * RhombicConstants.FaceCenters[config.YVectorIndex];
            Z = 2f * RhombicConstants.FaceCenters[config.ZVectorIndex];
            Transform(ref X, config.Rotation, scale);
            Transform(ref Y, config.Rotation, scale);
            Transform(ref Z, config.Rotation, scale);
        }

        #endregion Constructors

        //public Vector3 GridToWorldSpace(int x, int y, int z) { return new(); }

        //public (int x, int y, int z) WorldToGrid(Vector3 vec) { return (0, 0, 0); }

        #region Helpers

        private void Transform(Vector3[] array, Quaternion rotation, Vector3 scale)
        {
            for(var index = 0; index < array.Length; ++index)
            {
                Transform(ref array[index], rotation, scale);
            }
        }

        private void Transform(ref Vector3 vector, Quaternion rotation, Vector3 scale)
        {
            vector = Vector3.Scale(scale, vector);
            vector = rotation * vector;
        }

        #endregion Helpers

        #endregion Methods
    }
}