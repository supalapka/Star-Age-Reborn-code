using UnityEngine;

public class ItemsDrop : MonoBehaviour
{
    private GameObject[] itemList; 
    private int randNum; 
    private Transform EnemyPos;

    private void Start()
    {
        EnemyPos = GetComponent<Transform>();
    }

    void Update()
    {

    }
}
