using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerGetResorsers : MonoBehaviour
{
    SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        print("w");
    }
}
