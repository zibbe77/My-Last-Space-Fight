using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWorldUi : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        this.transform.position = gameObject.transform.position;
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
