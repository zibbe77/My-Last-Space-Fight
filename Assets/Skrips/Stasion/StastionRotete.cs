using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StastionRotete : MonoBehaviour
{
    Transform transform;
    void Start()
    {
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0, 10 * Time.deltaTime);
    }
}
