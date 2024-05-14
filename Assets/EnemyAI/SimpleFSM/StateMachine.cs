using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;
    [HideInInspector] public StatsUpdater enemy;

    private Dictionary<Type, Component> cachedComponents;
    protected void Init()
    {
        cachedComponents = new Dictionary<Type, Component>();
        enemy = GetComponent<StatsUpdater>();
    }

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.Update();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
    }

    public new T GetComponent<T>() where T : Component
    {
        if(cachedComponents.ContainsKey(typeof(T)))
            return cachedComponents[typeof(T)] as T;

        var component = base.GetComponent<T>();
        if(component != null)
        {
            cachedComponents.Add(typeof(T), component);
        }
        return component;
    }
}
