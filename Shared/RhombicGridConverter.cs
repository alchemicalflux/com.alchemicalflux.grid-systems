/*------------------------------------------------------------------------------
  File:           RhombicGridConverter.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Provides functionality to convert the unit coordinates of a
                    rhombic dodecahedron into local or world space.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-07-14 23:47:10 
------------------------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridConverter
    {
        public Vector3[] Verts = RhombicConstants.Verts;
        public Vector3[] FaceCenters = RhombicConstants.FaceCenters;
        public Vector3[] Neighbors = RhombicConstants.Neighbors;
        public Vector3 X = RhombicConstants.X;
        public Vector3 Y = RhombicConstants.Y;
        public Vector3 Z = RhombicConstants.Z;

        public void AlignUsing(Quaternion rotation)
        {
            Verts = RotateArray(RhombicConstants.Verts, rotation);
            FaceCenters = RotateArray(RhombicConstants.FaceCenters, rotation);
            Neighbors = RotateArray(RhombicConstants.Neighbors, rotation);

            
            var usedVectors = new HashSet<int>();

            var bestSet = FindBestFitSet(FaceCenters, Vector3.right, usedVectors);
            var xIndex = FindBestFitVector(FaceCenters, bestSet, new Vector3(1, 1, 1));
            X = FaceCenters[xIndex];
            usedVectors.Add(xIndex);

            bestSet = FindBestFitSet(FaceCenters, Vector3.forward, usedVectors);
            var zIndex = FindBestFitVector(FaceCenters, bestSet, new Vector3(1, 1, 1));
            Z = FaceCenters[zIndex];
            usedVectors.Add(zIndex);

            bestSet = FindBestFitSet(FaceCenters, Vector3.up, usedVectors);
            var yIndex = FindBestFitVector(FaceCenters, bestSet, new Vector3(1, 1, 1));
            Y = FaceCenters[yIndex];
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

        private int FindBestFitVector(Vector3[] originalArray, List<int> indicesToTest, Vector3 fitVector)
        {
            var bestFit = -1;
            var maxProjection = float.MinValue;
            foreach(var index in indicesToTest)
            {
                float projection = Vector3.Dot(originalArray[index], fitVector);
                if(projection > maxProjection)
                {
                    maxProjection = projection;
                    bestFit = index;
                }
            }
            return bestFit;
        }

        private List<int> FindBestFitSet(Vector3[] vectorsToTest, Vector3 fitVector, HashSet<int> toIgnore)
        {
            var bestFits = new List<int>();
            var maxProjection = float.MinValue;
            for(var index = 0; index < vectorsToTest.Length; ++index)
            {
                if(toIgnore.Contains(index)) { continue; }
                
                float projection = Vector3.Dot(vectorsToTest[index], fitVector);
                var isGreater = projection > maxProjection;
                if (isGreater || Mathf.Approximately(projection, maxProjection))
                {
                    if(isGreater) { bestFits.Clear(); }
                    maxProjection = projection;
                    bestFits.Add(index);
                }
            }
            return bestFits;
        }
    }
}