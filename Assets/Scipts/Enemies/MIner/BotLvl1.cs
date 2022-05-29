using Assets;
using Assets.Scipts.Models.Miners;
using UnityEngine;

public class BotLvl1 : MonoBehaviour
{
    public HealthBar healthBar;
    private Transform target;
    public GameObject thisBot;
    private Vector3 vectorWithNoZ;
    public float speed = 1f;
    public static bool canFollow = false;

    private int currentHealth = 100;
    int minerIdx;

    void Start()
    {
        MinerLvl1 miner = new MinerLvl1(healthBar);
        miner.Id = thisBot.name;
        miner.transform = thisBot.transform; //EnemyLVL1
        miner.minerGameObject = thisBot;
        miner.healthBar = this.healthBar;
        MinersOnMap.Miners.Add(miner);

        target = thisBot.transform;
    }

    void Update()
    {
        //if (canFollow)
        //{
        //    try
        //    {
        //        vectorWithNoZ = target.position;
        //    }
        //    catch
        //    {
        //    }
        //    MinersOnMap.Follow(minerIdx, vectorWithNoZ);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        minerIdx = MinersOnMap.GetMinerId(thisBot.name);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vectorWithNoZ = target.position;
            MinersOnMap.Follow(minerIdx, vectorWithNoZ);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            canFollow = false;
    }

    public static void DropItemsAfterDeath(GameObject drop, Vector3 position)
    {
        Quaternion rotation = Quaternion.identity;
        ItemsOnMap.Add(drop);
        Instantiate(drop, position, rotation);

    }

}
