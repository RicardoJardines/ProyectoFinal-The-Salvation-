using UnityEngine;
using System.Collections;

public class NavManager : MonoBehaviour {
	public bool Right;
    public GameObject wall;
    public GameObject[] SpawnPoint;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Player") ){
            bool turn= Right;
            if (other.GetComponent<Animator>().GetFloat("speed") > 0){
                turn = Right;
            }
            else if(other.GetComponent<Animator>().GetFloat("speed") < 0)
            {
                turn = !Right;
            }
            if (turn)
            {
                other.gameObject.GetComponent<PlayerController>().FirstRotation.y =Mathf.Round( (other.gameObject.transform.localEulerAngles + new Vector3(0, 90, 0)).y);
                other.gameObject.GetComponent<PlayerController>().position = other.gameObject.transform.position;
            }
            else
            {
                other.gameObject.GetComponent<PlayerController>().FirstRotation.y = Mathf.Round((other.gameObject.transform.localEulerAngles + new Vector3(0, -90, 0)).y);
                other.gameObject.GetComponent<PlayerController>().position = other.gameObject.transform.position;
            }
            wallUp();
        }
	}

    void wallUp()
    {
        if (wall != null)
        {
            wall.SetActive(true);
            if (SpawnPoint.Length != 0)
            {
                for (int i = 0; i < SpawnPoint.Length; i++)
                {
                    SpawnPoint[i].GetComponent<SpawnManager>().enabled = true;
                }
            }

        }

        gameObject.SetActive(false);
    }
   
}
