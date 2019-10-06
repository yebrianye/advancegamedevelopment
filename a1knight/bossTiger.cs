using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossTiger : enemy
{
    public override IEnumerator idling()
    {
        while (!anim.GetBool("dead"))
        {
            while (distance > 10)
            {

                yield return null;//wait for 1 flame, to let set the destination load up

            }
            StartCoroutine("trackPlayer");
            yield return null;
        }
        
    }

    protected override IEnumerator trackPlayer()
    {
        while (!anim.GetBool("dead"))
        {
            while (distance > 5)
            {
                anim.SetBool("running", true);
                agent.SetDestination(playerPos);
                yield return new WaitForSeconds(0.1f);
            }
            transform.LookAt(player.instance.transform);
            while (distance < 5)
            {
                if (!anim.GetBool("dead"))
                {
                    anim.SetBool("attack", true);

                    anim.SetInteger("bossAttacking", Random.Range(1, 4));
                    anim.transform.LookAt(player.instance.transform);
                    yield return new WaitForSeconds(0.1f);
                }
                while (distance < 5)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                anim.SetBool("attack", false);
                yield return null;

            }
        }

    }

    public override IEnumerator die()
    {
        print("winning1");
        anim.SetBool("dead", true);
        player.instance.getEXP(EXP);
        yield return new WaitForSeconds(3);
        GetComponent<Collider>().enabled = false;
        theCanves.gameObject.SetActive(false);
        anim.SetBool("attack", false);
        print("winning2");
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.Translate(0, -0.04f, 0);
            yield return null;
        }
        print("winning3");
        GM.instance.winning();

    }
   

    void FixedUpdate()
    {

        theCanves.rotation = camCode.instance.cam.rotation;
    }

}
