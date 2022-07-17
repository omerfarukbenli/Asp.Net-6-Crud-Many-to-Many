using Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product: EntityBase, IEntity
    {
        public string Name { get; set; }
        public ICollection<CategoryAndProduct> CategoryAndProduct { get; set; }
    }
}
