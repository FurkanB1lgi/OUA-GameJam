using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public PlayerStateType playerStateType { get; set; }

    public virtual PlayerStateType GetStateType()
    {
        return playerStateType;
    }

    public abstract void EnterState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void ExitState(PlayerStateManager player);
}