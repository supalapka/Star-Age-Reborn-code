using Assets.Scipts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Models.Spaceships
{
    public class Spaceship
    {
        public readonly string Name;

        public readonly int EngineWidth;
        public readonly int EngineHeight;

        public readonly int WeaponWidth;
        public readonly int WeaponHeight;

        public int WeaponCount;
        public int EngineCount;

        public int InventorySize;

        public List<Engine> Engines = new List<Engine>();
        // public List<Weapon> Weapon;

        public Spaceship(string name,
            int engineWidth,
            int engineHeight,
            int weaponHeight,
            int weaponWidth,
            int weaponCount,
            int engineCount)
        {
            Name = name;
            EngineWidth = engineWidth;
            EngineHeight = engineHeight;
            WeaponWidth = weaponWidth;
            WeaponHeight = weaponHeight;
            WeaponCount = weaponCount;
            EngineCount = engineCount;
        }

    }
}
