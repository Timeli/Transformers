using UnityEngine;

public class TPlane : Transformer
{
    [SerializeField] private float speed;
    [SerializeField] private string model;

    private void Start()
    {
        Speed = speed;
        Model = model;
    }

    public override void GoTo(Transform transform)
    {
        throw new System.NotImplementedException();
    }

    public override void GoTo(Vector3 vector)
    {
        throw new System.NotImplementedException();
    }

    public override void ToTransform()
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}