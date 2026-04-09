using System.Threading;
using Cysharp.Threading.Tasks;

namespace Tools.GameFSM.ConcreteStates
{
    public class LoseState : IState
    {
        private IGameStateMachine _stateMachine;
        public void BindGameStateMachine(IGameStateMachine gameStateMachine) => _stateMachine = gameStateMachine;

        public async UniTask Enter(CancellationTokenSource cancellationToken = default)
        {
            //G.GetLocal<GameplayUIView>().ShowScreen(UIScreen.Lose);
        }

        public async UniTask Exit() { }
    }
}
