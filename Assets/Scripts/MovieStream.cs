using UnityEngine;
using System.Collections;

public class MovieStream : MonoBehaviour {


    public new AudioSource audio;
    private MovieTexture movieTexture;
    

    void Start()
    {
        WWW www = new WWW("http://www.unity3d.com/webplayers/Movie/sample.ogg");
        while( www.isDone == false)
        {

        }
        movieTexture = www.movie;
        GetComponent<MeshRenderer>().materials[0].mainTexture = movieTexture;
        audio.clip = movieTexture.audioClip;
    }

    void Update()
    {
        if ( movieTexture.isReadyToPlay &&  !movieTexture.isPlaying)
        {
            movieTexture.Play();
            audio.Play();
        }
    }
}
