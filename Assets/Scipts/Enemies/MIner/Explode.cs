using Assets.Scipts;
using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public UnityEngine.GameObject Miner;
    public UnityEngine.GameObject Explosion;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //if miner are in player 
        {
            Explosion.transform.position = Miner.transform.position;
            Explosion.gameObject.SetActive(true);
            //   yield return new WaitForSeconds(0.45f); //explosing
            Invoke("MinerOff", .45f);  // destroy miner after 0.4 sec after explosion
            PlayersOnMap.DamagePlayer(other.name, 110);

            Invoke("ExplosionOff", .6f);  //destroy explosion after its done
        }
    }

    private void MinerOff()
    {
        Miner.gameObject.SetActive(false);

    }

    private void ExplosionOff()
    {
        Explosion.gameObject.SetActive(false);
    }




}
