using Contracts.StateContainers;
using TodoApi.Models.Response;

namespace StateContainers;

public class TodoStore : IStateContainer
{    
    public ICollection<TodoModel> TodoModels { get; set; } = [];
    public event Action? OnChange;

    public void NotifyStateChanged() => OnChange?.Invoke();    
   
}

