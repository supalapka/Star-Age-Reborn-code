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
            dropItems.Add(GameInventoryItems.AllItems.Where(x => x.Name == "Small Solar Panel").SingleOrDefault());
        }
    }
}
