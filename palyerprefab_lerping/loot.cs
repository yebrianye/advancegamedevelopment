using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loot : MonoBehaviour
{

    public Transform lootPoint;

    bool used;

    IEnumerator Start()
    {
        Vector3 height = new Vector3(0, 0.05f, 0);
        Vector3 b = transform.position+ new Vector3(Random.Range(-.5f,.5f),0, Random.Range(-.5f, .5f));

        float t = 0;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(transform.position + height, b, Mathf.SmoothStep(0, 1, t));

            t += Time.deltaTime ;
            yield return null;
        }
    }

    void OnMouseOver()
    {
        StartCoroutine("LerpToUI");
    }

    IEnumerator LerpToUI()
    {
        if (!used)
        {
            used = true;

            Vector3 a = transform.position;
            Vector3 b = lootPoint.position;

            float t = 0;
            while (t < 1)
            {
                transform.position = Vector3.Lerp(a, b, Mathf.SmoothStep(0, 1, t));

                t += Time.deltaTime * 4;
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
