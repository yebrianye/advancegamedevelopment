using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Color a, b;

    [Range(0f, 100f)]
    public float health = 100;
    public float maxHealth = 100;

    [Range(0f, 1f)]
    public float t;
    public SpriteRenderer spr;
    public Image hpBar;
    public Text hpUI;
    public Slider hpSlider;
    public GameObject theLoot;


    // Start is called before the first frame update
    IEnumerator Damage()
    {
        t = 0;
        while (t < 1)
        {
            
            spr.color = Color.Lerp(Color.red, Color.white, Mathf.SmoothStep(0, 1, t));
            t += Time.deltaTime * 4;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = health;
        hpUI.text = health + " / " + maxHealth;

        hpBar.color = (health >(maxHealth/2)) ?
            hpBar.color=Color.Lerp(Color.yellow, Color.green, (health - (maxHealth / 2)) / (maxHealth / 2))
            :
            hpBar.color=Color.Lerp(Color.red, Color.yellow, health / (maxHealth / 2));
        hpUI.color = (health > (maxHealth / 2)) ? Color.black : Color.white;

        /*
        if(health > (maxHealth/2))
        {
            hpBar.color = Color.Lerp(Color.yellow, Color.green, (health-(maxHealth/2)) /(maxHealth/2));
        }
        
        else
        {
            hpBar.color = Color.Lerp(Color.red, Color.yellow, health / (maxHealth/2));
        }
       */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Die");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("SpawnButterfly");
        }
    }

    IEnumerator SpawnButterfly()
    {
        Instantiate(theLoot, transform.position, transform.rotation);
        yield return null;
    }

    void OnMouseDown()
    {
        StopCoroutine("Damage");
        StartCoroutine("Damage");


        StartCoroutine("LerpHealth");
    }

    IEnumerator LerpHealth()
    {
        float t = 0;
        float a = health;
        float b = health - 20;

        while (t < 1)
        {
            health = (int)Mathf.Lerp(a, b, Mathf.SmoothStep(0, 1, t));

            t += Time.deltaTime * 4;
            yield return null;
        }
        
    }

    public Transform deathRf;
    IEnumerator Die()
    {
        float t = 0;
        Quaternion a = transform.rotation;
        Quaternion b = deathRf.rotation;

        Vector3 aa = transform.position;
        Vector3 bb = deathRf.position;

        while (t < 1)
        {
            t += Time.deltaTime * 4;
            transform.rotation = Quaternion.Lerp(a, b, Mathf.SmoothStep(0, 1, t));
            transform.position = Vector3.Lerp(aa, bb, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }

    }
}
