using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruckt : MonoBehaviour
{
    public float timerSet;
    float timer;

    void Start()
    {
        timer = timerSet;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            if (this.gameObject.layer != 6)
            {
                //creats resoresers
                GameObject g = Instantiate(ListOfAllTargets.pickUp) as GameObject;
                g.transform.position = this.gameObject.transform.position;
            }

            Destroy(this.gameObject);
        }
        timer -= Time.deltaTime;
    }
}
