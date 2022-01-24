using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private Transformer transformer = null;
    public event Action<Transformer> selected;
    private RaycastHit hit;

    private void FixedUpdate()
    {
        if (GetRaycastHit())
        {
            transform.position = hit.point;
            if (Input.GetMouseButtonDown(0))
                ClickOnTFormer(hit);
        }
    }

    private void ClickOnTFormer(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<Transformer>(out Transformer trans))
        {
            transformer = trans;
            selected?.Invoke(transformer);
        }
    }

    private bool GetRaycastHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycast))
        {
            hit = raycast;
            return true;
        }
        return false;
    }
}
