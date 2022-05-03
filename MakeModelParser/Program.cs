using MakeModelParser.AutoScout.Api;
using MakeModelParser.Conversion;
using MakeModelParser.Database;

var makeDtos = await new MakeFetcher().GetAllMakes();
var modelFetcher = new ModelFetcher();

foreach(var make in makeDtos)
{
    await modelFetcher.MapAllModelsToMake(make);
}

var makes = Converter.MakesFromDtoList(makeDtos);

using(var dbContext = new DatabaseContext())
{
    foreach(var make in makes)
    {
        dbContext.Makes.Add(make);
    }
    await dbContext.SaveChangesAsync();
}

Console.WriteLine("Done");