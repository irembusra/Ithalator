using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {


	private static GlobalVariables _This;

	public static GlobalVariables instance
	{
		get
		{
			if(_This == null)
			{
				_This = GameObject.FindObjectOfType<GlobalVariables> ();
			}
			return _This;
		}
	}


	public Vector3 v3_BottomLeft;
	public Vector3 v3_BottomRight;
	public Vector3 v3_TopLeft;
	public Vector3 v3_TopRight;


	public float f_ScreenTop;

	void Awake()
	{
		if(_This == null)
		{
			_This = this;
		}

		v3_BottomLeft = Camera.main.ViewportToWorldPoint (new Vector3(0,0,Camera.main.nearClipPlane));
		v3_BottomRight = Camera.main.ViewportToWorldPoint (new Vector3(1,0,Camera.main.nearClipPlane));
		v3_TopLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, Camera.main.nearClipPlane));
		v3_TopRight = Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, Camera.main.nearClipPlane));


		f_ScreenTop = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, Camera.main.nearClipPlane)).y;
	}


	public string FormatNumber(float num)
	{
		if(num >= 1000 && num < 1000000)
		{
			float divided = num / 1000;

			return divided.ToString("F") + "K";
			//return ((int)divided).ToString () + "K" + ((int)((divided - (int)divided) * 10)).ToString ();
		}
		else if(num >= 1000000 && num < 1000000000)
		{
			float divided = num / 1000000;

			return divided.ToString("F") + "M";
		}
		else if(num >= 1000000000)
		{
			float divided = num / 1000000000;

			return divided.ToString("F") + "B";
		}
		else
		{
			return ((int)num).ToString ();
		}
	}

}
