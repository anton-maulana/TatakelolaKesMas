// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using TatakelolaKesMas.Core.Models;

namespace TatakelolaKesMas.Core.Services.Shop
{
    public interface IItemService
    {

        Task<List<ItemReference>> GetListItems();
        Task AddItem(ItemReference item);
    }
}
