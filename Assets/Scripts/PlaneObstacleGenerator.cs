using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObstacleGenerator : MonoBehaviour {

	public float f_MaxLenght;
	public float f_ObstacleDensity;

	private float f_XMin;
	private float f_XMax;

	private float f_SpawnZ;
	public float f_DefaultZ;
	public float f_DefaultInterval;
	private float f_NewInterval;

	public GameObject go_Obstacle;



	void Start () {
		Debug.Log (f_XMax);
		Debug.Log (f_XMin);

		f_SpawnZ = f_DefaultZ;
	}
	

	void Update () {
		f_XMax = Camera.main.ViewportToWorldPoint (new Vector3(1,0,f_SpawnZ)).x;
		f_XMin = Camera.main.ViewportToWorldPoint (new Vector3(0,0,f_SpawnZ)).x;
		if(f_SpawnZ < f_MaxLenght)
		{
			Spawn ();
		}
	}

	void Spawn()
	{
		Vector3 v3_SpawnLoc = new Vector3 (Random.Range (-14, 14), go_Obstacle.transform.position.y, f_SpawnZ);
		Instantiate (go_Obstacle, v3_SpawnLoc, go_Obstacle.transform.rotation);

		f_NewInterval = f_DefaultInterval;

		f_SpawnZ += f_NewInterval;

	}

}
