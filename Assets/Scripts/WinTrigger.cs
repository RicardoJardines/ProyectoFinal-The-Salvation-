using UnityEngine;
using System.Collections;

public class WinTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
			Other.gameObject.GetComponent<PlayerController> ().enabled = false;
            UIManager.Instance.Win();
        }
    }
}
