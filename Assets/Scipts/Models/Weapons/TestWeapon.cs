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
            DamageAmount = 40;
            ShootingTime = 2f;
            ReloadTime = 5f;
        }
    }
}
