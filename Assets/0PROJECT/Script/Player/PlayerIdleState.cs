using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateType _playerStateType)
    {
        playerStateType = _playerStateType;
    }

    public override void EnterState(PlayerStateManager player)
    {
    }

    public override void UpdateState(PlayerStateManager player)
    {
    }

    public override void ExitState(PlayerStateManager player)
    {
    }
}