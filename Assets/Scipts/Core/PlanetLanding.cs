using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLanding : MonoBehaviour
{
    public static bool IsMovesToLanding = false;
    public static string PlanetName;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            IsMovesToLanding = true;
            PlanetName = other.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            IsMovesToLanding = false;
            PlanetName = null;
        }
    }
}
