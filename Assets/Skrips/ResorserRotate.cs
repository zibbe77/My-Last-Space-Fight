using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResorserRotate : MonoBehaviour
{
    Transform transform;
    void Start()
    {
        transform = this.gameObject.transform;
        transform.eulerAngles += new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(20 * Time.deltaTime, 20 * Time.deltaTime, 10 * Time.deltaTime);
    }
}
