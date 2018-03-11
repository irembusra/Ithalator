using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fiyat : MonoBehaviour
{

    // -- Genel Değerler--//


    public int i;
    public int i_totalPara = 100;
    public int i_totalTutar;
    public int i_totalGelir;
    public int i_TotalKilo;
    public int i_MaxKilo;
    public int i_KiloFark;

    public Text t_totalTutar;
    public Text t_totalPara;
    public Text t_totalKilo;

    public Text[] textArray;

    public GameObject YetersizBakiye;// yetersi bakiye paneli için
    public GameObject EndList;
    public GameObject Kilo;

    public GameObject go_HayvancılıkArtı;
    public GameObject go_HafifSanayiArtı;
    public GameObject go_AgırSanayiArtı;
    public GameObject go_HayvancılıkEksi;
    public GameObject go_HafifSanayiEksi;
    public GameObject go_AgırSanayiEksi;
    public GameObject go_GonderButonu;
    public GameObject[] removeArray;//remove buttonlarının içine alıyor

     // -- Tarım Değerler--//


    public bool is_T_Placed = false;
    public bool is_T_TextRemoved = false;

    public int i_T_Gider;
    public int i_T_Gelir;
    public int i_T_Miktar;
    public int i_T_Array;//array index
    public int i_T_TotalTutar;
    public int i_T_Kazanc = 0;
    public int i_T_Kilo;
    public int i_T_TotalKilo;

    public string t_Text;

    //--Hayvancılık Değerler--//


    public bool is_H_Placed = false;
    public bool is_H_TextRemoved = false;

    public int i_H_Gider;
    public int i_H_Gelir;
    public int i_H_Miktar;
    public int i_H_Array;//array index
    public int i_H_TotalTutar;
    public int i_H_Kazanc = 0;
    public int i_H_Kilo;
    public int i_H_TotalKilo;

    public string h_Text;

    public int i_H_remove;

    //--HafifSanayi Değerler--//

    public bool is_HS_Placed = false;
    public bool is_HS_TextRemoved = false;

    public int i_HS_Gider;
    public int i_HS_Gelir;
    public int i_HS_Miktar;
    public int i_HS_Array;//array index
    public int i_HS_TotalTutar;
    public int i_HS_Kazanc = 0;
    public int i_HS_Kilo;
    public int i_HS_TotalKilo;

    public string hs_Text;

    public int i_HS_remove;

    //--AğırSanayi Değerler--//

    public bool is_AS_Placed = false;
    public bool is_AS_TextRemoved = false;

    public int i_AS_Gider;
    public int i_AS_Gelir;
    public int i_AS_Miktar;
    public int i_AS_Array;//array index
    public int i_AS_TotalTutar;
    public int i_AS_Kazanc = 0;
    public int i_AS_Kilo;
    public int i_AS_TotalKilo;

    public string as_Text;

    public int i_AS_remove;

    // Use this for initialization
    void Start()
    {
       
        if(PlayerDataHandler.instance.b_Invesments[1] == false)
        {
            go_HayvancılıkArtı.GetComponent<Button>().interactable = false;
            go_HayvancılıkEksi.GetComponent<Button>().interactable = false;
        }
        else
        {
            go_HayvancılıkArtı.GetComponent<Button>().interactable = true;
            go_HayvancılıkEksi.GetComponent<Button>().interactable = true;
        }
        if (PlayerDataHandler.instance.b_Invesments[2] == false)
        {
            go_HafifSanayiArtı.GetComponent<Button>().interactable = false;
            go_HafifSanayiEksi.GetComponent<Button>().interactable = false;
        }
        else
        {

            go_HafifSanayiArtı.GetComponent<Button>().interactable = true;
            go_HafifSanayiEksi.GetComponent<Button>().interactable = true;
        }
        if (PlayerDataHandler.instance.b_Invesments[3] == false)
        {
            go_AgırSanayiArtı.GetComponent<Button>().interactable = false;
            go_AgırSanayiEksi.GetComponent<Button>().interactable = false;
        }
        else
        {

            go_AgırSanayiArtı.GetComponent<Button>().interactable = true;
            go_AgırSanayiEksi.GetComponent<Button>().interactable = true;
        }

        i_totalPara = PlayerDataHandler.instance.i_MyBudget;
    }
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerDataHandler.instance.RestartData();
        }

        if (i_totalGelir == 0)
        {
            go_GonderButonu.GetComponent<Button>().interactable = false;

        }
        else
        {

            go_GonderButonu.GetComponent<Button>().interactable = true;
        }
            // Debug.Log(i_AS_Array);
            // Debug.Log(is_AS_Placed);

            RemoveAçKapa();//remove buttonlarının textle birlikte gelmesi için
       
      
        t_totalTutar.text = "Tutar : " + i_totalTutar;
        t_totalPara.text = ""+ i_totalPara;
        t_totalKilo.text = "Kilo : " + i_TotalKilo;
        i_KiloFark = i_MaxKilo - i_TotalKilo;

        //--Tarım --//

        if (is_T_Placed)
        {
            textArray[i_T_Array].text = "Tarım x " + i_T_Miktar;

            if (i_T_Miktar == 0)
            {
                 textArray[i_T_Array].text = "ÜRÜN YOK";
            }
         }

        //--Hayvancılık--//

        if (is_H_Placed)
        {
            textArray[i_H_Array].text = "Hayvancılık x " + i_H_Miktar;

            if (i_H_Miktar == 0)
            {
                textArray[i_H_Array].text = "ÜRÜN YOK";
            }
        }

        //--HafifSanayi--//

        if (is_HS_Placed)
        {
            textArray[i_HS_Array].text = "Hafif Sanayi x " + i_HS_Miktar;

            if (i_HS_Miktar == 0)
            {
                textArray[i_HS_Array].text = "ÜRÜN YOK";
            }
        }

        //--AğırSanayi--//

        if (is_AS_Placed)
        {
            textArray[i_AS_Array].text = "Ağır Sanayi x " + i_AS_Miktar;

            if (i_AS_Miktar == 0)
            {
                textArray[i_AS_Array].text = "ÜRÜN YOK";
            }
        }
    }

    //--TARIM FOKSİYONLARI--//

    public void TarimArtı()
    {
         

        if (i_totalPara >= i_T_Gider && i_KiloFark >=i_T_Kilo)
        {

            i = 1;

            bool isPlacedArtı = false;
            i_T_TotalKilo += i_T_Kilo;
            i_T_Miktar++;
          
            i_T_TotalTutar += i_T_Gider;
            i_totalPara -= i_T_Gider;
           

            if (is_T_TextRemoved == true)
            {
                textArray[i_T_Array].text = t_Text; ;
            }
            for (int i = 0; i < textArray.Length; i++)
            {
                if (isPlacedArtı == false && is_T_Placed == false)
                {
                    if (textArray[i].text == "")
                    {
                        textArray[i].text = t_Text;

                        isPlacedArtı = true;
                        is_T_Placed = true;
                        i_T_Array = i;
                    }
                }
            }
        }
        else if(i_totalPara <= i_T_Gider)
        {
            YetersizBakiyePanel();

        }

        else if(i_KiloFark <= i_TotalKilo)
        {
           
            Kilopanel();
        }

        Hesaplama();
        KiloHesap();

    }
    public void TarimEksi()
    {

       
        if (i_T_Miktar > 0 && i_T_Miktar != 0)
        {
            if (is_T_Placed == true)
            {
                i_T_Miktar--;
                i_T_TotalTutar -= i_T_Gider;
                i_totalPara += i_T_Gider;
                i_T_TotalKilo -= i_T_Kilo;
                i = 1;
            }
        }
        Hesaplama();
        KiloHesap();
    }
    public void TarımRemove()
    {
       
        if (is_T_Placed == true)
        {
            int i_TarımTotalTutar;
            int i_TarımTotalKilo;
            is_T_Placed = false;

            textArray[i_T_Array].text = "ÜRÜN YOK";

            i_TarımTotalTutar = i_T_Gider * i_T_Miktar;
            i_TarımTotalKilo = i_T_Kilo * i_T_Miktar;
            i_T_TotalTutar -= i_TarımTotalTutar;
            i_totalPara += i_TarımTotalTutar;
            i_T_TotalKilo -= i_TarımTotalKilo;

            is_T_TextRemoved = true;
            i_T_Miktar = 0;
            i = 0;
        }
        Hesaplama();
        KiloHesap();
    }
    //--Hayvancılık Fonksiyonları--//

    public void HayvancılıkArtı()
    {


        

        if (i_totalPara >= i_H_Gider && i_KiloFark >= i_H_Kilo)
            
        {
            i = 1;
            bool isPlacedArtı = false;
            
            i_H_Miktar++;
            i_H_TotalKilo += i_H_Kilo;
            i_H_TotalTutar += i_H_Gider;
            i_totalPara -= i_H_Gider;
           
            if (is_H_TextRemoved == true)
            {
                textArray[i_H_Array].text = h_Text; ;
            }
            for (int i = 0; i < textArray.Length; i++)
            {
                if (isPlacedArtı == false && is_H_Placed == false)
                {
                    if (textArray[i].text == "")
                    {
                        textArray[i].text = h_Text;

                        isPlacedArtı = true;
                        is_H_Placed = true;
                        i_H_Array = i;
                    }
                }
            }
        }
        else if (i_totalPara <= i_H_Gider)
        {
            YetersizBakiyePanel();

        }
        else
        {
           
            Kilopanel();
        }
        Hesaplama();
        KiloHesap();
    }
    public void HayvancılıkEksi()
    {


        i = 1;
        if (i_H_Miktar > 0 && i_H_Miktar != 0)
        {
            if (is_H_Placed == true)
            {
                i_H_Miktar--;
                i_H_TotalTutar -= i_H_Gider;
                i_totalPara += i_H_Gider;
                i_H_TotalKilo -= i_H_Kilo; 
            }
        }
        Hesaplama();
        KiloHesap();
    }
    public void HayvancılıkRemove()
    {
        if (is_H_Placed == true)
        {
            i = 0;
            int i_HayvancilikTotalTutar;
            int i_HayvancilikTotalKilo;
            is_H_Placed = false;

            textArray[i_H_Array].text = "ÜRÜN YOK";

            i_HayvancilikTotalTutar = i_H_Gider * i_H_Miktar;
            i_HayvancilikTotalKilo = i_H_Kilo * i_H_Miktar;
            i_H_TotalTutar -= i_HayvancilikTotalTutar;
            i_totalPara += i_HayvancilikTotalTutar;
            i_H_TotalKilo -= i_HayvancilikTotalKilo;

            is_H_TextRemoved = true;
            i_H_Miktar = 0;
        }
        Hesaplama();
        KiloHesap();
    }

    //--HafifSanayi Fonksiyonları--//

    public void HafifSanayiArtı()
    {

   

        if (i_totalPara >= i_HS_Gider && i_KiloFark >= i_HS_Kilo)
        {
            i = 1;
            bool isPlacedArtı = false;
            i_HS_TotalKilo += i_HS_Kilo;
            i_HS_Miktar++;
            i_HS_TotalTutar += i_HS_Gider;
            i_totalPara -= i_HS_Gider;
            
            if (is_HS_TextRemoved == true)
            {
                textArray[i_HS_Array].text = hs_Text; ;
            }
            for (int i = 0; i < textArray.Length; i++)
            {
                if (isPlacedArtı == false && is_HS_Placed == false)
                {
                    if (textArray[i].text == "")
                    {
                        textArray[i].text = hs_Text;

                        isPlacedArtı = true;
                        is_HS_Placed = true;
                        i_HS_Array = i;
                    }
                }
            }
        }
        else if (i_totalPara <= i_HS_Gider)
        {
            YetersizBakiyePanel();

        }
        else
        {
           
            Kilopanel();
        }
        Hesaplama();
        KiloHesap();
    }
    public void HafifSanayikEksi()
    {

        i = 1;

        if (i_HS_Miktar > 0 && i_HS_Miktar != 0)
        {
            if (is_HS_Placed == true)
            {
                i_HS_Miktar--;
                i_HS_TotalTutar -= i_HS_Gider;
                i_totalPara += i_HS_Gider;
                i_HS_TotalKilo -= i_HS_Kilo;
            }
        }
        Hesaplama();
        KiloHesap();
    }
    public void HafifSanayiRemove()
    {
        if (is_HS_Placed == true)
        {
            int i_HafifSanayiTotalTutar;
            int i_HafifSanayiTotalKilo;
            is_HS_Placed = false;
            i = 0;

            textArray[i_HS_Array].text = "ÜRÜN YOK";

            i_HafifSanayiTotalTutar = i_HS_Gider * i_HS_Miktar;
            i_HafifSanayiTotalKilo = i_HS_Kilo * i_HS_Miktar;
            i_HS_TotalTutar -= i_HafifSanayiTotalTutar;
            i_totalPara += i_HafifSanayiTotalTutar;
            i_HS_TotalKilo -= i_HafifSanayiTotalKilo;

            is_HS_TextRemoved = true;
            i_HS_Miktar = 0;
        }
        Hesaplama();
        KiloHesap();
    }
    //--AğırSanayi Fonksiyonları--//
    public void AgırSanayiArtı()
    {



        if (i_totalPara >= i_AS_Gider && i_KiloFark >= i_AS_Kilo)
        {
            i = 1;
            bool isPlacedArtı = false;
            i_AS_TotalKilo += i_AS_Kilo;
            i_AS_Miktar++;
            i_AS_TotalTutar += i_AS_Gider;
            i_totalPara -= i_AS_Gider;


            if (is_AS_TextRemoved == true)
            {
                textArray[i_AS_Array].text = as_Text; ;
            }
            for (int i = 0; i < textArray.Length; i++)
            {
                if (isPlacedArtı == false && is_AS_Placed == false)
                {
                    if (textArray[i].text == "")
                    {
                        textArray[i].text = as_Text;

                        isPlacedArtı = true;
                        is_AS_Placed = true;
                        i_AS_Array = i;
                    }
                }
            }
        }
        else if (i_totalPara <= i_AS_Gider)
        {
            YetersizBakiyePanel();

        }
        else
        {
            Kilopanel();
        }
        Hesaplama();
        KiloHesap();
    }

    public void AgırSanayikEksi() 

    {


        if (i_AS_Miktar > 0 && i_AS_Miktar != 0)
        {
            if (is_AS_Placed == true)
            {
                i = 1;
                i_AS_Miktar--;
                i_AS_TotalTutar -= i_AS_Gider;
                i_totalPara += i_AS_Gider;
                i_AS_TotalKilo -= i_AS_Kilo;
            }
        }
        Hesaplama();
        KiloHesap();

    
    }
    public void AgırSanayiRemove()
    {
        if (is_AS_Placed == true)
        {
            i = 0;
            int i_AgırSanayiTotalTutar;
            int i_AgırSanayiTotalKilo;
            is_AS_Placed = false;

            textArray[i_AS_Array].text = "ÜRÜN YOK";

            i_AgırSanayiTotalTutar = i_AS_Gider * i_AS_Miktar;
            i_AgırSanayiTotalKilo = i_AS_Kilo * i_AS_Miktar;
            i_AS_TotalTutar -= i_AgırSanayiTotalTutar;
            i_totalPara += i_AgırSanayiTotalTutar;
            i_AS_TotalKilo -= i_AgırSanayiTotalKilo;

            is_AS_TextRemoved = true;
            i_AS_Miktar = 0;
        }
        Hesaplama();
        KiloHesap();
    }
    //remove//
    public void FirstRemove()
    {
        if (i_T_Array == 0 && is_T_Placed==true)
        {
            TarımRemove();
        }
        else if (i_H_Array == 0 && is_H_Placed == true)
        {
            HayvancılıkRemove();
        }
        else if (i_HS_Array == 0 && is_HS_Placed == true)
        {
            HafifSanayiRemove();
        }
        else if (i_AS_Array == 0 && is_AS_Placed == true)
        {
            AgırSanayiRemove();
        }
    }
    public void SecondRemove()
    {
        if (i_T_Array == 1)
        {
            TarımRemove();
        }
        else if (i_H_Array == 1)
        {
            HayvancılıkRemove();
        }
        else if (i_HS_Array == 1)
        {
            HafifSanayiRemove();
        }
        else if (i_AS_Array == 1)
        {
            AgırSanayiRemove();
        }
    }
    public void ThirdRemove()
    {
        if (i_T_Array == 2)
        {
            TarımRemove();
        }
        else if (i_H_Array == 2)
        {
            HayvancılıkRemove();
        }
        else if (i_HS_Array == 2)
        {
            HafifSanayiRemove();
        }
        else if (i_AS_Array == 2)
        {
            AgırSanayiRemove();
        }
    }
    public void FourtRemove()
    {
        if (i_T_Array == 3)
        {
            TarımRemove();
        }
        else if (i_H_Array == 3)
        {
            HayvancılıkRemove();
        }
        else if (i_HS_Array == 3)
        {
            HafifSanayiRemove();
        }
        else if (i_AS_Array == 3)
        {
            AgırSanayiRemove();
        }
    }
    public void Hesaplama()
      {
        i_totalTutar = i_H_TotalTutar + i_T_TotalTutar + i_HS_TotalTutar + i_AS_TotalTutar;


        i_T_Kazanc = i_T_Miktar * i_T_Gelir;
        i_H_Kazanc = i_H_Miktar * i_H_Gelir;
        i_HS_Kazanc = i_HS_Miktar * i_HS_Gelir;
        i_AS_Kazanc = i_AS_Miktar * i_AS_Gelir;
        i_totalGelir = i_T_Kazanc + i_HS_Kazanc + i_AS_Kazanc + i_H_Kazanc;






    }
    public void YetersizBakiyePanel()
    {
        YetersizBakiye.SetActive(true);
    }
    public void Kapat()
    {
        if (YetersizBakiye.activeSelf)
        {
            YetersizBakiye.SetActive(false);
        }
        if(Kilo.activeSelf)
        {
            Kilo.SetActive(false);

        }
    }

    public void Kilopanel()
    {
        Kilo.SetActive(true);

    }


    public void RemoveAçKapa()
    {
        for (int i = 0; i < textArray.Length; i++)
        {
            int j;
            j = i;
            if (textArray[i].text == "")
            {
                removeArray[j].SetActive(false);
            }
            else
            {
                removeArray[j].SetActive(true);
            }
        }
    }
    public void KiloHesap()
    {
       

        i_TotalKilo = i_T_TotalKilo + i_H_TotalKilo + i_HS_TotalKilo + i_AS_TotalKilo;

    }
    public void Gönder()
    {
        

        PlayerDataHandler.instance.PVO_SpendMoney(i_totalTutar);
        PlayerDataHandler.instance.PVO_LoadMoney(i_totalGelir);
        SceneManager.LoadScene( "TruckWithAI");
    }
    public void Yatırım()
    {
         SceneManager.LoadScene("Yatırım");
    }

}

