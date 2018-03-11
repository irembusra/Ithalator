using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour {

	void Update()
	{

		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if(Physics.Raycast(ray, out hit))
			{
				if(hit.transform.CompareTag("Interaction"))
				{
					hit.transform.GetComponent<InvesmentNode> ().PVO_TryUnlock ();
				}
			}
		}

	}
}
