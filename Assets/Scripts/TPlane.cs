using UnityEngine;

public class TPlane : Transformer
{
    [SerializeField] private string name;
    [SerializeField] private float speed;

    public TPlane()
    {
        Name = name;
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

    public override void ToTransform()
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}