using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDeactivator : MonoBehaviour {

	// Use this for initialization

	public GameObject parent;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("Player"))
		{
			parent.SetActive (false);
		}
	}
}
