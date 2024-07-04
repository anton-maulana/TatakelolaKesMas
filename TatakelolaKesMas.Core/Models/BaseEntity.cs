using System.ComponentModel.DataAnnotations;
using TatakelolaKesMas.Core.Models;

namespace Model.Common
{
    public class BaseEntity<TId> : IModel<TId>, IAuditableEntity
    {
        public virtual TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        
        [MaxLength(40)]
        public string? CreatedBy { get; set; }

        [MaxLength(40)]
        public string? UpdatedBy { get; set; }
        
        
    }
}