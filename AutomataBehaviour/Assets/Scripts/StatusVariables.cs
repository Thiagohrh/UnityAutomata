using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System;

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
    [SerializeField]
    private TMP_Text dispositionText;
    [SerializeField]
    private TMP_Text hydrationText;
    private Vector3 nextDestination;
    private Wants want { get; set; }
    public Vector3 NextDestination { get; set; }
    private Animator animator;

    void Start () {
        hydration = 10.0f;
        disposition = 10.0f;
        want = Wants.Default;

        animator = GetComponent<Animator>();
	}
	
	void Update () 
    {
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

        UpdateHUD();
        CheckForEscKey();
    }
    private void CheckForEscKey() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    private void UpdateHUD() 
    {
        hydrationText.SetText($"Hydration: {Mathf.Round(hydration)}");
        dispositionText.SetText($"Disposition: {Mathf.Round(disposition)}");
    }

    public void RecoverHydration(int rate) 
    {
        hydration += rate * Time.deltaTime;
    }
    public void RecoverDisposition(int rate) 
    {
        disposition += rate * Time.deltaTime;
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
