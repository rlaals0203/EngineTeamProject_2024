using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshCollider : MonoBehaviour
{
    private void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] meshToCombine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            meshToCombine[i].mesh = meshFilters[i].sharedMesh;
            meshToCombine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.GetComponent<MeshCollider>().enabled = false;
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(meshToCombine);
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = combinedMesh;

        gameObject.SetActive(true);
    }
}