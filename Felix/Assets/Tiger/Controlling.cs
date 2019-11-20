using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlling : MonoBehaviour
{
    private Animator tiger;
    //private CharacterController c;
    private Rigidbody rb;
    public float speed = 2;
    public int count = 1;
    //public float GroundDistance = 0.2f;
    public float rotationspeed = 100;
    public CapsuleCollider col;
    public LayerMask groundLayers;  

    void Start()
    {
        tiger = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        //c = GetComponent<CharacterController>();
        //count = 1;
    }

    void Update()
    {
        //grounded = false;
        //rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationspeed;
        rotation *= Time.deltaTime;
        transform.Translate(Vector3.forward * translation * Time.deltaTime);
        transform.Rotate(0, rotation, 0);
        //Debug.Log("HI");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Debug.Log(rb.velocity.y);
            //rb.velocity = 6.0f * Vector3.up;
            rb.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            tiger.SetBool("Attack", true);
        }

        else
        {
            tiger.SetBool("Attack", false);
        }

        if (translation != 0)
        {
            tiger.SetBool("IsWalking", true);
        }

        else
        {
            tiger.SetBool("IsWalking", false);
        }
    }

    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, groundLayers);
    }
}