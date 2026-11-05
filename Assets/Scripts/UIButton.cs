using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIButton : MonoBehaviour
{
    [SerializeField] internal int _i = 1;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private UIState _state;
    protected abstract void Integer();
    protected virtual void OnClick()
    {
        Debug.Log(_i);
    }

    private void Update()
    {
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }
}


public enum ButtonType
{

}