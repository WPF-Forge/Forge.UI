using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Forge.UI
{
    public class CodeManager
    {
        public Task<Assembly> GenerateAssembly(string code, string outputDll = "Scar.Injection.Generated.dll")
        {
            return Task.Run(() =>
            {
                var compilation = CreateCompilation(code, outputDll);
                var compilationResult = compilation.Emit(Path.Combine(Directory.GetCurrentDirectory(), outputDll));

                if (compilationResult.Success)
                {
                    return Assembly.LoadFrom(Path.Combine(Directory.GetCurrentDirectory(), outputDll));
                }

                foreach (var codeIssue in compilationResult.Diagnostics)
                {
                    throw new CompilationError(codeIssue,
                        $"ID: {codeIssue.Id}, Message: {codeIssue.GetMessage()}, Location: {codeIssue.Location.GetLineSpan()}, Severity: {codeIssue.Severity}");
                }

                return null;
            });
        }

        private static CSharpCompilation CreateCompilation(string code, string outputDll)
        {
            var compilation = CSharpCompilation.Create(outputDll)
                .WithOptions(
                    new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(AppDomain.CurrentDomain.GetAssemblies().Where(i => !i.IsDynamic)
                    .Distinct().Select(i => MetadataReference.CreateFromFile(i.Location)).OrderBy(i => i.FilePath)
                    .ToList())
                .AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(code));
            return compilation;
        }

        public Task<IEnumerable<Type>> GetTypesFrom(string path)
        {
            return Task.Run(() => Assembly.LoadFrom(path).GetTypes().AsEnumerable());
        }
    }
}