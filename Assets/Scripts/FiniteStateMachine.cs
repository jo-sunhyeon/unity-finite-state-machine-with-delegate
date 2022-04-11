using System;
using System.Collections.Generic;

public class FiniteStateMachine<TState> : IFiniteStateMachine where TState : struct, Enum
{
    public TState? State
    {
        get
        {
            return state;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            if (state != null && exitActions.TryGetValue(state.Value, out Action exitAction) && exitAction != null)
            {
                exitAction();
            }
            state = value;
            if (enterActions.TryGetValue(state.Value, out Action enterAction) && enterAction != null)
            {
                enterAction();
            }
        }
    }

    public void AddState(TState state, Action enterAction, Action updateAction, Action exitAction)
    {
        enterActions[state] = enterAction;
        updateActions[state] = updateAction;
        exitActions[state] = exitAction;
    }

    public void Update()
    {
        if (state != null && updateActions.TryGetValue(state.Value, out Action action) && action != null)
        {
            action();
        }
    }

    private TState? state;
    private Dictionary<TState, Action> enterActions = new Dictionary<TState, Action>();
    private Dictionary<TState, Action> updateActions = new Dictionary<TState, Action>();
    private Dictionary<TState, Action> exitActions = new Dictionary<TState, Action>();
}
