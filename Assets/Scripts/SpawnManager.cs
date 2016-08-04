using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
    public GameObject Enemy;
    public GameObject wall;
    public GameObject FinalCanvas;
    public int enemyCount;
    public GameObject WallDestroy;
    public GameObject[] tempEnemy;
    private int Enemies;
    // Use this for initialization
    void Start () {
        if (wall != null)
        {
            StartCoroutine(PutForwarWall());
        }
        StartCoroutine(Spawn());
	}
	
    void LateUpdate()
    {
        tempEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        int ActiveEnemi=0;
        for (int i = 0; i < tempEnemy.Length; i++)
        {
            if (tempEnemy[i] != null)
            {
                ActiveEnemi++;
            }
        }

        if (ActiveEnemi == 0)
        {
           
                StartCoroutine(DestroyWall());
        }
    }

	IEnumerator Spawn()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = (GameObject)Instantiate(Enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator PutForwarWall()
    {
        var wallTransform = wall.GetComponent<Transform>();
        float timeNow = Time.time;
        float firstPos = wallTransform.position.y;
        while ((Time.time - timeNow) <= 1)
        {
            wallTransform.position = new Vector3(wallTransform.position.x, Mathf.Lerp(firstPos, 1, (Time.time - timeNow) / 1), wallTransform.position.z);
            yield return null;
        }
    }

    IEnumerator DestroyWall()
    {
        WallDestroy.SetActive(true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}


