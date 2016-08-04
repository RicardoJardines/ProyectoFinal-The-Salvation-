using UnityEngine;
using System.Collections;

public class LocomotionManager : StateMachineBehaviour {

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    ////OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        var creature = GameObject.FindGameObjectsWithTag("Creature");
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].GetComponent<EnemyController>().DamageAttac = true;
        }

        for (int i = 0; i < creature.Length; i++)
        {
            creature[i].GetComponent<CreatureController>().DamageAttac = true;
        }
    }

    ////OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    ////OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK(inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}
}
