
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

    public PowerUps powerUps;

    private bool loaded = true;
    // Start is called before the first frame update

    public void Awake()
    {

    }
    void Start()
    {
       LoadPlayer();
    }

    public void SavePlayer() {
        Car myObj = new Car();
        myObj.startingPosX = transform.position.x;
        myObj.startingPosY = transform.position.y;
        myObj.level = SceneManager.GetActiveScene().name;
        myObj.coins = Coins;

    myObj.superDrugPowerUpOn = powerUps.superDrugPowerUpOn;
    myObj.flyingPowerUpOn = powerUps.flyingPowerUpOn;
    myObj.invisibilityPowerUpOn = powerUps.invisibilityPowerUpOn;
    myObj.doubleJumpingPowerUpOn = powerUps.doubleJumpingPowerUpOn;
    myObj.moonGravityPowerUpOn = powerUps.moonGravityPowerUpOn;


        Save.SaveData(myObj);

    }

    public void StartOver() {
                Car myObj = new Car();
        myObj.startingPosX = 0;
        myObj.startingPosY = 0;
        myObj.level = "SampleScene";
        myObj.coins = 0;


    myObj.superDrugPowerUpOn = false;
    myObj.flyingPowerUpOn = false;
    myObj.invisibilityPowerUpOn = false;
    myObj.doubleJumpingPowerUpOn = false ;
    myObj.moonGravityPowerUpOn = false;
        Save.SaveData(myObj);
        LoadPlayer();
    }

    public void LoadPlayer() {
        Car data = Save.LoadFile();
        
        transform.position = new Vector3(data.startingPosX, transform.position.y, 0);
        
        Coins = data.coins;

    powerUps.superDrugPowerUpOn = data.superDrugPowerUpOn;
    powerUps.flyingPowerUpOn = data.flyingPowerUpOn;
    powerUps.invisibilityPowerUpOn = data.invisibilityPowerUpOn;
    powerUps.doubleJumpingPowerUpOn = data.doubleJumpingPowerUpOn;
    powerUps.moonGravityPowerUpOn = data.moonGravityPowerUpOn;
        
    }

    public void CollectCoin() {
        Coins =+ 1;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
