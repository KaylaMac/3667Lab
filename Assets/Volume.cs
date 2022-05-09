using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

	[SerializeField] Slider volumeSlider;
	public bool isPlaying;
	AudioSource music;
	
    // Start is called before the first frame update
    void Start()
    {
        if(@PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",0);
            Load();
        }
        else
        {
            Load();
        }

	isPlaying = false;
	music = GetComponent<AudioSource>();
    }

	public void PlayStop(){
		isPlaying = !isPlaying;
		if(isPlaying){
			music.Play();
		}else{
			music.Stop();
		}
	}

    public void volumeChange(){
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
