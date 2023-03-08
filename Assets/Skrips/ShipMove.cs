using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    Vector3 targetPositionG;
    Vector3 CurentPosition;
    Vector3 Position;
    Transform transform;
    [SerializeField] private float Speed = 5f;

    bool Test = false;


    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveShipStatic();
    }

    public void MoveShip(Vector3 targetPosition)
    {
        targetPosition = targetPositionG;
        Test = false;
    }

    public void MoveShipStatic()
    {
        if (Test)
        {
            CurentPosition = transform.position;

            if (CurentPosition.x > targetPositionG.x)
            {
                Position += new Vector3(Speed, 0, 0);
            }
            else if (CurentPosition.x < targetPositionG.x)
            {
                Position += new Vector3(-Speed, 0, 0);
            }

            if (CurentPosition.z > targetPositionG.z)
            {
                Position += new Vector3(0, 0, Speed);
            }
            else if (CurentPosition.z < targetPositionG.z)
            {
                Position += new Vector3(0, 0, -Speed);
            }

            transform.position += Position;
        }
    }
}
