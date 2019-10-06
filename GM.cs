using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public int[] gold;
    public GameObject[] building;
    public GameObject erroMessage;
    public int[] upgradeCost;
    public string[] buildingName; 
    public float[] incomeRate;
    public int level;

    public Text buildNameText;
    public Text upgradeCostText;
    public Text incomeRateText;
    public Animator anim;

    public Image clock;
    public Text myGoldText;
    public int myGold;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        level = 0;
        buildNameText.text = buildingName[level];
        incomeRateText.text = "$" + incomeRate[level] + "/round";
        upgradeCostText.text = "Upgrade:$" + upgradeCost[level];
        while (true)
        {
            float t = 0;
            while (t < 3)
            {
                t += Time.deltaTime;
                clock.fillAmount = t / 3;
                yield return null;
            }

            //get gold
            myGold += gold[level];
            myGoldText.text = "Gold: " + myGold;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(level < building.Length && myGold>=upgradeCost[level])
        {
            myGold -= upgradeCost[level];
            myGoldText.text = "Gold: " + myGold;
            level++;
            building[level].SetActive(true);
            buildNameText.text = buildingName[level];
            incomeRateText.text = "$" + incomeRate[level] + "/round";
            upgradeCostText.text = "Upgrade:$" + upgradeCost[level];
            
        }
        else
        {
            StartCoroutine(displayErroMessage());
        }
    }

    IEnumerator displayErroMessage()
    {
        erroMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        erroMessage.SetActive(false);
    }

    void OnMouseOver()
    {
        anim.SetBool("mouseOver", true);
    }

    void OnMouseExit()
    {
        anim.SetBool("mouseOver", false);
    }
}
