using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinCollectUI : MonoBehaviour
{
    public Text coinUI;

    // Start is called before the first frame update
    void Start()
    {
        SM.instance.coinSound();
        coinUI.text = GM.tempCoin.ToString() + " Coins";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SM.instance.clickSound();
            SceneManager.LoadScene("mainScene");
        }
    }
}
