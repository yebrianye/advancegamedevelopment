using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM : MonoBehaviour
{
    public static SM instance;

    public AudioSource sfxSrc;

    public AudioClip[] sound;


    void Awake()
    {
        instance = this;
    }


    public void buildingSound()
    {
        sfxSrc.PlayOneShot(sound[0]);
    }

    public void clickSound()
    {
        sfxSrc.PlayOneShot(sound[1]);
    }

    public void coinSound()
    {
        sfxSrc.PlayOneShot(sound[2]);
    }

    public void errorSound()
    {
        sfxSrc.PlayOneShot(sound[3]);
    }

    public void jumpSound()
    {
        sfxSrc.PlayOneShot(sound[4]);
    }

    public void levelCompleteSound()
    {
        sfxSrc.PlayOneShot(sound[5]);
    }

    public void gameOverSound()
    {
        sfxSrc.PlayOneShot(sound[6]);
    }



}