using System;
using System.Collections.Generic;
using System.Text;
using NetArchTest.Rules;
using Xunit;
using FluentAssertions;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Code.Tests
{

    public class Class1
    {
        [SelfNamingFact]
        public void TryIt()
        {
            var result =
                Types.InCurrentDomain()
         .That()
         .ResideInNamespace("App.Modules.Core.Domain")
         .ShouldNot()
         .HaveDependencyOn("App.Modules.Core.Infrastructure")
         .GetResult()
         .IsSuccessful;

            result.Should().Be(true);
        }

        [SelfNamingFact]
        public void AllInterfacesShouldStartWithI()
        {
         
         var results =
             Types.InAssemblies(AppDomain.CurrentDomain.GetAppAssemblies())
                //Types.InCurrentDomain()
         .That()
         .AreInterfaces()
         .Should()
         .HaveNameStartingWith("I")
         .GetResult();

            var check = results.FailingTypes;

            // These are known to fail.

           // lName = "Lamar.IoC.Diagnostics.Line"}\"LamarCodeGeneration.Util.TextWriting.Line"}

    results.IsSuccessful.Should().Be(true);
        }


        //[SelfNamingFact]
        //public void ServicesShouldInheritFromBaseInterface()
        //{
        //    var result =
        //        Types.InCurrentDomain()
        // .That()
        // .ResideInNamespaceMatching($"{typeof(IDiagnosticsTracingService).Namespace.Replace(".","\\.")}*")
        // .And()
        // .AreClasses()
        // .And()
        // .AreNotAbstract()
        // .And()
        // .HaveNameEndingWith("Service")
        // .Should()
        // //.HaveDependencyOn(Shared.Contracts.Services.ISystemService)
        // .ImplementInterface(typeof(Shared.Contracts.Services.ISystemService))
        // .GetResult()
        // .IsSuccessful;
        //    result.Should().Be(true);
        //}

        //[SelfNamingFact]
        //public void ServicesShouldInheritFromBaseInterface()
        //{
        //    var result =
        //        Types.InCurrentDomain()
        // .That()
        // .HaveNameEndingWith("Service")
        // .Should()
        // //.HaveDependencyOn(Shared.Contracts.Services.ISystemService)
        // .ImplementInterface(typeof(Shared.Contracts.Services.ISystemService))
        // .GetResult()
        // .IsSuccessful;

        //    result.Should().Be(true);
        //}

    }
}
