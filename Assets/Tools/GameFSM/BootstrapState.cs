using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Tools.GameFSM
{
    public class BootstrapState : IState
    {
        private IGameStateMachine _stateMachine;
        public void BindGameStateMachine(IGameStateMachine gameStateMachine) => _stateMachine = gameStateMachine;

        public async UniTask Enter(CancellationTokenSource cancellationToken = default)
        {
            Debug.Log("bootstrap");
        }

        public async UniTask Exit()
        {
        }
    }
}