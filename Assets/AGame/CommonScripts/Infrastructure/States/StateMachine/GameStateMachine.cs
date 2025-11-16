using AGame.Infrastructure.States.Factory;
using AGame.Infrastructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;
using Zenject;

namespace AGame.Infrastructure.States.StateMachine
{
 public class GameStateMachine : IGameStateMachine, ITickable
    {
        private IExitableState _activeState;
        private readonly IStateFactory _stateFactory;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
                updateableState.Update();
        }
        
        public async UniTaskVoid Enter<TState>() where TState : class, IState
        {
            var state = await RequestEnter<TState>();
        }
        
        public async UniTaskVoid Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = await RequestEnter<TState, TPayload>(payload);
        }

        private async UniTask<TState> RequestEnter<TState>() where TState : class, IState
        {
            var state = await RequestChangeState<TState>();
            return EnterState(state);
        }

        private async UniTask<TState> RequestEnter<TState, TPayload>(TPayload payload) 
            where TState : class, IPayloadState<TPayload>
        {
            var state = await RequestChangeState<TState>();
            return EnterPayloadState(state, payload);
        }

        private TState EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
            state.Enter();
            return state;
        }

        private TState EnterPayloadState<TState, TPayload>(TState state, TPayload payload) 
            where TState : class, IPayloadState<TPayload>
        {
            _activeState = state;
            state.Enter(payload);
            return state;
        }

        private async UniTask<TState> RequestChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
            {
                await _activeState.BeginExit();
                _activeState.EndExit();
            }

            return await ChangeState<TState>();
        }

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            await UniTask.Yield(); // просто для асинхронності (можна прибрати)
            return _stateFactory.GetState<TState>();
        }
    }
}