using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAI : MonoBehaviour {

	public GameObject[] myTrucks;

	public float f_MinSpeed;
	public float f_MaxSpeed;

	public float f_CurrentSpeed;

	public int i_Location;
	Transform t_This;

	Rigidbody rb;


	private int i_TargetLocation;
	private bool b_MoveRight;
	private bool b_OnLane;

	private int index;


	void Start () {
		t_This = transform;
		f_CurrentSpeed = Random.Range (f_MinSpeed, f_MaxSpeed);
		rb = GetComponent<Rigidbody> ();

	}

	public void Activate()
	{
		i_Location = (int)transform.position.x + 1;
		index = Random.Range (0, 2);
		myTrucks [index].SetActive (true);
	}
	

	void Update () {


			transform.Translate (transform.forward * f_CurrentSpeed);

		//rb.velocity = transform.forward * f_CurrentSpeed;

		if(Mathf.Abs(TruckController.instance.f_MyZ - transform.position.z) <= 6 && b_OnLane)
			VO_CheckForward ();

		if(!b_OnLane && b_MoveRight && i_TargetLocation - transform.position.x > 0.01f)
		{
			VO_MoveRight ();
		}

		if(!b_OnLane && !b_MoveRight && transform.position.x - i_TargetLocation > 0.01f)
		{
			VO_MoveLeft ();
		}

		if(Mathf.Abs(i_TargetLocation - transform.position.x) <= 0.01f)
		{

			b_OnLane = true;

		}

		if(TruckController.instance.f_MyZ - transform.position.z >= 5)
		{
			myTrucks [index].SetActive (false);
			gameObject.SetActive (false);
		}
	}

	void VO_CheckForward()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit))
		{
			if(hit.distance <= 3)
			{
				TruckAI truckAI = hit.transform.GetComponent<TruckAI> ();
				if(truckAI != null)
				{
					float f_truckSpeed = truckAI.f_CurrentSpeed;
					if(f_truckSpeed == f_CurrentSpeed)
					{
						f_CurrentSpeed -= 0.02f;
					}

				}

				if(i_Location == 0 && b_OnLane)
				{
					RaycastHit rightHit;
					if(Physics.Raycast(transform.position, transform.right, out rightHit))
					{
						Debug.Log ("Have truck on right");
					}
					else
					{
						VO_SwitchRight ();
					}
				}
				if(i_Location == 2 && b_OnLane)
				{
					RaycastHit leftHit;
					if(Physics.Raycast(transform.position, transform.right, out leftHit))
					{
						Debug.Log ("have truck on elft");
					}
					else
					{
						VO_SwitchLeft ();
					}
				}

				if(i_Location == 1 && b_OnLane)
				{
					if(Random.Range(0,2) == 1)
					{
						RaycastHit rightHit;
						if(Physics.Raycast(transform.position, transform.right, out rightHit))
						{

						}
						else
						{
							VO_SwitchRight ();
						}
					}
					else
					{
						RaycastHit leftHit;
						if(Physics.Raycast(transform.position, transform.right, out leftHit))
						{

						}
						else
						{
							VO_SwitchLeft ();
						}
					}
				}


			}
		}
	}


	void VO_MoveRight()
	{
		transform.Translate (transform.right * 0.01f);
	}

	void VO_MoveLeft()
	{
		transform.Translate (-transform.right * 0.01f);
	}

	void VO_SwitchRight()
	{
		Debug.Log ("NPC RIGHT");
		if(i_Location == 2)
		{
			Debug.Log ("ALREADY RIGHT");
		}

		if(i_Location == 0)
		{
			b_OnLane = false;
			b_MoveRight = true;
			i_Location++;
			i_TargetLocation = 0;
			//t_This.position = new Vector3 (0, t_This.position.y, t_This.position.z);

		}
		else if(i_Location == 1)
		{
			b_OnLane = false;
			b_MoveRight = true;
			i_Location++;
			i_TargetLocation = 1;
			//t_This.position = new Vector3 (1, t_This.position.y, t_This.position.z);

		}
	}

	void VO_SwitchLeft()
	{
		Debug.Log ("NPC LEFT");
		if(i_Location == 0)
		{
			Debug.Log ("ALREADY Left");
		}

		if(i_Location == 1)
		{
			b_OnLane = false;
			i_Location--;
			i_TargetLocation = -1;
			b_MoveRight = false;

			//t_This.position = new Vector3 (-1, t_This.position.y, t_This.position.z);
		}

		else if(i_Location == 2)
		{
			b_OnLane = false;
			i_Location--;
			i_TargetLocation = 0;
			b_MoveRight = false;
			//t_This.position = new Vector3 (0, t_This.position.y, t_This.position.z);
		}
	}
		
}
