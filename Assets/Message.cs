using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Message : MonoBehaviour
{
	[SerializeField] Text message;
	[SerializeField] Text score;

    // Start is called before the first frame update
    void Start()
    {
        message.text = "Great job, " + PersistentData.Instance.GetName()+ "!";
	score.text = "Final Score: " + PersistentData.Instance.GetScore();
    }
}
