using UnityEngine;
using System.Collections;

public class AudioFXManager : MonoBehaviour {
    public AudioClip[] soundsFX;
    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            audioSource.PlayOneShot(soundsFX[0]);
        if (Input.GetMouseButtonDown(1))
            audioSource.PlayOneShot(soundsFX[1]);

    }
}
