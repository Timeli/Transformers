using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private TMP_Text selectedText;

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
        transformer = hit.collider.GetComponent<Transformer>();
        selected?.Invoke(transformer);
        selectedText.text = $"selected: {transformer?.name}";
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
