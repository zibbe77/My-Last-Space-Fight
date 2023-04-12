using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelection : MonoBehaviour
{
    GameObject marker;
    GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        marker = ListOfAllTargets.marker;
        CreatMarker();
    }
    void Update()
    {
        SetMarker();
    }

    void CreatMarker()
    {
        g = Instantiate(marker) as GameObject;
        SetMarker();
    }

    void SetMarker()
    {
        g.transform.position = this.transform.position;
    }

    private void OnDestroy()
    {
        Destroy(g);
    }
}
