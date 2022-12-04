using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CustomerModel
    {
        public long? Id { get; init; }

        [Required]
        public string Firstname { get; init; } = null!;

        [Required]
        public string Lastname { get; init; } = null!;
    }
}