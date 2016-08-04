using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour {

    public static Utilities Instance;
    //public Texture2D ScreenShot;

    public delegate void CaptureScreenShotCallback();

    public CaptureScreenShotCallback captureScreenShotCallback;

    void Start()
    {
        Instance = this;
        //ScreenShot = new Texture2D(Screen.width, Screen.height);
    }

    //public void TakeScreenShot()
    //{
    //    StartCoroutine(WaitForCapture());
    //}

    //IEnumerator WaitForCapture()
    //{
    //    yield return new WaitForEndOfFrame();
    //    ScreenShot.ReadPixels(new Rect(0,0,Screen.width, Screen.height), 0,0,false);
    //    ScreenShot.Apply();
    //    captureScreenShotCallback();
    //}


    public void SaveGame(string Level, int FaitPoints)
    {
        PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore")+ FaitPoints);
        PlayerPrefs.SetInt(Level, FaitPoints);
    }
}
