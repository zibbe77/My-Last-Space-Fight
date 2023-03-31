using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StasionDetect : MonoBehaviour
{
    List<GameObject> shipListClose = new List<GameObject>();
    StasionInfo stasionInfo;

    private void Start()
    {
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();

    }

    private void Update()
    {
        CheckForShipInRange();
        foreach (GameObject ship in shipListClose)
        {
            ShipInfo shipInfo = ship.GetComponent<ShipInfo>();

            stasionInfo.gas += shipInfo.gas;
            shipInfo.gas = 0;

            stasionInfo.minerals += shipInfo.minerals;
            shipInfo.minerals = 0;
        }
    }

    public void DoOnRepairClick()
    {
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();
        print(stasionInfo.gas);
        print(stasionInfo.minerals);

        if (stasionInfo.gas > 10 && stasionInfo.minerals > 100)
        {
            stasionInfo.gas -= 10;
            stasionInfo.minerals -= 100;

            CheckForShipInRange();
            foreach (GameObject ship in shipListClose)
            {
                ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
                shipInfo.Hp = shipInfo.MaxHp;
                shipInfo.Shield = shipInfo.Maxshields;
            }
        }
    }

    public void NoMoreShips()
    {
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();
        if (ListOfAllTargets.ShipList.Count < 3)
        {
            if (stasionInfo.gas > 20 && stasionInfo.minerals > 200)
            {
                stasionInfo.gas -= 20;
                stasionInfo.minerals -= 200;

                CreatShip();
            }
        }
    }
    public void CreatShip()
    {
        GameObject g = Instantiate(ListOfAllTargets.shipPrefab) as GameObject;
        g.transform.position = new Vector3(3, g.transform.position.y, g.transform.position.z);
        ListOfAllTargets.ShipList.Add(g);
    }

    private void CheckForShipInRange()
    {
        shipListClose.Clear();

        try
        {
            foreach (GameObject ship in ListOfAllTargets.ShipList)
            {
                if (Vector3.Distance(ListOfAllTargets.Stasion.transform.position, ship.transform.position) < 5)
                {
                    shipListClose.Add(ship);
                }
            }
        }
        catch { }

        //DEBUG
        foreach (var item in shipListClose)
        {
            Debug.DrawLine(ListOfAllTargets.Stasion.transform.position, item.transform.position, Color.magenta);
        }
    }
}
