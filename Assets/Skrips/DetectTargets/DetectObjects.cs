using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    //obejcts
    float enemyAtackRaidus = 10;

    //finding targets  
    void Update()
    {
        try
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
                if (nerestDistance < enemyAtackRaidus)
                {
                    //debug
                    Debug.DrawLine(ship.transform.position, nerestObj.transform.position, Color.red);

                    //atack logic prep

                    AttackShip(ship, nerestObj);
                }
            }
        }
        catch { }
    }

    private void AttackShip(GameObject ship, GameObject nerestObj)
    {
        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
        Enemyinfo enemyinfo = nerestObj.GetComponent<Enemyinfo>();

        //Ship attack enemy
        enemyinfo.Shield = enemyinfo.Shield - shipInfo.dmg;

        //Enemy attack Ship
        shipInfo.Shield = shipInfo.Shield - enemyinfo.dmg;
    }
}
