using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Domain
{
    [Keyless]
    public partial class VGetAllCategory
    {
        [StringLength(50)]
        public string ParentProductCategoryName { get; set; } = null!;
        [StringLength(50)]
        public string? ProductCategoryName { get; set; }
        [Column("ProductCategoryID")]
        public int? ProductCategoryId { get; set; }
    }
}
