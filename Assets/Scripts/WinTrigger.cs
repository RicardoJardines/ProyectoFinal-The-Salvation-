using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            UIManager.Instance.Win();
        }
    }
}
