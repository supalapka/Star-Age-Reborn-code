using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scipts.Models.Miners
{
    public static class MinersOnMap
    {
        public static List<Miner> Miners = new List<Miner>();

        public static void Damage(int index, string damagedBy, int damage)
        {
            Miners.ElementAt(index).Damage(damagedBy, damage);
        }

        public static int GetMinerIndex(string id)
        {
            int index = 0;
            foreach (var miner in Miners)
            {
                if (miner.Id == id)
                    return index;
                index++;
            }
            Debug.Log("not finded miner with id: " + id);
            return -1; //miner are not finded 
        }

        public static void Follow(int index, Vector3 targetPosition)
        {
            // Debug.Log("following for " + targetPosition + " by miner id: " + index);

            Miners.ElementAt(index).Follow(targetPosition);
        }

        public static void RemoveMiner(Miner miner)
        {
            Miners.Remove(miner);
        }

    }
}
