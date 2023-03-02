using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    Vector3 targetPosition;
    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveShip(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
}
