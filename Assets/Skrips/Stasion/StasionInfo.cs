using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasionInfo : MonoBehaviour
{
    private void Start()
    {
        minerals = 150;
    }

    //resursers 
    public int minerals { get; set; }
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
