using UnityEngine;
using System.Collections;

public class MeshOrderRendering : MonoBehaviour {

    public string layerName;
    public int sortinOrder;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = layerName;
        meshRenderer.sortingOrder = sortinOrder;

    }

    void Update()
    {
        meshRenderer.sortingLayerName = layerName;
        meshRenderer.sortingOrder = sortinOrder;
    }
}