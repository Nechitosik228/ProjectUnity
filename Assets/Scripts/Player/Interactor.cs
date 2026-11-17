using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _interactDistance = 3f;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private Transform _interactPoint;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(_interactPoint.position, _interactDistance, _interactableLayer);
        if (colliders.Length > 0)
        {
            if (colliders[0].TryGetComponent(out IInteractable interactable))
            {
                if (interactable != null && interactable.CanInteract(gameObject))
                {
                    interactable.Interact(gameObject);
                }
            }
        }
    }
}
