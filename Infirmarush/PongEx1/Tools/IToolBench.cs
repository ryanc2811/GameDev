using PongEx1.Entities.Button;

namespace PongEx1.Tools
{
    public interface IToolBench
    {
        void addTool(ITool tool);
        ITool getTool(string name);
        void SetToolButtons(IButton BoneSawButton);
    }
}