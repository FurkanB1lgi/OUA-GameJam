using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PlayerMove,
    CatRescue,
}

public class GameManager : InstanceManager<GameManager>
{
    public GameState GameState;
}