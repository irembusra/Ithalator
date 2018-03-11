using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class PlayerData {

	private int i_MyBudget;
	private int i_LoadedMoney;
	private bool[] b_Invesments;
    private int i_RoundCount;

	private bool b_GameInitialized;

	//Coins
    public void SetRound(int round)
    {
        
        this.i_RoundCount = round;
    }

    public int GetRound()
    {
        return this.i_RoundCount;
    }

    

	public void SetBudget(int goldCoins)
	{
		this.i_MyBudget = goldCoins;
	}
	public int GetBudget()
	{
		return this.i_MyBudget;
	}

	public void SetLoadedMoney(int amount)
	{
		this.i_LoadedMoney = amount;
	}
	public int GetLoadedMoney()
	{
		return this.i_LoadedMoney;
	}

	public void SetInvesments(bool[] invesments)
	{
		this.b_Invesments = invesments;
	}

	public bool[] GetInvesments()
	{
		return this.b_Invesments;
	}

	//Game Initialized
	public void SetGameInitialized(bool isGameInitialized)
	{
		this.b_GameInitialized = isGameInitialized;
	}
	public bool GetGameInitialized()
	{
		return this.b_GameInitialized;
	}

}
