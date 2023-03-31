using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasionInfo : MonoBehaviour
{
    //resursers 
    public int minerals;
    public int gas;

    //ships
    private int shipPri;
    public int ship
    {
        get
        {
            ship = 4;
            return shipPri;
        }
        private set
        {
            shipPri = ListOfAllTargets.ShipList.Count;
        }
    }
}
