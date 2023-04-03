using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoOnStart : MonoBehaviour
{
    public GameObject shipPrefab;
    public GameObject EnemyPrefab;
    public GameObject Stasion;
    public GameObject pickUp;

    // Start is called before the first frame update
    void Start()
    {
        //creats enemys
        for (var i = 0; i < 5; i++)
        {
            GameObject g = Instantiate(EnemyPrefab) as GameObject;
            g.transform.position = new Vector3(i * 10, g.transform.position.y, g.transform.position.z + 15);

            ListOfAllTargets.TargetList.Add(g);
        }

        //Creats frendly ships
        for (var i = 0; i < 3; i++)
        {
            GameObject g = Instantiate(shipPrefab) as GameObject;
            g.transform.position = new Vector3(5 + i * 10, g.transform.position.y, g.transform.position.z);

            ListOfAllTargets.ShipList.Add(g);
        }

        //Creats a refrence to the the prefab.
        ListOfAllTargets.shipPrefab = shipPrefab;

        //creats a pickup prefab recrende 
        ListOfAllTargets.pickUp = pickUp;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
