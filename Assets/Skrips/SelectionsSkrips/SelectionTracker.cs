using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTracker : MonoBehaviour
{
    //hold all the selected Objects 
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();
    public void SelectedThing(GameObject thing, bool shift)
    {
        if (!(thing.layer == 8))
        {
            if (!(thing.layer == 9))
            {
                int id = thing.GetInstanceID();
                if (!(selectedTable.ContainsKey(id)))
                {
                    selectedTable.Add(id, thing);
                    thing.AddComponent<OnSelection>();
                }
                else if (shift == true)
                {
                    DeSelectedThing(id);
                }
            }
        }
    }
    public void DeSelectedThing(int id)
    {
        Destroy(selectedTable[id].GetComponent<OnSelection>());
        selectedTable.Remove(id);
    }

    public void DeSelectedAllThings()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                Destroy(selectedTable[pair.Key].GetComponent<OnSelection>());
            }
        }
        selectedTable.Clear();
    }
}
