using CodeGenerator.Extensions;
using System.Text;

namespace CodeGenerator.Generator;

public static partial class Generate
{
    public static async Task ContextContractAsync(string projectPath, IList<Type> entities)
    {
        var filePath = $"{projectPath}\\Context.cs";

        var sb = new StringBuilder();

        sb.AppendLine(GetFileHeader());

        sb.AppendLine();

        sb.AppendLine("using Entities.Concrete;");

        sb.AppendLine("using Microsoft.EntityFrameworkCore;");

        sb.AppendLine("");

        sb.AppendLine("namespace DataAccess.Concrete.EntityFramework;");

        sb.AppendLine("");

        sb.AppendLine("public class Context : DbContext");

        sb.AppendLine("{");

        sb.AppendLine("     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
        sb.AppendLine("     {");
        sb.AppendLine(@"         optionsBuilder.UseSqlServer(""Server =.; Database = test; trusted_connection = false; User Id = sa; Password = Berat41Berat;"");");
        sb.AppendLine("     }");
        sb.AppendLine("");

        foreach (var entity in entities)
        {
            sb.AppendLine($"    public DbSet<{entity.Name}> {entity.Name} {{ get; set; }}");
        }

        sb.AppendLine("}");

        var fileContent = sb.ToString();

        await File.WriteAllTextAsync(filePath, fileContent.TrimFileContent());
    }
}
