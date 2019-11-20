using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    //public float health = 100.0f;
    //public float damage = 5.0f;
    public GameObject other;
    private Rigidbody rb;
    public int count = 0;
    public bool isDestroyed = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (count == 5)
        {
            isDestroyed = true;
            Destroy(other);
        }
        else { isDestroyed = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy_Truck")
        {
            rb.mass -= 100;

            count++;
            //Debug.Log(count);
        }
    }
}

