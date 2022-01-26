using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformManager : MonoBehaviour
{
    [SerializeField] private Selector selector;
    private Transformer Tformer = null;
    private Vector3 direction;

    private void Manage(Transformer transformer)
    {
        Tformer = transformer;
        if (transformer != null)
            direction = transformer.transform.position;
    }

    private void Update()
    {
        if (Tformer != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Tformer.Shoot();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Tformer.Assembly();
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Tformer.Disassembly();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycast))
                {
                    direction = raycast.point;
                }
            }
            Tformer.GoTo(direction);
        }
    }

    private void OnEnable()
    {
        selector.selected += Manage;
    }

    private void OnDisable()
    {
        selector.selected -= Manage;
    }
}
