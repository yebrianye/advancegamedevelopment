using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runner : MonoBehaviour
{
    public static runner instance;


    public int[] coinRate;
    //coinrate's index +1 = player's level
    //coinRate[playerLevel - 1]

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GM.instance.isGameOver == true || GM.instance.isWinning == true)
        {
            GM.playerCoin = (int)Time.time * coinRate[GM.playerLevel - 1];
        }
    }
}
