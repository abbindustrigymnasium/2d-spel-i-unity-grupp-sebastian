
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

    public Save save;

    private bool loaded;

    public KillAndRespawn killAndRespawn;

        public bool isDead = false;

    public bool savePlayer = false;

    public bool loadPlayer = false;

    public bool savePlayerNow;
    // Start is called before the first frame update

    public void Awake()
    {

    }
    void Start()

    {
        if(savePlayer) {
            SavePlayer();
            savePlayer = false;
        }
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

Debug.Log(myObj.moonGravityPowerUpOn);

        
        Save.SaveData(myObj);
        save.data = Save.LoadFile();
    }

    public void StartOver() {
                Car myObj = new Car();
        myObj.startingPosX = -722;
        myObj.startingPosY = -9;
        myObj.level = "SampleScene";
        myObj.coins = 0;


    myObj.superDrugPowerUpOn = false;
    myObj.flyingPowerUpOn = false;
    myObj.invisibilityPowerUpOn = false;
    myObj.doubleJumpingPowerUpOn = false ;
    myObj.moonGravityPowerUpOn = false;
        Save.SaveData(myObj);
        SceneManager.LoadScene("SampleScene");
        LoadPlayer();
        
    }

    public void LoadPlayer() {
        Car data = Save.LoadFile();
        save.data = data;
        
        transform.position = new Vector2(data.startingPosX, data.startingPosY);
        Debug.Log("loaded player");
        Coins = data.coins;

    powerUps.superDrugPowerUpOn = data.superDrugPowerUpOn;
    powerUps.flyingPowerUpOn = data.flyingPowerUpOn;
    powerUps.invisibilityPowerUpOn = data.invisibilityPowerUpOn;
    powerUps.doubleJumpingPowerUpOn = data.doubleJumpingPowerUpOn;
    powerUps.moonGravityPowerUpOn = data.moonGravityPowerUpOn;
        
    }

    public void CollectCoin() {
        Coins += 1;
        
    }

    // Update is called once per frame
    public void Update()
    {
            
        if (isDead) {
            Debug.Log("died");
            killAndRespawn.Die();
            isDead = false;
        }
        if (loadPlayer) {
            LoadPlayer();
            loadPlayer = false;
        }
        if (savePlayerNow) {
            SavePlayer();
            savePlayerNow = false;
        }



    
    }
}
