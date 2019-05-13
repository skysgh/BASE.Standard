using System.Reflection;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
// associated with an assembly.

[assembly: AssemblyTitle("XAct.Diagrams.Uml.PlantUml")]
[assembly: AssemblyDescription("An XActLib assembly: a library of services to leverage PlantUML.")]
#if DEBUG
[assembly: AssemblyConfiguration("DEBUG")]
#else 
[assembly: AssemblyConfiguration("")]
#endif

[assembly: AssemblyCompany("XAct Software Solutions, Inc.")]
[assembly: AssemblyProduct("XActLib")]
[assembly: AssemblyCopyright("Copyright © XAct Software Solutions, Inc. 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]


//Begin:SIGNED
#if SIGNED
//Allow this signed assembly access from Partially trusted: http://bit.ly/vyFFTu
[assembly: System.Security.AllowPartiallyTrustedCallers] //Only If Signed
#if NET40
//When Ninject3 running in a .NET40 environment starts causing errors due to demanding
//more precise security. Can't do it, so added this:
[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)] //Only If Signed
//See note in NinjectMvcBootstrapper regarding Security.Critical use of IKernel

Example error:
...is marked with the AllowPartiallyTrustedCallersAttribute, and 
uses the level 2 security transparency model.  
Level 2 transparency causes all methods in AllowPartiallyTrustedCallers 
assemblies to become security transparent by default, which may be the cause of this exception.
#endif
#endif
//End:SIGNED

