using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scipts
{
    public static class PlayersOnMap
    {
        public static List<Player> Players = new List<Player>();

        public static Player GetPlayer(string name) { return Players.Where(x => x.Name == name).FirstOrDefault(); }
        public static Player GetPlayer(int idx) { return Players.ElementAt(idx); }


        public static int GetPlayerIndexByName(string name)
        {
            var player = Players.Where(x => x.Name == name).FirstOrDefault();
            return Players.IndexOf(player);
        }

        public static void DamagePlayer(string name, int damage)
        {
            var player = Players.Where(x => x.Name == name).FirstOrDefault();
            player.Damage(damage);
        }

        public static void AddExpToPlayer(string name, int exp)
        {
            var player = Players.Where(x => x.Name == name).FirstOrDefault();
            player.AddExp(exp);
        }



        public static void AddItemToSpaceshipInventory(string name, UnityEngine.GameObject item)
        {

        }
    }
}
