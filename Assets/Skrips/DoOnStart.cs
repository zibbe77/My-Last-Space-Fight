using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoOnStart : MonoBehaviour
{
    public GameObject shipPrefab;
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < 3; i++)
        {
            GameObject g = Instantiate(EnemyPrefab) as GameObject;
            g.transform.position = new Vector3(i * 10, g.transform.position.y, 10 + i * 10);

            ListOfAllTargets.TargetList.Add(g);
        }

        //Creats frendly ships
        for (var i = 0; i < 3; i++)
        {
            GameObject g = Instantiate(shipPrefab) as GameObject;
            g.transform.position = new Vector3(i * 10, g.transform.position.y, g.transform.position.z);

            ListOfAllTargets.ShipList.Add(g);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}