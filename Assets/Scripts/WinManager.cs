using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinManager : MonoBehaviour {

    public Text Fait;

    void OnEnable()
    {
        Fait.text = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Feit.ToString();
    }
    
    

}
