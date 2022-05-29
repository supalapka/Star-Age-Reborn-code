using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform coreTransform;
    private float moveSpeed = 0;
    public List<GameObject> flames;
    [SerializeField] private Collider targetCollider;
    private Vector3 target;
    void Start()
    {
        if (!Core.isInited)
            Core.Init();
        target = coreTransform.transform.position;
        foreach (var engine in Core.spaceship.Engines)
            moveSpeed += engine.MoveSpeed;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = coreTransform.transform.position.z;
            targetCollider.transform.position = target;

            foreach (var flame in flames)
            {
                flame.SetActive(true);
            }
        }

        if (target != coreTransform.transform.position)
            coreTransform.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        else
            foreach (var flame in flames)
            {
                flame.SetActive(false);
            }

        if (Input.GetKeyDown(KeyCode.S)) //stop moving
        {
            target = coreTransform.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider) 
        {
            target = coreTransform.transform.position;
            if(PickUpItem.IsPickingUpItem == true)
            {
                PickUpItem.PickUp();
            }
        }
    }

}
