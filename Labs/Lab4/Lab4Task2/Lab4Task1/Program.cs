CancellationTokenSource cts = new();
CancellationToken cancellationToken = cts.Token;


Dictionary<char, string> endpoints = new()
{
    {'1', "/success" },
    {'2', "/temporary" },
    {'3', "/timeout" },
    {'4', "/unavailable" },
    {'5', "/bad-request" },
    {'6', "/reset" },
};

using (var client = new HttpClient
{
    BaseAddress = new Uri("http://localhost:8081"),
}){
    char action;
    var selectedEndpoint = "";

    while (!cancellationToken.IsCancellationRequested)
    {
        Console.WriteLine("---Клиент апи---");
        foreach (var endpoint in endpoints)
            Console.WriteLine($"[{endpoint.Key}] - {endpoint.Value}");

        do
        {
            action = Console.ReadKey(true).KeyChar;
        }
        while (!endpoints.Keys.Contains(action));

        selectedEndpoint = endpoints[action];

        try
        {
            using (HttpResponseMessage response = await client.GetAsync(selectedEndpoint))
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Status: {(int)response.StatusCode} {response.StatusCode}");
                Console.WriteLine($"Body: {content}");
            };
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("Время ожидания запроса истекло");
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Ошибка HTTP: {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }

        Console.WriteLine("Нажмите Enter, чтобы продолжить.");
        while (ConsoleKey.Enter != Console.ReadKey(true).Key)
            continue;

        Console.Clear();
    }
};

