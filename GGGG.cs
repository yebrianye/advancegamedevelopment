using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGGG : MonoBehaviour
{


    public GameObject selectGO;
    public GameObject cube;
    public GameObject cap;
    public GameObject sph;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectGO = GameObject.Find("cube");
        }
    }
}
