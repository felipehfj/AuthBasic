namespace Http.Handlers;
public class FakeApiHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("x-me", "myself");

        return await base.SendAsync(request, cancellationToken);
    }
}