
namespace PongEx1._Game.Behaviour
{
    /// <summary>
    /// This class is for creating behaviours and returning them
    /// </summary>
    class BehaviourFactory : IBehaviourFactory
    {
        /// <summary>
        /// Creates an IBehaviour and returns it back
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IBehaviour Create<T>() where T : IBehaviour, new()
        {
            //return new instance of an IBehaviour object
            return new T();
        }
    }
}
