using PongEx1.Entities.Button;

namespace PongEx1.Tools
{
    /// <summary>
    /// INTERFACE FOR THE TOOL BENCH ENTITY, WHICH STORES ALL THE TOOLS IN THE GAME
    /// </summary>
    public interface IToolBench
    {
        /// <summary>
        /// SETTER FOR THE TOOLS
        /// </summary>
        /// <param name="tool"></param>
        void addTool(ITool tool);
        /// <summary>
        /// GETTER FOR THE TOOLS
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ITool getTool(string name);
        /// <summary>
        /// SETTER FOR THE TOOL BUTTONS
        /// </summary>
        /// <param name="boneSawButton"></param>
        /// <param name="leechButton"></param>
        void SetToolButtons(IButton boneSawButton, IButton leechButton);
    }
}