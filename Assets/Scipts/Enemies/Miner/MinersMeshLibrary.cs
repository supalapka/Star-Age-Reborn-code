using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinersMeshLibrary : MonoBehaviour
{
    [SerializeField]
    List<MeshFilter> _Meshes = new List<MeshFilter>();
    public static List<MeshFilter> Meshes = new List<MeshFilter>();
    void Awake()
    {
        Meshes = _Meshes;
    }

    public static Mesh GetMeshByLvl(int lvl)
    {
        return Meshes[lvl - 1].mesh;
    }


}

