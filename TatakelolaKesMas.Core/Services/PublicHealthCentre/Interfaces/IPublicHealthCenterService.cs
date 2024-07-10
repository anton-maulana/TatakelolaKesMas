// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using TatakelolaKesMas.Core.Models;

namespace TatakelolaKesMas.Core.Services.PublicHealthCentre.Interfaces
{
    public interface IPublicHealthCenterService
    {

        Task<List<PublicHealthCenter>> GetAll();
        Task AddItem(PublicHealthCenter item);
    }
}
