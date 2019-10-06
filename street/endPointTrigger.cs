using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(reachEndpoint());
        SM.instance.levelCompleteSound();
    }

    public IEnumerator reachEndpoint(){

        yield return new WaitForSeconds(2);
        GM.instance.winning();
    }
}
