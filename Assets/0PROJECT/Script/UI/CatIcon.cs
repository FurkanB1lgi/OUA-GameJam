using System;
using UnityEngine;
using UnityEngine.UI;

public class CatIcon : MonoBehaviour
{
    [SerializeField] private CatType catType;

    [Space(10)] [SerializeField] private Image catImage;

    [Space(10)] [SerializeField] private GameObject correct_Icon;
    [SerializeField] private GameObject wrongIcon;

    [Space(10)] [SerializeField] private Sprite lossSprite;
    [SerializeField] private Sprite normalSprite;


    private void Start()
    {
        catImage.sprite = lossSprite;

        wrongIcon.SetActive(true);
        correct_Icon.SetActive(false);
    }

    //################################################### EVENTS #######################################################
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnCatFound, OnCatFound);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnCatFound, OnCatFound);
    }

    void OnCatFound(object _catType)
    {
        CatType currentCatType = (CatType)_catType;
        if (currentCatType == catType)
        {
            catImage.sprite = normalSprite;
            wrongIcon.SetActive(false);
            correct_Icon.SetActive(true);
        }
    }
}