/*------------------------------------------------------------------------------
  File:           RhombicGridConverter.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Provides functionality to convert the unit coordinates of a
                    rhombic dodecahedron into local or world space.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-03 09:16:05 
------------------------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridConverter
    {
        public Vector3[] Verts = RhombicConstants.Verts;
        public Vector3[] FaceCenters = RhombicConstants.FaceCenters;
        public Vector3 X = RhombicConstants.X;
        public Vector3 Y = RhombicConstants.Y;
        public Vector3 Z = RhombicConstants.Z;

        public RhombicGridConverter(RhombicGridConfig config)
        {
            Verts = RotateArray(RhombicConstants.Verts, config.Rotation);
            FaceCenters = RotateArray(RhombicConstants.FaceCenters, config.Rotation);
            X = config.Rotation * RhombicConstants.FaceCenters[config.XVectorIndex];
            Y = config.Rotation * RhombicConstants.FaceCenters[config.YVectorIndex];
            Z = config.Rotation * RhombicConstants.FaceCenters[config.ZVectorIndex];
        }

        public Vector3 GridToWorldSpace(int x, int y, int z) { return new(); }

        public (int x, int y, int z) WorldToGrid(Vector3 vec) { return (0, 0, 0); }

        // Method to apply rotation to a Vector3 array
        protected static Vector3[] RotateArray(Vector3[] originalArray, Quaternion rotation)
        {
            Vector3[] rotatedArray = new Vector3[originalArray.Length];
            for(int index = 0; index < originalArray.Length; ++index)
            {
                rotatedArray[index] = rotation * originalArray[index];
            }
            return rotatedArray;
        }

    }
}