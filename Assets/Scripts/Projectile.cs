using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float destroyProjectileTime;
  

    private void Start()
    {
        StartCoroutine(DelayBeforeDestroy(destroyProjectileTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private IEnumerator DelayBeforeDestroy(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
