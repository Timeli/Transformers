using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Selector selector;

    private Transform target;
    private float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(5, 5, -5);

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 goalPos = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, goalPos, 
                                                    ref velocity, smoothTime);
        }
    }


    private void GetObjectPosition(Transformer trans)
    {
        target = trans.transform;
    }

    private void OnEnable()
    {
        selector.selected += GetObjectPosition;
    }

    private void OnDisable()
    {
        selector.selected -= GetObjectPosition;
    }
}
