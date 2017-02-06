using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private float rotationX, rotationY;
	private Quaternion originalRotation;

	public float moveSpeed, tilt, turnSpeed;

	// Use this for initialization
	void Start () {	
		originalRotation = transform.localRotation;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (GAMECONTROLLER.playerAlive == true && GAMECONTROLLER.safeZone == false) {
			// Mouse turning
			rotationX = Input.GetAxis ("Horizontal");
			rotationY += Input.GetAxis ("Horizontal") * turnSpeed;
			// Roll
			transform.localRotation = Quaternion.Euler (0.0f, rotationY - 90f, rotationX * -tilt);
			// Forward movement
			transform.position += transform.forward * moveSpeed;
		}
		else if(GAMECONTROLLER.safeZone == true)
		{
			transform.position = new Vector3(-20.0f,3.35f,-4.08f);
			originalRotation.y = 180.0f;
			transform.localRotation = originalRotation;
		}
	}
}
