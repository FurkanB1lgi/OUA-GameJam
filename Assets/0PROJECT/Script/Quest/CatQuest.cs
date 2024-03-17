using UnityEngine;

public enum CatQuestType
{
    Car,
    Trash
}

[RequireComponent(typeof(Outline))]
[RequireComponent(typeof(BoxCollider))]
public class CatQuest : MonoBehaviour, IInteractable
{
    private Outline outline => GetComponent<Outline>();

    public void Interact()
    {
      
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