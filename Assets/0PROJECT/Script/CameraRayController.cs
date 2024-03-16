using System;
using UnityEngine;

public class CameraRayController : InstanceManager<CameraRayController>
{
    public LayerMask WalkableLayerMask;
    public LayerMask InteractableLayerMask;

    private void Update()
    {
        GetMovePos();
        Interact();
    }

    public void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) // Mouse'un sol tuşuna basıldığında
        {
            if (Physics.Raycast(ray, out hit, InteractableLayerMask))
            {
                if (hit.transform.GetComponent<IInteractable>() != null)
                {
                    hit.transform.GetComponent<IInteractable>().Interact();
                }
            }
        }

        if (Physics.Raycast(ray, out hit, InteractableLayerMask))
        {
            if (hit.transform.GetComponent<IInteractable>() != null)
            {
                hit.transform.GetComponent<IInteractable>().OnMouse();
            }
        }
    }

    public Vector3 GetMovePos()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse'un sol tuşuna basıldığında
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, WalkableLayerMask))
            {
                print("move");
                return new Vector3(hit.point.x, 0, hit.point.z);
            }
        }

        return PlayerMovementController.Instance.transform.position;
    }
}