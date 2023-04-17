using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    //obejcts
    float enemyAtackRaidus = 10;
    float stasionRaidus = 5;

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

                        Enemyinfo enemyinfo = nerestObj.GetComponent<Enemyinfo>();
                        if (enemyinfo.LaserTimeSet < 0)
                        {
                            enemyinfo.lineRendererToMakeLaser.enabled = false;
                        }
                    }
                }

                //gun look at enemy
                ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
                shipInfo.gun.transform.LookAt(nerestObj.transform);



                //checks if its an emeny
                if (nerestObj.layer == 9)
                {
                    // Do after finding closest 
                    if (nerestDistance < enemyAtackRaidus)
                    {
                        //gun look at enemy
                        Enemyinfo enemyinfo = nerestObj.GetComponent<Enemyinfo>();
                        enemyinfo.gun.transform.LookAt(ship.transform);
                        enemyinfo.gun.transform.eulerAngles += new Vector3(-90, 0, 0);

                        //atack logic prep
                        AttackShip(ship, nerestObj);
                        enemyAtack(ship, nerestObj);
                    }
                    else
                    {
                        uppdateLaserShip(ship);
                        uppdateLaserEnemy(nerestObj);
                    }
                }

            }
        }
        catch { }
    }

    private void AttackShip(GameObject ship, GameObject nerestObj)
    {
        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
        Enemyinfo enemyinfo = nerestObj.GetComponent<Enemyinfo>();

        if (shipInfo.timeSet < 0)
        {
            //Ship attack enemy
            enemyinfo.Shield = enemyinfo.Shield - shipInfo.dmg;

            shipInfo.lineRendererToMakeLaser.enabled = true;

            //timer
            shipInfo.timeSet = shipInfo.timeBase;
            shipInfo.LaserTimeSet = shipInfo.LaserTimeBase;

            print("ship");
        }
        if (shipInfo.LaserTimeSet < 0)
        {
            shipInfo.lineRendererToMakeLaser.enabled = false;
        }

        //change time valuse
        shipInfo.timeSet -= Time.deltaTime;
        shipInfo.LaserTimeSet -= Time.deltaTime;

        //set laser pos
        Vector3[] linePos = new Vector3[2];
        linePos[0] = shipInfo.transformFirePoint.position;
        linePos[1] = nerestObj.transform.position;
        shipInfo.lineRendererToMakeLaser.SetPositions(linePos);


    }
    private void enemyAtack(GameObject ship, GameObject nerestObj)
    {
        //Enemy attack Ship
        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
        Enemyinfo enemyinfo = nerestObj.GetComponent<Enemyinfo>();

        if (enemyinfo.timeSet < 0)
        {
            //Enemy attack Ship
            shipInfo.Shield = shipInfo.Shield - enemyinfo.dmg;


            enemyinfo.lineRendererToMakeLaser.enabled = true;

            //timer
            enemyinfo.timeSet = enemyinfo.timeBase;
            enemyinfo.LaserTimeSet = enemyinfo.LaserTimeBase;

            print("enemy");
        }
        if (enemyinfo.LaserTimeSet < 0)
        {
            enemyinfo.lineRendererToMakeLaser.enabled = false;
        }

        //change time valuse
        enemyinfo.timeSet -= Time.deltaTime;
        enemyinfo.LaserTimeSet -= Time.deltaTime;

        //set laser pos
        Vector3[] linePosEnemy = new Vector3[2];
        linePosEnemy[0] = enemyinfo.transformFirePoint.position;
        linePosEnemy[1] = ship.transform.position;
        enemyinfo.lineRendererToMakeLaser.SetPositions(linePosEnemy);
    }
    private void uppdateLaserShip(GameObject ship)
    {
        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
        shipInfo.lineRendererToMakeLaser.enabled = false;
    }
    private void uppdateLaserEnemy(GameObject nerestObj)
    {
        Enemyinfo enemyinfo = nerestObj.GetComponent<Enemyinfo>();
        enemyinfo.lineRendererToMakeLaser.enabled = false;
    }
}
