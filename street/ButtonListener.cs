using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    public GameObject theGrid;
   // public GameObject currentObj;
    public GameObject comfirmMessage;
    public GameObject errorMessage;
    public GameObject notEnoughCoinMessage;

    public Text[] buildingNumber;
    public int[] buildingNum;
    public int[] currentBuildingNum;
    public int[] buildingCost;
    public Animator[] anim;
    public GameObject[] buildings;
    public int isComfirm;

    public GameObject buildingParticle;
    
    public void Start()
    {
        //PlayerPrefs.DeleteKey("blueHouse1");
        if (PlayerPrefs.HasKey("blueHouse1"))
        {
            buildings[0].SetActive(true);
            currentBuildingNum[0]++;
            buildingNumber[0].text = currentBuildingNum[0] + "/" + buildingNum[0];
        }
        if (PlayerPrefs.HasKey("blueHouse2"))
        {
            buildings[1].SetActive(true);
            currentBuildingNum[0]++;
            buildingNumber[0].text = currentBuildingNum[0] + "/" + buildingNum[0];
        }
        if (PlayerPrefs.HasKey("pinkHouse1"))
        {
            buildings[2].SetActive(true);
            currentBuildingNum[1]++;
            buildingNumber[1].text = currentBuildingNum[1] + "/" + buildingNum[1];
        }
        if (PlayerPrefs.HasKey("pinkHouse2"))
        {
            buildings[3].SetActive(true);
            currentBuildingNum[1]++;
            buildingNumber[1].text = currentBuildingNum[1] + "/" + buildingNum[1];
        }
        if (PlayerPrefs.HasKey("whiteUnit1"))
        {
            buildings[4].SetActive(true);
            currentBuildingNum[2]++;
            buildingNumber[2].text = currentBuildingNum[2] + "/" + buildingNum[2];
        }
        if (PlayerPrefs.HasKey("whiteaUnit2"))
        {
            buildings[5].SetActive(true);
            currentBuildingNum[2]++;
            buildingNumber[2].text = currentBuildingNum[2] + "/" + buildingNum[2];
        }
        if (PlayerPrefs.HasKey("pinkUnit"))
        {
            buildings[6].SetActive(true);
            currentBuildingNum[3]++;
            buildingNumber[3].text = currentBuildingNum[3] + "/" + buildingNum[3];
        }

        if (PlayerPrefs.HasKey("shop1"))
        {
            buildings[7].SetActive(true);
            currentBuildingNum[4]++;
            buildingNumber[4].text = currentBuildingNum[4] + "/" + buildingNum[4];
        }
        if (PlayerPrefs.HasKey("shop2"))
        {
            buildings[8].SetActive(true);
            currentBuildingNum[4]++;
            buildingNumber[4].text = currentBuildingNum[4] + "/" + buildingNum[4];
        }
        if (PlayerPrefs.HasKey("park"))
        {
            buildings[9].SetActive(true);
            currentBuildingNum[5]++;
            buildingNumber[5].text = currentBuildingNum[5] + "/" + buildingNum[5];
        }
        if (PlayerPrefs.HasKey("gasStation"))
        {
            buildings[10].SetActive(true);
            currentBuildingNum[6]++;
            buildingNumber[6].text = currentBuildingNum[6] + "/" + buildingNum[6];
        }

    }

    public void earnCoinBtn()
    {
        SceneManager.LoadScene("runnerScene");
        SM.instance.clickSound();
    }

    public void buildingsBtn()
    {
        SM.instance.clickSound();
        if (!theGrid.activeSelf)
        {
            theGrid.SetActive(true);
           
        }

        else
        {
            theGrid.SetActive(false);
        }

        
    }

    public void blueHouseBtn()
    {
        SM.instance.clickSound();
        StartCoroutine(PlaceblueHouse());
        print("aaaa");
    }

    public IEnumerator PlaceblueHouse()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[0] < buildingNum[0])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (currentBuildingNum[0] == 0)
                {
                    if (GM.playerCoin >= buildingCost[0])
                    {
                        buildings[0].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[0].transform.position, anim[0].transform.rotation);
                        anim[0].SetBool("blueHouse1", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[0];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[0]++;
                        buildingNumber[0].text = currentBuildingNum[0] + "/" + buildingNum[0];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("blueHouse1", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }
                else if (currentBuildingNum[0] == 1)
                {
                    if (GM.playerCoin >= buildingCost[0])
                    {
                        buildings[1].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[1].transform.position, anim[1].transform.rotation);
                        anim[1].SetBool("blueHouse2", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[0];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[0]++;
                        buildingNumber[0].text = currentBuildingNum[0] + "/" + buildingNum[0];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("blueHouse2", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }
                

            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }

    }

    public void pinkHouseBtn()
    {
        SM.instance.clickSound();
        StartCoroutine(PlacePinkHouse());
        print("bbbb");
    }

    public IEnumerator PlacePinkHouse()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[1] < buildingNum[1])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (currentBuildingNum[1] == 0)
                {
                    if (GM.playerCoin >= buildingCost[1])
                    {
                        buildings[2].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[2].transform.position, anim[2].transform.rotation);
                        anim[2].SetBool("pinkHouse1", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[1];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[1]++;
                        buildingNumber[1].text = currentBuildingNum[1] + "/" + buildingNum[1];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("pinkHouse1", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }
                else if (currentBuildingNum[1] == 1)
                {
                    if (GM.playerCoin >= buildingCost[1])
                    {
                        buildings[3].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[3].transform.position, anim[3].transform.rotation);
                        anim[3].SetBool("pinkHouse2", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[1];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[1]++;
                        buildingNumber[1].text = currentBuildingNum[1] + "/" + buildingNum[1];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("pinkHouse2", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }


            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }

    }

    public void whiteUnitBtn()
    {
        SM.instance.clickSound();
        StartCoroutine(PlaceWhiteUnit());
        print("cccc");
    }

    public IEnumerator PlaceWhiteUnit()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[2] < buildingNum[2])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (currentBuildingNum[2] == 0)
                {
                    if (GM.playerCoin >= buildingCost[2])
                    {
                        buildings[4].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[4].transform.position, anim[4].transform.rotation);
                        anim[4].SetBool("whiteUnit1", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[2];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[2]++;
                        buildingNumber[2].text = currentBuildingNum[2] + "/" + buildingNum[2];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("whiteUnit1", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }
                else if (currentBuildingNum[2] == 1)
                {
                    if (GM.playerCoin >= buildingCost[2])
                    {
                        buildings[5].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[5].transform.position, anim[5].transform.rotation);
                        anim[5].SetBool("whiteUnit2", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[2];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[2]++;
                        buildingNumber[2].text = currentBuildingNum[2] + "/" + buildingNum[2];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("whiteUnit2", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }


            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }

    }

    public void pinkUnitBtn()
    {
        SM.instance.clickSound();
        StartCoroutine(PlacePinkUnit());
        print("dddd");
    }

    public IEnumerator PlacePinkUnit()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[3] < buildingNum[3])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (currentBuildingNum[3] == 0)
                {
                    if (GM.playerCoin >= buildingCost[3])
                    {
                        buildings[6].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[6].transform.position, anim[6].transform.rotation);
                        anim[6].SetBool("pinkUnit", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[3];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[3]++;
                        buildingNumber[3].text = currentBuildingNum[3] + "/" + buildingNum[3];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("pinkUnit", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }
                
            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }

    }

    public void shopBtn()
    {
        SM.instance.clickSound();
        StartCoroutine(PlaceShop());
        print("eeee");
    }

    public IEnumerator PlaceShop()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[4] < buildingNum[4])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (currentBuildingNum[4] == 0)
                {
                    if (GM.playerCoin >= buildingCost[4])
                    {
                        buildings[7].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[7].transform.position, anim[7].transform.rotation);
                        anim[7].SetBool("shop1", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[4];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[4]++;
                        buildingNumber[4].text = currentBuildingNum[4] + "/" + buildingNum[4];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("shop1", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }
                else if (currentBuildingNum[4] == 1)
                {
                    if (GM.playerCoin >= buildingCost[4])
                    {
                        buildings[8].SetActive(true);
                        SM.instance.buildingSound();
                        Instantiate(buildingParticle, anim[8].transform.position, anim[8].transform.rotation);
                        anim[8].SetBool("shop2", true);
                        GM.playerCoin = GM.playerCoin - buildingCost[4];
                        GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                        currentBuildingNum[4]++;
                        buildingNumber[4].text = currentBuildingNum[4] + "/" + buildingNum[4];
                        GM.playerLevel++;
                        GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                        PlayerPrefs.SetInt("shop2", 0);
                    }
                    else
                    {
                        StartCoroutine(notEnoughCoin());
                    }
                }


            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }

    }

    public void parkBtn()
    {
        SM.instance.clickSound();

        StartCoroutine(PlacePark());
        print("ffff");
    }

    public IEnumerator PlacePark()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[5] < buildingNum[5])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (GM.playerCoin>=buildingCost[5])
                {
                    buildings[9].SetActive(true);
                    SM.instance.buildingSound();
                    Instantiate(buildingParticle, anim[9].transform.position, anim[9].transform.rotation);
                    anim[9].SetBool("park", true);
                    GM.playerCoin = GM.playerCoin - buildingCost[5];
                    GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                    currentBuildingNum[5] ++;
                    buildingNumber[5].text = currentBuildingNum[5] + "/" + buildingNum[5];
                    GM.playerLevel++;
                    GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                    PlayerPrefs.SetInt("park", 0);
                }
                else
                {
                    StartCoroutine(notEnoughCoin());
                }

            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }
       
    }

    public void gasStationBtn()
    {
        SM.instance.clickSound();
        StartCoroutine(PlaceGasStation());
        print("gggg");
    }

    public IEnumerator PlaceGasStation()
    {
        //currentObj = GameObject.FindWithTag("park");
        if (currentBuildingNum[6] < buildingNum[6])
        {
            isComfirm = 3;
            while (isComfirm == 3)
            {
                comfirmMessage.SetActive(true);
                yield return isComfirm; // wait
            }
            if (isComfirm == 1)
            {
                if (GM.playerCoin >= buildingCost[6])
                {
                    buildings[10].SetActive(true);
                    SM.instance.buildingSound();
                    Instantiate(buildingParticle, anim[10].transform.position, anim[10].transform.rotation);
                    anim[10].SetBool("gasStation", true);
                    GM.playerCoin = GM.playerCoin - buildingCost[6];
                    GM.instance.playerCoinText.text = "Coins: " + GM.playerCoin;
                    currentBuildingNum[6]++;
                    buildingNumber[6].text = currentBuildingNum[6] + "/" + buildingNum[6];
                    GM.playerLevel++;
                    GM.instance.playerLevelText.text = GM.playerLevel.ToString();
                    PlayerPrefs.SetInt("gasStation", 0);
                }
                else
                {
                    StartCoroutine(notEnoughCoin());
                }

            }
            else if (isComfirm == 0)
            {
                // remove the temporary / preview building
            }
        }
        else
        {
            StartCoroutine(displayErrorMessage());
        }

    }

    public void yesBtn()
    {
        SM.instance.clickSound();
        isComfirm = 1;
        comfirmMessage.SetActive(false);
    }

    public void noBtn()
    {
        SM.instance.clickSound();
        isComfirm = 0;
        comfirmMessage.SetActive(false);

    }

    public IEnumerator displayErrorMessage() 
    {
        SM.instance.errorSound();
        errorMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        errorMessage.SetActive(false);
    }

    public IEnumerator notEnoughCoin()
    {
        SM.instance.errorSound();
        notEnoughCoinMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        notEnoughCoinMessage.SetActive(false);
    }
    




}
