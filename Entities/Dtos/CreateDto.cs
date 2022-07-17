using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CreateDto
    {
        public string Name { get; set; }
        public int[] Categories { get; set; }
    }
}
