using MakeModelParser.AutoScout.AutoscoutData;
using MakeModelParser.AutoScout.Dto;
using MakeModelParser.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeModelParser.AutoScout.Api
{
    public class MakeFetcher
    {
        private readonly ModelFetcher modelFetcher;

        public MakeFetcher()
        {
            modelFetcher = new ModelFetcher();
        }
        public async Task<List<MakeDto>> GetAllMakes()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://www.autoscout24.se/as24-home/api/taxonomy/cars/search-filters");
            var data = await response.Content.ReadAsStringAsync();

            var json = JsonConvert.DeserializeObject<MakeResponse>(data);
            var makes = json.Make.Values;

            foreach(var make in makes)
            {
                make.Models = await modelFetcher?.GetModelsByMakeId(make.Id);
            }
            return makes;
        }
    }
}
