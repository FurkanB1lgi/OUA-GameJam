using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatFoundPanel : InstanceManager<CatFoundPanel>
{
    [SerializeField] private GameObject panel;

    [Space(10)] [SerializeField] private Image catImage;
    public TextMeshProUGUI contentText;

    [Header("Enum Sırasına Göre Diz")] [Space(10)] [SerializeField]
    private List<Sprite> catSprites;

    [SerializeField] private Button closeButton;

    [SerializeField] private List<CatType> foundedCats = new List<CatType>();

    //############################################## EVENTS ############################################################
    private void Start()
    {
        closeButton.onClick.AddListener(CloseButton);
    }

    private void CloseButton()
    {
        if (foundedCats.Count >= 4)
        {
            EventManager.Broadcast(GameEvent.OnGameOver);
        }
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnCatFound, OnCatFound);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnCatFound, OnCatFound);
    }

    private void OnCatFound(object _catType)
    {
        panel.SetActive(true);
        CatType catType = (CatType)_catType;
        foundedCats.Add(catType);
        catImage.sprite = catSprites[(int)catType];
    }
}