using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TReject : Transformer
{
    [Header("TReject")]
    [SerializeField] private float speed;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private readonly string assemblyTrigger = "assembly";
    private readonly float delayAssembly = 2f;
    private bool isAssembly = false;

    public override float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (value >= 0)
                speed = value;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        navMeshAgent.speed = Speed;
    }

    public override void Assembly()
    {
        if (animator != null)
        {
            animator.SetBool(assemblyTrigger, true);
            StartCoroutine(Delay(delayAssembly));
        }
        
    }

    private IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAssembly = true;
    }

    public override void Disassembly()
    {
        if (animator != null)
        {
            animator.SetBool(assemblyTrigger, false);
            isAssembly = false;
        }
        
    }

    public override void GoTo(Transform endPoint)
    {
        if (isAssembly)
        {
            navMeshAgent.SetDestination(endPoint.position);
        }
    }

    public override void GoTo(Vector3 endPoint)
    {
        if (isAssembly && navMeshAgent != null)
        {
            navMeshAgent.SetDestination(endPoint);
        }
    }

    public override void Shoot()
    {
        if (isAssembly && navMeshAgent != null)
        {
            int c = transform.childCount;
            for (int i = 0; i < c; i++)
            {
                transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                transform.GetChild(i).GetComponent<Rigidbody>()
                .AddExplosionForce(1000, transform.position, 10);
            }
            DestroyReject();
        }
    }

    private void DestroyReject()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent = null;
        Destroy(navMeshAgent);
        Destroy(animator);
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(20f);
        gameObject.SetActive(false);
    }

}