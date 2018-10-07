using System;
namespace Infrastructure.Identity.Policy
{
    public static class Policy
    {
        public readonly static string CanListCustomer = "CanListCustomer";
        public readonly static string CanWriteCustomer = "CanWriteCustomer";
        public readonly static string CanDeleteCustomer = "CanDeleteCustomer";
    }
}
