using Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetProductWithCategoryDto:DtoBase
    {
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
