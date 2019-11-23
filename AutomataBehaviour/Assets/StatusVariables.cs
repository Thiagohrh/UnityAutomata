using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    public enum Wants
    {
        Default, Drink, Sleep
    }

public class StatusVariables : MonoBehaviour {
    public float hydration { get; set; }
    public float disposition { get; set; }

    [SerializeField]
    private Transform hydrationPoint;
    [SerializeField]
    private Transform sleepPoint;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    //Control variables to check navMesh destination and stuff.
    private Vector3 nextDestination;
    private Wants want { get; set; }

    public Vector3 NextDestination { get; set; }

    //Let it be known, that I have no plans on how to implement this. Just going with the flow.
    private Animator animator;

    // Use this for initialization
    void Start () {
        hydration = 10.0f;
        disposition = 10.0f;
        want = Wants.Default;

        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.KeypadEnter)) 
        //{
        //    navMeshAgent.SetDestination(hydrationPoint.position);
        //}
        LowerDispositions();
	}
    private void LowerDispositions() 
    {
        if (hydration > 0)
            hydration -= 1 * Time.deltaTime;
        if (disposition > 0)
            disposition -= 1 * Time.deltaTime;

        animator.SetFloat("hydration", hydration);
        animator.SetFloat("disposition", disposition);
        animator.SetFloat("distanceToTarget", navMeshAgent.remainingDistance);
    }

    public void RecoverHydration(int rate) 
    {
        hydration += rate * Time.deltaTime;
    }
    public void RecoverDisposition(int rate) 
    {
        disposition += rate * Time.deltaTime;
    }

    public Vector3 GetHydrationPosition() 
    {
        return hydrationPoint.position;
    }
    public Vector3 GetSleepPosition() 
    {
        return sleepPoint.position;
    }
    public NavMeshAgent GetNavMeshAgent() 
    {
        return navMeshAgent;
    }

    public void SetHydrationWants() 
    {
        want = Wants.Drink;
        nextDestination = hydrationPoint.position;
        navMeshAgent.SetDestination(nextDestination);
    }
    public void SetDispositionWants() 
    {
        want = Wants.Sleep;
        nextDestination = sleepPoint.position;
        navMeshAgent.SetDestination(nextDestination);
    }
}
