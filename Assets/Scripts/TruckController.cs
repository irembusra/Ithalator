using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TruckController : MonoBehaviour {

	private static TruckController _This;

	public static TruckController instance
	{
		get
		{
			if(_This == null)
			{
				_This = FindObjectOfType<TruckController> ().GetComponent<TruckController> ();
			}

			return _This;
		}
	}

    public Animator fadeout;
    public Color start;
    public Color end;
    public float f_MaxDistance;
    private bool b_WinCondition;
    public int i_Health;
    private float f_WinTime = 0;
    private float f_ExitTime = 3f;

    public AudioSource aus;

	public float f_Speed;
	public float f_MyZ;

	//public Transform t_Left;
	//public Transform t_Mid;
	//public Transform t_Right;

	Vector3 v3_CurrentPos;
	Transform t_This;

	private int i_Location;
	private int i_TargetLocation;
	private bool b_MoveRight;
	private bool b_OnLane;

    Vector2 v2TouchDelta;
    bool bSwiped;
    Touch myTouch;
    Vector2 v2TouchOrigin;
    Vector2 v2TouchFinal;
    public float fDeadzoneDiameter;


	private int i_LoadedMoney;

	void Start () {

		i_LoadedMoney = PlayerDataHandler.instance.i_LoadedMoney;

		t_This = GetComponent<Transform> ();
		i_Location = 1;
		t_This.position = new Vector3 (0, t_This.position.y, t_This.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		f_MyZ = t_This.position.z;

        if(f_MyZ >= f_MaxDistance && !b_WinCondition)
        {
            b_WinCondition = true;
            f_WinTime = Time.time;
            fadeout.SetTrigger("Fadde");
        }

        if(b_WinCondition)
        {
            Debug.Log("Win Con");
            
            if(Time.time >= f_WinTime + f_ExitTime)
            {
                Debug.Log("LO");
                EndGame();
            }

            return;
        }

		//Debug.Log (i_Location);
		if(Input.GetKeyDown(KeyCode.D))
		{
			VO_SwitchRight ();
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			VO_SwitchLeft ();
		}

		t_This.Translate (transform.forward * f_Speed);

		if(!b_OnLane && b_MoveRight && i_TargetLocation - transform.position.x > 0.01f)
		{
			VO_MoveRight ();
		}

		if(!b_OnLane && !b_MoveRight && transform.position.x - i_TargetLocation > 0.01f)
		{
			VO_MoveLeft ();
		}

		if(Mathf.Abs(i_TargetLocation - transform.position.x) <= 0.01f)
		{

			b_OnLane = true;

		}

        if (Input.touchCount > 0)
        {
            myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                //Tap ();
                v2TouchOrigin = myTouch.position;
            }

            if (myTouch.phase == TouchPhase.Ended || myTouch.phase == TouchPhase.Canceled)
            {
                v2TouchFinal = myTouch.position;
                v2TouchDelta = v2TouchFinal - v2TouchOrigin;
                bSwiped = false;
            }

            //Deadzone
            if (v2TouchDelta.magnitude > fDeadzoneDiameter && bSwiped == false)
            {
                float x = v2TouchDelta.x;
                float y = v2TouchDelta.y;
                //Swipe Horizontal
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        VO_SwitchLeft();
                    }
                    else {
                        VO_SwitchRight();
                    }
                }
                bSwiped = true;
            }
        }

    }

	void VO_MoveRight()
	{
		transform.Translate (transform.right * 0.05f);
	}

	void VO_MoveLeft()
	{
		transform.Translate (-transform.right * 0.05f);
	}

	void VO_SwitchRight()
	{
		if(i_Location == 2)
		{
			Debug.Log ("ALREADY RIGHT");
		}

		if(i_Location == 0)
		{
			b_OnLane = false;
			b_MoveRight = true;
			i_Location++;
			i_TargetLocation = 0;
			//t_This.position = new Vector3 (0, t_This.position.y, t_This.position.z);

		}
		else if(i_Location == 1)
		{
			b_OnLane = false;
			b_MoveRight = true;
			i_Location++;
			i_TargetLocation = 1;
			//t_This.position = new Vector3 (1, t_This.position.y, t_This.position.z);
		
		}
	}

	void VO_SwitchLeft()
	{
		if(i_Location == 0)
		{
			Debug.Log ("ALREADY Left");
		}

		if(i_Location == 1)
		{
			b_OnLane = false;
			i_Location--;
			i_TargetLocation = -1;
			b_MoveRight = false;

			//t_This.position = new Vector3 (-1, t_This.position.y, t_This.position.z);
		}

		else if(i_Location == 2)
		{
			b_OnLane = false;
			i_Location--;
			i_TargetLocation = 0;
			b_MoveRight = false;
			//t_This.position = new Vector3 (0, t_This.position.y, t_This.position.z);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.CompareTag("RoadObstacle"))
		{
			VO_GetHit ();
		}
	}

	void VO_GetHit()
	{
		Debug.Log ("Gıt Hit");

        aus.Play();

        i_Health--;

        if(i_Health <= 0)
        {
            EndGame();
        }

		// if dead, reset loadedmoney
		// if no dead, PVO_EarnMoney, reset loaded money;
	}

    void EndGame()
    {
       
        PlayerDataHandler.instance.PVO_RoundUp();
        Debug.Log("End Called");
        if(b_WinCondition)
        {
            Success();
        }
        else
        {
            RIP();
        }



    }
	void RIP()
	{
		PlayerDataHandler.instance.PVO_ResetLoadedMoney ();
        PlayerDataHandler.instance.PVO_SpendMoney(10 + PlayerDataHandler.instance.i_RoundCount * 1);
        SceneManager.LoadScene("sceneMain");
	}

	void Success()
	{
		PlayerDataHandler.instance.PVO_EarnMoney (PlayerDataHandler.instance.i_LoadedMoney);
		PlayerDataHandler.instance.PVO_ResetLoadedMoney ();
        PlayerDataHandler.instance.PVO_SpendMoney(10 + PlayerDataHandler.instance.i_RoundCount * 1);
        SceneManager.LoadScene("sceneMain");

    }

}
