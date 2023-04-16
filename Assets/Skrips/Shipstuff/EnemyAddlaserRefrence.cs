using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAddlaserRefrence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enemyinfo enemyinfo = this.GetComponentInParent<Enemyinfo>();
        //gets laser refrens
        LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
        enemyinfo.lineRendererToMakeLaser = lineRenderer;
    }
}
