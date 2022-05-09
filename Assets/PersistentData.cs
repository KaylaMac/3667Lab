using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

	int playerScore;
	string playerName;
	public static PersistentData Instance;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
	playerName = "";
    }

	private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        } 
    }

	public void SetScore(int s)
    {
        playerScore = s;
    }

	 public int GetScore()
    {
        return playerScore;
    }

	public void SetName(string s)
    {
        playerName = s;
    }

	 public string GetName()
    {
        return playerName;
    }
}

