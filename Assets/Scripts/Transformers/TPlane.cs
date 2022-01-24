using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class TPlane : Transformer
{
    [SerializeField] private float speed;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private readonly string assemblyTrigger = "assembly";
    private readonly float delayAssembly = 3f;
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

    public override void GoTo(Transform endPoint)
    {
        if (isAssembly)
        {
            print(endPoint);
            navMeshAgent.SetDestination(endPoint.position);
        }
    }

    public override void GoTo(Vector3 endPoint)
    {
        if (isAssembly)
        {
            navMeshAgent.SetDestination(endPoint);
        }
    }

    public override void Assembly()
    {
        animator.SetBool(assemblyTrigger, true);
        StartCoroutine(Delay(delayAssembly));
    }

    private IEnumerator Delay(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAssembly = true;
    }
    

    public override void Disassembly()
    {
        animator.SetBool(assemblyTrigger, false);
        isAssembly = false;
    }

    public override void Shoot()
    {
        base.Shoot();
    }

}