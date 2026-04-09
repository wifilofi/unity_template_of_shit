using System.Threading;
using Cysharp.Threading.Tasks;

namespace Tools.GameFSM.ConcreteStates
{
    public class GameplayState : IState
    {
        private IGameStateMachine _stateMachine;
        public void BindGameStateMachine(IGameStateMachine gameStateMachine) => _stateMachine = gameStateMachine;

        public async UniTask Enter(CancellationTokenSource cancellationToken)
        {
            //G.GetLocal<GameplayUIView>().ShowScreen(UIScreen.Gameplay);
        }

        public async UniTask Exit() { }
    }
}