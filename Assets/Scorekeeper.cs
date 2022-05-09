using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{

	int score;
	string playerName;
	[SerializeField] Text scoreTxt;
	
    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
	playerName = PersistentData.Instance.GetName();
	DisplayScore();
    }

	public void DisplayScore()
    {
        scoreTxt.text = playerName + "'s Score: " + score;
    }

	public void UpdateScore(int addend){
        	score += addend;
        	DisplayScore();
        	PersistentData.Instance.SetScore(score);
	}
}
