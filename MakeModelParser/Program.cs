using MakeModelParser.AutoScout.Api;
using MakeModelParser.Conversion;
using MakeModelParser.Database;

var makeDtos = await new MakeFetcher().GetAllMakes();

var makes = Converter.MakesFromDtoList(makeDtos);
Console.WriteLine($"Fetched {makes.Count} car makes.");
Console.WriteLine($"Fetched {makes.Sum(x => x.Models.Count)} car models.");

using(var dbContext = new DatabaseContext())
{
    foreach(var make in makes)
    {
        dbContext.Makes.Add(make);
    }
    await dbContext.SaveChangesAsync();
    Console.WriteLine("Saved all makes and models");
}

Console.WriteLine("Done");