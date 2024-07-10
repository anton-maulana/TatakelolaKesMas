// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using TatakelolaKesMas.Core.Models;
using TatakelolaKesMas.Core.Models.Shop;

namespace TatakelolaKesMas.Core.Services.Interfaces
{
    public interface IRegionService
    {
        Task<Region?> GetById(string id);
        Task<List<Region>> GetByParentId(string id);
    }
}
