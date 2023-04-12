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

    public int gasValueInt;
    public int mineralValueint;

    //all
    public SelectionTracker selectionTracker;
    public GameObject uppgradesUiObj;
    bool active = false;
    GameObject ship;
    public StasionInfo stasionInfo;

    [SerializeField] private int uppValue;
    [SerializeField] private int shipValue;
    static private int internalShipValue;
    static private int uppgradeSlot;

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

        //set active

        active = uppgradesUiObj.active;
        active = !active;
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

        //set active
        active = !active;
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
        //set active
        active = !active;
        uppgradesUiObj.SetActive(active);
    }

    public void OnBuy()
    {
        //uppgrade Ship
        ship = CheckShip(internalShipValue);

        ShipInfo shipInfo = ship.GetComponent<ShipInfo>();

        if (shipInfo.uppgradeList[uppgradeSlot] == false)
        {
            if (stasionInfo.gas > gasValueInt && stasionInfo.minerals > mineralValueint)
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
}
