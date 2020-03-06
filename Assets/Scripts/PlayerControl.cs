using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody rb;
    private float jumpcool;
    private Camera cam;

    bool Isgrounded() {
        float sy = transform.localScale.y/1.9f;
        bool r1 = Physics.Raycast(transform.position, -Vector3.up, sy);
        bool r2 = Physics.Raycast(transform.position+new Vector3(0.45f,0,0),-Vector3.up,sy);
        bool r3 = Physics.Raycast(transform.position-new Vector3(0.45f,0,0),-Vector3.up,sy);
        return (r1 || r2 || r3);
    }
    void Start()
    {
        cam = Camera.main;
        rb = gameObject.GetComponent<Rigidbody>();
        jumpcool = Time.time;
    }

    void FixedUpdate()
    {
        Vector3 dirVector = new Vector3(Input.GetAxis("Horizontal")*speed, 0, 0);
        rb.MovePosition(transform.position + dirVector * Time.deltaTime);
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && Isgrounded() && Time.time-jumpcool > 0.1)
        {
            rb.AddForce(transform.up*13,ForceMode.VelocityChange);
            jumpcool = Time.time;
        }
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = Mathf.Lerp(speed,15,15*Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,7,15*Time.deltaTime);
        }else{
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,5,15*Time.deltaTime);
            speed = Mathf.Lerp(speed,5,15*Time.deltaTime);
        }
    }
}
