using System.Reflection;
using CodeGenerator.Generator;
using Entities.Marker;

const string SolutionFilename = "Solution.sln";
const string EntityNamespace = "Entities.Concrete";
var entityProperties = new Dictionary<string, IList<PropertyInfo>>();

string solutionPath;


solutionPath = AppContext.BaseDirectory;

while (!string.IsNullOrEmpty(solutionPath))
{
    if (File.Exists(Path.Combine(solutionPath, SolutionFilename)))
    {
        break;
    }

    solutionPath = Path.GetDirectoryName(solutionPath);
}

if (string.IsNullOrEmpty(solutionPath))
{
    Console.Error.WriteLine("Solution path not found.");
}

Console.WriteLine($"Solution path: {solutionPath}");

var contextPath = $"{solutionPath}\\DataAccess\\Concrete\\EntityFramework";
var dataAccessAbstractPath = $"{solutionPath}\\DataAccess\\Abstract";
var dataAccessConcretePath = $"{solutionPath}\\DataAccess\\Concrete\\EntityFramework";
var businessAbstractPath = $"{solutionPath}\\Business\\Abstract";
var businessConcretePath = $"{solutionPath}\\Business\\Concrete";

var entities =
    typeof(ICoreAssemblyMarker).Assembly
        .GetTypes()
        .Where(
            t =>
                t.Namespace == EntityNamespace &&
                t.GetCustomAttributes().Select(o => o.GetType()).All(attr => attr.Name != "CompilerGeneratedAttribute"))
        .ToArray();

foreach (var entity in entities)
{
    Console.WriteLine(entity.Name);

    var properties =
        entity
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(p => p)
            .ToArray();

    foreach (var property in properties)
    {
        Console.WriteLine("- {0}", property.Name);
    }

    entityProperties.Add(entity.FullName, properties);
}

RecreateDirectories();

await Generate.ContextContractAsync(contextPath, entities);
await Generate.DataAccessAbstractContractAsync(dataAccessAbstractPath, entities);
await Generate.DataAccessConcreteContractAsync(dataAccessConcretePath, entities);
await Generate.BusinessAbstractContractAsync(businessAbstractPath, entities);
await Generate.BusinessConcreteContractAsync(businessConcretePath, entities);

//Dosya oluşturma
void RecreateDirectories()
{
    Console.WriteLine("Recreating directories...");

    var directories =
        new[]
        {
            $"{dataAccessAbstractPath}",
            $"{dataAccessConcretePath}",
            $"{businessAbstractPath}",
            $"{businessConcretePath}",
            $"{contextPath}",
        };

    foreach (var dir in directories)
    {
        if (Directory.Exists(dir))
        {
            Console.WriteLine($"- Deleting: {dir}");

            Directory.Delete(dir, true);
        }

        Console.WriteLine($"- Creating: {dir}");

        Directory.CreateDirectory(dir);
    }
}
