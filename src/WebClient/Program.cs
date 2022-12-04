using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebClient;

static class Program
{
    private const string WebApiBaseAddress = "https://localhost:5001";

    private static readonly string[] FirstNames = { "Тест", "Джон", "Санса", "Дейнерис", "Петир" };
    private static readonly string[] LastNames = { "Тестов", "Сноу", "Старк", "Таргариен", "Бейлиш" };

    static async Task Main()
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(WebApiBaseAddress);

        long customerId;
        Console.Write("Enter customer Id: ");
        while (!long.TryParse(Console.ReadLine(), out customerId)) ;

        Console.WriteLine("Customer:");
        await ShowCustomerInfo(httpClient, customerId);

        customerId = await AddRandomCustomer(httpClient);
        Console.WriteLine("New customer:");
        await ShowCustomerInfo(httpClient, customerId);
    }

    private static async Task<long> AddRandomCustomer(HttpClient httpClient)
    {
        var customerRequest = CreateRandomCustomerRequest();

        var response = await httpClient.PostAsJsonAsync("customers", customerRequest, default);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<long>();
    }

    private static CustomerCreateRequest CreateRandomCustomerRequest()
    {
        string GetRandomItem(string[] items)
        {
            return items[Random.Shared.Next(items.Length)];
        }

        return new CustomerCreateRequest(GetRandomItem(FirstNames), GetRandomItem(LastNames));
    }

    private static async Task ShowCustomerInfo(HttpClient httpClient, long customerId)
    {
        var response = await httpClient.GetAsync($"customers/{customerId}");
        try
        {
            response.EnsureSuccessStatusCode();

            var customer = await response.Content.ReadFromJsonAsync<Customer>();

            Console.WriteLine($"    Id: {customer.Id}");
            Console.WriteLine($"    Firstname: \"{customer.Firstname}\"");
            Console.WriteLine($"    Lastname: \"{customer.Lastname}\"");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}