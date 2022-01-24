using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformer : MonoBehaviour
{
    public abstract float Speed { get; set; }

    public abstract void Assembly();
    public abstract void Disassembly();
    public abstract void GoTo(Transform transform);
    public abstract void GoTo(Vector3 vector);

    public virtual void Shoot()
    {
        Debug.Log($"{this.name} is shooting");
    }
}  
