using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinOrLose : MonoBehaviour
{
    StasionInfo stasionInfo;
    void Update()
    {
        stasionInfo = ListOfAllTargets.Stasion.GetComponent<StasionInfo>();

        if (ListOfAllTargets.TargetList.Count == 0)
        {
            TestClearStuff();
            SceneManager.LoadScene(4);
        }
        if (ListOfAllTargets.ShipList.Count == 0 && stasionInfo.gas < 10)
        {
            TestClearStuff();
            SceneManager.LoadScene(3);
        }
    }

    private void TestClearStuff()
    {
        ListOfAllTargets.ShipList.Clear();
        ListOfAllTargets.TargetList.Clear();
        ListOfAllTargets.Stasion = null;
    }
}
