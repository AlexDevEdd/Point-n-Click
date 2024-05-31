using Cysharp.Threading.Tasks;

namespace App
{
    public interface IState: IExitableState
    {
        public UniTask Enter();
    }
  
    public interface IExitableState
    {
        public UniTask Exit();
    }
  
    public interface IPaylodedState<TPayload> : IExitableState
    {
        public UniTask Enter(TPayload payload);
    }
}