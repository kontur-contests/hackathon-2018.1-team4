using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeMinigameData {

    [MenuItem("Assets/Create/Minigame Data")]
    public static void CreateMyAsset()
    {
        ScriptableObjectUtility.CreateAsset<MinigameData>();
    }
}
