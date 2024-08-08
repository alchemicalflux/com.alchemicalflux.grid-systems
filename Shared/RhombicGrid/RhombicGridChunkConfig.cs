/*------------------------------------------------------------------------------
  File:           RhombicGridChunkConfig.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    Class for storing details for rhombic grid chunks.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-07 23:20:30 
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
        // x, y, z, -x, -y, -z, -x+y, -x+z, -y+x, -y+z, -z+x, -z+y

        #endregion Constructors

        private void GeneratePositions()
        {
            Positions = _positions = new Vector3[_ySize * _xSize * _zSize];
            var xzSize = _xSize * _zSize;

            Parallel.For(0, _ySize, y =>
            {
                var yshift = YShift(y);
                var yOffset = y * xzSize;
                Parallel.For(0, _zSize, z =>
                {
                    var offset = z * _xSize + yOffset;
                    var shift = ZShift(z) + yshift;
                    Parallel.For(0, _xSize, x =>
                    {
                        _positions[offset + x] = shift + 
                            _converter.X * x + _converter.Y * y + _converter.Z * z;
                    });
                });
            });
        }

        public Vector3 YShift(int y) 
        { 
            return (y / 3) * -_converter.Z + (++y / 3) * -_converter.X; 
        }

        public Vector3 ZShift(int z) 
        {
            return (z / 2) * -_converter.X; 
        }

        #endregion Methods
    }
}
