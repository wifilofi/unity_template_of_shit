using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

namespace Tools.GameFSM
{
    
    public interface IGameStateMachine
    {
        public UniTask Enter<TState>() where TState : class, IState;
        public UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    }
}