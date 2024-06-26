﻿    // ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Model.Common;

namespace TatakelolaKesMas.Core.Models.Shop
{
    public class ProductCategory : BaseEntity<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }

        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
