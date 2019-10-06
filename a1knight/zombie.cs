using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : enemy
{
    public void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Color col = Color.yellow;
        col.a = 0.1f;
        Gizmos.color = col;
        Gizmos.DrawSphere(transform.position,12);
    }

    public override IEnumerator idling()
    {
        while (distance > 12)
        {

            yield return null;//wait for 1 flame, to let set the destination load up

        }
        StartCoroutine("trackPlayer");
    }

    protected override IEnumerator trackPlayer()
    {
        while (!anim.GetBool("dead"))
        {
            while (distance > 6)
            {
                anim.SetBool("running", true);
                agent.SetDestination(playerPos);
                yield return new WaitForSeconds(0.1f);

            }

            transform.LookAt(player.instance.transform);
            while (distance < 6)
            {
                if (!anim.GetBool("dead"))
                {
                    anim.SetBool("attacking", true);
                    anim.transform.LookAt(player.instance.transform);
                }
                yield return null;
            }
                while (distance < 6)
                 {
                    yield return new WaitForSeconds(0.1f);
                 }
                anim.SetBool("attacking", false);
                
                yield return null;
         }
    }



    void FixedUpdate()
    {

        theCanves.rotation = camCode.instance.cam.rotation;
    }
}
