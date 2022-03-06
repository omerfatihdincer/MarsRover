namespace MarsRover.Managers
{
    public interface IRoverManager
    {
        void Execute(string command);
        string GetStatus();
    }
}
