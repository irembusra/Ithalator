using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTruckSpawner : MonoBehaviour {

	public int i_SpawnAmount;

	private int i_SpawnCount;

	public Transform[] spawnLocations;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PVO_Activate()
	{
		Spawn ();
	}

	void Spawn()
	{


		for(int i = 0; i < spawnLocations.Length; i++)
		{
			if(Random.value <= 0.55)
			{
				GameObject truck = ObjectPoolerTruck.instance.GetPooledObject ();
				truck.transform.position = spawnLocations [i].position;
				truck.transform.position += new Vector3 (0, 0.315f, 0);
				truck.GetComponent<TruckAI> ().Activate ();
				truck.SetActive (true);
			}
		}
	}
}
