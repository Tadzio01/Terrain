using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody rb;
    private float jumpcool;

    bool Isgrounded() {
        float sy = transform.localScale.y/2;
        bool r1 = Physics.Raycast(transform.position, -Vector3.up, sy);
        bool r2 = Physics.Raycast(transform.position+new Vector3(0.5f,0,0),-Vector3.up,sy);
        bool r3 = Physics.Raycast(transform.position-new Vector3(0.5f,0,0),-Vector3.up,sy);
        return (r1 || r2 || r3);
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
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && Isgrounded() && Time.time-jumpcool > 0.1)
        {
            rb.AddForce(transform.up * 15,ForceMode.VelocityChange);
            jumpcool = Time.time;
        }
    }

}
