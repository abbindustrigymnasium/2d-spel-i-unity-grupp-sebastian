
using System.Resources;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int Coins = 0;
    public int Level = 0;

    private bool loaded = true;
    // Start is called before the first frame update

    public void Awake()
    {

    }
    void Start()
    {

    }

    public void SavePlayer() {
        Car myObj = new Car();
        myObj.startingPosX = transform.position.x;
        myObj.startingPosY = transform.position.y;
        myObj.level = SceneManager.GetActiveScene().name;
        myObj.coins = Coins;


        Save.SaveData(myObj);

    }

    public void StartOver() {
                Car myObj = new Car();
        myObj.startingPosX = 0;
        myObj.startingPosY = 0;
        myObj.level = "SampleScene";
        myObj.coins = 0;


        Save.SaveData(myObj);
        LoadPlayer();
    }

    public void LoadPlayer() {
        Car data = Save.LoadFile();
        SceneManager.LoadScene(data.level);
        transform.position = new Vector3(data.startingPosX, transform.position.y, 0);
        
        Coins = data.coins;
        
    }

    public void CollectCoin() {
        Coins =+ 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        SavePlayer();
    }
}
