using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour {

    public GameObject StartPanel;
    public GameObject Menu;
    public GameObject Options;
    public GameObject LevelList;
    public GameObject Shop;
    public GameObject ErrorShopPanel;
	public GameObject Dificulty;
    public Text FeithAmount;


    void Start()
    {
        StartPanel.SetActive(true);
        Menu.SetActive(false);
        Options.SetActive(false);
        LevelList.SetActive(false);
        Shop.SetActive(false);
		Dificulty.SetActive (false);
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("TotalScore"))
            FeithAmount.text = PlayerPrefs.GetInt("TotalScore").ToString();
        else
            FeithAmount.text = "0";
    }

    // Use this for initialization
    public void StartGame () {
        StartPanel.SetActive(false);
        Menu.SetActive(true);
	}

    public void ShowShop()
    {
        Shop.SetActive(true);
        Menu.SetActive(false);
    }

    public void Play()
    {
		Dificulty.SetActive (true);
        Menu.SetActive(false);
    }

    public void ShowOptions()
    {
        Options.SetActive(true);
        Menu.SetActive(false);
    }

    

    public void AcceptBuy()
    {
        Shop.SetActive(false);
        Menu.SetActive(true);
    }


    public void GoToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void ShopAttack()
    {
        if (PlayerPrefs.GetInt("TotalScore") > 300)
        {
            PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore") - 100);
            PlayerPrefs.SetInt("Attack", PlayerPrefs.GetInt("Attack") + 5);
        }
        else
        {
            ErrorShopPanel.SetActive(true);
        }
    }

    public void ShopLife()
    {
        if (PlayerPrefs.GetInt("TotalScore") > 100)
        {
            PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore") - 100);
            PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") + 10);
        }
        else
        {
            ErrorShopPanel.SetActive(true);
        }

    }


    public void AcceptOptions()
    {
        Options.SetActive(false);
        Menu.SetActive(true);
    }

    public void Ok()
    {
        ErrorShopPanel.SetActive(false);
    }


	public void Facil()
	{
		PlayerPrefs.SetString ("Dificultad", "facil");
		DataManager.instance.fileName = "facil";
		DataManager.instance.Vida = 50;
		DataManager.instance.Fuerza = 5;
		DataManager.instance.SaveData ();
		Dificulty.SetActive (false);
		LevelList.SetActive(true);
	}


	public void Dificil()
	{
		PlayerPrefs.SetString ("Dificultad", "dificil");
		DataManager.instance.fileName = "dificil";
		DataManager.instance.Vida = 100;
		DataManager.instance.Fuerza = 10;
		DataManager.instance.SaveData ();
		Dificulty.SetActive (false);
		LevelList.SetActive(true);
	}

}
