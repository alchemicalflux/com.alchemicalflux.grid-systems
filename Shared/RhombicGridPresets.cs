/*------------------------------------------------------------------------------
  File:           RhombicGridPresets.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Contains useful values for configurations of the rhombic grid
                    system.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-04 06:53:33 
------------------------------------------------------------------------------*/
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridPresets
    {
        #region Mathematical Constants
        
        private static readonly float LargeAngle = 2 * Mathf.Atan(Mathf.Sqrt(2));
        private static readonly float LargeDegrees = LargeAngle * Mathf.Rad2Deg;
        private static readonly float HexAngle = LargeDegrees / 2f;

        #endregion Mathematical Constants

        #region Rotational Constants

        public static readonly Quaternion HexRotation =
            Quaternion.AngleAxis(HexAngle, new Vector3(1, 0, 1));
        public static readonly Quaternion TopAlign =
            Quaternion.AngleAxis(15, new Vector3(0, 1, 0)) * HexRotation;
        public static readonly Quaternion SideAlign =
            Quaternion.AngleAxis(45, new Vector3(0, 1, 0)) * HexRotation;

        #endregion Rotational Constants

        #region Grid Configurations

        public static readonly RhombicGridConfig BaseAlignment =
            new RhombicGridConfig(Quaternion.identity, 4, 0, 8);

        public static readonly RhombicGridConfig TopAlignment =
            new RhombicGridConfig(TopAlign, 4, 0, 8);

        public static readonly RhombicGridConfig SideAlignment =
            new RhombicGridConfig(SideAlign, 4, 0, 8);

        public static readonly float UnitScale = 1f / Mathf.Sqrt(2);

        #endregion Grid Configurations
    }
}