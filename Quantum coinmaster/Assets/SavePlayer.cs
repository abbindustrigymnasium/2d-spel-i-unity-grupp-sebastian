using System.Resources;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int Coins = 0;
    public int Level = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
    }

    public void SavePlayer() {
        Car myObj = new Car();
        myObj.startingPosX = transform.position.x;
        myObj.startingPosY = transform.position.y;
        myObj.level = Coins;
        myObj.coins = Level;

        Saves.SaveData(myObj);

    }

    public void LoadPlayer() {
        Car data = Saves.LoadFile();
        transform.position = new Vector3(data.startingPosX, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        SavePlayer();
    }
}
