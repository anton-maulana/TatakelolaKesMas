using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Common;
using TatakelolaKesMas.Core.Models.Shop;

namespace TatakelolaKesMas.Core.Models;

public class ItemTransaction : BaseEntity<int>
{
    public int QuantityDelivered { get; set; }
    public int QuantityReceived { get; set; }
    public string NotesFromHead { get; set; }
    public string NotesFromPpk { get; set; }
    public string NotesFromClinic { get; set; }
    
    [ForeignKey(nameof(FkItemId))]
    public virtual ItemReference Item { get; set; }
    public int FkItemId { get; set; }
}