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

    
    public void playerAttack()
    {
        sfxSrc.PlayOneShot(sound[0]);
    }

    


}


