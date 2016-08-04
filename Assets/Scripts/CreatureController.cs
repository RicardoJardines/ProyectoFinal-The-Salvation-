using UnityEngine;
using System.Collections;

public class CreatureController : MonoBehaviour {

    public int life = 50;
    public bool DamageAttac;
    private Animator CreatureAnimator;
    private GameObject Player;
    private NavMeshAgent Agente;

	// Use this for initialization
	void Start () {
        CreatureAnimator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Agente = GetComponent<NavMeshAgent>();
        StartCoroutine(attack());
    }
	
    void Update()
    {
        if (DamageAttac)
        {
            CreatureAnimator.SetTrigger("Hit");
            life -= 2;
        }

        if (life <= 0)
        {
            StartCoroutine(Die());
        }
        DamageAttac = false;
    }


	IEnumerator attack()
    {
        Debug.Log("Entra en attack");
        while (true)
        {
            
            CreatureAnimator.SetTrigger("Run");
            Agente.SetDestination(Player.transform.position);
            while (Vector3.Distance(transform.position, Player.transform.position) > 1)
                yield return null;
            CreatureAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Die()
    {
        CreatureAnimator.SetBool("Death", true);
        yield return new WaitForSeconds(2);
        UIManager.Instance.Win();
        Destroy(gameObject);
    }
}
