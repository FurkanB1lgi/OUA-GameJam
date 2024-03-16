using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovementController : InstanceManager<PlayerMovementController>
{
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();

    private PlayerStateManager playerStateManager;

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 targetPos = CameraRayController.Instance.GetMovePos();
            agent.SetDestination(new Vector3(targetPos.x, transform.position.y, targetPos.z));
            // playerStateManager.s
        }
    }
}