using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutant : enemy
{
    public Transform cubeA;
    public Transform cubeB;

    public override IEnumerator idling()
    {
        cubeA.parent = cubeB.parent = null;

        while (distance > 10)
        {
            agent.stoppingDistance = 0;
            agent.SetDestination(cubeA.position);

            yield return null;

            while (agent.remainingDistance > 0.05f && distance > 10)
            {
                yield return null;
            }

            agent.SetDestination(cubeB.position);
            yield return null;

            while (agent.remainingDistance > 0.05f && distance > 10)
            {
                yield return null;
            }

        }
        StartCoroutine("trackPlayer");
    }

    protected override IEnumerator trackPlayer()
    {
        agent.stoppingDistance = 4;
        while (!anim.GetBool("dead"))
        {
            while (distance > 4)
            {
                anim.SetBool("running", true);
                agent.SetDestination(playerPos);
                yield return new WaitForSeconds(0.1f);
            }
            transform.LookAt(player.instance.transform);
            while (distance < 4)
            {
                if (!anim.GetBool("dead"))
                {
                    anim.SetBool("attack", true);
                    anim.SetInteger("mutantAttacking", Random.Range(1, 3));
                    anim.transform.LookAt(player.instance.transform);
                }
                yield return null;
            }

                while (distance < 4)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                anim.SetBool("attack", false);
                yield return null;

        }
    }
}
