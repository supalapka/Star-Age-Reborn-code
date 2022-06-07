using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Transform coreTransform; // this spaceship

    [SerializeField] GameObject SpaceshipModel; 
    bool isSpaceshipModelActive = false;

    private float moveSpeed;
    public List<GameObject> flames;
    [SerializeField] private Collider targetCollider;
    private Vector3 target; //target to move
    private bool isLanding = false; //is landing on planet
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

        if (!isSpaceshipModelActive) //set spaceship mesh to player //redo later;
        {
            isSpaceshipModelActive = true;
            var model = Instantiate(Core.spaceship.SpaceshipMesh, SpaceshipModel.transform.parent);
            SpaceshipModel.SetActive(false);

            model.SetActive(true);
           // model.transform.position = Vector3.zero;

            flames.Clear();
            foreach (Transform flame in model.transform)
            {
                flame.transform.localScale = new Vector3(.1f, .1f, .1f);
                flames.Add(flame.gameObject);
            }

        }

        if (other == targetCollider)
        {
            target = coreTransform.transform.position;

            if (PickUpItem.IsPickingUpItem) //pick up item
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
