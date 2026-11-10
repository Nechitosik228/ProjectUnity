using UnityEngine;
using DG.Tweening;

public class MainMenuButton : UIButton
{
    public override void Initialize()
    {
        base.Initialize();
    }
    protected override void SendPayLoad()
    {
        _eventBus.OnButtonClickTrigger(_type);
        base.SendPayLoad();
    }
}
