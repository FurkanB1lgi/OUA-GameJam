using System;
using UnityEngine;

public class CameraRayController : InstanceManager<CameraRayController>
{
    public LayerMask WalkableLayerMask;
    public LayerMask InteractableLayerMask;

    [Space(10)] [SerializeField] private IInteractable currentInteractable;

    private void Update()
    {
        InteractableAciton();
    }

    public void InteractableAciton()
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
                currentInteractable?.OnMouseUp();
                currentInteractable = hit.transform.GetComponent<IInteractable>();
                currentInteractable.OnMouseDown();
            }
            else
            {
                currentInteractable?.OnMouseUp();
            }
        }
    }

    public Vector3 GetMovePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, WalkableLayerMask))
        {
            return new Vector3(hit.point.x, 0, hit.point.z);
        }

        return PlayerMovementController.Instance.transform.position;
    }
}