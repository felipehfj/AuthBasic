namespace Contracts.StateContainers;

public interface IStateContainer
{
    event Action? OnChange;

    void NotifyStateChanged();
}
