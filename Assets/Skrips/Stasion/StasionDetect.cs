using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StasionDetect : MonoBehaviour
{
    List<GameObject> shipListClose = new List<GameObject>();


    public void DoOnRepairClick()
    {
        CheckForShipInRange();
        foreach (GameObject ship in shipListClose)
        {
            ShipInfo shipInfo = ship.GetComponent<ShipInfo>();
            shipInfo.Hp = shipInfo.MaxHp;
            shipInfo.Shield = shipInfo.Maxshields;
        }
    }

    public void NoMoreShips()
    {
        if (ListOfAllTargets.ShipList.Count < 3)
        {
            CreatShip();
        }
    }
    public void CreatShip()
    {
        GameObject g = Instantiate(ListOfAllTargets.ShipPrefab) as GameObject;
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

        foreach (var item in shipListClose)
        {
            Debug.DrawLine(ListOfAllTargets.Stasion.transform.position, item.transform.position, Color.magenta);
        }
    }
}