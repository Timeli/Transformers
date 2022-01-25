using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TTank : Transformer
{
    [Header("Right Rocket Position")]
    [SerializeField] private Transform RA_Pos;
    [SerializeField] private Transform RB_Pos;

    [Header("Left Rocket Position")]
    [SerializeField] private Transform LA_Pos;
    [SerializeField] private Transform LB_Pos;

    [Header("Projectile")]
    [SerializeField] private Projectile projectile;
    [SerializeField] private float projectileSpeed;

    [Header("TTank")]
    [SerializeField] private float speed;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private readonly string assemblyTrigger = "assembly";
    private readonly float delayAssembly = 2f;
    private bool isAssembly = false;
    private bool shootFlag = false;

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

    public override void GoTo(Transform endPoint)
    {
        if (isAssembly)
        {
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

    public override void Shoot()
    {
        if (isAssembly)
        {
            shootFlag = shootFlag ? false : true;
            Projectile bomb = Instantiate(projectile, GetAlterShootPosition(), transform.rotation);
            Rigidbody body = bomb.GetComponent<Rigidbody>();
            body.AddForce(GetDirection() * projectileSpeed, ForceMode.Impulse);
        }
    }

    private Vector3 GetAlterShootPosition() => shootFlag ? RA_Pos.position : LA_Pos.position;

    private Vector3 GetDirection()
    {
        Vector3 direction;
        if (shootFlag)
            direction = (RB_Pos.position - RA_Pos.position).normalized;
        else
            direction = (LB_Pos.position - LA_Pos.position).normalized;
        return direction;
    }
}
