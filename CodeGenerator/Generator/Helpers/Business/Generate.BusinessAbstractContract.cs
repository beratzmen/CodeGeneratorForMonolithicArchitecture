using CodeGenerator.Extensions;

namespace CodeGenerator.Generator;

public static partial class Generate
{
    public static async Task BusinessAbstractContractAsync(string projectPath, IList<Type> entities)
    {
        var dir = $"{projectPath}";

        foreach (var entity in entities)
        {
            var filePath = $"{dir}\\I{entity.Name}Service.cs";

            var fileContent =
                $@"
{GetFileHeader()}

using Entities.Concrete;

namespace Business.Abstract;

public interface I{entity.Name}Service
{{
    List<{entity.Name}> GetAll();
    List<{entity.Name}> GetById(int {entity.Name.ToLower()}Id);
    void Add({entity.Name} {entity.Name.ToLower()});
    void Update({entity.Name} {entity.Name.ToLower()});
    void Delete(int {entity.Name.ToLower()}Id);
}}
                ";

            await File.WriteAllTextAsync(filePath, fileContent.TrimFileContent());
        }
    }
}