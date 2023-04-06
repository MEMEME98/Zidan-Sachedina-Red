using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private Quaternion lastLook;
    public float speed;
    public float decelerationMultiplier = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        anim = GetComponent<Animator>();
        lastLook = transform.rotation;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.mass = 1;
        Vector3 movementVector = new Vector3(horizontal, 0, vertical).normalized;
        
        if (movementVector.magnitude != 0)
        {
            lastLook = Quaternion.LookRotation(movementVector);
        }
        transform.rotation = lastLook;

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed / 100;
        //rb.MovePosition(transform.position + movement);
        rb.AddForce(movementVector * speed);
        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            rb.drag = 1000;
        }
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            rb.drag = 0.5f;
        }

        anim.SetFloat("horizontalVector", movementVector.magnitude);
        anim.SetFloat("verticalVector", 0);
    }

}
