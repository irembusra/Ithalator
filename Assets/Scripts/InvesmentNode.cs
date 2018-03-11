using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvesmentNode : MonoBehaviour {



	public int i_InvesmentCost;
	public int i_MyIndex;

	private bool b_Unlocked;

	public Material OriginalMaterial;
	public Material LockedMaterial;
	public MeshRenderer mr_Target;

	void Start()
	{
		if(PlayerDataHandler.instance.b_Invesments[i_MyIndex] == true)
		{
			b_Unlocked = true;
			mr_Target.material = OriginalMaterial;
		}
		else
		{
			b_Unlocked = false;
			mr_Target.material = LockedMaterial;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void VO_Unlock()
	{
		b_Unlocked = true;
		mr_Target.material = OriginalMaterial;
		PlayerDataHandler.instance.PVO_SpendMoney (i_InvesmentCost);
		PlayerDataHandler.instance.PVO_Invest (i_MyIndex);
	}

	public void PVO_TryUnlock()
	{
		if(!b_Unlocked)
		{
			if(PlayerDataHandler.instance.i_MyBudget >= i_InvesmentCost)
			{
				Debug.Log ("Unlocked");
				VO_Unlock ();
			}
			else
			{
				Debug.Log ("Not Enough Coins");

				InfoTextScript.instance.PVO_WriteText (gameObject.name + "  Yatırımını Yapacak Bütçeye Sahip Değilsin!");
			}
		}

	}

}
