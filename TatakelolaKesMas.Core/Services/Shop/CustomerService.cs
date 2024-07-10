// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Microsoft.EntityFrameworkCore;
using TatakelolaKesMas.Core.Infrastructure;
using TatakelolaKesMas.Core.Models.Shop;
using TatakelolaKesMas.Core.Services.Shop.Interfaces;

namespace TatakelolaKesMas.Core.Services.Shop
{
    public class CustomerService(ApplicationDbContext dbContext) : ICustomerService
    {
        public IEnumerable<Customer> GetTopActiveCustomers(int count) => throw new NotImplementedException();

        // public IEnumerable<Customer> GetAllCustomersData() => dbContext.Customers
        //         .Include(c => c.Orders).ThenInclude(o => o.OrderDetails).ThenInclude(d => d.Product)
        //         .Include(c => c.Orders).ThenInclude(o => o.Cashier)
        //         .AsSingleQuery()
        //         .OrderBy(c => c.Name)
        //         .ToList();
    }
}
