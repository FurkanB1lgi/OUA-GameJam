using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(BoxCollider))]
public class Building : MonoBehaviour, IInteractable
{
    private Outline outline => GetComponent<Outline>();

    [SerializeField] private string infoContent;

    private void Start()
    {
        outline.OutlineWidth = 9.5f;
        outline.enabled = false;
    }

    public void Interact()
    {
        transform.DOComplete();
        transform.DOPunchScale(Vector3.one * .1f, .2f, 1, .5f);

        UIManager.Instance.DialoguePanel.gameObject.SetActive(true);
        UIManager.Instance.DialoguePanel_Text.text = infoContent;

        PlayerMovementController.Instance.PlayerStop();
    }

    public void OnMouseDown()
    {
        outline.enabled = true;
    }

    public void OnMouseUp()
    {
        outline.enabled = false;
    }
}