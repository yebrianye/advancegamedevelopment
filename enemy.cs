using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Rigidbody rigi;
  

    // Update is called once per frame
    IEnumerator Start()
    {
        for(int a = 0; a < wayPoint.instance.wp.Length; a++)
        {
           // while (transform.position = wayPoint.instance.wp[a].position)
            {
                rigi.MovePosition(Vector3.MoveTowards(transform.position, wayPoint.instance.wp[a].position, 0.05f));
                yield return null;
            }
        }
        
    }
}
