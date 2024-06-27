using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Common;
using TatakelolaKesMas.Core.Models.Shop;

namespace TatakelolaKesMas.Core.Models;

public class ClinicHealth : BaseEntity<int>
{
    public required string ClinicCode { get; set; }
    public required string Name { get; set; }
    public required string NameHeadCenter { get; set; }
    public required string NipHeadCenter { get; set; }
    public required string Phone { get; set; }
    public required string Status { get; set; }
    
    [ForeignKey(nameof(FkRegionId))]
    public Region Region { get; set; }
    public string FkRegionId { get; set; }
}