using Assets.Scipts.Model;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotateSpeed = 0;
    Quaternion rotation;
    public Animator animator;
    private float startedRotationAngleZ;
    bool isTurning = false;
    Vector3 mousePosition;
    Vector2 direction;
    float angle;
    void Start()
    {
        foreach (var engine in Core.spaceship.Engines)
            rotateSpeed += engine.RotationSpeed;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTurning = true;
            animator.SetFloat("speed", 1f);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - transform.position;

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            startedRotationAngleZ = transform.rotation.z; //save current z angle for identificate turn side
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime); //make one move for get difference in z axis


            if (startedRotationAngleZ > transform.rotation.z) // identificate turn side
            { //turning right
                animator.SetBool("isTurningRight", true);
                animator.SetBool("isTurningLeft", false);
            }
            else
            {//turning left
                animator.SetBool("isTurningLeft", true);
                animator.SetBool("isTurningRight", false);
            }
            animator.SetBool("isReadyToDefault", false);
        }

        if (isTurning)
        {
            direction = mousePosition - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (transform.rotation != rotation)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        else
        {
            animator.SetBool("isReadyToDefault", true);
            animator.SetBool("isTurningLeft", false);
            animator.SetBool("isTurningRight", false);
        }

        if (Input.GetKeyDown(KeyCode.S)) //stop moving
        {
            rotation = transform.rotation;
            animator.SetFloat("speed", -1f);
        }
    }

}
