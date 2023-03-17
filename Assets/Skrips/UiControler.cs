using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiControler : MonoBehaviour
{
    //Menu 1 
    public GameObject menu1;
    public TextMeshProUGUI miniralsMenu1;
    public TextMeshProUGUI gasMenu1;

    //Menu 2
    public GameObject menu2;
    public TextMeshProUGUI miniralsMenu2;
    public TextMeshProUGUI gasMenu2;

    //Menu u
    public GameObject menu3;
    public TextMeshProUGUI miniralsMenu3;
    public TextMeshProUGUI gasMenu3;

    //integrated 
    private TextMeshProUGUI[] mineralsArray = new TextMeshProUGUI[3];
    private TextMeshProUGUI[] gasArray = new TextMeshProUGUI[3];

    //general
    public List<ShipInfo> Shiplist = new List<ShipInfo>();
    SelectionTracker selectionTracker;

    int shipCount;

    // Start is called before the first frame update
    void Start()
    {
        selectionTracker = GetComponent<SelectionTracker>();

        //making arrays of refrences 
        mineralsArray[0] = miniralsMenu1;
        mineralsArray[1] = miniralsMenu2;
        mineralsArray[2] = miniralsMenu3;

        gasArray[0] = gasMenu1;
        gasArray[1] = gasMenu1;
        gasArray[2] = gasMenu1;

    }

    // Update is called once per frame
    void Update()
    {
        ShipUi();
    }

    public void ShipUi()
    {
        Shiplist.Clear();
        shipCount = 0;

        foreach (KeyValuePair<int, GameObject> pair in selectionTracker.selectedTable)
        {
            if (pair.Value.gameObject.layer == 6)
            {
                Shiplist.Add(pair.Value.gameObject.GetComponent<ShipInfo>());
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
                menu1.SetActive(true);
                menu2.SetActive(true);

                menu3.SetActive(false);
                break;
            case 3:
                menu3.SetActive(true);
                menu1.SetActive(true);
                menu2.SetActive(true);
                break;
        }

        for (int i = 0; i < shipCount; i++)
        {
            mineralsArray[i].text = Shiplist[i].Minerals.ToString();
            gasArray[i].text = Shiplist[i].Gas.ToString();
        }
    }
}
