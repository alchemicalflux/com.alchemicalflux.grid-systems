/*------------------------------------------------------------------------------
  File:           RhombicGridConfig.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Class for storing transform details for rhombic grid systems.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-03 09:16:05 
------------------------------------------------------------------------------*/
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public struct RhombicGridConfig
    {
        public readonly Quaternion Rotation;
        public readonly int XVectorIndex;
        public readonly int YVectorIndex;
        public readonly int ZVectorIndex;

        public RhombicGridConfig(Quaternion rotation, int xIndex, int yIndex, int zIndex)
        {
            Rotation = rotation;
            XVectorIndex = xIndex;
            YVectorIndex = yIndex;
            ZVectorIndex = zIndex;
        }

        public static readonly RhombicGridConfig BaseAlignment =
            new RhombicGridConfig(Quaternion.identity, 4, 0, 8);

        public static readonly RhombicGridConfig TopAlignment =
            new RhombicGridConfig(RhombicConstants.TopAlign, 4, 0, 8);

        public static readonly RhombicGridConfig SideAlignment = 
            new RhombicGridConfig(RhombicConstants.SideAlign, 4, 0, 8);
    }
}