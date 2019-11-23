using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour {
    private StatusVariables statusVariables = null;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (statusVariables == null)
            statusVariables = animator.GetComponent<StatusVariables>();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (statusVariables.hydration < 2)
        {
            statusVariables.SetHydrationWants();
            animator.SetBool("wantsDrink", true);
        }
        else if (statusVariables.disposition < 2)
        {
            statusVariables.SetDispositionWants();
            animator.SetBool("wantsSleep", true);
        }
	}
}
