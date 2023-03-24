using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ship in ListOfAllTargets.ShipList)
        {
            var nerestDistance = float.MaxValue;
            GameObject nerestObj = null;

            foreach (GameObject target in ListOfAllTargets.TargetList)
            {
                if (Vector3.Distance(ship.transform.position, target.transform.position) < nerestDistance)
                {
                    nerestDistance = Vector3.Distance(ship.transform.position, target.transform.position);
                    nerestObj = target;
                }
            }

            // Do after finding closest 
            Debug.DrawLine(ship.transform.position, nerestObj.transform.position, Color.red);

        }
    }
}
