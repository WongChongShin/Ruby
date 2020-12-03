using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spartanKingDetectTarget : MonoBehaviour
{
    public Transform Enemy;
    public Animator anim;
    public int speed;
    private spartanKingMove moveSpartanKing;
    private Vector3 myCharacter;
    private Vector3 targetEnemy;
    private NavMeshAgent agent;
    public GameObject electricalVolt;
    private bool particleOn = false;
    private bool startChase = false;
    public Transform[] door;
    private int spartanHealthPoint = 12;
    public AudioClip enemyDieSound;
    private bool attack = false;
    private CapsuleCollider collider;
    public Slider mainSlider;
    private float minusHealthBar = 1.00f;
    private string levelToLoad;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().speed = speed;
        anim = GetComponent<Animator>();
        moveSpartanKing = gameObject.GetComponent<spartanKingMove>();
        collider = GetComponent<CapsuleCollider>();
        mainSlider = GameObject.Find("SpartanKingHealth").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        getDoorPosition();
        detectionChecker();
    }
    void changeAnimation()
    {

        if (Vector3.Distance(myCharacter, targetEnemy) <= 49 && Vector3.Distance(myCharacter, targetEnemy) > 0)
        {
            if (attack == false)
            {
                collider.radius = 30.0f;
                agent.isStopped = true;
                anim.SetBool("isWalking", false);
                anim.SetBool("isCharge", false);
                anim.SetBool("isAttack", true);
                attack = true;
                StartCoroutine(attackTime());
            }

        }
        else
        {
            if (!electricalVolt.GetComponent<ParticleSystem>().isPlaying)
            {
                collider.radius = 8.49f;
                anim.SetBool("isWalking", false);
                anim.SetBool("isCharge", true);
                anim.SetBool("isAttack", false);
            }
            else
            {
                collider.radius = 8.49f;
                anim.SetBool("isWalking", false);
                anim.SetBool("isCharge", false);
                anim.SetBool("isAttack", false);
            }
        }
    }
    public void detectionChecker()
    {
        myCharacter = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetEnemy = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);

        if (startChase == true)
        {
            if (Vector3.Distance(myCharacter, targetEnemy) > 10)
            {
                if (!electricalVolt.GetComponent<ParticleSystem>().isPlaying)
                {
                    agent.isStopped = false;
                    agent.destination = targetEnemy;
                }
            }
            changeAnimation();
            if (Vector3.Distance(myCharacter, targetEnemy) > 49)
            {
                if (particleOn == false)
                {
                    particleOn = true;
                    StartCoroutine(wait1());
                }
            }
            if (spartanHealthPoint <= 0)
            {
                collider.radius = 8.49f;
                agent.isStopped = true;
                anim.SetBool("isWalking", false);
                anim.SetBool("isCharge", false);
                anim.SetBool("isAttack", false);

            }

        }
    }
    void electronicCreate()
    {
        if (electricalVolt.GetComponent<ParticleSystem>().isPlaying)
        {
            electricalVolt.GetComponent<ParticleSystem>().Stop();
            agent.isStopped = false;
            particleOn = false;
        }
        else
        {
            electricalVolt.GetComponent<ParticleSystem>().Play();
            agent.isStopped = true;
            particleOn = false;
        }
    }
    IEnumerator wait1()
    {
        yield return new WaitForSeconds(10);
        electronicCreate();
    }
    void getDoorPosition()
    {
        for (int i = 0; i < door.Length; i++)
        {
            if (door[i].position.y > 70)
            {
                startChase = true;

            }
        }
    }

    void OnCollisionEnter(Collision colliderInfo)
    {
        if (spartanHealthPoint > 0)
        {
            if (changePower.powerNum == 0)//green
            {
                if (colliderInfo.gameObject.tag == "redPowerball")
                {
                    spartanHealthPoint--;
                    minusHealthBar -= 0.05f;
                    mainSlider.value = minusHealthBar;
                    print("Damage");
                }
                
            }
            else if (changePower.powerNum == 1)//blue
            {
                if (colliderInfo.gameObject.tag == "greenPowerball")
                {

                    spartanHealthPoint--;
                    minusHealthBar -= 0.05f;
                    mainSlider.value = minusHealthBar;
                    print("Damage");
                }
            }
            else if (changePower.powerNum == 2)//red
            {
                if (colliderInfo.gameObject.tag == "bluePowerball")
                {
                    spartanHealthPoint--;
                    minusHealthBar -= 0.05f;
                    mainSlider.value = minusHealthBar;
                    print("Damage");
                }
                
            }

        }
        else
        {
            anim.SetBool("isDie", true);
            StartCoroutine(win());

            IEnumerator win()
            {
                yield return new WaitForSeconds(2);
                levelToLoad = "WinScene";
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
    IEnumerator dieTime()
    {
        yield return new WaitForSeconds(2);
        audio.clip = enemyDieSound;
        audio.Play();
        Destroy(gameObject, 2);
       
    }

    IEnumerator attackTime()
    {
        yield return new WaitForSeconds(1);
        agent.isStopped = true;
        anim.SetBool("isAttack", false);
        StartCoroutine(idleTime());
    }
    IEnumerator idleTime()
    {
        yield return new WaitForSeconds(1);
        attack = false;
    }
}
