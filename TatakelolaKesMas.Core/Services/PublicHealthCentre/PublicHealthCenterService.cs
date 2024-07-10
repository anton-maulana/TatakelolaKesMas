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
using TatakelolaKesMas.Core.Services.PublicHealthCentre.Interfaces;
namespace TatakelolaKesMas.Core.Services.PublicHealthCentre
{
    public class PublicHealthCenterService(ApplicationDbContext dbContext, ILogger<PublicHealthCenterService> logger)
        : IPublicHealthCenterService
    {
        public async Task<List<PublicHealthCenter>> GetAll()
        {
            try
            {
                return await dbContext.PublicHealthCenters.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving item references.");
                throw; // Rethrow the exception after logging it
            }
        }
        
        public async Task AddItem(PublicHealthCenter item)
        {
            try
            {
                var region = dbContext.Regions.Find(item.FkRegionId);
                if (region != null)
                {
                    dbContext.Entry(region).State = EntityState.Unchanged;
                    item.Region = region;
                }

                // Attach the existing region to the context if not found directly
                if (item.Region == null)
                {
                    var existingRegion = new Region { Id = item.FkRegionId };
                    dbContext.Regions.Attach(existingRegion);
                    item.Region = existingRegion;
                }

                // Add the public health center
                dbContext.PublicHealthCenters.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error occurred while retrieving item references.");
                throw; // Rethrow the exception after logging it
            }
        }
        
    }
}
