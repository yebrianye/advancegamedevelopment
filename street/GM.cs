using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    //[System.Serializable]
    //public class buildings
    //{
    //    public string name;
    //    public int cost;
    //    public Sprite buildingSprite;
    //}

    //public Image[] buildingImage;
    //public buildings[] building;
   // public GameObject theGrid;
   // public GameObject theButton;


    public static GM instance;
    public static int playerLevel=1;
    public static int playerCoin=2500;
    public static int tempCoin;

    public Text playerCoinText;
    public Text playerLevelText;

    float tempTime;

    public bool isGameOver;
    public bool isWinning;

    public int[] coinRate;

    void Awake()
    {
        instance = this;
        
    }

    public void Start()
    {
        tempCoin= 0;
        tempTime = Time.time;
        playerCoinText.text = "Coins: " + playerCoin;
        playerLevelText.text = playerLevel.ToString();
        isGameOver = false;
        isWinning = false;

    }

    /*
    public void openbuildingOptions()
    {
        
        for (int a = 0; a < 7; a++)
        {
            Instantiate(theButton, theGrid.transform);
        }

        buildingImage = theGrid.GetComponentsInChildren<Image>();

        for (int b = 0; b < buildingImage.Length; b++)
        {
            buildingImage[b].transform.Find("name").GetComponent<Text>().text = building[b].name;
            buildingImage[b].transform.Find("cost").GetComponent<Text>().text = building[b].cost.ToString("$00");
            buildingImage[b].GetComponent<Image>().sprite = building[b].buildingSprite;
        }
    }
     */
    
    public void gameOver()
    {
        if (isGameOver == false)
        {
            
            isGameOver = true;
            tempCoin = (int)(Time.time-tempTime )* coinRate[GM.playerLevel - 1];
            playerCoin = playerCoin + tempCoin;
           // playerCoinText.text = "Coins: " + playerCoin; 
            //pauseGame();

            //play gameover music

            print("gameover");
            print("player coin : "+playerCoin);
            print("temp coin : "+tempCoin);
            print(Time.time);
            //print the final score

            //go to main menu

            Invoke("goToEndRunning", 0.2f);
        }
    }

    public void goToEndRunning()
    {
        SceneManager.LoadScene("endRunning");
    }

    public void winning()
    {
        if (isWinning == false)
        {
            isWinning = true;
            tempCoin = (int)(Time.time - tempTime) * coinRate[GM.playerLevel - 1]*10;
            playerCoin = playerCoin + tempCoin;
            //pauseGame();
            //play wining music

            print("wining");
            //print the final score

            //go to main menu


            Invoke("goToEndRunning", 0.2f);
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }


    void Update()
    {
        //print(Time.time);
        if (GM.instance.isGameOver == true || GM.instance.isWinning == true)
        {
            
        }

        //if (Input.GetKeyDown("space"))
        //{
        //    openbuildingOptions();
        //}

    }
}
