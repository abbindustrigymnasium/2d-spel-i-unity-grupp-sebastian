//////using System.Diagnostics;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



[System.Serializable]
public class Car
{
    public float startingPosX = 5;
    public float startingPosY = 100;

    public int coins = 0;

    public string level = "";
}
public class Save : MonoBehaviour
{


    public static void SaveData(Car myObj) {

        BinaryFormatter formatter = new BinaryFormatter();


        string path = Application.persistentDataPath + "/player.json";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, myObj);
        stream.Close();

    }

    public void Start()
    {

        Car data = LoadFile();
        Debug.Log(data.startingPosY);

    }

    public static Car LoadFile()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            Debug.Log("tets");
            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            Car data = formatter.Deserialize(stream) as Car;
            stream.Close();
            return data;


        }
        else {
            return null;
        }
    }





    // Update is called once per frame
    void Update()
    {

    }
}





