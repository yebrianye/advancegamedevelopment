using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animListener : MonoBehaviour
{
    public GameObject hitBox;//player 1 attack
    public GameObject hitBox2;//player 2 attack
    public GameObject hitBox3;//player 3 attack
    public GameObject AOEHitBox;//player AOE attack


    //enemy's hitbox
    public GameObject hitBox4;//skeleton's attack

    //boss' hitbox
    public GameObject hitBox5;//boss skill 1
    public GameObject hitBox6;//boss skill 2
    public GameObject hitBox7;//boss skill 3

    //mutant hitBox
    public GameObject hitBox8;//mutant skill 1
    public GameObject hitBox9;//mutant skill 2

    //zombie's hitBox
    public GameObject hitBox10;//zombie skill 1

    public void showHitBox(int whichBox)
    {
        //player's hitbox
        if(whichBox ==1) hitBox.SetActive(true);
        if (whichBox == 2) hitBox2.SetActive(true);
        if (whichBox == 3) hitBox3.SetActive(true);
        if (whichBox == 111)
        {
            AOEHitBox.SetActive(true);
            var a = Instantiate(player.instance.AOEParticle, player.instance.transform.position, player.instance.transform.rotation);
            Destroy(a, 4);
        }
        

        //enemy's hitBox
        if (whichBox == 4) hitBox4.SetActive(true);

        //boss' hitbox
        if (whichBox == 5) hitBox5.SetActive(true);
        if (whichBox == 6) hitBox6.SetActive(true);
        if (whichBox == 7) hitBox7.SetActive(true);

        //mutant's hitBox
        if (whichBox == 8) hitBox8.SetActive(true);
        if (whichBox == 9) hitBox9.SetActive(true);

        //zombie's hitBox
        if (whichBox == 10) hitBox10.SetActive(true);

    }

    public void hideHitBox(int whichBox)
    {
        //player's hitbox

        if (whichBox == 1) hitBox.SetActive(false);
        if (whichBox == 2) hitBox2.SetActive(false);
        if (whichBox == 3) hitBox3.SetActive(false);
        if (whichBox == 111)
        {
            AOEHitBox.SetActive(false);
        }

        //enemy's hitBox
        //skelton
        if (whichBox == 4) hitBox4.SetActive(false);

        //boss' hitbox
        if (whichBox == 5) hitBox5.SetActive(false);
        if (whichBox == 6) hitBox6.SetActive(false);
        if (whichBox == 7) hitBox7.SetActive(false);

        //mutant's hitBox
        if (whichBox == 8) hitBox8.SetActive(false);
        if (whichBox == 9) hitBox9.SetActive(false);

        //zombie's hitBox
        if (whichBox == 10) hitBox10.SetActive(false);
    }
}
