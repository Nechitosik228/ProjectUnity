using UnityEngine;

public class MainMenuButton : UIButton
{
    private void Start()
    {
        OnClick();
    }
    protected override void Integer()
    {
        Debug.Log(_i += 1);
    }

    protected override void OnClick()
    {
        Debug.Log("Hello World");
        base.OnClick();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log("Gogogogo");
    }
}
