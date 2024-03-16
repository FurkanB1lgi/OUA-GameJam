using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerStateType
{
    Idle,
    Walk,
}

public class PlayerStateManager : MonoBehaviour
{
    public NavMeshAgent Agent => GetComponent<NavMeshAgent>();
    public Animator animator => GetComponent<Animator>();

    private PlayerBaseState currentState;

    public PlayerBaseState CurrentState
    {
        get { return currentState; }
        set { currentState = value; }
    }

    [SerializeField] private PlayerStateType currentStateType;

    public PlayerStateType CurrentStateType
    {
        get
        {
            currentStateType = CurrentState.GetStateType();
            return currentStateType;
        }
        set { currentStateType = value; }
    }

    Dictionary<PlayerStateType, PlayerBaseState> states = new Dictionary<PlayerStateType, PlayerBaseState>();

    void Start()
    {
        AddState(PlayerStateType.Idle, new PlayerIdleState(PlayerStateType.Idle));
        AddState(PlayerStateType.Walk, new PlayerWalkState(PlayerStateType.Walk));

        SwitchState(PlayerStateType.Idle);
    }

    void Update()
    {
        CurrentState.UpdateState(this);
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     CurrentState.OnCollisionEnter(this, other);
    // }

    public void SwitchState(PlayerStateType stateType)
    {
        if (states.ContainsKey(stateType))
        {
            if (CurrentState != null)
                CurrentState.ExitState(this);

            CurrentState = states[stateType];
            CurrentState.EnterState(this);
            UpdateCurrentStateType();
        }
        else
        {
            Debug.LogError("Invalid state: " + stateType);
        }
    }

    public void AddState(PlayerStateType stateName, PlayerBaseState state)
    {
        states[stateName] = state;
    }

    void UpdateCurrentStateType()
    {
        CurrentStateType = CurrentState.GetStateType();
    }
}