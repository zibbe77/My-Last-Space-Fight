using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInfo : MonoBehaviour
{
    //ship stuff
    private int pHp;
    public int Hp
    {
        get
        {
            return pHp;
        }
        set
        {
            if (value <= 0)
            {
                Destroy(this.gameObject);
                ListOfAllTargets.ShipList.Remove(this.gameObject);
            }
            else
            {
                pHp = value;
            }
        }
    }
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
            if (value <= 1)
            {
                pShield = 0;
                Hp = Hp + value;
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
