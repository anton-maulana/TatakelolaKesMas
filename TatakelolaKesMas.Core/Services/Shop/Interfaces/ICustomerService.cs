﻿// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using TatakelolaKesMas.Core.Models.Shop;

namespace TatakelolaKesMas.Core.Services.Shop.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetTopActiveCustomers(int count);
        // IEnumerable<Customer> GetAllCustomersData();
    }
}
