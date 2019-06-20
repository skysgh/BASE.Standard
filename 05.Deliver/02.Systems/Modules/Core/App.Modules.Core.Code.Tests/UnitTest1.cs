//using System;
//using System.Collections.Generic;
//using System.IO;
//using Xunit;
//using System.Linq;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.Diagnostics;
//using Microsoft.CodeAnalysis.MSBuild;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using FluentAssertions;

//namespace App.Modules.Core.Code.Tests
//{
//    public static class DirectoryInfoExtensions {

//        public static FileInfo FindInAnscestors(this DirectoryInfo directoryInfo, string searchPattern)
//        {
//            if (directoryInfo == null) { return null; }
//            if (!directoryInfo.Exists) { return null; }

//            FileInfo file = directoryInfo.GetFiles(searchPattern).FirstOrDefault();
//            if (file != null) { return file; }
//            return FindInAnscestors(directoryInfo.Parent, searchPattern);
//        }
//    }
//    public class SolutionSanity
//    {
//        private readonly List<Microsoft.CodeAnalysis.Document> _documents;

//        public SolutionSanity()
//        {
//            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
//            var fileInfo = directoryInfo.FindInAnscestors("*.sln");

//            var slnPath = fileInfo.FullName;

//            var workspace = AdhocWorkspace.Create();

//            var solution = workspace.OpenSolutionAsync(slnPath).Result;

//            _documents = new List<Document>();

//            foreach (var projectId in solution.ProjectIds)
//            {
//                var project = solution.GetProject(projectId);

//                foreach (var documentId in project.DocumentIds)
//                {
//                    var document = solution.GetDocument(documentId);

//                    if (document.SupportsSyntaxTree)
//                    {
//                        _documents.Add(document);
//                    }
//                }
//            }
//        }

//        [SelfNamingFact]
//        public void Interfaces_ShouldBePrefixedWithI()
//        {
//            var interfaces = _documents
//                .SelectMany(x => x.GetSyntaxRootAsync()
//                .Result.DescendantNodes()
//                .OfType<InterfaceDeclarationSyntax>()).ToList();

//            interfaces.All(x => x.Identifier.ToString().StartsWith("I")).Should().BeTrue();
//        }
//    }
//}
