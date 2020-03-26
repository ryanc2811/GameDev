namespace PongEx1.Tools
{
    public interface IToolBench
    {
        void addTool(ITool tool);
        ITool getTool(string name);
    }
}