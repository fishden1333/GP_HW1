using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0, -5, -50);
	public Vector3 offsetFromTarget2 = new Vector3(0, 0, 0);

	Vector3 destination = Vector3.zero;
	CharacterController charController;
	float rotateVel = 0;
	bool changePOV = false;

	// Use this for initialization
	void Start()
	{
		SetCameraTarget(target);
	}

	void SetCameraTarget(Transform t)
	{
		target = t;
		if (target != null)
		{
			if (target.GetComponent<CharacterController>())
			{
				charController = target.GetComponent<CharacterController>();
			}
			else
			{
				Debug.LogError("The camera's target needs a character controller.");
			}
		}
		else
		{
			Debug.LogError("The camera needs a target.");
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C))
		{
			changePOV = !changePOV;
		}
	}

	void ChangeCamera()
	{
		if (!changePOV)
		{

		}
	}

	// Updates only after the Update() is called
	void LateUpdate()
	{
		// Moving
		MoveToTarget(changePOV);
		// Turning
		LookAtTarget();
	}

	void MoveToTarget(bool changeCam)
	{
		if (!changeCam)
		{
			destination = charController.TargetRotation * offsetFromTarget;
		}
		else
		{
			destination = charController.TargetRotation * offsetFromTarget2;
		}
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget()
	{
		float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
	}

}
