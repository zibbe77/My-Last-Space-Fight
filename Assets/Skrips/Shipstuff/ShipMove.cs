using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipMove : MonoBehaviour
{
    Vector3 targetPositionG;
    Vector3 Position;
    Transform transform;
    LineRenderer lineRenderer;

    NavMeshAgent agent;

    [SerializeField] private float Speed = 5f;

    bool Test = false;


    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
        agent = this.GetComponent<NavMeshAgent>();
        lineRenderer = this.GetComponent<LineRenderer>();
        targetPositionG = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShipStatic();
        DrawLine();
    }

    public void MoveShip(Vector3 targetPosition)
    {
        targetPositionG = targetPosition;
    }

    public void MoveShipStatic()
    {
        agent.SetDestination(targetPositionG);
    }

    public void DrawLine()
    {
        Vector3[] linePos = new Vector3[2];
        linePos[0] = transform.position;
        linePos[1] = targetPositionG;

        lineRenderer.SetPositions(linePos);
    }
}
