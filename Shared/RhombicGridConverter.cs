/*------------------------------------------------------------------------------
  File:           RhombicGridConverter.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Provides functionality to convert the unit coordinates of a
                    rhombic dodecahedron into local or world space.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-07-11 22:36:30 
------------------------------------------------------------------------------*/
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridConverter
    {
        public Vector3[] Verts = RhombicConstants.Verts;
        public Vector3[] FaceCenters = RhombicConstants.FaceCenters;
        public Vector3[] Neighbors = RhombicConstants.Neighbors;
        public Vector3 X = new(-2, 2, 0);
        public Vector3 Y = new(-2, 0, 2);
        public Vector3 Z = new(0, 2, 2);

        public RhombicGridConverter() { }

        //public RhombicGridConverter(Quaternion rotation)
        //{
        //    _rotation = rotation;
        //    Verts = RotateArray(RhombicConstants.Verts, _rotation);
        //    FaceCenters = RotateArray(RhombicConstants.FaceCenters, _rotation);
        //    Neighbors = RotateArray(RhombicConstants.Neighbors, _rotation);
        //    X = _rotation * X;
        //    Y = _rotation * Y;
        //    Z = _rotation * Z;
        //}

        public void AlignUsing(Quaternion rotation)
        {
            Verts = RotateArray(RhombicConstants.Verts, rotation);
            FaceCenters = RotateArray(RhombicConstants.FaceCenters, rotation);
            Neighbors = RotateArray(RhombicConstants.Neighbors, rotation);
            X = rotation * X;
            Y = rotation * Y;
            Z = rotation * Z;
        }


        // Method to apply rotation to a Vector3 array
        private static Vector3[] RotateArray(Vector3[] originalArray, Quaternion rotation)
        {
            Vector3[] rotatedArray = new Vector3[originalArray.Length];
            for (int index = 0; index < originalArray.Length; index++)
            {
                rotatedArray[index] = rotation * originalArray[index];
            }
            return rotatedArray;
        }
    }
}