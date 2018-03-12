using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Uretim : MonoBehaviour {

    private static Uretim _This;
    public static Uretim instance
    {
        get
        {
            if (_This == null)
            {
                _This = GameObject.FindObjectOfType<Uretim>();
            }

            return _This;
        }
    }

    public int i;
    public int i_toplamPara;
    public int i_toplamTutar;
    public int i_toplamlGelir;
    public int i_ToplamKilo;
    public int i_maxKilo;
    public int i_kiloFark;

    public Text t_toplamTutar;
    public Text t_toplamPara;
    public Text t_toplamKilo;

    public Text[] a_textArray;

    //Tarım//

    public bool b_isPlaced_t= false;
    public bool b_TextRemoved_t = false;

    public int i_gider_t;
    public int i_gelir_t;
    public int i_miktar_t;
    public int i_array_t;//array index
    public int i_totalTutar_t;
    public int i_kazanc_t;
    public int i_kilo_t;
    public int i_totalKilo_t;
    public int i_urunTotalTutar_t;
    public int i_urunTotalKilo_t;

    public string s_text_t;

    //Hayvancılık//

    public bool b_isPlaced_h = false;
    public bool b_TextRemoved_h = false;

    public int i_gider_h;
    public int i_gelir_h;
    public int i_miktar_h;
    public int i_array_h;//array index
    public int i_totalTutar_h;
    public int i_kazanc_h;
    public int i_kilo_h;
    public int i_totalKilo_h;
    public int i_urunTotalTutar_h;
    public int i_urunTotalKilo_h;

    public string s_text_h;

    //Hafif Sanayi//

    public bool b_isPlaced_hs= false;
    public bool b_TextRemoved_hs = false;

    public int i_gider_hs;
    public int i_gelir_hs;
    public int i_miktar_hs;
    public int i_array_hs;//array index
    public int i_totalTutar_hs;
    public int i_kazanc_hs;
    public int i_kilo_hs;
    public int i_totalKilo_hs;
    public int i_urunTotalTutar_hs;
    public int i_urunTotalKilo_hs;

    public string s_text_hs;


    //Agır Sanayi//

    public bool b_isPlaced_as = false;
    public bool b_TextRemoved_as = false;

    public int i_gider_as;
    public int i_gelir_as;
    public int i_miktar_as;
    public int i_array_as;//array index
    public int i_totalTutar_as;
    public int i_kazanc_as;
    public int i_kilo_as;
    public int i_totalKilo_as;
    public int i_urunTotalTutar_as;
    public int i_urunTotalKilo_as;

    public string s_text_as;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void F_Artı(bool b_isPlaced, bool b_TextRemoved, int i_gider, int i_gelir, int i_miktar, int i_array, int i_totalTutar, int i_kazanc, int i_kilo, int i_totalKilo, int i_urunTotalTutar, int i_urunTotalKilo, string s_text)
    {

        if(i_toplamPara>=i_gider&& i_kiloFark >= i_kilo) { 
        bool b_isPlacedArtı = false;
        i_totalKilo += i_kilo;
        i_miktar++;

        if (b_TextRemoved == true)
        {
            a_textArray[i_array].text = s_text;

        }
        for (int j = 0; j < a_textArray.Length; j++)
        {
            if (b_isPlacedArtı == false && b_isPlaced == false)
            {

                if (a_textArray[j].text == "")

                {
                    a_textArray[j].text = s_text;

                    b_isPlaced = true;
                    b_isPlacedArtı = true;
                    i_array = j;
                }
            }

        }

    }
    else if(i_toplamPara<=i_gider)
        {
            //yetersizbakiyepanel();

        }

        else if(i_kiloFark<=i_totalKilo)
        {

            //kilopanel();
         }

        //hesaplama
        //KiloHesap
    }
    public void F_Eksi(bool b_isPlaced, bool b_TextRemoved, int i_gider, int i_gelir, int i_miktar, int i_array, int i_totalTutar, int i_kazanc, int i_kilo, int i_totalKilo, int i_urunTotalTutar, int i_urunTotalKilo, string s_text)
    {
        if(i_miktar>0&& i_miktar != 0)
        {
            if(b_isPlaced==true)
            {
                i_miktar--;
                i_totalTutar -= i_gider;
                i_toplamPara += i_gider;
                i_totalKilo -= i_kilo;


            }
        }
        //hesaplama
        //KiloHesap
    }
    public void F_Remove(bool b_isPlaced, bool b_TextRemoved, int i_gider, int i_gelir, int i_miktar, int i_array, int i_totalTutar, int i_kazanc, int i_kilo, int i_totalKilo, int i_urunTotalTutar, int i_urunTotalKilo, string s_text)
    {
        if(b_isPlaced==true)
        {
            b_isPlaced = false;
            a_textArray[i_array].text = "URUN YOK";
            i_urunTotalTutar = i_gider * i_miktar;
            i_urunTotalKilo = i_kilo - i_miktar;
            i_toplamPara += i_urunTotalTutar;
            i_ToplamKilo -= i_urunTotalKilo;

            b_TextRemoved = true;
            i_miktar = 0;


        }
        //hesaplama
        //KiloHesap
    }

    public void F_TarımArtı()
    {
        F_Artı(b_isPlaced_t, b_TextRemoved_t, i_gider_t, i_gelir_t, i_miktar_t, i_array_t, i_totalTutar_t, i_kazanc_t, i_kilo_t, i_totalKilo_t, i_urunTotalTutar_t, i_urunTotalKilo_t, s_text_t);
    }
    public void F_TarımEksi()
    {
        F_Eksi(b_isPlaced_t, b_TextRemoved_t, i_gider_t, i_gelir_t, i_miktar_t, i_array_t, i_totalTutar_t, i_kazanc_t, i_kilo_t, i_totalKilo_t, i_urunTotalTutar_t, i_urunTotalKilo_t, s_text_t);
    }
    public void F_TarımRemove()
    {
        F_Remove(b_isPlaced_t, b_TextRemoved_t, i_gider_t, i_gelir_t, i_miktar_t, i_array_t, i_totalTutar_t, i_kazanc_t, i_kilo_t, i_totalKilo_t, i_urunTotalTutar_t, i_urunTotalKilo_t, s_text_t);

    }



    public void F_HayvancılıkArtı()
    {
        F_Artı(b_isPlaced_h, b_TextRemoved_h, i_gider_h, i_gelir_h, i_miktar_h, i_array_h, i_totalTutar_h, i_kazanc_h, i_kilo_h, i_totalKilo_h, i_urunTotalTutar_h, i_urunTotalKilo_h, s_text_h);
    }
    public void F_HayvancılıkEksi()
    {
        F_Eksi(b_isPlaced_h, b_TextRemoved_h, i_gider_h, i_gelir_h, i_miktar_h, i_array_h, i_totalTutar_h, i_kazanc_h, i_kilo_h, i_totalKilo_h, i_urunTotalTutar_h, i_urunTotalKilo_h, s_text_h);
    }

    public void F_HayvancılıkRemove()
    {
        F_Remove(b_isPlaced_h, b_TextRemoved_h, i_gider_h, i_gelir_h, i_miktar_h, i_array_h, i_totalTutar_h, i_kazanc_h, i_kilo_h, i_totalKilo_h, i_urunTotalTutar_h, i_urunTotalKilo_h, s_text_h);
    }



    public void F_HafifSanayiArtı()
    {
        F_Artı(b_isPlaced_hs, b_TextRemoved_hs, i_gider_hs, i_gelir_hs, i_miktar_hs, i_array_hs, i_totalTutar_hs, i_kazanc_hs, i_kilo_hs, i_totalKilo_hs, i_urunTotalTutar_hs, i_urunTotalKilo_hs, s_text_hs);
    }
    public void F_HafifSanayiEksi()
    {
        F_Eksi(b_isPlaced_hs, b_TextRemoved_hs, i_gider_hs, i_gelir_hs, i_miktar_hs, i_array_hs, i_totalTutar_hs, i_kazanc_hs, i_kilo_hs, i_totalKilo_hs, i_urunTotalTutar_hs, i_urunTotalKilo_hs, s_text_hs);
    }
    public void F_HafifSanayiRemove()
    {

        F_Remove(b_isPlaced_hs, b_TextRemoved_hs, i_gider_hs, i_gelir_hs, i_miktar_hs, i_array_hs, i_totalTutar_hs, i_kazanc_hs, i_kilo_hs, i_totalKilo_hs, i_urunTotalTutar_hs, i_urunTotalKilo_hs, s_text_hs);
    }


    public void F_AgırSanayiArtı()
    {
        F_Artı(b_isPlaced_as, b_TextRemoved_as, i_gider_as, i_gelir_as, i_miktar_as, i_array_as, i_totalTutar_as, i_kazanc_as, i_kilo_as, i_totalKilo_as, i_urunTotalTutar_as, i_urunTotalKilo_as, s_text_as);

    }
    public void F_AgırSanayiEksi()
    {

        F_Eksi(b_isPlaced_as, b_TextRemoved_as, i_gider_as, i_gelir_as, i_miktar_as, i_array_as, i_totalTutar_as, i_kazanc_as, i_kilo_as, i_totalKilo_as, i_urunTotalTutar_as, i_urunTotalKilo_as, s_text_as);
    }
    public void F_AgırSanayiRemove()
    {
        F_Remove(b_isPlaced_as, b_TextRemoved_as, i_gider_as, i_gelir_as, i_miktar_as, i_array_as, i_totalTutar_as, i_kazanc_as, i_kilo_as, i_totalKilo_as, i_urunTotalTutar_as, i_urunTotalKilo_as, s_text_as);

    }
    }
