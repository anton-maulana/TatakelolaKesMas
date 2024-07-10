// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Common;
using TatakelolaKesMas.Core.Helpers;

namespace TatakelolaKesMas.Core.Models
{
    public class Region : BaseEntity<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }
        
        public RegionType Type { get; set; }
        
        [NotImported]
        [ForeignKey("FkParentId")]
        public virtual Region? Parent { get; set; }
        public string? FkParentId { get; set; }
    }
}