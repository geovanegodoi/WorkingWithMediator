using System;
namespace WWM.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
