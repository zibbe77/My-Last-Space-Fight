using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInfo : MonoBehaviour
{
    //ship stuff
    public int Hp { get; set; }
    public int MaxHp { get; set; }

    private int pShield;
    public int Shield
    {
        get
        {
            return pShield;
        }
        set
        {
            if (value <= 0)
            {
                Hp = pShield - value;
            }
            else
            {
                pShield = value;
            }
        }
    }
    public int Maxshields { get; set; }

    public int dmg;

    //closest enemy
    public GameObject closestEnemy;

    //resursers 
    public int minerals;
    public int gas;

    public ShipInfo()
    {
        Hp = 100;
        MaxHp = 100;

        Shield = 50;
        Maxshields = 50;
    }
}
