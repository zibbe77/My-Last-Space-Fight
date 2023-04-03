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

    //all
    public SelectionTracker selectionTracker;
    public GameObject uppgradesUiObj;
    bool active = false;
    GameObject ship;

    [SerializeField] private int uppValue;

    public void OnFirstUppgrade()
    {
        RectTransform rectTransform = uppgradesUiObj.GetComponent<RectTransform>();
        rectTransform.position = new Vector3(rectTransform.position.x, uppValue, 0);

        //Changes numbers
        uppgradeNumber.text = "1";
        gasValue.text = "5";
        mineralValue.text = "50";

        //uppgrade Ship
        ship = CheckShip();
        UppgradeShip(ship);

        //set active
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

        //set active
        active = !active;
        uppgradesUiObj.SetActive(active);
    }

    private GameObject CheckShip()
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

        return ships[ships.Count - 1];
    }
    private void UppgradeShip(GameObject s)
    {
        ShipInfo shipInfo = s.GetComponent<ShipInfo>();
        shipInfo.MaxHp += 25;
        shipInfo.Maxshields += 25;
    }
}
