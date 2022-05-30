using Assets.Scipts.Models.Miners;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LineRenderer ShootingEffect;

    Transform target;// to get coordinates for draw shoot visual effect
    public Transform Spaceship; // to get coordinates for draw shoot visual effect
    int minerIndex = -1; //miner to attack

    public static bool readyToShoot = true;
    public static bool isShooting = false;

    void Start()
    {
        ShootingEffect.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isShooting)
        {
            var spaceshipPosition = Spaceship.transform.position;
            ShootingEffect.SetPosition(0, spaceshipPosition);

            var enemyPosition = target.position;
            ShootingEffect.SetPosition(1, enemyPosition);
        }
    }


    IEnumerator OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Miner"))
        {
            if (readyToShoot)
            {

                minerIndex = MinersOnMap.GetMinerId(other.transform.parent.name); //name: EnemyLVL1
                var saveMinerIndex = minerIndex;//save if allready shooted but core is out of attack range and miner index sets -1

                readyToShoot = false;
                isShooting = true;
                target = other.transform;
                ShootingEffect.gameObject.SetActive(true);

                yield return new WaitForSeconds(1.2f); //shooting for 1.2 sec
                string AttackerName = transform.parent.name;
                MinersOnMap.Damage(saveMinerIndex, AttackerName, 13);

                ShootingEffect.gameObject.SetActive(false);
                isShooting = false;

                yield return new WaitForSeconds(2.1f); //reload
                readyToShoot = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Miner"))
        {
            ShootingEffect.gameObject.SetActive(false);
            minerIndex = -1;
            readyToShoot = true;
            isShooting = false;
        }
    }

}
