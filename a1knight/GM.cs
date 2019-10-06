using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public static GM instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "gameOverScene" || scene.name == "winningScene")
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("menuScene");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (scene.name == "menuScene")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("gamePlayScene");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

        public void startgame()
    {

        SceneManager.LoadScene("gamePlayScene");
    }

   
    public void PauseGame()
    {
        print("pause");
        Time.timeScale = 0;
    }

    public void gameOver()
    {
        SceneManager.LoadScene("gameOverScene");
    }

    public void winning()
    {
        SceneManager.LoadScene("winningScene");
    }
    
    
}
