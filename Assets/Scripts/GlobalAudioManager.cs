using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
public class GlobalAudioManager : MonoBehaviour {

    public AudioMixer globalMixer;
    public Slider globalSlider;
    public Slider musicSlider;
    public Slider fxSlider;

	void Start(){
		if (PlayerPrefs.HasKey ("SoundFxVolume")) {
			if(globalSlider!=null)
				fxSlider.value = PlayerPrefs.GetFloat ("SoundFxVolume");
			globalMixer.SetFloat("SoundFxVolume", PlayerPrefs.GetFloat ("SoundFxVolume"));
		}

		if (PlayerPrefs.HasKey ("MusicVolume")) {
			if(globalSlider!=null)
				musicSlider.value = PlayerPrefs.GetFloat ("MusicVolume");
			globalMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat ("MusicVolume"));
		}


	}

    public void SetGlobalVolume()
    {
        globalMixer.SetFloat("MasterVolume", globalSlider.value);
		PlayerPrefs.SetFloat ("MasterVolume", globalSlider.value);
    }

    public void SetFxVolume()
    {
        globalMixer.SetFloat("SoundFxVolume", fxSlider.value);
		PlayerPrefs.SetFloat ("SoundFxVolume", fxSlider.value);
    }

    public void SetMusicVolume()
    {
        globalMixer.SetFloat("MusicVolume", musicSlider.value);
		PlayerPrefs.SetFloat ("MusicVolume", musicSlider.value);
    }

	public void Exit(){
		Time.timeScale = 1f;
		gameObject.SetActive (false);
	}
}
