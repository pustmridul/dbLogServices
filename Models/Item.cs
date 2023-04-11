using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbLogServices.Models
{
    [Table("prd_Item")]
    public class Item
    {
        [Key]
        public int EntityId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public int? LastChangedBy { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Code { get; set; }
        public int ItemUnitId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
