using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyinfo : MonoBehaviour
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
                //creat explosion
                GameObject e = Instantiate(ListOfAllTargets.explosionprefab) as GameObject;
                e.transform.position = this.gameObject.transform.position;

                //destroys it self
                Destroy(this.gameObject);
                ListOfAllTargets.TargetList.Remove(this.gameObject);
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

    //timers
    //Ship atack timer
    public float timeBase = 1;
    public float timeSet = 1;

    //ship laser timer
    public float LaserTimeBase = 0.4f;
    public float LaserTimeSet = 0.4f;

    //laser
    public LineRenderer lineRendererToMakeLaser;
    public Transform transformFirePoint;

    //turet
    public GameObject gun;

    public Enemyinfo()
    {
        Hp = 50;
        MaxHp = 50;

        Shield = 50;
        Maxshields = 50;
    }
}
