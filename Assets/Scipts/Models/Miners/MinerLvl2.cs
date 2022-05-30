using System.Linq;

namespace Assets.Scipts.Models.Miners
{
    public class MinerLvl2 : Miner
    {
        public MinerLvl2(HealthBar healthBar)
        {
            MaxHealth = 110;
            SetMaxHealth(MaxHealth);
            HealthBar = healthBar;
            healthBar.SetMaxHealth(MaxHealth);
            MoveSpeed = 1f;
            DamageAmount = 110;
            Lvl = 2;
            Exp = Lvl * 10;

            dropItems.Add(GameInventoryItems.AllItems.Where(x => x.Name == "Small Solar Panel").SingleOrDefault());
        }
    }
}
