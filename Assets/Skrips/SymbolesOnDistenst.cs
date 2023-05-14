using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolesOnDistenst : MonoBehaviour
{
    public float distance = 20;

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ship in ListOfAllTargets.ShipList)
        {
            ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
            if (Vector3.Distance(Camera.main.transform.position, ship.transform.position) < distance)
            {
                Debug.DrawLine(Camera.main.transform.position, ship.transform.position);

                shipInfo.distenstSymbel.active = false;
            }
            else
            {
                shipInfo.distenstSymbel.active = true;
            }
        }
    }
}
