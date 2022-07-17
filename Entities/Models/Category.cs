using Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category: EntityBase, IEntity //baseler
    {
        public string Name { get; set; }
        public ICollection<CategoryAndProduct> CategoryAndProduct { get; set; }
    }
}
