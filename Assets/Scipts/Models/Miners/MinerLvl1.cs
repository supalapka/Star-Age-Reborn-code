using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Models.Miners
{
    public class MinerLvl1 : Miner
    {
        public MinerLvl1(HealthBar healthBar)
        {
            MaxHealth = 75;
            SetMaxHealth(MaxHealth);
            HealthBar = healthBar;
            healthBar.SetMaxHealth(MaxHealth);
            MoveSpeed = 0.8f;
            DamageAmount = 70;
            Lvl = 1;
            Exp = Lvl * 10;

            dropItems.Add(GameInventoryItems.AllItems.Where(x => x.Name == "Small Solar Panel").SingleOrDefault());
        }
    }
}
