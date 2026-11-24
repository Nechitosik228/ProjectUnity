using System;
using System.ComponentModel;
using UnityEngine;

public abstract class NPCBase : MonoBehaviour
{
    public NPCType _type { get; private set; }
    public NPCName _name { get; private set; }

    public virtual void Initialize(NPCStats stats)
    {
        _type = stats.Type;
        _name = stats.Name;
    }

    protected abstract void OnTickAi(float dt);
    protected abstract void OnTickPhysics(float dt);
    protected abstract void OnTickAnim(float dt);

    private void Update()
    {
        OnTickAi(Time.deltaTime);
    }

    private void FxedUpdate()
    {
        OnTickPhysics(Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        OnTickAnim(Time.deltaTime);
    }
}
