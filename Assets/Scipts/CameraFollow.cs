using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField ]private Transform player;
    private Vector3 playerPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.position;
        playerPos.z = transform.position.z;
        transform.position = playerPos;
    }
}
