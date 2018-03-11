using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObstacleGenerator : MonoBehaviour {

	public Transform t_Left;
	public Transform t_Mid;
	public Transform t_Right;

	public GameObject go_Obstacle;

	public float f_ObstacleCount;
	[Range(0,1)]
	public float f_ObstacleDensity;
	public float f_DefaultSpawnZ;
	public float f_DefaultSpawnZInterval;

	public float f_MaxReactionTime;
	public float f_RoadLength;
	private float f_TruckSpeed;

	private float f_LastSpawn;
	private float f_SpawnZ;

	private int i_Location;


	void Start () {
		f_SpawnZ = f_DefaultSpawnZ;
		f_TruckSpeed = TruckController.instance.f_Speed;

		f_ObstacleCount = f_RoadLength / f_DefaultSpawnZInterval;

		VO_FillObstacles ();

	}
	

	void Update () {
		
	}

	void VO_FillObstacles()
	{
		for(int i = 0; i < f_ObstacleCount; i++)
		{

			i_Location = Random.Range (0, 3);
			Vector3 v3_SpawnLoc = Vector3.zero;

			if(i_Location == 0)
			{
				v3_SpawnLoc = new Vector3 (t_Left.position.x, 1, f_SpawnZ);
			}
			if(i_Location == 1)
			{
				v3_SpawnLoc = new Vector3 (t_Mid.position.x, 1, f_SpawnZ);
			}
			if(i_Location == 2)
			{
				v3_SpawnLoc = new Vector3 (t_Right.position.x, 1, f_SpawnZ);
			}
				
			Instantiate (go_Obstacle, v3_SpawnLoc, Quaternion.identity);


			f_SpawnZ += f_TruckSpeed * f_MaxReactionTime * f_DefaultSpawnZInterval ;




		}
	}


}
