using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Experimental.VFX;

public class SmokeControler : MonoBehaviour
{
    Enemyinfo enemyinfo;
    public VisualEffect SmokePrefabe;

    // Start is called before the first frame update
    void Start()
    {
        enemyinfo = this.GetComponent<Enemyinfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyinfo.Hp <= 40)
        {
            SmokePrefabe.SetFloat("SpawnCountF", 0.3f);
        }
        else if (enemyinfo.Shield <= 30)
        {
            SmokePrefabe.SetFloat("SpawnCountF", 0.02f);
        }
    }
}


