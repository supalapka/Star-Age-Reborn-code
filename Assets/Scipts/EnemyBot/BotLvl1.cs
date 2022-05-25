using Assets.Scipts.Models.Miners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLvl1 : MonoBehaviour
{
    private Transform target;
    public GameObject thisBot;
    private Vector3 vectorWithNoZ;
    public float speed = 1f;
    public static bool canFollow = false;

    private int currentHealth = 100;
    int minerIdx;

    void Start()
    {
        Miner miner = new Miner();
        miner.Id = thisBot.name;
        miner.transform = thisBot.transform; //EnemyLVL1
        miner.minerGameObject = thisBot;
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
        //if (other.CompareTag("Player"))
        //{
        //    canFollow = true;
        //    target = other.transform;
        //    minerIdx = MinersOnMap.GetMinerId(thisBot.name);
        //}
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            canFollow = false;
    }
}
