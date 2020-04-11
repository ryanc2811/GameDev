namespace PongEx1._Game.Behaviour
{
    public interface IBehaviourFactory
    {
        IBehaviour Create<T>() where T : IBehaviour,new();
    }
}
