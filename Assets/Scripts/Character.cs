using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{ 
private float Speed;
public float walkSpeed;
public float runSpeed;
private Vector3 _velocity;
public Vector3 Drag;
public float DashDistance;
public float landShockDuration;
public float cooldown;
private float timestamp;
private float timestamp2;
private CharacterController _controller;

void Start()
    {
        _controller = GetComponent<CharacterController>();
		Speed = runSpeed;
    }

void Update()
    {

    Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    _controller.Move(move * Time.deltaTime * Speed);

	if (move != Vector3.zero)
            transform.forward = move;

	if (Input.GetButtonDown("Walk"))
	{
		Speed = walkSpeed;
	}
	if (Input.GetButtonUp("Walk"))
	{
		Speed = runSpeed;
	}

 	if (Input.GetKeyDown(KeyCode.Space))
	{
		if (timestamp <= Time.time) //once total + cooldown time reaches realtime, re-enable
		{
			timestamp = Time.time + cooldown;
            _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
		 	Speed = 1;
			Invoke("resetSpeed", landShockDuration);
		 }
    }

		_velocity.x /= 1 + Drag.x * Time.deltaTime;
		_velocity.z /= 1 + Drag.z * Time.deltaTime;

	 	_controller.Move(_velocity * Time.deltaTime);
    }	 
	void resetSpeed()
	{
		Speed = runSpeed;
	}
}

