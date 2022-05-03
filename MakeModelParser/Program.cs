using MakeModelParser.AutoScout.Api;
using MakeModelParser.Conversion;
using MakeModelParser.Database;

var makeDtos = await new MakeFetcher().GetAllMakes();

var makes = Converter.MakesFromDtoList(makeDtos);
Console.WriteLine(makes.Count);
Console.WriteLine(makes.Sum(x => x.Models.Count));

using(var dbContext = new DatabaseContext())
{
    foreach(var make in makes)
    {
        dbContext.Makes.Add(make);
    }
    await dbContext.SaveChangesAsync();
}

Console.WriteLine("Done");