using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusForEnemys : MonoBehaviour
{
    //Variables

    [SerializeField] private int numPoints = 360;
    [SerializeField] private float radius = 10f;
    LineRenderer lineRenderer;
    //GameObject gameObject;
    Transform transform;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //gameObject = GetComponent<GameObject>() as GameObject;
        transform = this.GetComponent<Transform>();
        lineRenderer.positionCount = numPoints;

        Vector3[] points = new Vector3[numPoints];

        for (int n = 0; n < numPoints; n++)
        {
            var angle = (Mathf.PI * 2f) * ((float)n / numPoints);
            points[n] = new Vector3((Mathf.Sin(angle) * radius) + transform.position.x, 0f, (Mathf.Cos(angle) * radius) + transform.position.z);
        }

        lineRenderer.SetPositions(points);
    }
}


