using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class DataManager : MonoBehaviour {

    public string fileName;
    public static DataManager instance;

    string[] tmpString;
    char[] delimeterCharacteres = { '|' , ','};
    public int Fuerza, Vida;

	
	void Awake () {
        instance = this;
        LoadData();
	}
	
	public void LoadData()
    {
		if (File.Exists(Application.dataPath + "/" +fileName))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/" +fileName); //application es para moviles
            string stringLine;
            while ((stringLine = sr.ReadLine()) != null)
                {
                tmpString = stringLine.Split(delimeterCharacteres);
				Fuerza = int.Parse(tmpString[0]);
				Vida = int.Parse(tmpString[1]);
            }
            sr.Close();
        }
        else
        {
			Fuerza = 5;
			Vida = 100;
        }
    }

    public void SaveData()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "/" +  fileName);
		string tmpData = Fuerza + "|" + Vida;
        sw.WriteLine(tmpData);
        sw.Close();
    }
}
