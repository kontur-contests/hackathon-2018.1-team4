using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinigamesManager : MonoBehaviour {

    public MinigameData[] miniGames;
    public Transform activitiesContaier;
    public int maxActivePoints = 2;
    public float maxActiveTime = 20f;

    private void Start()
    {
        StartCoroutine(ActiveatePointsCourutine());
    }

    IEnumerator ActiveatePointsCourutine()
    {
        while(true)
        {
            DisableAllPoints();
            UpdateActivePoints();
            yield return new WaitForSeconds(maxActiveTime);
        }
    }

    private void DisableAllPoints()
    {
        ActivityController[] activitiesControllers = activitiesContaier.GetComponentsInChildren<ActivityController>();

        foreach(ActivityController activityController in activitiesControllers)
        {
            activityController.DisableActivity();
        }
    }

    private void UpdateActivePoints()
    {
        List<int> indexes = new List<int>();

        for(int i = 0; i < maxActivePoints; i++)
        {
            int index = Random.Range(0, activitiesContaier.childCount);

            while(indexes.Contains(index))
            {
                index = Random.Range(0, activitiesContaier.childCount);
            }

            indexes.Add(index);
            activitiesContaier.GetChild(index).GetComponent<ActivityController>().ActivateActivity(miniGames[Random.Range(0, miniGames.Length)]);
        }
    }

}
