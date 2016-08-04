using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {


    public static UIManager Instance;
    public GameObject WinPanel;

    void Start()
    {
        Instance = this;
    }

    public void Win()
    {
        //faceboockComposerPanel.SetActive(true);
        if (WinPanel != null)
        {
            WinPanel.SetActive(true);
            StartCoroutine(winNext());

        }
        
    } 


    public void Continue()
    {
        Utilities.Instance.SaveGame("Level" + SceneManager.GetActiveScene().buildIndex.ToString() , GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Feit );
        SceneManager.LoadScene(0);
    }


    IEnumerator winNext()
    {
        yield return new WaitForSeconds(3);
        Utilities.Instance.SaveGame("Level" + SceneManager.GetActiveScene().buildIndex.ToString(), GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Feit);
        SceneManager.LoadScene(0);
    }
}
