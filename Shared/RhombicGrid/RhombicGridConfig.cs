/*------------------------------------------------------------------------------
  File:           RhombicGridConfig.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Class for storing transform details for rhombic grid systems.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-05 23:10:02 
------------------------------------------------------------------------------*/
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public struct RhombicGridConfig
    {
        #region Members

        public readonly Quaternion Rotation;
        public readonly int XVectorIndex;
        public readonly int YVectorIndex;
        public readonly int ZVectorIndex;

        #endregion Members

        public RhombicGridConfig(Quaternion rotation, int xIndex, int yIndex, int zIndex)
        {
            Rotation = rotation;
            XVectorIndex = xIndex;
            YVectorIndex = yIndex;
            ZVectorIndex = zIndex;
        }
    }
}