using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : InstanceManager<PlayerMovementController>
{
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();
    private PlayerStateManager playerStateManager => GetComponent<PlayerStateManager>();

    public LayerMask WalkableLayerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UIManager.Instance.DialoguePanel.activeInHierarchy)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, WalkableLayerMask))
            {
                if (hit.transform.tag == "Ground")
                {
                    PlayerMove();
                }
            }
        }
    }

    public void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetPos = CameraRayController.Instance.GetMovePos();
            agent.SetDestination(new Vector3(targetPos.x, transform.position.y, targetPos.z));
            playerStateManager.SwitchState(PlayerStateType.Walk);
        }
    }
}