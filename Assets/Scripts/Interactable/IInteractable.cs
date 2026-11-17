using UnityEngine;

public interface IInteractable
{
    public void Interact(GameObject gameObject);
    public bool CanInteract(GameObject gameObject);
}
