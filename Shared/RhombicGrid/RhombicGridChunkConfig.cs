/*------------------------------------------------------------------------------
  File:           RhombicGridChunkConfig.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Class for storing details for rhombic grid chunks.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-07 21:46:15 
------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridChunkConfig
    {
        #region Members

        private readonly int _xSize, _ySize, _zSize;
        private readonly RhombicGridConverter _converter;
        private Vector3[] _positions;
        public IReadOnlyCollection<Vector3> Positions;

        #endregion Members

        #region Methods

        #region Constructors

        public RhombicGridChunkConfig(RhombicGridConverter converter, int size) : 
            this(converter, size, size, size) { }

        public RhombicGridChunkConfig(RhombicGridConverter converter, 
            int xSize, int ySize, int zSize)
        {
            _converter = converter;
            _xSize = xSize;
            _ySize = ySize;
            _zSize = zSize;
            GeneratePositions();
        }

        #endregion Constructors

        private void GeneratePositions()
        {
            Positions = _positions = new Vector3[_ySize * _xSize * _zSize];
            var xzSize = _xSize * _zSize;

            Parallel.For(0, _ySize, y =>
                {
                    var yOffset = y * xzSize;
                    for(var z = 0; z < _zSize; ++z)
                    {
                        var offset = z * _xSize + yOffset;
                        for(var x = 0; x < _xSize; ++x)
                        {
                            _positions[offset + x] = _converter.X * x + _converter.Y * y + _converter.Z * z;
                        }
                    }
                }
            );
        }
        // x, y, z, -x, -y, -z, -x+y, -x+z, -y+x, -y+z, -z+x, -z+y

        #endregion Methods
    }
}
