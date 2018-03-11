using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {


	Camera mainCamera;
	Touch myTouch;
	Transform t_This;
	float f_CamDepth;
	public GameObject aimPlane;


	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		t_This = transform;

		f_CamDepth = mainCamera.transform.position.z - transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.D))
		{
			VO_Right ();
		}

		if(Input.GetKey(KeyCode.A))
		{
			VO_Left ();
		}

		transform.Translate (transform.forward * 1f);


		/*if(Input.GetMouseButton(0))
		{
			AimInstantPC ();
		}

		if(Input.touchCount > 0)
		{
			myTouch = Input.touches [0];
			AimInstant ();
		}*/

	}

	void VO_Right()
	{
		if(transform.position.x < 7)
		transform.Translate (transform.right * 0.6f);
	}

	void VO_Left()
	{
		if(transform.position.x > -7)
		transform.Translate (transform.right * -0.6f);
	}

	void AimInstantPC()
	{
		Vector3 v3_MousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane);
		Debug.Log (v3_MousePos);
		Vector3 v3_MousePosTranslated = mainCamera.ScreenToWorldPoint (v3_MousePos);
		Vector3 MovePosition = new Vector3 (v3_MousePos.x, t_This.position.y, t_This.position.z);


		t_This.position = MovePosition;
	}


	void AimInstant()
	{
		Vector3 v3_MousePosWithDepth = new Vector3 (myTouch.position.x, myTouch.position.y, f_CamDepth);
		Vector3 v3_MousePosTranslated = mainCamera.ScreenToWorldPoint (v3_MousePosWithDepth);

		Vector3 v3_MovePosition = new Vector3 (v3_MousePosTranslated.x, t_This.position.y, t_This.position.z);

		t_This.position = v3_MovePosition;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("AirObstacle"))
		{
			VO_GetHit ();
		}
	}

	void VO_GetHit()
	{
		Debug.Log ("Gıt Hit");
	}
}
