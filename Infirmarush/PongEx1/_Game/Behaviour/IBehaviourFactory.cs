namespace PongEx1._Game.Behaviour
{
    /// <summary>
    /// interface for the IBehaviour Factory that creates and return new IBehaviours
    /// </summary>
    public interface IBehaviourFactory
    {
        /// <summary>
        /// Creates an IBehaviour and returns it back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IBehaviour Create<T>() where T : IBehaviour,new();
    }
}
