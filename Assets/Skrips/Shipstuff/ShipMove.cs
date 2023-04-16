using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class ShipMove : MonoBehaviour
{
    Vector3 targetPositionG;
    Transform transform;
    LineRenderer lineRenderer;
    NavMeshAgent agent;

    //vfx
    public VisualEffect upBurst;
    public VisualEffect upGlow;
    public VisualEffect downBurst;
    public VisualEffect downGlow;
    private bool isPlayning = false;

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

        if (Vector3.Distance(targetPositionG, transform.position) < 1)
        {
            if (isPlayning == true)
            {
                upBurst.Stop();
                upGlow.Stop();
                downGlow.Stop();
                downBurst.Stop();

                isPlayning = false;
            }
        }
        else
        {
            if (isPlayning == false)
            {
                upBurst.Play();
                upGlow.Play();
                downBurst.Play();
                downGlow.Play();

                isPlayning = true;
            }
        }
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
