using System.Net.Http;
using System.Net.Http.Json;
using TodoApi.Models.Response;

namespace Http.Clients
{
    public interface ITodoHttpClient
    {
        Task<ICollection<TodoModel>> GetTodos(CancellationToken cancellationToken = default);
        Task<TodoModel> GetOne(int id, CancellationToken cancellationToken = default);
    }

    public class TodoHttpClient : HttpClient, ITodoHttpClient
    {
        HttpClient Client { get; }

        public TodoHttpClient(IHttpClientFactory clientFactory)
        {
            Client = clientFactory.CreateClient("FakeAPI");
        }


        public async Task<ICollection<TodoModel>> GetTodos(CancellationToken cancellationToken = default)
        {
            return await Client.GetFromJsonAsync<TodoModel[]>("/todos", cancellationToken) ?? [];
        }   

        public async Task<TodoModel> GetOne(int id, CancellationToken cancellationToken = default)
        {
            return await Client.GetFromJsonAsync<TodoModel>($"/todos/{id}", cancellationToken) ?? default!;
        }   
    }
}