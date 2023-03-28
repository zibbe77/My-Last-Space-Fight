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


    //Menu 2
    public GameObject menu2;
    public TextMeshProUGUI miniralsMenu2;
    public TextMeshProUGUI gasMenu2;

    public Slider sliderHp2;
    public Slider slidershild2;

    //Menu 3
    public GameObject menu3;
    public TextMeshProUGUI miniralsMenu3;
    public TextMeshProUGUI gasMenu3;

    public Slider sliderHp3;
    public Slider slidershild3;


    //Arrays 
    private TextMeshProUGUI[] mineralsArray = new TextMeshProUGUI[3];
    private TextMeshProUGUI[] gasArray = new TextMeshProUGUI[3];
    private Slider[] SliderHpArray = new Slider[3];
    private Slider[] SliderShilidArray = new Slider[3];

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

        SliderHpArray[0] = sliderHp1;
        SliderHpArray[1] = sliderHp2;
        SliderHpArray[2] = sliderHp3;

        SliderShilidArray[0] = slidershild1;
        SliderShilidArray[1] = slidershild2;
        SliderShilidArray[2] = slidershild3;
    }

    // Update is called once per frame
    void Update()
    {
        ShipUi();
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
        }
        catch { }
    }
}
