namespace Domain.Entities;

public class Customer : IEntity<long>
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
