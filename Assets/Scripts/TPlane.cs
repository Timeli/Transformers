using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TPlane : Transformer
{
    [SerializeField] private float speed;
    [SerializeField] private string model;

    private Animator animator;
    private readonly string assemblyTrigger = "assembly";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Model = model;
        Speed = speed;
    }

    public override void GoTo(Transform transform)
    {
        throw new System.NotImplementedException();
    }

    public override void GoTo(Vector3 vector)
    {
        throw new System.NotImplementedException();
    }

    public override void Assembly()
    {
        throw new System.NotImplementedException();
    }

    public override void Disassembly()
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        base.Shoot();
    }

    
}