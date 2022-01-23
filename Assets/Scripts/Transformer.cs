using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformer : MonoBehaviour
{
    public string Name 
    {
        get 
        {
            return Name; 
        }
        set 
        {
            if (value.Length >= 2 && value.Length <= 7 )
                Name = value;
            else
                Debug.Log("Name must be between 3 and 7 characters");
        } 
    }

    public float Speed 
    {
        get 
        {
            return Speed;
        }
        set 
        {
            if (value >= 0)
                Speed = value;
            else
                Debug.Log("Speed cannot be negative");
        } 
    }

    public abstract void ToTransform();
    public abstract void GoTo(Transform transform);
    public abstract void GoTo(Vector3 vector);

    public virtual void Shoot()
    {
        Debug.Log($"{name} is shooting");
    }
}  
