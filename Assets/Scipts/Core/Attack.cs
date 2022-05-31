using Assets.Scipts.Models;
using Assets.Scipts.Models.Miners;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public LineRenderer ShootingEffect;

    Transform target;// to get coordinates for draw shoot visual effect
    public Transform Spaceship; // to get coordinates for draw shoot visual effect
    int minerIndex = -1; //miner to attack

    private static Weapon weapon;

    void Start()
    {
        ShootingEffect.gameObject.SetActive(false);

        if (!Core.isInited)
            Core.Init();
        weapon = Core.spaceship.Weapon[0];
        weapon.IsShooting = false;
        weapon.IsReadyToShoot = true;
    }

    void Update()
    {
        if (weapon.IsShooting)
        {
            var spaceshipPosition = Spaceship.transform.position;
            ShootingEffect.SetPosition(0, spaceshipPosition);

            var enemyPosition = target.position;
            ShootingEffect.SetPosition(1, enemyPosition);
        }
    }


    async void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Miner"))
        {
            if (weapon.IsReadyToShoot)
            {
                weapon.IsReadyToShoot = false;
                weapon.IsShooting = true;


                string minerid = other.transform.parent.name;
                minerIndex = MinersOnMap.GetMinerIndex(minerid); //name: EnemyLVL1
                var saveMinerIndex = minerIndex;//save if allready shooted but core is out of attack range and miner index sets -1

                ShootingEffect.gameObject.SetActive(true);

                target = other.transform;

                await weapon.Shooting();//shooting delay for 1.2 sec

                string AttackerName = transform.parent.name; //if killed then add exp to attacker
                if (ShootingEffect.gameObject.activeSelf) //fix bug where damagind when attack ended
                    MinersOnMap.Damage(saveMinerIndex, AttackerName, weapon.DamageAmount);

                ShootingEffect.gameObject.SetActive(false);
                weapon.IsShooting = false;

                weapon.IsReloading = true;
                await weapon.Reload();
            }
        }
    }

    private async void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Miner"))
        {
            if (weapon.IsShooting)
            {
                ShootingEffect.gameObject.SetActive(false);
                weapon.IsReloading = true;
                await weapon.Reload();
                weapon.IsShooting = false;
            }
            else
            {
                ShootingEffect.gameObject.SetActive(false);
                if (!weapon.IsReloading) //if reloading then not ready to shoot
                    weapon.IsReadyToShoot = true;
                weapon.IsShooting = false;
            }

            minerIndex = -1;

        }
    }

}
