using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipsMeshesList : MonoBehaviour
{
    [SerializeField] List<GameObject> spaceshipsList;
    public static List<GameObject> Spaceships = new List<GameObject>();
    void Awake()
    {
        foreach (var spaceship in spaceshipsList)
        {
            Spaceships.Add(spaceship);
        }
    }

    public static GameObject GetSpaceshipByName(string name)
    {
        return Spaceships.Find(x => x.name == name);
    }


}
