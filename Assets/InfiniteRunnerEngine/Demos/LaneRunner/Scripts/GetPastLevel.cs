using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;
using MoreMountains.Feedbacks;

public class GetPastLevel : MonoBehaviour
{
    // Start is called before the first frame update 

    public int TargetScore = 1000;
    //public GameObject LevelComplete;

    private void Update()
    {
        if (GameManager.Instance.Points < TargetScore) return;
       
        enabled = false;
        Debug.Log("Won");
        MMTimeManager.Instance.SetTimescaleTo(0);
        // LevelComplete.SetActive(true);
    }
}
