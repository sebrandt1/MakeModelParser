using MakeModelParser.AutoScout.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeModelParser.AutoScout.AutoscoutData
{
    public class MakeResponse
    {
        public MakeResponseData Make { get; set; }
    }

    public class MakeResponseData
    {
        public List<MakeDto> Values { get; set; }
    }


}
