using System.Threading.Tasks;

namespace Assets.Scipts.Models
{
    public abstract class Weapon
    {
        public string Name;
        public int DamageAmount;

        public float ShootingTime;
        public float ReloadTime;

        public bool IsReadyToShoot;
        public bool IsReloading;
        public bool IsShooting;



        public async Task Reload()
        {
            await Task.Delay((int)(ReloadTime * 1000));
            IsReadyToShoot = true;
            IsReloading = false; //reload ended;
        }

        public async Task Shooting()
        {
            await Task.Delay((int)(ShootingTime * 1000));
          //  IsReadyToShoot = true;
        }

    }
}
