using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLvl1 : MonoBehaviour
{
    private Transform target;
    public Transform thisBot;
    private Vector3 vectorWithNoZ;
    public float speed = 0.07f;
    public static bool canFollow = false;

    void Start()
    {
        
    }

    void Update()
    {

        if (canFollow)
        {
            vectorWithNoZ = target.position;
            thisBot.position = Vector3.MoveTowards(thisBot.position, vectorWithNoZ, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canFollow = true;
            target = other.transform;
        }
    }
}
