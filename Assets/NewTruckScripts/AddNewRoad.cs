using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewRoad : MonoBehaviour {

	//public GameObject go_RoadCollection;
	public Transform t_AddPosition;

	//public ObjectPooler roadPool;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("Player"))
		{
			VO_NewRoad ();
		}
	}

	void VO_NewRoad()
	{

		Debug.Log ("Add New Road Called");
		GameObject roadCol = ObjectPooler.roadInstance.GetPooledObject ();
		roadCol.transform.position = t_AddPosition.position;

		roadCol.SetActive (true);
		roadCol.GetComponent<NPCTruckSpawner> ().PVO_Activate ();
	}
}
