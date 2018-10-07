using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WWM.Application.Customers.Models;

namespace WWM.Service.Customer
{
    public interface ICustomerService : IService
    {
        Task<IEnumerable<CustomerListModel>> GetCustomerList();
        Task<CustomerDetailModel> GetCustomerById(Guid Id);
    }
}
