using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;


public class Door : BaseInteractable
{
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private float _rotationTime = 1.5f;
    [SerializeField] private float _openRotation = 90f;

    private Tween _tween;
    private Ease _rotationEase = Ease.OutBack;
    private bool _isOpen = false;

    protected override void OnInteract(GameObject gameObject)
    {
        base.OnInteract(gameObject);
        AnimateDoor(_isOpen);
        _isOpen = !_isOpen;
        Debug.Log(_isOpen);
    }

    private void AnimateDoor(bool isOpen)
    {
        float rotationTarget = 0f;
        if (!isOpen)
        {
            rotationTarget = _openRotation;
        }
        _tween?.Kill();
        _tween = _pivotPoint.DOLocalRotate(new Vector3(0f, rotationTarget, 0f), _rotationTime).SetEase(_rotationEase);
    }
    protected override bool CanInteractInternal(GameObject gameObject)
    {
        Debug.Log("Door Can Interact");
        return base.CanInteractInternal(gameObject);
    }
}
