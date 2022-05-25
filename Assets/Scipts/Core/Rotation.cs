using System.Linq;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform coreTransform;
    private float rotateSpeed;
    public float rotateSpeedVisualEffect = 30f;
    Quaternion rotation;
    public Animator animator;
    private float startedRotationAngleZ;
    bool isTurning = false;
    Vector3 mousePosition;
    Vector2 direction;
    float angle;
    Quaternion rotationVisualEffect;


    void Start()
    {
        if (!Core.isInited)
            Core.Init();
        rotateSpeed += Core.spaceship.Engines.ElementAt(0).RotationSpeed;
    }


    //REPLACE ROTATION CHANGES HERE INSTEAD OF ANIMATION!!!
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTurning = true;
            startedRotationAngleZ = coreTransform.rotation.z; //save current z angle for identificate turn side
            //   animator.SetFloat("speed", 1f);
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - coreTransform.position;

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            coreTransform.rotation = Quaternion.RotateTowards(coreTransform.rotation, rotation, rotateSpeed * Time.deltaTime); //make one move for get difference in z axis
        }

        if (isTurning)
        {
            direction = mousePosition - coreTransform.position; 
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            coreTransform.rotation = Quaternion.RotateTowards(coreTransform.rotation, rotation, rotateSpeed * Time.deltaTime);


            if (startedRotationAngleZ > coreTransform.rotation.z) // identificate turn side
            { //turning right
                rotationVisualEffect = Quaternion.AngleAxis(45, Vector3.right);
                //coreTransform.rotation = Quaternion.RotateTowards(transform.rotation, rotationVisualEffect,
                //    rotateSpeedVisualEffect * Time.deltaTime); 
                // animator.SetBool("isTurningRight", true);
                //  animator.SetBool("isTurningLeft", false);
            }
            else
            {//turning left
                rotationVisualEffect = Quaternion.AngleAxis(45, Vector3.left);
                //coreTransform.rotation = Quaternion.RotateTowards(transform.rotation, rotationVisualEffect,
                //    rotateSpeedVisualEffect * Time.deltaTime);
                //  animator.SetBool("isTurningLeft", true);
                //  animator.SetBool("isTurningRight", false);
            }
            // animator.SetBool("isReadyToDefault", false);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationVisualEffect,
                   rotateSpeedVisualEffect * Time.deltaTime);  //rotate to 0    
        }

        if (coreTransform.rotation == rotation)
        {
            isTurning = false;
            // animator.SetBool("isReadyToDefault", true);
            // animator.SetBool("isTurningLeft", false);
            // animator.SetBool("isTurningRight", false);
        }

        if (Input.GetKeyDown(KeyCode.S)) //stop moving
        {
            rotation = coreTransform.rotation;
            //  animator.SetFloat("speed", -1f);
        }
    }

}
