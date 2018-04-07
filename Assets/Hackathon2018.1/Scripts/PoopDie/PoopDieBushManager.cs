using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopDieBushManager : MonoBehaviour
{
    private int totlaBushCount = 0;

    public void AddBush()
    {
        totlaBushCount++;
    }

    public void RemoveBush()
    {
        totlaBushCount--;

        if (totlaBushCount <= 0)
            MinigameController.instance.GameComplete();
    }
}
