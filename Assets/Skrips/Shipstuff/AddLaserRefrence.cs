using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLaserRefrence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShipInfo shipInfo = this.GetComponentInParent<ShipInfo>();
        //gets laser refrens
        LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
        shipInfo.lineRendererToMakeLaser = lineRenderer;
    }
}
