using System.Threading;
using Cysharp.Threading.Tasks;

namespace Tools.GameFSM.ConcreteStates
{
    public class WinState : IState
    {
        private IGameStateMachine _stateMachine;
        public void BindGameStateMachine(IGameStateMachine gameStateMachine) => _stateMachine = gameStateMachine;

        public async UniTask Enter(CancellationTokenSource cancellationToken = default)
        {
          //  G.GetLocal<GameplayUIView>().ShowScreen(UIScreen.Win);
        }

        public async UniTask Exit() { }
    }
}
