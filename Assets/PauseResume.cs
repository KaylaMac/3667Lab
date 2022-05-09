using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{

	GameObject[] pauseMode;
	GameObject[] resumeMode;

	GameObject highScores;
	GameObject finalPanel;

    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("showInPause");
	resumeMode = GameObject.FindGameObjectsWithTag("showInPlay");

	foreach (GameObject g in pauseMode)
            g.SetActive(false);

	highScores = GameObject.Find("HighScoresPanel");
	finalPanel = GameObject.Find("FinalPanel");

	highScores.SetActive(false);
    }

	public void Pause()
    {
        Time.timeScale = 0f;

        foreach (GameObject g in resumeMode)
            g.SetActive(false);

        foreach (GameObject g in pauseMode)
            g.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in resumeMode)
            g.SetActive(true);

    }

    public void MainMenu()
    {
	Time.timeScale = 1f;
	PersistentData.Instance.SetScore(0);
        SceneManager.LoadScene("Menu");
    }

	public void ShowHighScores(){
		highScores.SetActive(true);
		finalPanel.SetActive(false);
	}
}
