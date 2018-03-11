using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GostergePanel : MonoBehaviour {
    public GameObject Gostergen;
    public GameObject go_Button1;
    public GameObject go_Button2;
    public GameObject go_Button3;

    public Text[] GostergeTextArray;
    Fiyat fiyat;
    void Start()
    {
        fiyat = GameObject.Find("GameManager2").GetComponent<Fiyat>();
        if (PlayerDataHandler.instance.b_Invesments[1] == false)
        {
            go_Button1.GetComponent<Button>().interactable = false;

        }
        else
        {
            go_Button1.GetComponent<Button>().interactable = true;

        }
        if (PlayerDataHandler.instance.b_Invesments[2] == false)
        {
            go_Button2.GetComponent<Button>().interactable = false;
        }
        else
        {

            go_Button2.GetComponent<Button>().interactable = true;
        }
        if (PlayerDataHandler.instance.b_Invesments[3] == false)
        {
            go_Button3.GetComponent<Button>().interactable = false;
        }
        else
        {
            go_Button3.GetComponent<Button>().interactable = true;
        }
        
    }
    void Update ()
    {
		
	}
    public void Ikon()
    {
        Gostergen.SetActive(true);
    }
    public void Button1()
        
    {
        fiyat.i = 1;
        GostergeTextArray[0].text = "TARIM";
        GostergeTextArray[1].text = ""  +fiyat.i_T_Gider;
        GostergeTextArray[2].text = ""  + fiyat.i_T_Gelir;
        GostergeTextArray[3].text = "" + fiyat.i_T_Kilo;
    }
    public void Button2()

    {
        fiyat.i = 1;
        GostergeTextArray[0].text = "HAYVANCILIK";
        GostergeTextArray[1].text = ""  + fiyat.i_H_Gider;
        GostergeTextArray[2].text = ""   + fiyat.i_H_Gelir;
        GostergeTextArray[3].text = "" + fiyat.i_H_Kilo;
    }
    public void Button3()

    {
        fiyat.i = 1;
        GostergeTextArray[0].text = "HAFiF SANAYi";
        GostergeTextArray[1].text = ""  + fiyat.i_HS_Gider;
        GostergeTextArray[2].text = ""   + fiyat.i_HS_Gelir;
        GostergeTextArray[3].text = "" + fiyat.i_HS_Kilo;
    }
    public void Button4()

    {
        fiyat.i = 1;
        GostergeTextArray[0].text = "AĞIR SANAYİ";
        GostergeTextArray[1].text = ""  + fiyat.i_AS_Gider;
        GostergeTextArray[2].text = ""  + fiyat.i_AS_Gelir;
        GostergeTextArray[3].text = "" + fiyat.i_AS_Kilo;
    }

    public void Kapat()
    {

        Gostergen.SetActive(false);

    }

}
