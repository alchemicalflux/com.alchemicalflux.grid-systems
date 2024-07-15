/*------------------------------------------------------------------------------
  File:           RhombicConstants.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Contains relevant mathematical values for a rhombic 
                    dodecahedron and its spacial coordinates.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-07-14 23:47:10 
------------------------------------------------------------------------------*/
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicConstants
    {
        public static readonly float ShortToLongDiagScale = Mathf.Sqrt(2);
        public static readonly float EdgeToLongDiagScale = Mathf.Sqrt(3);

        public static readonly Vector3[] Verts =
        {
            new(1, 1, -1), new(-1, -1, 1),
            new(1, 1, 1), new(1, -1, -1), new(-1, 1, -1),
            new(1, -1, 1), new(-1, 1, 1), new(-1, -1, -1),

            new(2, 0, 0), new(-2, 0, 0),
            new(0, 2, 0), new(0, -2, 0),
            new(0, 0, 2), new(0, 0, -2),
        };

        public static readonly Vector3[] FaceCenters =
        {
            new(1, 1, 0), new(1, -1, 0), new(-1, 1, 0), new(-1, -1, 0),
            new(1, 0, 1), new(1, 0, -1), new(-1, 0, 1), new(-1, 0, -1),
            new(0, 1, 1), new(0, 1, -1), new(0, -1, 1), new(0, -1, -1)
        };

        public static readonly Vector3[] Neighbors =
        {
            new(2, 2, 0), new(2, 0, 2), new(0, 2, 2),
            new(2, -2, 0), new(2, 0, -2), new(0, 2, -2),
            new(-2, 2, 0), new(-2, 0, 2), new(0, -2, 2),
            new(-2, -2, 0), new(-2, 0, -2), new(0, -2, -2),
        };

        // Define the rotation quaternion
        private static readonly float LARGE_ANGLE = 2 * Mathf.Atan(Mathf.Sqrt(2));
        private static readonly float LARGE_DEGREES = LARGE_ANGLE * Mathf.Rad2Deg;
        private static readonly float HEX_ROTATION = LARGE_DEGREES / 2f;

        public static readonly Quaternion HexRotation = Quaternion.AngleAxis(HEX_ROTATION, new Vector3(1, 0, 1));
        public static readonly Quaternion TopAlign = Quaternion.AngleAxis(45, new Vector3(0, 1, 0)) * HexRotation;

        // Traversals
        public static readonly Vector3 X = new(2, 0, 2);
        public static readonly Vector3 Y = new(0, 2, 2);
        public static readonly Vector3 Z = new(-2, 0, 2);
    }
}