using UnityEngine;

public class NPCInteractor : BaseInteractable
{
    [SerializeField] private NPC _main;

    protected override void OnInteract(GameObject gameObject)
    {
        base.OnInteract(gameObject);
        Debug.Log($"{_main._name}");
    }
}
