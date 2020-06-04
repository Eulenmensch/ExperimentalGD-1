using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SlingshotLine : MonoBehaviour
{
    [SerializeField] LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = 2;
        Vector3[] vertices = new Vector3[2];
        vertices[0] = startPoint;
        vertices[1] = endPoint;

        lr.SetPositions(vertices);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
