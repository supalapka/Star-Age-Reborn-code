using Assets;
using Assets.Scipts.Models.Miners;
using UnityEngine;
using UnityEngine.UI;

public class MinerBot : MonoBehaviour
{
    public HealthBar healthBar;
    private Transform target;
    public GameObject thisBot;
    private Vector3 vectorWithNoZ;
    public static bool canFollow = false;
    [SerializeField] UnityEngine.UI.Text levelTextAboveMiner;

    int minerIdx;

    void Start()
    {
        Miner miner;
        System.Random r = new System.Random();
        int rand = r.Next(1, 4); // for  spawn random level bots
        if (rand == 3) //1 to 4 change to spawn lvl 2 bot
        {
            miner = new MinerLvl2(healthBar);
            levelTextAboveMiner.text += "Miner Bot LVL 2";
        }
        else
        {
            miner = new MinerLvl1(healthBar);
            levelTextAboveMiner.text += "Miner Bot LVL 1";
        }

        miner.Id = thisBot.name;
        miner.transform = thisBot.transform; //EnemyLVL1
        miner.minerGameObject = thisBot;
        miner.HealthBar = this.healthBar;
        MinersOnMap.Miners.Add(miner);

        target = thisBot.transform;
    }

    void Update()
    {
        if (canFollow)
        {
            vectorWithNoZ = target.position;
            //thisBot.transform.position = Vector3.MoveTowards(transform.position, vectorWithNoZ, speed * Time.deltaTime);
            MinersOnMap.Follow(minerIdx, vectorWithNoZ);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canFollow = true;
            target = other.transform;
        }
        minerIdx = MinersOnMap.GetMinerId(thisBot.name);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //MinersOnMap.Follow(minerIdx, vectorWithNoZ);
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
