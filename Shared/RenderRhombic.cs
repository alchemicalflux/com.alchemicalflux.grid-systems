/*------------------------------------------------------------------------------
  File:           RenderRhombic.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    MonoBehaviour for rendering the coordinates and directional
                    vectors for a rhombic dodecahedron based grid.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-08-03 03:57:37 
------------------------------------------------------------------------------*/
using UnityEngine;
namespace AlchemicalFlux.GridSystems
{
    public class RenderRhombic : MonoBehaviour
    {
        public enum RotationStateValue { Square, Hex };
        public RotationStateValue RotationState;

        private RhombicGridConverter _rhombicConverter = new();

        private void Start()
        {
        }

        private void OnDrawGizmos()
        {
            switch(RotationState)
            {
                case RotationStateValue.Square:
                    DrawLocalPointSet(RhombicConstants.Verts, Color.green);
                    DrawLocalPointSet(RhombicConstants.FaceCenters, Color.red);
                    DrawLocalLine(new(), RhombicConstants.X, Color.red);
                    DrawLocalLine(new(), RhombicConstants.Y, Color.green);
                    DrawLocalLine(new(), RhombicConstants.Z, Color.blue);
                    break;
                case RotationStateValue.Hex:
                    _rhombicConverter.AlignUsing(transform.localRotation * RhombicConstants.SideAlign);
                    //DrawChunk(_rhombicConverter.X, _rhombicConverter.Y, _rhombicConverter.Z);
                    DrawPointSet(_rhombicConverter.Verts, Color.green);
                    DrawPointSet(_rhombicConverter.FaceCenters, Color.red);
                    DrawLine(new(), _rhombicConverter.X, Color.red);
                    DrawLine(new(), _rhombicConverter.Y, Color.green);
                    DrawLine(new(), _rhombicConverter.Z, Color.blue);
                    break;
            }

            //var percent = 13;
            //foreach(var neighbor in RhombicGrid.Neighbors)
            //{
            //    Gizmos.DrawSphere(neighbor, Mathf.Sqrt(2));
            //    //var color = (--percent / 12f);
            //    //Gizmos.color = new(color, color, color);
            //    //foreach (var vert in RhombicGrid.Verts)
            //    //{
            //    //    Gizmos.DrawSphere(vert + neighbor, .05f);
            //    //}
            //}
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
            var limit = 3;
            for(var x = -2; x < limit; ++x)
            {
                for(var y = -2; y < limit; ++y)
                {
                    for(var z = -2; z < limit; ++z)
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
