using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SlingshotLine : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lineRenderer.positionCount = 2;
        Vector3[] vertices = new Vector3[2];
        vertices[0] = startPoint;
        vertices[1] = endPoint;

        lineRenderer.SetPositions(vertices);
    }

    public void EndLine()
    {
        lineRenderer.positionCount = 0;
    }
}
