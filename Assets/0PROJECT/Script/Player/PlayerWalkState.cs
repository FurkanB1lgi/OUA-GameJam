using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(PlayerStateType _playerStateType)
    {
        playerStateType = _playerStateType;
    }

    public override void EnterState(PlayerStateManager player)
    {
        player.animator.SetBool("IsWalk", true);
        player.animator.SetBool("IsIdle", false);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if (HasReachedDestination())
        {
            player.SwitchState(PlayerStateType.Idle);
        }

        bool HasReachedDestination()
        {
            // Eğer agent yolda değilse veya hedefe çok yakınsa, varmış kabul edilir
            return !player.Agent.pathPending &&
                   player.Agent.remainingDistance <= .1f &&
                   player.Agent.hasPath;
        }
    }

    public override void ExitState(PlayerStateManager player)
    {
    }
}