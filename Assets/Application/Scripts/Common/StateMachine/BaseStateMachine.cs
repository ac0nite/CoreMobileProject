using System;
using System.Collections.Generic;
using Application;

namespace Common.StateMachine
{
    public class BaseStateMachine<TEnum> : IStateMachine<TEnum> where TEnum : Enum 
    {
        private TEnum _currentTypeState;
        private Dictionary<TEnum, IInternalState<TEnum>> _states;

        public BaseStateMachine()
        {
            _states = new Dictionary<TEnum, IInternalState<TEnum>>();
        }

        public TEnum CurrentTypeState => _currentTypeState;
        
        public InternalState<TEnum> Register(TEnum type, IState state)
        {
            var internalState = new InternalState<TEnum>(state);
            _states.Add(type, internalState);
            
            return internalState;
        }

        public void NextState()
        {
            var internalState = _states[_currentTypeState];
            if (!internalState.IsNextState())
            {
                Log.Warning(Prefix.FSM, $"Next state is empty! Current: [{_currentTypeState}]");
                return;
            }
            
            internalState.State.OnExit();

            _currentTypeState = internalState.NextState();
            
            Log.Debug(Prefix.FSM, $"Next state [{_currentTypeState}]");
            
            _states[_currentTypeState].State.OnEnter();
        }

        public void NextState(TEnum type)
        {
            var internalState = _states[_currentTypeState];
            if (!internalState.IsNextState(type))
            {
                Log.Warning(Prefix.FSM, "Next state is missing! Current: [{type}]");
                return;
            }
            
            internalState.State.OnExit();
            _currentTypeState = type;
            Log.Debug(Prefix.FSM, $"Next state [{_currentTypeState}]");
            
            _states[_currentTypeState].State.OnEnter();
        }

        public void ForceNextState(TEnum type)
        {
            if (!_states.ContainsKey(type))
            {
                Log.Warning($"[FSM] Force next state is missing [{type}]!");
                return;
            }
            
            var internalState = _states[type];
            internalState.State.OnExit();
            _currentTypeState = type;
            
            Log.Debug(Prefix.FSM, $"Force next state [{_currentTypeState}]");
            
            _states[_currentTypeState].State.OnEnter();
        }

        public void Run(TEnum type)
        {
            _currentTypeState = type;
            
            Log.Debug(Prefix.FSM, $"Run state [{_currentTypeState}]");
            
            _states[_currentTypeState].State.OnEnter();
        }
    }
}