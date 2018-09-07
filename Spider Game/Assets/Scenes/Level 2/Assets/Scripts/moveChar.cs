using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChar : MonoBehaviour {

    Vector3 position;
    Rigidbody rb;
    Vector3 jump, targetPosition, lookAtTarget;

    public float velocity = 1.0f;
    public bool isGrounded;
    public float jumpForce = 2.0f;

    float rotSpeed = 5;
    Quaternion playerRot;
    public Camera main;
    //quaternion es  para rotaciones
    //transform toma todas las propiedades del objeto asociado al script
    //slertp rotacion mas cercana al punto de llamado



    // Use this for initialization
    void Start()
    {

        position = this.transform.position;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }




    void OncollisionStay()
    {

        isGrounded = true;

    }

    void onCollisionExit()
    {

        isGrounded = false;

    }
    // Update is called once per frame
    void Update()
    {

        transform.Translate(velocity * Input.GetAxis("Horizontal")
            * Time.deltaTime, 0f, velocity
            * Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetMouseButton(1)) {
            setTargetPosition();
            Movement();


        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

        }

       




    }


    void Movement()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            playerRot, rotSpeed * Time.deltaTime);
        //Se mueve hacia la dirección del click mouse
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
            velocity * Time.deltaTime);
    }

    void setTargetPosition()
    {
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag == "Floor")
            {
                targetPosition = hit.point;
                lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y,
                    targetPosition.z - transform.position.z);
                playerRot = Quaternion.LookRotation(lookAtTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                            playerRot, rotSpeed * Time.deltaTime);
            }
        }
    }
}
