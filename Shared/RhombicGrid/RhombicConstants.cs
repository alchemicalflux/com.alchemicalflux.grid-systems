/*------------------------------------------------------------------------------
  File:           RhombicConstants.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Contains relevant mathematical values for a rhombic 
                    dodecahedron and its spacial coordinates.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-05 23:10:02 
------------------------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicConstants
    {
        #region Mathematical Constants

        public static readonly float ShortToLongDiagScale = Mathf.Sqrt(2);
        public static readonly float EdgeToLongDiagScale = Mathf.Sqrt(3);

        #endregion Mathematical Constants

        #region Spacial Constants

        private static readonly Vector3[] _verts =
        {
            new(1, 1, -1), new(-1, -1, 1),
            new(1, 1, 1), new(1, -1, -1), new(-1, 1, -1),
            new(1, -1, 1), new(-1, 1, 1), new(-1, -1, -1),

            new(2, 0, 0), new(-2, 0, 0),
            new(0, 2, 0), new(0, -2, 0),
            new(0, 0, 2), new(0, 0, -2),
        };
        public static readonly IReadOnlyList<Vector3> Verts = _verts;

        private static readonly Vector3[] _faceCenters =
        {
            new(1, 1, 0), new(1, -1, 0), new(-1, 1, 0), new(-1, -1, 0),
            new(1, 0, 1), new(1, 0, -1), new(-1, 0, 1), new(-1, 0, -1),
            new(0, 1, 1), new(0, 1, -1), new(0, -1, 1), new(0, -1, -1)
        };
        public static readonly IReadOnlyList<Vector3> FaceCenters = _faceCenters;

        #endregion Spacial Constants
    }
}