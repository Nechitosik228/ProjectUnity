using UnityEngine;

public class Door : BaseInteractable
{
    protected override void OnInteract(GameObject gameObject)
    {
        base.OnInteract(gameObject);
        Debug.Log("Interact");
    }
    protected override bool CanInteractInternal(GameObject gameObject)
    {
        Debug.Log("Door Can Interact");
        return base.CanInteractInternal(gameObject);

    }
}
