using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

	GameObject instructions;
	GameObject main;
	GameObject settings;

	[SerializeField] InputField inputName;	

    // Start is called before the first frame update
    void Start()
    {
        instructions = GameObject.Find("InstructionsPanel");
	main = GameObject.Find("MainMenuButtons");
	settings = GameObject.Find("SettingsPanel");
	
	instructions.SetActive(false);
	settings.SetActive(false);
    }

	public void StartGame(){
		// play button should not work unless input is received
		if(inputName.text != ""){
			string s = inputName.text;
        		PersistentData.Instance.SetName(s);
			SceneManager.LoadScene("Level1");
		}
	}

	public void ShowInstructions(){
		instructions.SetActive(true);
		main.SetActive(false);
	}

	public void HideInstructions(){
		instructions.SetActive(false);
		main.SetActive(true);
	}

	public void ShowSettings(){
		settings.SetActive(true);
		main.SetActive(false);
	}

	public void HideSettings(){
		settings.SetActive(false);
		main.SetActive(true);
	}

}
