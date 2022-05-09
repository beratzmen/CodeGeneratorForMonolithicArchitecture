using CodeGenerator.Extensions;

namespace CodeGenerator.Generator;

public static partial class Generate
{
    public static async Task BusinessConcreteContractAsync(string projectPath, IList<Type> entities)
    {
        var dir = $"{projectPath}";

        foreach (var entity in entities)
        {
            var filePath = $"{dir}\\{entity.Name}Manager.cs";

            var fileContent =
                $@"
{GetFileHeader()}

using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class {entity.Name}Manager : I{entity.Name}Service
{{
    private I{entity.Name}Dal _{entity.Name.ToLower()}Dal;

    public {entity.Name}Manager(I{entity.Name}Dal {entity.Name.ToLower()}Dal)
    {{
        _{entity.Name.ToLower()}Dal = {entity.Name.ToLower()}Dal;
    }}

    public void Add({entity.Name} entity)
    {{
        _{entity.Name.ToLower()}Dal.Add(entity);
    }}

    public void Delete(int entityId)
    {{
        _{entity.Name.ToLower()}Dal.Delete(new {entity.Name} {{ {entity.Name}Id = entityId }});
    }}

    public List<{entity.Name}> GetAll()
    {{
        return _{entity.Name.ToLower()}Dal.GetList();
    }}

    public List<{entity.Name}> GetById(int entityId)
    {{
        return _{entity.Name.ToLower()}Dal.GetList(p => p.{entity.Name}Id == entityId);
    }}

    public void Update({entity.Name} entity)
    {{
        _{entity.Name.ToLower()}Dal.Update(entity);
    }}
}}
";

            await File.WriteAllTextAsync(filePath, fileContent.TrimFileContent());
        }
    }
}