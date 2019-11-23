using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingState : StateMachineBehaviour {
    private StatusVariables statusVariables = null; 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (statusVariables == null)
            statusVariables = animator.GetComponent<StatusVariables>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        statusVariables.RecoverDisposition(3);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        animator.SetBool("wantsSleep", false);
    }

}
