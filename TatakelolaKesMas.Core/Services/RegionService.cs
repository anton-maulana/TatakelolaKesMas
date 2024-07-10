// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TatakelolaKesMas.Core.Infrastructure;
using TatakelolaKesMas.Core.Models;
using TatakelolaKesMas.Core.Models.Shop;
using TatakelolaKesMas.Core.Services.Interfaces;

namespace TatakelolaKesMas.Core.Services
{
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<RegionService> _logger;
        
        public RegionService(ApplicationDbContext dbContext, ILogger<RegionService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        

        public async Task<Region?> GetById(string id)
        {
            try
            {
                return await _dbContext.Regions.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving item references.");
                throw; // Rethrow the exception after logging it
            }
        }

        public async Task<List<Region>> GetByParentId(string id)
        {
            try
            {
                var anu = await _dbContext.Regions.Where(e => e.FkParentId == id && e.Id != "0").ToListAsync();
                return anu;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving item references.");
                throw; // Rethrow the exception after logging it
            }
        }
    }
}
