using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverTrigger : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {

        StartCoroutine(reachGameOverPoint());
        SM.instance.gameOverSound();
    }

    public IEnumerator reachGameOverPoint()
    {

        yield return new WaitForSeconds(2);
        GM.instance.gameOver();
    }
}