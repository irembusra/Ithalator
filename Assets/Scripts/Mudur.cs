using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mudur : MonoBehaviour
{
    public GameObject[] mudurArray;
    Fiyat fiyat;
    float timer;

    public float duration;

    void Start()
    {
        fiyat = GameObject.Find("GameManager2").GetComponent<Fiyat>();

    }
    // Update is called once per frame
    void Update()
    {
        if (fiyat.i == 1)
        {
            if (timer >= duration)
            {
                fiyat.i = 0;


            }
            else if (timer < duration)
            {

                MudurSol();


            }

        }

        else if (fiyat.i == 0)
        {
            MudurDefoult();
        }



        timer += Time.deltaTime;

    }
    void MudurDefoult()
    {
        mudurArray[0].SetActive(true);
        mudurArray[1].SetActive(false);
        mudurArray[2].SetActive(false);
        timer = 0;

    }
  

    


    void MudurSol()
    {
        mudurArray[0].SetActive(false);
        mudurArray[1].SetActive(true);
        mudurArray[2].SetActive(false);


    }

}