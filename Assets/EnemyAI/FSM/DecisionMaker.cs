using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DecisionMaker : MonoBehaviour
{
    [HideInInspector]public StateMachine sm;
    [HideInInspector]protected States newState;
    private void Awake()
    {
        sm = GetComponent<StateMachine>();
    }
    public abstract States Decide(States previousState);
}
