using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyinfo : MonoBehaviour
{
    //ship stuff

    public int Hp
    {
        get
        {
            return Hp;
        }
        set
        {
            if (value <= 0)
            {
                Destroy(this);
            }
            else
            {
                Hp = value;
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
}
