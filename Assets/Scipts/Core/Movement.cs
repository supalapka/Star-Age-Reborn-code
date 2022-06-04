using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Transform coreTransform;
    private float moveSpeed = 0;
    public List<GameObject> flames;
    [SerializeField] private Collider targetCollider;
    private Vector3 target;
    private bool isLanding = false;
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

        if (isLanding)
        {
            coreTransform.transform.localScale = Vector3.Lerp(coreTransform.transform.localScale, Vector3.zero, 1.2f * Time.deltaTime);
            if (coreTransform.transform.localScale.y < 0.04f)
            {
                isLanding = false;
                SceneManager.LoadScene("Base");
            }

            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider) 
        {
            target = coreTransform.transform.position;

            if(PickUpItem.IsPickingUpItem) //pick up item
            {
                PickUpItem.PickUp();
                PickUpItem.IsPickingUpItem = false;
            }

            if (PlanetLanding.IsMovesToLanding) //land spaceship
            {
                PlanetLanding.IsMovesToLanding = false;
                isLanding = true; 
            }
        }
    }

}
