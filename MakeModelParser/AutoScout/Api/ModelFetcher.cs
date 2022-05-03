using MakeModelParser.AutoScout.AutoscoutData;
using MakeModelParser.AutoScout.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeModelParser.AutoScout.Api
{
    public class ModelFetcher
    {

        public async Task MapAllModelsToMake(MakeDto makeDto)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://www.autoscout24.se/as24-home/api/taxonomy/cars/makes/{makeDto.Id}/models");
            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<ModelResponse>(data);
            var models = json.Models.Model.Values;

            makeDto.Models = new List<ModelDto>();
            foreach(var model in models)
            {
                makeDto.Models.Add(model);
            }
        }


    }
}
