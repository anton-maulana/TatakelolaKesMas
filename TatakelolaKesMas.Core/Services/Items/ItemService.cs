// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TatakelolaKesMas.Core.Infrastructure;
using TatakelolaKesMas.Core.Models;
using TatakelolaKesMas.Core.Services.Items.Interfaces;
using TatakelolaKesMas.Core.Services.Shop;

namespace TatakelolaKesMas.Core.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ItemService> _logger;
        
        public ItemService(ApplicationDbContext dbContext, ILogger<ItemService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<List<ItemReference>> GetListItems()
        {
            try
            {
                return await _dbContext.ItemReferences.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving item references.");
                throw; // Rethrow the exception after logging it
            }
        }
        
        public async Task AddItem(ItemReference item)
        {
            try
            {
                _dbContext.ItemReferences.Add(item);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving item references.");
                throw; // Rethrow the exception after logging it
            }
        }
        
    }
}
