using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float rotSpeed;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Hor = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce((Speed / (rb.velocity.z + 3)) * Vector3.forward);
        }



        rb.AddTorque(Hor * rotSpeed * Vector3.up);
    }
}
