using CodeGenerator.Extensions;

namespace CodeGenerator.Generator;

public static partial class Generate
{
    public static async Task DataAccessAbstractContractAsync(string projectPath, IList<Type> entities)
    {
        var dir = $"{projectPath}";

        foreach (var entity in entities)
        {
            var filePath = $"{dir}\\I{entity.Name}Dal.cs";

            var fileContent =
                $@"
{GetFileHeader()}

using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface I{entity.Name}Dal : IEntityRepository<{entity.Name}>
{{
    //Custom Operations
}}
                ";

            await File.WriteAllTextAsync(filePath, fileContent.TrimFileContent());
        }
    }
}
