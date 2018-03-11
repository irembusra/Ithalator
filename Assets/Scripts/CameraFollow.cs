using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Transform t_Camera;

	float f_ZOffset;

	void Start () {
		t_Camera = Camera.main.transform;
		f_ZOffset = transform.position.z - t_Camera.position.z;
	}
	

	void Update () {
		t_Camera.position = new Vector3 (t_Camera.position.x, t_Camera.position.y, transform.position.z - f_ZOffset);	
	}
}
