// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Common;

namespace TatakelolaKesMas.Core.Models.Shop
{
    public class Region : BaseEntity<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }
        
        public RegionType Type { get; set; }
        
        [ForeignKey("Parent")]
        public string fkParentId { get; set; }
        public virtual Region Parent { get; set; }
    }
}