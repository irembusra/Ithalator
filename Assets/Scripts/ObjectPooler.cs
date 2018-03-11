using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	private static ObjectPooler _This;

	public static ObjectPooler roadInstance
	{
		get
		{
			if(_This == null)
			{
				_This = FindObjectOfType<ObjectPooler> ().GetComponent<ObjectPooler> ();
			}
			return _This;
		}
	}


	public GameObject go_PooledObject;
	public int i_PooledAmount;

	List<GameObject> Pool;

	void Start () {
		Pool = new List<GameObject> ();
		VO_PoolObjects ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void VO_PoolObjects()
	{
		for(int i = 0; i < i_PooledAmount; i++)
		{
			GameObject go = Instantiate (go_PooledObject, transform.position, go_PooledObject.transform.rotation);
			Pool.Add (go);
			go.SetActive (false);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < Pool.Count; i++)
		{
			Debug.Log ("Get Pooled Object");
			if (Pool[i] == null)
			{
				GameObject obj = Instantiate (go_PooledObject, transform.position, go_PooledObject.transform.rotation);
				obj.SetActive(false);
				Pool[i] = obj;
				return Pool[i];
			}
			if (!Pool[i].activeInHierarchy)
			{
				return Pool[i];
			}
		}
		return null;
	}

}
