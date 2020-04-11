
namespace PongEx1._Game.Behaviour
{
    class BehaviourFactory : IBehaviourFactory
    {
        public IBehaviour Create<T>() where T : IBehaviour, new()
        {
            return new T();
        }
    }
}
