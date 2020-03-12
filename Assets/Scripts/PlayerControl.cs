using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	private float speed = 5;
	private float jumpForce = 10;
	private float gravityScale = 1;
    private Camera cam;
	public CharacterController controller;

	private Vector3 direction;
    bool Isgrounded() {
        float sy = transform.localScale.y/1.9f;
        bool r1 = Physics.Raycast(transform.position, -Vector3.up, sy);
        bool r2 = Physics.Raycast(transform.position+new Vector3(0.45f,0,0),-Vector3.up,sy);
        bool r3 = Physics.Raycast(transform.position-new Vector3(0.45f,0,0),-Vector3.up,sy);
        return (r1 || r2 || r3);
    }
	//Use this for initialization
	void Start()
    
	{
        cam = Camera.main;
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
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
		direction = new Vector3(
			Input.GetAxis("Horizontal") * speed, 
			direction.y,
			Input.GetAxis("Vertical") * speed
		);

		// Y movement
		if (controller.isGrounded)
		{
			// Jump
			if (Input.GetButtonDown("Jump"))
			{
				direction.y = jumpForce; // Jump
			}
			else
			{
				direction.y = -1; // Ensures contact with the ground
			}
		}
		else
		{
			if (!Isgrounded()){
		    	direction.y = direction.y + (-35 * gravityScale * Time.deltaTime);
            }
		}
		controller.Move(direction * Time.deltaTime);
	}
}
