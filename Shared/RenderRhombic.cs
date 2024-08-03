/*------------------------------------------------------------------------------
  File:           RenderRhombic.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    MonoBehaviour for rendering the coordinates and directional
                    vectors for a rhombic dodecahedron based grid.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-03 09:16:05 
------------------------------------------------------------------------------*/
using UnityEngine;
namespace AlchemicalFlux.GridSystems
{
    public class RenderRhombic : MonoBehaviour
    {
        public enum RotationStateValue { Base, HexTop, HexSide };
        public RotationStateValue RotationState;

        private RhombicGridConverter _baseAlignment = new(RhombicGridConfig.BaseAlignment);
        private RhombicGridConverter _hexTopAlignment = new(RhombicGridConfig.TopAlignment);
        private RhombicGridConverter _hexSideAlignment = new(RhombicGridConfig.SideAlignment);

        private void OnDrawGizmos()
        {
            switch(RotationState)
            {
                case RotationStateValue.Base: DrawSet(_baseAlignment); break;
                case RotationStateValue.HexTop: DrawSet(_hexTopAlignment); break;
                case RotationStateValue.HexSide: DrawSet(_hexSideAlignment); break;
            }
        }

        private void DrawSet(RhombicGridConverter converter)
        {
            //DrawChunk(converter.X, converter.Y, converter.Z);
            DrawLocalPointSet(converter.Verts, Color.green);
            DrawLocalPointSet(converter.FaceCenters, Color.red);
            DrawLocalLine(new(), converter.X, Color.red);
            DrawLocalLine(new(), converter.Y, Color.green);
            DrawLocalLine(new(), converter.Z, Color.blue);
        }

        private void DrawPointSet(Vector3[] points, Color color)
        {
            Gizmos.color = color;
            foreach(var point in points) { Gizmos.DrawSphere(transform.position + point, .1f); }
        }

        private void DrawLocalPointSet(Vector3[] points, Color color)
        {
            Gizmos.color = color;
            foreach (var point in points) { Gizmos.DrawSphere(transform.TransformPoint(point), .1f); }
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
    }
}
