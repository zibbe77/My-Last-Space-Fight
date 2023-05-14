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
                GameObject e = Instantiate(ListOfAllTargets.explosionprefab) as GameObject;
                e.transform.position = this.gameObject.transform.position;
                e.layer = 6;

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

    //Ship atack timer
    public float timeBase = 1;
    public float timeSet = 1;

    //ship laser timer
    public float LaserTimeBase = 0.4f;
    public float LaserTimeSet = 0.4f;

    //laser
    public LineRenderer lineRendererToMakeLaser;
    public Transform transformFirePoint;

    //uppgrades
    public bool[] uppgradeList = { false, false, false };

    //turet
    public GameObject gun;
    public ShipInfo()
    {
        Hp = 100;
        MaxHp = 100;

        Shield = 50;
        Maxshields = 50;
    }

    //Distesnce symbel
    public GameObject distenstSymbel;
}
