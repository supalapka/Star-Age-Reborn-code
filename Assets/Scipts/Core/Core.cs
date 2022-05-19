using Assets.Scipts.Model;
using Assets.Scipts.Model.Engines;
using Assets.Scipts.Models.Spaceships;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core
{
    public static Spaceship spaceship = new Corsar();
    public static void Init()
    {
        Engine tesla = new Core1();
        spaceship.Engines.Add(tesla);
        
    }
    
}
