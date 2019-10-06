using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{

    public bullet[] bullet;
    public Transform nuzzel;
    public GameObject muzzle;
    public float fireLevel;

    int bulletIndex;
    bool shoot;

    // Start is called before the first frame update
    IEnumerator shooting()
    {
        shoot = true;
        fireLevel = 1;

        while (shoot)
        {
            int availableBullet = whichBullet();
            bullet[availableBullet].transform.position = nuzzel.position;
            bullet[availableBullet].transform.rotation = nuzzel.rotation;
            bullet[availableBullet].gameObject.SetActive(true);
            StartCoroutine("MuzzleFlash");
            yield return new WaitForSeconds(fireLevel);
        }
        
    }

    int whichBullet()
    {
        for(int a = 0; a< bullet.Length; a++)
        {
            if (bullet[a].gameObject.activeSelf == false) 
            return a;
        }
        return 0;
    }

    IEnumerator MuzzleFlash()
    {
        muzzle.transform.Rotate(0, 0, Random.Range(0, 360));
        muzzle.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzle.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(fireLevel>=0.3f)
            fireLevel-=0.2f;
        }
    }

    /*
    public Transform myTarget;

    void OnTriggerEnter(Collider other)
    {
        if(myTarget == null)
        {
            myTarget = other.transform;
            StartCoroutine("shooting");
        }
    }

    void OnTriggerStay(Collider other)
    {
        head.LookAt(other.transform);

    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform == myTarget)
        {
            myTarget = null;
            StopCoroutine("shooting");
        }
    }
    */
}
