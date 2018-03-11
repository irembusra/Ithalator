using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextScript : MonoBehaviour {

	private static InfoTextScript _This;

	public static InfoTextScript instance
	{
		get
		{
			if(_This == null)
			{
				_This = FindObjectOfType<InfoTextScript> ();
			}
			return _This;
		}
	}

	void Awake()
	{
		_This = this;

		PVO_WriteText ("Burada Yatırım Yapabilirsin.");

	}


	public void PVO_WriteText(string ntext)
	{
		GetComponent<Text> ().text = ntext;
	}


}
