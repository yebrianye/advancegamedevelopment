using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camCode : MonoBehaviour
{
    public Transform cam;
    public static camCode instance;
    public float intensity;

    public void Awake()
    {
        instance = this;
    }
    IEnumerator shake()
    {
        float t = 1;
        while(t > 0)
        {
            t -= Time.deltaTime *4;
            cam.localPosition = Random.insideUnitSphere * intensity * t;
            yield return null;
        }

        cam.localPosition = Vector3.zero;
    }

    IEnumerator shake(float howShake)
    {
        float t = 1;
        while (t > 0)
        {
            t -= Time.deltaTime * 4;
            cam.localPosition = Random.insideUnitSphere * howShake * t;
            yield return null;
        }

        cam.localPosition = Vector3.zero;
    }

    
}
