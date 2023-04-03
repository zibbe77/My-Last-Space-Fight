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
                GameObject g = Instantiate(ListOfAllTargets.pickUp) as GameObject;
                g.transform.position = this.gameObject.transform.position;

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

    public Enemyinfo()
    {
        Hp = 50;
        MaxHp = 50;

        Shield = 50;
        Maxshields = 50;
    }
}
