using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public Rigidbody rigi;

    
    void OnEnable()
    {
        StartCoroutine("shoot");
    }
    // Update is called once per frame
    IEnumerator shoot()
    {
        print("shooting");
        float t = 0;
        while (t < 2)
        {
            rigi.velocity = transform.forward * 10;
            t += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
        
    }
}
