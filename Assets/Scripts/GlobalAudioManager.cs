using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
public class GlobalAudioManager : MonoBehaviour {

    public AudioMixer globalMixer;
    public Slider globalSlider;
    public Slider musicSlider;
    public Slider fxSlider;

    public void SetGlobalVolume()
    {
        globalMixer.SetFloat("MasterVolume", globalSlider.value);
    }

    public void SetFxVolume()
    {
        globalMixer.SetFloat("SoundFxVolume", fxSlider.value);
    }

    public void SetMusicVolume()
    {
        globalMixer.SetFloat("MusicVolume", musicSlider.value);
    }
}
