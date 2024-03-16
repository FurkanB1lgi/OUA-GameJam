using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Building : MonoBehaviour, IInteractable
{
    private Outline outline => GetComponent<Outline>();

    [SerializeField] private string infoContent;

    public void Interact()
    {
        transform.DOComplete();
        transform.DOPunchScale(Vector3.one * .5f, .2f, 1, 1);

        UIManager.Instance.DialoguePanel.gameObject.SetActive(true);
        UIManager.Instance.DialoguePanel_Text.text = infoContent;
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