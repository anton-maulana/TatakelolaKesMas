using System.ComponentModel.DataAnnotations;
using TatakelolaKesMas.Attributes;
using TatakelolaKesMas.Core.Extensions;
using TatakelolaKesMas.ViewModels.Account;

namespace TatakelolaKesMas.Server.ViewModels.ItemReference
{
    public class ItemVM : ISanitizeModel
    {
        public virtual void SanitizeModel()
        {
            Id = Id.NullIfWhiteSpace();
            Name = Name.NullIfWhiteSpace();
            Code = Code.NullIfWhiteSpace();
        }

        public string? Id { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        public string? Code { get; set; }
    }
}