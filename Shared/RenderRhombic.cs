/*------------------------------------------------------------------------------
  File:           RenderRhombic.cs 
  Project:        AlchemicalFlux Grid Systems
  Description:    MonoBehaviour for rendering the coordinates and directional
                    vectors for a rhombic dodecahedron based grid.
  Copyright:      ©2024 AlchemicalFlux. All rights reserved.

  Last commit by: alchemicalflux 
  Last commit at: 2024-07-14 23:47:10 
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
            switch (RotationState)
            {
                case RotationStateValue.Square:
                    DrawLocalPointSet(RhombicConstants.Verts, Color.green);
                    DrawLocalPointSet(RhombicConstants.FaceCenters, Color.red);
                    DrawLocalLine(new(), RhombicConstants.X, Color.red);
                    DrawLocalLine(new(), RhombicConstants.Y, Color.green);
                    DrawLocalLine(new(), RhombicConstants.Z, Color.blue);
                    break;
                case RotationStateValue.Hex:
                    _rhombicConverter.AlignUsing(transform.localRotation);
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
    }
}
