using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody rb;
    private float jumpcool;

    bool Isgrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, 1.1f + 0.1f);
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jumpcool = Time.time;
    }

    void FixedUpdate()
    {
        Vector3 dirVector = new Vector3(Input.GetAxis("Horizontal")*speed, 0, 0);
        rb.MovePosition(transform.position+dirVector*Time.fixedDeltaTime);
        if (Input.GetKeyDown("space") && Isgrounded() && Time.time-jumpcool > 0.1)
        {
            rb.AddForce(transform.up * 15,ForceMode.VelocityChange);
            jumpcool = Time.time;
        }
    }

}
