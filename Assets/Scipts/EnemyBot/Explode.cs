using Assets.Scipts;
using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject Miner;
    public GameObject Explosion;


    IEnumerator OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) //if miner are in player 
        {
            Explosion.transform.position = Miner.transform.position;
            Explosion.gameObject.SetActive(true);

            Debug.Log("wait (0.4 second");
            yield return new WaitForSeconds(0.4f); //explosing
            Debug.Log("time had pass (0.4 second...");

            Miner.gameObject.SetActive(false);
            PlayersOnMap.DamagePlayer(other.name, 110);
            Debug.Log("wait 0.6 second");
            yield return new WaitForSeconds(0.6f); //explosing
            Debug.Log("time had pass 0.6 second...");

            Explosion.gameObject.SetActive(false);

            Debug.Log("wait 3 second");
            yield return new WaitForSeconds(3f); //explosing
            Debug.Log("time had pass 3 second...");

        }
    }




}
