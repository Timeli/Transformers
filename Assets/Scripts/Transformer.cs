using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformer : MonoBehaviour
{
    private string model = string.Empty;
    private float speed = 1f;

    public string Model
    {
        get { return model; }
        set
        {
            if (value.Length > 2 && value.Length < 8)
                model = value;
            else
                Debug.Log("model < 3 or > 8");
        }
    }

    public float Speed 
    { 
        get { return speed; } 
        set 
        {
            if (value >= 0)
                speed = value;
            else
                Debug.Log("speed < 0");
        } 
    }

    
    public abstract void Assembly();
    public abstract void Disassembly();
    public abstract void GoTo(Transform transform);
    public abstract void GoTo(Vector3 vector);

    public virtual void Shoot()
    {
        Debug.Log($"{model} is shooting");
    }
}  
