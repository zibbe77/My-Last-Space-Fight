using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerGetResorsers : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        ShipInfo shipInfo = this.GetComponent<ShipInfo>();
        shipInfo.gas += 5;
        shipInfo.minerals += 50;

        Destroy(other.gameObject);
    }
}
