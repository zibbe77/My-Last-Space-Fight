using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControler : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    SelectionTracker selectionTracker;

    int shipCount;

    // Start is called before the first frame update
    void Start()
    {
        selectionTracker = GetComponent<SelectionTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        ShipUi();
    }

    public void ShipUi()
    {
        shipCount = 0;

        foreach (KeyValuePair<int, GameObject> pair in selectionTracker.selectedTable)
        {
            if (pair.Value.gameObject.layer == 6)
            {
                shipCount++;
            }
        }

        switch (shipCount)
        {
            case 0:
                menu1.SetActive(false);
                menu2.SetActive(false);
                menu3.SetActive(false);
                break;
            case 1:
                menu1.SetActive(true);

                menu2.SetActive(false);
                menu3.SetActive(false);
                break;
            case 2:
                menu2.SetActive(true);

                menu1.SetActive(false);
                menu3.SetActive(false);
                break;
            case 3:
                menu3.SetActive(true);

                menu1.SetActive(false);
                menu2.SetActive(false);
                break;
        }
    }
}
