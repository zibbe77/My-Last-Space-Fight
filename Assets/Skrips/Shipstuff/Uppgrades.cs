using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Uppgrades : MonoBehaviour
{
    public TextMeshProUGUI uppgradeNumber;
    public TextMeshProUGUI gasValue;
    public TextMeshProUGUI mineralValue;

    public static int gasValueInt;
    public static int mineralValueint;

    //all
    public SelectionTracker selectionTracker;
    public GameObject uppgradesUiObj;
    bool active = false;
    GameObject ship;
    private StasionInfo stasionInfo;

    [SerializeField] private int uppValue;
    [SerializeField] private int shipValue;
    static private int internalShipValue;
    static private int uppgradeSlot;

    //
    static private int activeIntOverrite;
    public int activeIntOverriteCeack;

    static private int activeIntOverrite2;

    public void OnFirstUppgrade()
    {
        RectTransform rectTransform = uppgradesUiObj.GetComponent<RectTransform>();
        rectTransform.position = new Vector3(rectTransform.position.x, uppValue, 0);

        //Changes numbers
        uppgradeNumber.text = "1";
        gasValue.text = "5";
        mineralValue.text = "50";

        internalShipValue = shipValue;
        uppgradeSlot = 0;

        gasValueInt = 5;
        mineralValueint = 50;

        CheckCost();

        //set active

        active = uppgradesUiObj.active;
        active = !active;

        if (activeIntOverrite != activeIntOverriteCeack)
        {
            active = true;
        }
        if (activeIntOverrite2 != 0)
        {
            active = true;
        }

        activeIntOverrite2 = 0;
        activeIntOverrite = activeIntOverriteCeack;

        uppgradesUiObj.SetActive(active);
    }

    public void OnSecondUppgrade()
    {
        RectTransform rectTransform = uppgradesUiObj.GetComponent<RectTransform>();
        rectTransform.position = new Vector3(rectTransform.position.x, uppValue, 0);

        //Changes numbers
        uppgradeNumber.text = "2";
        gasValue.text = "10";
        mineralValue.text = "100";

        internalShipValue = shipValue;
        uppgradeSlot = 1;

        gasValueInt = 10;
        mineralValueint = 100;

        CheckCost();

        //set active
        active = !active;

        if (activeIntOverrite != activeIntOverriteCeack)
        {
            active = true;
        }
        if (activeIntOverrite2 != 1)
        {
            active = true;
        }

        activeIntOverrite2 = 1;
        activeIntOverrite = activeIntOverriteCeack;

        uppgradesUiObj.SetActive(active);
    }

    public void OnThirdUppgrade()
    {
        RectTransform rectTransform = uppgradesUiObj.GetComponent<RectTransform>();
        rectTransform.position = new Vector3(rectTransform.position.x, uppValue, 0);

        //Changes numbers
        uppgradeNumber.text = "3";
        gasValue.text = "15";
        mineralValue.text = "150";

        internalShipValue = shipValue;
        uppgradeSlot = 2;

        gasValueInt = 15;
        mineralValueint = 150;

        CheckCost();

        //set active
        active = !active;

        if (activeIntOverrite != activeIntOverriteCeack)
        {
            active = true;
        }
        if (activeIntOverrite2 != 2)
        {
            active = true;
        }

        activeIntOverrite2 = 2;
        activeIntOverrite = activeIntOverriteCeack;

        uppgradesUiObj.SetActive(active);
    }

    public void OnBuy()
    {
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();

        //uppgrade Ship
        ship = CheckShip(internalShipValue);

        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();

        if (shipInfo.uppgradeList[uppgradeSlot] == false)
        {
            if (stasionInfo.gas >= gasValueInt && stasionInfo.minerals >= mineralValueint)
            {
                stasionInfo.gas -= gasValueInt;
                stasionInfo.minerals -= mineralValueint;

                UppgradeShip(ship);
                shipInfo.uppgradeList[uppgradeSlot] = true;
            }
        }
    }

    private GameObject CheckShip(int shipValueloc)
    {
        List<GameObject> ships = new List<GameObject>();

        foreach (KeyValuePair<int, GameObject> pair in selectionTracker.selectedTable)
        {
            if (pair.Value.gameObject != null)
            {
                if (pair.Value.gameObject.layer == 6)
                {
                    ships.Add(pair.Value.gameObject);
                }
            }
        }

        return ships[shipValueloc];
    }
    private void UppgradeShip(GameObject s)
    {
        ShipInfo shipInfo = s.GetComponent<ShipInfo>();
        shipInfo.MaxHp += 25;
        shipInfo.Maxshields += 25;
    }

    private void CheckCost()
    {
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();

        if (stasionInfo.gas >= gasValueInt)
        {
            gasValue.color = Color.black;
        }
        else
        {
            gasValue.color = Color.red;
        }

        if (stasionInfo.minerals >= mineralValueint)
        {
            mineralValue.color = Color.black;
        }
        else
        {
            mineralValue.color = Color.red;
        }
    }
}
