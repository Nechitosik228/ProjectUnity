using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour, IInteractable
{
    public void Interact(GameObject gameObject)
    {
        OnInteract(gameObject);
    }
    protected virtual void OnInteract(GameObject gameObject)
    {

    }


    public bool CanInteract(GameObject gameObject)
    {
        return CanInteractInternal(gameObject);
    }
    protected virtual bool CanInteractInternal(GameObject gameObject)
    {
        return true;
    }
}
