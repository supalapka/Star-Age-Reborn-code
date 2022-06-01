using Assets.Scipts.Planets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    private float speed;
    [SerializeField] Transform Sun;
    void Start()
    {
        if (!PlanetsFuncLib.IsInited)
            PlanetsFuncLib.Init();

        speed = PlanetsFuncLib.GetPlanetSpeed(transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Sun.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
    }
}
