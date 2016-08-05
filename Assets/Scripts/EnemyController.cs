using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour {

   
    public Image LifePanel;
    public GameObject Expotion;
    public GameObject Warning;
    public bool DistanceAttack;
    public bool OnPatroll;

    public bool DamageAttac;
    public bool DamageSkill;
    public float life = 40;
    public float Velocity;
    private GameObject player;
    private Animator enemyAnimator;
    private Animator PlayerAnimator;
    private float StartLife;
    private NavMeshAgent Agente;
    private bool isDieing;
    private int attack;
    // Use this for initialization
    void Start() {

		DataManager.instance.fileName = PlayerPrefs.GetString ("Dificultad");
		DataManager.instance.LoadData ();
		life = DataManager.instance.Vida;

        enemyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerAnimator = player.GetComponent<Animator>();
        StartLife = life;
        Agente = GetComponent<NavMeshAgent>();
        if (DistanceAttack)
            StartCoroutine(DistanceAttac());

        if (PlayerPrefs.HasKey("Attack"))
        {
            attack = PlayerPrefs.GetInt("Attack");
        }
        else
        {
            attack = 5;
        }

    }

    // Update is called once per frame
    void Update() {

        if (!isDieing)
        {
            if (DistanceAttack)
            {
                enemyAnimator.SetBool("Run", true);
                if (Agente != null)
                {
                    Agente.SetDestination(player.transform.position);
                }
                if (DamageAttac && Vector3.Distance(player.transform.position, transform.position) < 1f)
                {
                    enemyAnimator.SetTrigger("Damage1");
                    life -= attack;
					LifePanel.fillAmount = life / StartLife;
                }
                else if (DamageSkill && Vector3.Distance(player.transform.position, transform.position) < 1f)
                {
                    enemyAnimator.SetTrigger("Damage2");
                    life -= attack*2;
					LifePanel.fillAmount -= life / StartLife;
                }
                if (life <= 0)
                {
                    Warning.SetActive(true);
                    Agente.SetDestination(transform.position);
                    StartCoroutine(Die());
                }

                DamageAttac = false;
                DamageSkill = false;
            }
            else if (OnPatroll)
            {
                var playerDistance = Vector3.Distance(player.transform.position, transform.position);
                //var playerPosition = player.GetComponent<Transform>().position;

                //transform.LookAt(new Vector3(playerPosition.x, transform.position.y, playerPosition.z));

                enemyAnimator.SetBool("Run", true);

                if (Agente != null)
                {
                    Agente.SetDestination(player.transform.position);
                }
                //if(playerDistance>0.25f)
                //transform.Translate( Vector3.forward * Velocity * Time.deltaTime);

                if (playerDistance < 0.25f)
                {
                    var numAttac = Random.Range(1, 3);
                    enemyAnimator.SetTrigger("Attack" + numAttac.ToString());
                }
                if (DamageAttac && Vector3.Distance(player.transform.position, transform.position) < 1f)
                {
                    enemyAnimator.SetTrigger("Damage1");
                    life -= attack;
					LifePanel.fillAmount = life / StartLife;
                }
                else if (DamageSkill && Vector3.Distance(player.transform.position, transform.position) < 1f)
                {
                    enemyAnimator.SetTrigger("Damage2");
                    life -= attack*2;
					LifePanel.fillAmount = life / StartLife;
                }
                if (life <= 0)
                {
                    Warning.SetActive(true);
                    Agente.SetDestination(transform.position);
                    StartCoroutine(Die());
                }

                DamageAttac = false;
                DamageSkill = false;
            }
            else
            {
                var playerDistance = Vector3.Distance(player.transform.position, transform.position);
                //var playerPosition = player.GetComponent<Transform>().position;

                //transform.LookAt(new Vector3(playerPosition.x, transform.position.y, playerPosition.z));

                enemyAnimator.SetBool("Run", true);

                if (Agente != null)
                {
                    Agente.SetDestination(player.transform.position);
                }
                //if(playerDistance>0.25f)
                //transform.Translate( Vector3.forward * Velocity * Time.deltaTime);

                if (playerDistance < 0.25f)
                {
                    var numAttac = Random.Range(1, 3);
                    enemyAnimator.SetTrigger("Attack" + numAttac.ToString());
                }
                if (DamageAttac && Vector3.Distance(player.transform.position, transform.position) < 1f)
                {
                    enemyAnimator.SetTrigger("Damage1");
                    life -= attack;
					LifePanel.fillAmount = life / StartLife;
                }
                else if (DamageSkill && Vector3.Distance(player.transform.position, transform.position) < 1f)
                {
                    enemyAnimator.SetTrigger("Damage2");
                    life -= attack*2;
					LifePanel.fillAmount = life / StartLife;
                }
                if (life <= 0)
                {
                    Warning.SetActive(true);
                    Agente.SetDestination(transform.position);
                    StartCoroutine(Die());
                }

                DamageAttac = false;
                DamageSkill = false;
            }
        }

        

       
    }


    IEnumerator Die()
    {
        isDieing = true;
        enemyAnimator.SetBool("Death", true);
        yield return new WaitForSeconds(4);
        Expotion.SetActive(true);
        yield return new WaitForSeconds(1);
        var Player = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].GetComponent<PlayerController>().Feit += 20;
        }
        Destroy(gameObject);
    }

    IEnumerator DistanceAttac()
    {
        while (life>0)
        {
            yield return new WaitForSeconds(4);

            var playerDistance = Vector3.Distance(player.transform.position, transform.position);
            
            
                var numAttac = 2;
                enemyAnimator.SetTrigger("Attack" + numAttac.ToString());
                gameObject.GetComponentInChildren<Shooter>().Fireball();
            
        }

        
    }


    


}
