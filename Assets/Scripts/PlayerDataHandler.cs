using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerDataHandler : MonoBehaviour
{

    private static PlayerDataHandler _This;

    public static PlayerDataHandler instance
    {
        get
        {
            if (_This == null)
            {
                _This = GameObject.FindObjectOfType<PlayerDataHandler>();
            }

            return _This;
        }
    }


    private PlayerData playerData;
    public int i_MyBudget;
	public int i_LoadedMoney;
	public bool[] b_Invesments;
    public int i_RoundCount;

    private bool b_GameInitializedFirstTime;

    //Path filePath = Application.persistentDataPath;





    void Awake()
    {
		if(_This == null)
		{
			_This = this;
		}
        InitializeGame();
    }

	public void PVO_ResetLoadedMoney()
	{
		i_LoadedMoney = 0;
		SaveData ();
	}

	public void PVO_LoadMoney(int amount)
	{
		i_LoadedMoney = amount;
		SaveData ();
	}

	public void PVO_SpendMoney(int amount)
	{
		i_MyBudget -= amount;
		SaveData ();
	}

	public void PVO_EarnMoney(int amount)
	{
		i_MyBudget += amount;
		SaveData ();
	}

	public void PVO_Invest(int index)
	{
		b_Invesments [index] = true;
		SaveData ();
	}

    public void PVO_RoundUp()
    {
        i_RoundCount++;
        SaveData();
    }


    public void RestartData()
    {
        b_GameInitializedFirstTime = true;
        SaveData();
        InitializeGame();
    }


    void InitializeGame()
    {
        Debug.Log("Player Data Handler Initialization");
        LoadData();

        if (playerData != null)
        {
            b_GameInitializedFirstTime = playerData.GetGameInitialized();
        }
        else
        {
            b_GameInitializedFirstTime = true;
        }

        if (b_GameInitializedFirstTime)
        {
            Debug.Log("First Time Initialization");
            b_GameInitializedFirstTime = false;

			b_Invesments = new bool[4];

			i_MyBudget = 10000;
			i_LoadedMoney = 0;
            i_RoundCount = 1;
            
            //Default Value Stuff

			b_Invesments [0] = true;
			for(int i = 1; i < b_Invesments.Length; i++)
			{
				b_Invesments [i] = false;
			}

            playerData = new PlayerData();


			playerData.SetBudget(i_MyBudget);
			playerData.SetInvesments (b_Invesments);

            playerData.SetGameInitialized(b_GameInitializedFirstTime);

            SaveData();
            LoadData();

        }

    }

    void SaveData()
    {
        Debug.Log("Saving Data");

        FileStream myFile = null;
        try
        {
            BinaryFormatter binaryForm = new BinaryFormatter();

            myFile = File.Create(Application.persistentDataPath + "/PlayerData.dat");

            if (playerData != null)
            {
				playerData.SetBudget(i_MyBudget);
				playerData.SetLoadedMoney(i_LoadedMoney);
				playerData.SetInvesments(b_Invesments);
                playerData.SetRound(i_RoundCount);

                playerData.SetGameInitialized(b_GameInitializedFirstTime);

                binaryForm.Serialize(myFile, playerData);
            }
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (myFile != null)
            {
                myFile.Close();
            }
        }

    }

    public void PVO_ForceLoad()
    {
        LoadData();
    }

    void LoadData()
    {
        Debug.Log("Loading Data");

        FileStream myFile = null;

        try
        {
            BinaryFormatter binaryForm = new BinaryFormatter();

            myFile = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);

            playerData = (PlayerData)binaryForm.Deserialize(myFile);

            if (playerData != null)
            {
				i_MyBudget = playerData.GetBudget();
				i_LoadedMoney = playerData.GetLoadedMoney();
				b_Invesments = playerData.GetInvesments();
                i_RoundCount = playerData.GetRound();

                b_GameInitializedFirstTime = playerData.GetGameInitialized();
            }
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (myFile != null)
            {
                myFile.Close();
            }
        }
    }

}
