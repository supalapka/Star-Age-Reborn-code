using Assets;
using Assets.Scipts.Models.Miners;
using UnityEngine;
using UnityEngine.UI;

public class MinerBot : MonoBehaviour
{
    public HealthBar healthBar;
    private Transform target;
    public GameObject thisBot;
    private float speed;
    private Vector3 vectorWithNoZ;
    public bool canFollow = false;
    [SerializeField] Text levelTextAboveMiner;
    [SerializeField] MeshFilter MinerMesh;

    Miner miner;
    int minerIdx;

    void Start()
    {
        System.Random r = new System.Random();
        int rand = r.Next(0, 4); // for  spawn random level bots
        if (rand == 3) //1 to 4 change to spawn lvl 2 bot
        {
            miner = new MinerLvl2(healthBar);
            levelTextAboveMiner.text += "Miner Bot LVL 2";
            MinerMesh.mesh = MinersMeshLibrary.GetMeshByLvl(2);
        }
        else
        {
            miner = new MinerLvl1(healthBar);
            levelTextAboveMiner.text += "Miner Bot LVL 1";
            MinerMesh.mesh = MinersMeshLibrary.GetMeshByLvl(1);
        }
        speed = miner.MoveSpeed;
        miner.Id = thisBot.name;
        miner.transform = thisBot.transform; //EnemyLVL1
        miner.minerGameObject = thisBot;
        miner.HealthBar = this.healthBar;
        MinersOnMap.Miners.Add(miner);

        target = thisBot.transform;
    }

    void Update()
    {
        //foreach (var miner in MinersOnMap.Miners)
        //{
        //    if (miner.canFollow)
        //    miner.Follow(target.position);
        //}

        if (canFollow)
        {
            thisBot.transform.position = Vector3.MoveTowards(thisBot.transform.position, target.position, speed * Time.deltaTime);
        //    MinersOnMap.Follow(minerIdx, target.position);
            //miner.Follow(target.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            minerIdx = MinersOnMap.GetMinerId(this.name);
            //   MinersOnMap.Miners[minerIdx].canFollow = true;
            canFollow = true;
            target = other.transform;
        }
        minerIdx = MinersOnMap.GetMinerId(thisBot.name);
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
