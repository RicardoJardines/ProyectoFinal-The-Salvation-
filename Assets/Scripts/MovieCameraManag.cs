using UnityEngine;
using System.Collections;

public class MovieCameraManag : MonoBehaviour {

    public GameObject player;

    public void StartGame()
    {
        GetComponent<ThirdPersonCamera>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;

        GetComponent<Animator>().enabled = false;
    }
}
