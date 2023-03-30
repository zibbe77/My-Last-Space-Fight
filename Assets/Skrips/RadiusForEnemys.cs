using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusForEnemys : MonoBehaviour
{
    //Variables
    private int n = 0;
    [SerializeField] private int numPoints = 360;
    [SerializeField] private float radius = 10f;
    LineRenderer lineRenderer;
    GameObject gameObject;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        gameObject = GetComponent<GameObject>();

        Vector3[] points = new Vector3[numPoints];

        for (n = 0; n < numPoints; n++)
        {
            var angle = (Mathf.PI * 2f) * ((float)n / numPoints);
            points[n] = new Vector3(Mathf.Sin(angle) * radius, 0f, Mathf.Cos(angle) * radius);
        }

        lineRenderer.SetPositions(points);
    }

    public void SetOrbit(Vector3[] points)
    {

    }

}


