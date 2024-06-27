using System.ComponentModel.DataAnnotations;
using Model.Common;

namespace TatakelolaKesMas.Core.Models;

public class ItemReference : BaseEntity<int>
{
    public required string Code { get; set; }
    public required string Name { get; set; }
}