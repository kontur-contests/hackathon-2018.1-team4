using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBgtiling : MonoBehaviour {

    public float verticalSpeed = 1f;
    public float horizontalSpeed = 1f;


    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update ()
    {
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", meshRenderer.sharedMaterial.GetTextureOffset("_MainTex") + new Vector2(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime));
    }
}
