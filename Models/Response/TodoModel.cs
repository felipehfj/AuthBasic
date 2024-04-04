namespace TodoApi.Models.Response;

public class TodoModel
{
    public int Id { get; set; }
    public string Title { get; set; }=string.Empty;
    public bool Completed { get; set; }
    public int UserId { get; set; }
}