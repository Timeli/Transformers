using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.GetComponent<Rigidbody>());
        collision.gameObject.SetActive(false);
    }
}
