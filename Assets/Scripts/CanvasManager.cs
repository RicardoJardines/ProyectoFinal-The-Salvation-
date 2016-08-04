using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

    private Transform MainCamer;

	// Use this for initialization
	void Start () {
        MainCamer = Camera.main.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(MainCamer.position);
	}
}
