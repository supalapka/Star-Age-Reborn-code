using Assets.Scipts.Models.Miners;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool readyToShoot = true;
    bool isShooting = false;
    Transform target;
    public Transform Spaceship;
    int minerIndex = -1;

    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isShooting)
        {
            var spaceshipPosition = Spaceship.transform.position;
            lineRenderer.SetPosition(0, spaceshipPosition);

            var enemyPosition = target.position;
            lineRenderer.SetPosition(1, enemyPosition);
        }
    }


    IEnumerator OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Miner"))
        {
            if (readyToShoot)
            {
                if (minerIndex == -1)
                {
                    minerIndex = MinersOnMap.GetMinerId(other.transform.parent.name); //name: EnemyLVL1
                }
                readyToShoot = false;
                isShooting = true;
                target = other.transform;
                lineRenderer.gameObject.SetActive(true);

                yield return new WaitForSeconds(1.2f); //shooting for 1.2 sec
                string AttackerName = transform.parent.name;
                MinersOnMap.Damage(minerIndex, AttackerName, 29);

                lineRenderer.gameObject.SetActive(false);
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
            lineRenderer.gameObject.SetActive(false);
            minerIndex = -1;
            readyToShoot = true;
            isShooting = false;
        }
    }



}
