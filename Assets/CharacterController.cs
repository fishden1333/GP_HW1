using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	public float inputDelay = 0.1f;
	public float forwardVel = 50;
	public float rotateVel = 200;

	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;

	public Quaternion TargetRotation
	{
		get { return targetRotation; }
	}

	// Use this for initialization
	void Start()
	{
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody>())
		{
			rBody = GetComponent<Rigidbody>();
		}
		else
		{
			Debug.LogError("The character needs a rigidbody.");
		}
		forwardInput = turnInput = 0;
	}

	void GetInput()
	{
		forwardInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
	}

	// Update is called once per frame
	void Update()
	{
		GetInput();
		Turn();
	}

	// For physical updates
	void FixedUpdate()
	{
		Run();
	}

	// For rigidbody to move forward
	void Run()
	{
		// Move
		if (Mathf.Abs(forwardInput) > inputDelay)
		{
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		}
		// Don't Move
		else
		{
			rBody.velocity = Vector3.zero;
		}
	}

	// For rigidbody to rotate
	void Turn()
	{
		if (Mathf.Abs(turnInput) > inputDelay)
		{
			targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
}
