/*------------------------------------------------------------------------------
  File:           RhombicGridRenderer.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    MonoBehaviour for rendering the coordinates and directional
                    vectors for a rhombic dodecahedron based grid.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-05 23:10:02 
------------------------------------------------------------------------------*/
using System.Collections.Generic;
using UnityEngine;
namespace AlchemicalFlux.GridSystems
{
    public class RhombicGridRenderer : MonoBehaviour
    {
        public enum RotationStateValue { Base, HexTop, HexSide };

        [SerializeField]
        private RotationStateValue _rotationState;
        public RotationStateValue RotationState
        {
            get => _rotationState;
            set
            {
                _rotationState = value;
                if(_rotationState != value) { UpdateRotationConfig(); }
            }
        }

        [SerializeField]
        private bool _renderUnitAtOrigin = true;

        private RhombicGridConverter _baseAlignment = 
            new(RhombicGridPresets.BaseAlignment, RhombicGridPresets.UnitScale);
        private RhombicGridConverter _hexTopAlignment = 
            new(RhombicGridPresets.TopAlignment, RhombicGridPresets.UnitScale);
        private RhombicGridConverter _hexSideAlignment = 
            new(RhombicGridPresets.SideAlignment, RhombicGridPresets.UnitScale);

        private RhombicGridConverter _currentConverter;

        public RhombicGridRenderer()
        {
            _currentConverter = _baseAlignment;
        }

        private void OnDrawGizmos()
        {
            if(_renderUnitAtOrigin) { DrawUnitAtOrigin(_currentConverter); }
        }

        private void OnValidate()
        {
            UpdateRotationConfig();
        }

        private void DrawUnitAtOrigin(RhombicGridConverter converter)
        {
            //DrawChunk(converter.X, converter.Y, converter.Z);
            DrawLocalPointSet(converter.Verts, Color.green);
            DrawLocalPointSet(converter.FaceCenters, Color.red);
            DrawLocalLine(Vector3.zero, converter.X, Color.red);
            DrawLocalLine(Vector3.zero, converter.Y, Color.green);
            DrawLocalLine(Vector3.zero, converter.Z, Color.blue);
        }

        private void DrawPointSet(IReadOnlyList<Vector3> points, Color color)
        {
            Gizmos.color = color;
            foreach(var point in points) { Gizmos.DrawSphere(transform.position + point, .05f); }
        }

        private void DrawLocalPointSet(IReadOnlyList<Vector3> points, Color color)
        {
            Gizmos.color = color;
            foreach (var point in points) { Gizmos.DrawSphere(transform.TransformPoint(point), .05f); }
        }

        private void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(transform.position + start, transform.position + end);
        }

        private void DrawLocalLine(Vector3 start, Vector3 end, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(transform.TransformPoint(start), transform.TransformPoint(end));
        }

        private void DrawChunk(Vector3 xAxis, Vector3 yAxis, Vector3 zAxis)
        {
            var limit = 2;
            for(var x = -limit; x <= limit; ++x)
            {
                for(var y = -limit; y <= limit; ++y)
                {
                    for(var z = -limit; z <= limit; ++z)
                    {
                        var result = x * xAxis + y * yAxis + z * zAxis;
                        result *= 2;
                        Gizmos.color = new(x / (float)limit, y / (float)limit, z / (float)limit);
                        Gizmos.DrawSphere(transform.TransformPoint(result), .25f);
                    }
                }
            }
        }

        private void UpdateRotationConfig()
        {
            switch(RotationState)
            {
                case RotationStateValue.Base: _currentConverter = _baseAlignment; break;
                case RotationStateValue.HexTop: _currentConverter = _hexTopAlignment; break;
                case RotationStateValue.HexSide: _currentConverter = _hexSideAlignment; break;
            }
        }
    }
}
