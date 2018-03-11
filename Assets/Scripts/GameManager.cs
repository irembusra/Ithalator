using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject p;
    public GameObject a;
	
	void Start ()
    {
		
	}
	
	
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");

    }
    public void HakkımızdaPanel()
    {
        
            p.SetActive(true);
        
        
    }
    public void Ayarlar()
    {
       

            a.SetActive(true);
        

    }

    public void Kapat()
    {
        if (a.activeSelf)
        {
            a.SetActive(false);
        }
        if (p.activeSelf)
        {
            p.SetActive(false);
        }
    }
}
