using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public bool lockCursor;
	public float mouseSensitivity = 10;
	public Transform target;//you must create a empty gameobject where the camera will lookat(name it lookAt)
	public float dstFromTarget = 2;//distance from player 
	public Vector2 pitchMinMax = new Vector2 (-40, 85);//rotation at the x axis

	public float rotationSmoothTime = .12f;
	Vector3 rotationSmoothVelocity;
	Vector3 currentRotation;

	float yaw;
	float pitch;

	void Start() {
		if (lockCursor) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}

	void LateUpdate () {
        //rotating camera with mouse
		yaw += Input.GetAxis ("Mouse X") * mouseSensitivity;
		pitch -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		pitch = Mathf.Clamp (pitch, pitchMinMax.x, pitchMinMax.y);

		currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
		transform.eulerAngles = currentRotation;

		transform.position = target.position - transform.forward * dstFromTarget;

	}

}
