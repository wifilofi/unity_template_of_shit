using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Tools.GameFSM.ConcreteStates;
using Unity.VisualScripting;

namespace Tools.GameFSM
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        public IExitableState _activeState;
        public UniTask currentEnter;
        public CancellationTokenSource cts;

        public GameStateMachine()
        {
            var bootstrapState = new BootstrapState();
            var gameplayState = new GameplayState();
            var winState = new WinState();
            var loseState = new LoseState();

            bootstrapState.BindGameStateMachine(this);
            gameplayState.BindGameStateMachine(this);
            winState.BindGameStateMachine(this);
            loseState.BindGameStateMachine(this);

            //TODO: add auto generic
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = bootstrapState,
                [typeof(GameplayState)] = gameplayState,
                [typeof(WinState)] = winState,
                [typeof(LoseState)] = loseState,
            };
        }

        public async UniTask Enter<TState>() where TState : class, IState
        {
            cts = new CancellationTokenSource();
            var state = await ChangeState<TState>();
            currentEnter = state.Enter(cts).AttachExternalCancellation(cts.Token);
            await currentEnter;
        }

        public void CancelState()
        {
            cts?.Cancel();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = await ChangeState<TState>();
            state.Enter(payload);
        }

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
            {
                await _activeState.Exit();
            }

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;
    }
}