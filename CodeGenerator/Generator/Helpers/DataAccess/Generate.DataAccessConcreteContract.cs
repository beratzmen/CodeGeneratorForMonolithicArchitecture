using CodeGenerator.Extensions;

namespace CodeGenerator.Generator;

public static partial class Generate
{
    public static async Task DataAccessConcreteContractAsync(string projectPath, IList<Type> entities)
    {
        var dir = $"{projectPath}";

        foreach (var entity in entities)
        {
            var filePath = $"{dir}\\{entity.Name}Dal.cs";

            var fileContent =
                $@"
{GetFileHeader()}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class {entity.Name}Dal : RepositoryBase<{entity.Name}, Context>, I{entity.Name}Dal
{{
    //Custom Operations
}}
                ";

            await File.WriteAllTextAsync(filePath, fileContent.TrimFileContent());
        }
    }
}
