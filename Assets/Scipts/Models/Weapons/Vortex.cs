using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Models.Weapons
{
    public class Vortex : Weapon
    {
        public Vortex()
        {
            Name = "Vortex";
            DamageAmount = 30;
            ShootingTime = 1.2f;
            ReloadTime = 2.5f;
        }
    }
}
