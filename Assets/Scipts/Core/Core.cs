using Assets.Scipts.Model;
using Assets.Scipts.Model.Engines;
using Assets.Scipts.Models;
using Assets.Scipts.Models.Spaceships;
using Assets.Scipts.Models.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core
{
    public static Spaceship spaceship = new Corsar();
    public static bool isInited = false;
    public static void Init()
    {
        Engine tesla = new Tesla();
        spaceship.Engines.Add(tesla);

        Weapon weapon = new TestWeapon();
        spaceship.Weapon.Add(weapon);

        isInited = true;
    }

}
