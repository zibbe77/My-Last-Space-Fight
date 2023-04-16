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

    public Slider sliderHp1;
    public Slider slidershild1;

    //upgrades 
    public GameObject menu1slot1;
    public GameObject menu1slot2;
    public GameObject menu1slot3;


    //Menu 2
    public GameObject menu2;
    public TextMeshProUGUI miniralsMenu2;
    public TextMeshProUGUI gasMenu2;

    public Slider sliderHp2;
    public Slider slidershild2;

    //upgrades 
    public GameObject menu2slot1;
    public GameObject menu2slot2;
    public GameObject menu2slot3;

    //Menu 3
    public GameObject menu3;
    public TextMeshProUGUI miniralsMenu3;
    public TextMeshProUGUI gasMenu3;

    public Slider sliderHp3;
    public Slider slidershild3;

    //upgrades 
    public GameObject menu3slot1;
    public GameObject menu3slot2;
    public GameObject menu3slot3;

    //Stasion Menu
    public GameObject stasionMenu;

    //Stasion Menu Top
    public TextMeshProUGUI gasTop;
    public TextMeshProUGUI miniralsTop;
    public TextMeshProUGUI shipsTop;
    public GameObject toManyShips;

    //Arrays 
    private TextMeshProUGUI[] mineralsArray = new TextMeshProUGUI[3];
    private TextMeshProUGUI[] gasArray = new TextMeshProUGUI[3];
    private Slider[] SliderHpArray = new Slider[3];
    private Slider[] SliderShilidArray = new Slider[3];
    private GameObject[,] imageArray = new GameObject[3, 3];

    //general
    public List<ShipInfo> Shiplist = new List<ShipInfo>();
    SelectionTracker selectionTracker;

    int shipCount;

    //stasion 
    StasionInfo stasionInfo;
    public TextMeshProUGUI stasionCostMin1;
    public TextMeshProUGUI stasionCostGas1;

    public TextMeshProUGUI stasionCostMin2;
    public TextMeshProUGUI stasionCostGas2;
    public GameObject uppgradesUiObj;

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

        SliderHpArray[0] = sliderHp1;
        SliderHpArray[1] = sliderHp2;
        SliderHpArray[2] = sliderHp3;

        SliderShilidArray[0] = slidershild1;
        SliderShilidArray[1] = slidershild2;
        SliderShilidArray[2] = slidershild3;

        //stasion top ui 
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();

        //uppgrades
        imageArray[0, 0] = menu1slot1;
        imageArray[0, 1] = menu1slot2;
        imageArray[0, 2] = menu1slot3;

        imageArray[1, 0] = menu2slot1;
        imageArray[1, 1] = menu2slot2;
        imageArray[1, 2] = menu2slot3;

        imageArray[2, 0] = menu3slot1;
        imageArray[2, 1] = menu3slot2;
        imageArray[2, 2] = menu3slot3;

    }

    // Update is called once per frame
    void Update()
    {
        ShipUi();
        StasionUi();
        StasionUiTop();
        ToManyShipsM();
        SetStasionNubersRed();
    }

    public void ShipUi()
    {
        try
        {
            Shiplist.Clear();
            shipCount = 0;

            foreach (KeyValuePair<int, GameObject> pair in selectionTracker.selectedTable)
            {
                if (pair.Value.gameObject != null)
                {
                    if (pair.Value.gameObject.layer == 6)
                    {
                        Shiplist.Add(pair.Value.gameObject.GetComponent<ShipInfo>());
                        shipCount++;
                    }
                }
                else
                {
                    selectionTracker.selectedTable.Remove(pair.Key);
                }
            }

            switch (shipCount)
            {
                case 0:
                    menu1.SetActive(false);
                    menu2.SetActive(false);
                    menu3.SetActive(false);
                    uppgradesUiObj.SetActive(false);
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
                //resursers
                mineralsArray[i].text = Shiplist[i].minerals.ToString();
                gasArray[i].text = Shiplist[i].gas.ToString();

                //Hp and shilds
                SliderHpArray[i].maxValue = Shiplist[i].MaxHp;
                SliderHpArray[i].value = Shiplist[i].Hp;

                SliderShilidArray[i].maxValue = Shiplist[i].Maxshields;
                SliderShilidArray[i].value = Shiplist[i].Shield;
            }

            for (var i = 0; i < shipCount; i++)
            {
                for (int ii = 0; ii < Shiplist[i].uppgradeList.Length; ii++)
                {
                    if (Shiplist[i].uppgradeList[ii] == true)
                    {
                        imageArray[i, ii].SetActive(true);
                    }
                    else
                    {
                        imageArray[i, ii].SetActive(false);
                    }
                }
            }
        }
        catch { }
    }
    public void StasionUi()
    {
        bool stasionIsSelected = false;

        foreach (KeyValuePair<int, GameObject> pair in selectionTracker.selectedTable)
        {
            if (pair.Value.gameObject != null)
            {
                if (pair.Value.gameObject.layer == 10)
                {
                    stasionIsSelected = true;
                }
            }
            else
            {
                selectionTracker.selectedTable.Remove(pair.Key);
            }
        }

        stasionMenu.SetActive(stasionIsSelected);
    }
    private void SetStasionNubersRed()
    {

        //Repair
        if (stasionInfo.minerals < 100)
        {
            stasionCostMin1.color = Color.red;
        }
        else
        {
            stasionCostMin1.color = Color.black;
        }


        if (stasionInfo.gas < 10)
        {
            stasionCostGas1.color = Color.red;
        }
        else
        {
            stasionCostGas1.color = Color.black;
        }

        //Creat ship
        if (stasionInfo.minerals < 200)
        {
            stasionCostMin2.color = Color.red;
        }
        else
        {
            stasionCostMin2.color = Color.black;
        }

        if (stasionInfo.gas < 20)
        {
            stasionCostGas2.color = Color.red;
        }
        else
        {
            stasionCostGas2.color = Color.black;
        }
    }
    public void StasionUiTop()
    {
        //print(stasionInfo.minerals);
        gasTop.text = stasionInfo.gas.ToString();
        miniralsTop.text = stasionInfo.minerals.ToString();
        shipsTop.text = stasionInfo.ship.ToString();
    }
    public void ToManyShipsM()
    {
        if (ListOfAllTargets.ShipList.Count < 3)
        {
            toManyShips.SetActive(false);
        }
        else
        {
            toManyShips.SetActive(true);
        }
    }
}
