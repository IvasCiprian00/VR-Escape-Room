using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<GameObject> targetList = new List<GameObject>();
    public int index;
    public GameObject paperClue;

    public void Start()
    {
        foreach (GameObject target in targetList) {
            target.SetActive(false);
        }
        index = -1;
        StartNextTarget();
    }

    public void StartNextTarget()
    {
        index++;

        if(index >= targetList.Count)
        {
            paperClue.SetActive(true);
            return;
        }

        targetList[index].SetActive(true);
    }
}
