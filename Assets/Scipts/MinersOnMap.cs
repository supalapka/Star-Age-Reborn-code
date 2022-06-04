using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scipts.Models.Miners
{
    public static class MinersOnMap
    {
        public static List<Miner> Miners = new List<Miner>();
        public static bool IsInited = false;

        public static void Init(GameObject _miner)
        {
            var random = new System.Random();
            int x;
            int y;
            for (int i = 0; i < 40; i++)
            {
                GameObject newMiner = GameObject.Instantiate(_miner);
                newMiner.name += FunctionsLib.RandomString(6);
                x = random.Next(-20, 80);
                y = random.Next(-40, 40);
                var pos = new Vector3(x, y, 0);
                newMiner.transform.position = pos;

             //  MinerBot.CreateMiner(newMiner);

            }
            IsInited = true;

        }

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
