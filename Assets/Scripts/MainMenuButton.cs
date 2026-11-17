using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : UIButton, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 _originalScale;
    [SerializeField] private float _scaleFactor = 1.2f;
    [SerializeField] private float _scaleTime = 0.15f;
    [SerializeField] private Ease _scaleEase = Ease.OutQuad;
    [SerializeField] private Ease _DEscaleEase = Ease.InQuad;
    private Sequence _clickSequence;
    private Tween _scaleTween;

    protected override void Initialize()
    {
        base.Initialize();
        _originalScale = transform.localScale;
    }
    protected override void DeInitialize()
    {
        base.DeInitialize();
        if (_scaleTween != null)
        {
            _scaleTween.Kill();
        }
        _clickSequence?.Kill();
    }
    protected override void SendPayLoad()
    {
        //event_Bus.OnButtonClickTrigger(_Type);
        base.SendPayLoad();
        PLayClickAnim();

    }
    private void SendEvent()
    {
        _eventBus.OnButtonClickTrigger(_type);
    }
    private void PLayClickAnim()
    {
        _clickSequence?.Kill();
        _clickSequence = DOTween.Sequence()
        .Append(transform.DOScale(_originalScale * _scaleFactor * 50, _scaleTime * 2).SetEase(_scaleEase))
        .Append(transform.DOScale(_originalScale, _scaleTime).SetEase(_DEscaleEase))
        .Join(transform.DORotate(new Vector3(1500, 15, 10), _scaleTime).SetEase(_scaleEase))
        .OnComplete(SendEvent);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_scaleTween != null)
        {
            _scaleTween.Kill();
        }
        _scaleTween = transform.DOScale(_originalScale * _scaleFactor, _scaleTime).SetEase(_scaleEase);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_scaleTween != null)
        {
            _scaleTween.Kill();
        }
        _scaleTween = transform.DOScale(_originalScale, _scaleTime).SetEase(_DEscaleEase);
    }
}