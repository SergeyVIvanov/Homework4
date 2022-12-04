using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebClient;

static class Program
{
    private const string WebApiBaseAddress = "https://localhost:5001";

    static async Task Main()
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(WebApiBaseAddress);

        long customerId;
        Console.Write("Enter customer Id: ");
        while (!long.TryParse(Console.ReadLine(), out customerId)) ;

        var response = await httpClient.GetAsync($"customers/{customerId}");
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        Console.ReadLine();
    }

    private static CustomerCreateRequest RandomCustomer()
    {
        throw new NotImplementedException();
    }
}