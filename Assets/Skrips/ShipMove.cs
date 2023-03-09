using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipMove : MonoBehaviour
{
    Vector3 targetPositionG;
    Vector3 Position;
    Transform transform;

    NavMeshAgent agent;

    [SerializeField] private float Speed = 5f;

    bool Test = false;


    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
        agent = this.GetComponent<NavMeshAgent>();
        targetPositionG = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveShipStatic();
    }

    public void MoveShip(Vector3 targetPosition)
    {
        targetPositionG = targetPosition;
    }

    public void MoveShipStatic()
    {
        agent.SetDestination(targetPositionG);
    }
}
