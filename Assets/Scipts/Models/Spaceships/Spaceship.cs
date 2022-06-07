using Assets.Scipts.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Models.Spaceships
{
    public class Spaceship
    {
        public readonly string Name;
        public GameObject SpaceshipMesh;

        public readonly int MaxHP;
        public readonly int CurrentHP;

        public readonly int EngineWidth;
        public readonly int EngineHeight;

        public readonly int WeaponWidth;
        public readonly int WeaponHeight;

        public int WeaponCount;
        public int EngineCount;

        public int InventorySize;

        public List<Engine> Engines = new List<Engine>();
        public List<Weapon> Weapon = new List<Weapon>();

        public Spaceship(string name,
            int hp,
            int engineWidth,
            int engineHeight,
            int weaponHeight,
            int weaponWidth,
            int weaponCount,
            int engineCount,
            int inventorySize)
        {
            Name = name;
            MaxHP = hp;
            CurrentHP = hp;
            EngineWidth = engineWidth;
            EngineHeight = engineHeight;
            WeaponWidth = weaponWidth;
            WeaponHeight = weaponHeight;
            WeaponCount = weaponCount;
            EngineCount = engineCount;
            InventorySize = inventorySize;
        }

        public void SetSpaceshipMesh(ref GameObject obj) //redo later
        {
            // SpaceshipMesh.transform.position = obj.transform.position;

            //obj.GetComponent<MeshFilter>().mesh = SpaceshipMesh.GetComponent<MeshFilter>().mesh;


        }

    }
}
