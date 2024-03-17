using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;


    //####################################################### EVENTS #################################################
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnGameOver, OnGameOver);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnGameOver, OnGameOver);
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}