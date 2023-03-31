using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoOnStartStasion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //adds Space stasion to list
        ListOfAllTargets.Stasion = this.gameObject;
    }
}
