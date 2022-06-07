using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Models.Weapons
{
    public class TestWeapon :Weapon
    {
        public TestWeapon()
        {
            Name = "TestWeapon";
            DamageAmount = 15;
            ShootingTime = 0.7f;
            ReloadTime = 1.1f;
        }
    }
}
