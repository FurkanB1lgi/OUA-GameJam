using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum CatType
{
    Tarcin,
    Latte,
    Mila,
    Tosbik
}

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(BoxCollider))]
public class CatBuilding : MonoBehaviour, IInteractable
{
    private Outline outline => GetComponent<Outline>();

    [SerializeField] private string infoContent;
    public CatType CatType;

    private void Start()
    {
        outline.enabled = false;
    }

    public void Interact()
    {
        transform.DOComplete();
        transform.DOPunchScale(Vector3.one * .1f, .2f, 1, .5f);

        CatFoundPanel.Instance.contentText.text = infoContent;
        EventManager.Broadcast(GameEvent.OnCatFound, CatType);
        PlayerMovementController.Instance.PlayerStop();
    }

    public void OnMouseDown()
    {
        outline.enabled = true;
        outline.OutlineWidth = 9.5f;
    }

    public void OnMouseUp()
    {
        outline.enabled = false;
    }
}