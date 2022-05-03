using MakeModelParser.AutoScout.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeModelParser.AutoScout.AutoscoutData
{
    public class ModelResponse
    {
        public ModelResponseDataLayer Models { get; set; }
    }

    public class ModelResponseData
    {
        public List<ModelDto> Values { get; set; }
    }

    public class ModelResponseDataLayer
    {
        public ModelResponseData Model { get; set; }
    }
}
