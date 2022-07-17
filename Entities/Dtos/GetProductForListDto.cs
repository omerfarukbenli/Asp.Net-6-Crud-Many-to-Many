using Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetProductForListDto: DtoBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
