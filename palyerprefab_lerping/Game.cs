using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    int score = 0;
    bool gameStart;
    int highestScore;


    // Update is called once per frame
    IEnumerator Start()
    {
        checkPrefs();
        highestScore = PlayerPrefs.GetInt("bestScore");
        print("CLICK TO START! current high score is " + highestScore);

        while (!gameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameStart = true;
                print("GAME START!");
            }

            yield return null;

        }

        float t = 0;

        while (t < 3)
        {

            if (Input.GetMouseButtonDown(0))
            {
                score++;
                print(".");
            }
            t += Time.deltaTime;
            yield return null;
        }

        print("TIMES UP , SCORE WAS " + score);

        if(score > highestScore)
        {
            print("you have the new highest score, which is " + score);
            PlayerPrefs.SetInt("bestScore", score);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetInt("hasBow", 0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetInt("mickey", 0);


        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerPrefs.SetInt("world", 3);

        }
    }

    void checkPrefs()
    {

    }

}
