using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public static player instance;
    void Awake() { instance = this; }


    [Header("Compones")]
    Rigidbody rigi;
    public GameObject level1Player, level2Player, level3Player;
    public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public Animator damageTextAnim;
    public Transform refCube;
    public Text hpText;
    public Slider hpSlider;
    public Text damageText;
    public Text EXPText;
    public Slider manaSlider;
    public Text manaText;
    public Slider EXPSlider;
    public GameObject miniMap;

    [Header("status")]
    public int playerHP;
    public int playerEXP;
    public int playerMana;
    public int playerMaxHP;
    public int playerDamage;
    public int playerLevel;

    [Header("particles")]
    public GameObject hitParticle, levelUpParticle, AOEParticle, deadParticle;

    float verti, hori, mHori, speed = 8;
    float gravity = 1f;
    Vector3 movement;

    float lastTime;
    bool grounded;
    [Header("Camare Compones")]
    public Transform camareRig;



    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        initLevel1Player();

    }

    // Update is called once per frame
    void Update()
    {

        hori = Input.GetAxis("Horizontal");
        mHori = Input.GetAxis("Mouse X");
        verti = Input.GetAxis("Vertical");
        movement.z = verti * speed;
        movement.x = hori * speed;



        if (!grounded)
        {
            movement.y -= gravity;
        }

        else
        {
            movement.y = 0;

        }

        

        rigi.velocity = camareRig.TransformDirection(movement);

        anim.SetFloat("speed", rigi.velocity.magnitude);
        anim2.SetFloat("speed", rigi.velocity.magnitude);
        anim3.SetFloat("speed", rigi.velocity.magnitude);
        refCube.localPosition = new Vector3(hori, -1, verti);
        anim.transform.LookAt(refCube);
        anim2.transform.LookAt(refCube);
        anim3.transform.LookAt(refCube);

        camareRig.position = transform.position;
        camareRig.Rotate(0, mHori, 0);


        if (rigi.velocity.magnitude > 0)
            transform.rotation = camareRig.rotation;

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastTime > 0.3f)
            {
                anim.SetInteger("combo", anim.GetInteger("combo") + 1);
                anim2.SetInteger("combo", anim2.GetInteger("combo") + 1);
                anim3.SetInteger("combo", anim3.GetInteger("combo") + 1);
                lastTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 18;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerMana > 40)
            {
                anim.SetBool("AOE", true);
                anim2.SetBool("AOE", true);
                anim3.SetBool("AOE", true);
                playerMana = playerMana - 40;
                manaText.text = playerMana.ToString();
                manaSlider.value = playerMana;
            }


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("AOE", false);
            anim2.SetBool("AOE", false);
            anim3.SetBool("AOE", false);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            miniMap.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            miniMap.SetActive(false);
        }


    }

    public void OnTriggerEnter(Collider other)
    {

        SM.instance.playerAttack();
        dealDamage(other.gameObject);
    }

    public void dealDamage(GameObject enemy)
    {
        if (playerLevel == 1)
        {
            playerDamage = Random.Range(10, 30);
            enemy.SendMessage("getHit", playerDamage);
        }
        if (playerLevel == 2)
        {
            playerDamage = Random.Range(20, 50);
            enemy.SendMessage("getHit", playerDamage);
        }
        if (playerLevel == 3)
        {
            playerDamage = Random.Range(30, 60);
            enemy.SendMessage("getHit", playerDamage);
        }

    }

    public void getHit(int howMuchDamage)
    {

        if (anim.GetBool("dead") == false || anim2.GetBool("dead") == false || anim3.GetBool("dead") == false)
        {

            anim.SetTrigger("hit");
            anim2.SetTrigger("hit");
            anim3.SetTrigger("hit");
            Instantiate(hitParticle, transform.position, transform.rotation);
            StartCoroutine("flashRed");
            camCode.instance.StartCoroutine("shake");
            playerHP -= howMuchDamage;
            hpText.text = playerHP.ToString();
            hpSlider.value = playerHP;

            //damage text
            damageText.text = "" + howMuchDamage*2;
            damageTextAnim.Play("damageAnimation", 0, 0);

            if (playerHP <= 0)
            {
                hpText.text = "0";
                hpSlider.value = playerHP;
                StartCoroutine("die");
            }
        }


    }

    public IEnumerator die()
    {
        anim.SetBool("dead", true);
        anim2.SetBool("dead", true);
        anim3.SetBool("dead", true);
        Instantiate(deadParticle, transform.position, transform.rotation);
        yield return new WaitForSeconds(2);
        
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.Translate(0, -0.04f, 0);
            yield return null;
        }

        GM.instance.gameOver();
        gameObject.SetActive(false);
    }

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

    public void getEXP(int enemyEXP)
    {
        if (playerEXP < EXPSlider.maxValue)
        {

            playerEXP = playerEXP + enemyEXP;
            EXPText.text = playerEXP.ToString();
            EXPSlider.value = playerEXP;
        }
        if (playerEXP >= EXPSlider.maxValue)
        {
            levelUp();


        }
    }

    public void levelUp()
    {
        Instantiate(levelUpParticle, transform.position, transform.rotation);
        if (playerLevel == 1)
        {
            initLevel2Player();
        }

        else
        {
            initLevel3Player();

        }

    }

    public void initLevel1Player()
    {

        playerLevel = 1;
        
        playerHP = playerMaxHP;
        hpSlider.maxValue = playerMaxHP;
        hpSlider.value = playerHP;
        hpText.text = playerHP.ToString();


        manaSlider.maxValue = 100;
        manaSlider.value = playerMana;
        manaText.text = playerMana.ToString();

        EXPSlider.maxValue = 50;
        EXPSlider.value = 0;
        EXPText.text = playerEXP.ToString();
    }
    public void initLevel2Player()
    {
        level1Player.SetActive(false);
        level2Player.SetActive(true);
        playerLevel = 2;
        playerMaxHP = 500;
        playerHP = playerMaxHP;
        hpSlider.maxValue = playerMaxHP;
        hpSlider.value = playerHP;
        hpText.text = playerHP.ToString();


        manaSlider.maxValue = 100;
        playerMana = 0;
        manaSlider.value = playerMana;
        manaText.text = playerMana.ToString();

        EXPSlider.maxValue = 150;
        playerEXP = 0;
        EXPSlider.value = 0;
        EXPText.text = playerEXP.ToString();
    }
    public void initLevel3Player()
    {
        level2Player.SetActive(false);
        level3Player.SetActive(true);
        playerLevel = 3;
        playerMaxHP = 800;
        playerHP = playerMaxHP;
        hpSlider.maxValue = playerMaxHP;
        hpSlider.value = playerHP;
        hpText.text = playerHP.ToString();


        manaSlider.maxValue = 100;
        playerMana = 0;
        manaSlider.value = manaSlider.maxValue;
        manaText.text = playerMana.ToString();

        EXPSlider.maxValue = 300;
        playerEXP = 0;
        EXPSlider.value = 0;
        EXPText.text = playerEXP.ToString();
    }

    public void OnCollisionStay()
    {
        grounded = true;
    }

    public void manaIncreasing()
    {
        if (playerMana < 80)
        {
            playerMana += 20;
            manaText.text = playerMana.ToString();
            manaSlider.value = playerMana;
        }
        else
        {
            playerMana = 100;
            manaText.text = playerMana.ToString();
            manaSlider.value = playerMana;
        }
    }


    
}
