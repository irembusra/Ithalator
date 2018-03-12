using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour {
    public GameObject[] go_removeButton;
    public int i;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        F_RemoveAçKapa();
	}
    public void F_Remove()
    {

        for (int k = 0; k < 4; k++)

            go_removeButton[k] = go_removeButton[i];
        {

            if (Uretim.instance.i_array_t == i)
            {
                Uretim.instance.F_TarımRemove();
            }

            if (Uretim.instance.i_array_h == i)
            {
                Uretim.instance.F_HayvancılıkRemove();

            }
            if(Uretim.instance.i_array_hs==i)
            {

                Uretim.instance.F_HafifSanayiRemove();
            }
            if(Uretim.instance.i_array_as==i)
            {
                Uretim.instance.F_AgırSanayiRemove();

            }


        }

    }

    public void F_RemoveAçKapa()
    {
        for(int i=0; i<Uretim.instance.a_textArray.Length; i++)
        {
            int j;
            j = i;
            if(Uretim.instance.a_textArray[i].text=="")
            {
                go_removeButton[j].SetActive(false);
            }
            else
            {
                go_removeButton[j].SetActive(true);
            }

        }
    }
}
