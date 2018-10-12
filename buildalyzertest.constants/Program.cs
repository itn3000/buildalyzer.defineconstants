using System;
using Buildalyzer;
using Buildalyzer.Workspaces;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
namespace buildalyzertest.constants
{
    class Program
    {
        static void OutputNamespaceMembers(INamespaceOrTypeSymbol ns)
        {
            switch(ns)
            {
                case ITypeSymbol t:
                    Console.WriteLine($"ns={ns}, {t.Name}");
                    break;
                case INamespaceSymbol nst:
                    foreach(var child in nst.GetMembers())
                    {
                        OutputNamespaceMembers(child);
                    }
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            var analyzer = new AnalyzerManager();
            var proj1 = analyzer.GetProject("../sandboxproject/sandboxproject.csproj");
            var ws = proj1.GetWorkspace();
            var compilation = ws.CurrentSolution.Projects.First().GetCompilationAsync().Result;
            foreach(var typeSymbol in compilation.Assembly.GlobalNamespace.GetMembers())
            {
                OutputNamespaceMembers(typeSymbol);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
