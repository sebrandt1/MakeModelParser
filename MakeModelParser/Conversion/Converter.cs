using MakeModelParser.AutoScout.Dto;
using MakeModelParser.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeModelParser.Conversion
{
    public class Converter
    {
        public static Make MakeFromDto(MakeDto dto)
        {
            return new Make()
            {
                Name = dto.Name,
                Models = ModelListFromDtoList(dto.Models)
            };
        }

        public static List<Make> MakesFromDtoList(List<MakeDto> dtos)
        {
            var result = new List<Make>();

            foreach(var dto in dtos)
            {
                result.Add(MakeFromDto(dto));
            }
            return result;
        }

        private static Model ModelFromDto(ModelDto dto)
        {
            return new Model()
            {
                Name = dto.Name
            };
        }

        private static List<Model> ModelListFromDtoList(IList<ModelDto> dtos)
        {
            var result = new List<Model>();
            foreach (var dto in dtos)
            {
                result.Add(ModelFromDto(dto));
            }
            return result;
        }
    }
}
