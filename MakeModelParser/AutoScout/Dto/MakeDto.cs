using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeModelParser.AutoScout.Dto
{
    public class MakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ModelDto> Models { get; set; }
    }
}
