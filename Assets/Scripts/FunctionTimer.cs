using System;
using UnityEngine;

public class FunctionTimer
{
    public static FunctionTimer Create(Action action, float timer)
    {
        FunctionTimer functionTimer = new FunctionTimer(action, timer);

        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviorHook));
        gameObject.GetComponent<MonoBehaviorHook>().onUpdate = functionTimer.Update;

        return functionTimer;
    }
    private class MonoBehaviorHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null){
                onUpdate();
            }

        }
    }

    private Action action;
    private float timer;
    private bool isDetroyed;

    private FunctionTimer(Action action, float timer)
    {
        this.action = action;
        this.timer = timer;
        isDetroyed = false;

    }
    public void Update()
    {
        if (!isDetroyed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                // Realiza a ação
                action();
                DestroySelf();
            }
        }
    }
    private void DestroySelf()
    {
        isDetroyed = true;
    }
}