using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float speed;
    public int damage;
    public int EXP;

    [Header("Compones")]
    public Animator anim;
    public Animator damageTextAnim;

    public Text hpText;
    public Slider hpSlider;
    public Transform theCanves;
    public Text damageText;
    public Vector3 originalTextSize;

    [Header("AI")]
    public NavMeshAgent agent;
    protected Vector3 origin;

    public void Start()
    {
        health = maxHealth;
        hpSlider.maxValue = maxHealth;
        hpSlider.value = health;
        hpText.text = health + "/" + hpSlider.maxValue;
        origin = transform.position;

        //origin text size
        originalTextSize = theCanves.localScale;

        StartCoroutine("idling");
    }

    public void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Color col = Color.yellow;
        col.a = 0.1f;
        Gizmos.color = col;
        Gizmos.DrawSphere(transform.position, 8);
    }




    public virtual IEnumerator idling()
    {
        while (!anim.GetBool("dead"))
        {
            while (distance > 8)
            {
                Vector3 randomPos = origin + (Random.insideUnitSphere * 8);
                randomPos.y = 0;
                agent.stoppingDistance = 0;
                agent.SetDestination(randomPos);

                yield return null;//wait for 1 flame, to let set the destination load up

                //moving around
                while (agent.remainingDistance > 0.05f && distance > 8)
                {
                    yield return null;
                }

                //stand around for second.
                float t = Random.Range(1f, 3f);

                while (t > 0 && distance > 8)
                {
                    t -= Time.deltaTime;
                    yield return null;
                }

            }
            StartCoroutine("trackPlayer");
            yield return null;
        }
        
    }


    protected virtual IEnumerator trackPlayer()
    {
        agent.stoppingDistance = 3;
        while (!anim.GetBool("dead"))
        {
            while (distance > 3)
            {
                anim.SetBool("running", true);
                agent.SetDestination(playerPos);
                yield return new WaitForSeconds(0.1f);
            }
            transform.LookAt(player.instance.transform);
            while (distance < 3)
            {
                if (!anim.GetBool("dead"))
                {
                    anim.SetBool("attacking", true);
                    anim.transform.LookAt(player.instance.transform);
                }
                yield return null;
            }
                while (distance < 3)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                anim.SetBool("attacking", false);
                yield return null;
            }
        
    }

    protected float distance
    {
        get
        {
           return Vector3.Distance(transform.position, playerPos);
        }
        set
        {
            distance = value;
        }
    }

    protected Vector3 playerPos
    {
        get
        {
            return player.instance.transform.position;
        }
    }

    public void getHit(int howMuchDamage)
    {
        if(anim.GetBool("dead") == false)
        {
            anim.SetTrigger("hit");
            StartCoroutine("flashRed");
            player.instance.manaIncreasing();
            camCode.instance.StartCoroutine("shake");

            health -= howMuchDamage;
            hpText.text = health + "/" + hpSlider.maxValue;
            hpSlider.value = health;
            //damage text
            damageText.text = "" + howMuchDamage;
            damageTextAnim.Play("damageAnimation", 0, 0); 

            //if critical damage
            if (player.instance.playerLevel == 1)
            {
                if (howMuchDamage > 23)
                {
                    damageText.color = Color.red;
                }
                else
                {
                    damageText.color = Color.white;
                }
            }

            if (player.instance.playerLevel == 2)
            {
                if (howMuchDamage > 40)
                {
                    damageText.color = Color.red;
                }
                else
                {
                    damageText.color = Color.white;
                }
            }

            if (player.instance.playerLevel == 3)
            {
                if (howMuchDamage > 50)
                {
                    damageText.color = Color.red;
                }
                else
                {
                    damageText.color = Color.white;
                }
            }
            

            if (health <= 0)
            {
                hpText.text ="0/" + hpSlider.maxValue;
                hpSlider.value = health;
                StartCoroutine("die");
            }
        }
        
    }

    public virtual IEnumerator die()
    {
        anim.SetBool("dead", true);
        player.instance.getEXP(EXP);
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = false;
        theCanves.gameObject.SetActive(false);
        anim.SetBool("attack", false);
        float t = 0;
        while(t<1)
        {
            t += Time.deltaTime;
            transform.Translate(0, -0.04f, 0);
            yield return null;
        }

        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        anim.SetFloat("walking", agent.velocity.magnitude);
        theCanves.rotation = camCode.instance.cam.rotation;
    }

    //flash red
    public Renderer[] rends;
    IEnumerator flashRed()
    {
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = Color.red;
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = Color.white;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        dealDamage(other.gameObject);
    }

    public void dealDamage(GameObject other)
    {
        other.SendMessage("getHit", damage);
       
        camCode.instance.StartCoroutine("shake");
    }
}
