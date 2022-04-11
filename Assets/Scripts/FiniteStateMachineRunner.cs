using System;
using UnityEngine;

public class FiniteStateMachineRunner : MonoBehaviour
{
    public FiniteStateMachine<TState> Initialize<TState>() where TState : struct, Enum
    {
        var finiteStateMachine = new FiniteStateMachine<TState>();
        this.finiteStateMachine = finiteStateMachine;
        return finiteStateMachine;
    }

    private void Update()
    {
        finiteStateMachine.Update();
    }

    private IFiniteStateMachine finiteStateMachine;
}
