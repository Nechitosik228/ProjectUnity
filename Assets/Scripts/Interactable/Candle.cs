using UnityEngine;

public class Candle : BaseInteractable
{
    [SerializeField] private ParticleSystem _flame;
    [SerializeField] private GameObject _light;
    private bool _isLighted;

    protected override void OnInteract(GameObject gameObject)
    {
        base.OnInteract(gameObject);
        if (!_isLighted)
        {
            _flame.Play();
        }
        else
        {
            _flame.Stop();
        }
        _isLighted = !_isLighted;
        _light.SetActive(_isLighted);
    }
}
