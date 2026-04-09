using System.Threading;
using Cysharp.Threading.Tasks;

namespace Tools.GameFSM
{
    public interface IState : IExitableState
    {
        UniTask Enter(CancellationTokenSource cancellationToken = default);

        void BindGameStateMachine(IGameStateMachine gameStateMachine);
    }

    public interface IExitableState
    {
        UniTask Exit();
    }

    public interface IPayloadedState<TPayload> : IExitableState
    {
        void Enter(TPayload tPayload);
    }
}