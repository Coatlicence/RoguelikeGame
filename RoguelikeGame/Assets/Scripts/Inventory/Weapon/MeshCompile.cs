using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshCompile : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combines = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combines[i].mesh = meshFilters[i].sharedMesh;
            combines[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
        MeshFilter meshFilter = transform.GetComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combines);
        GetComponent<MeshCollider>().sharedMesh = meshFilter.mesh;
        transform.gameObject.SetActive(true);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        GenerateWeapon(new Vector3(0,9,0));
    //    }
    //}



}
