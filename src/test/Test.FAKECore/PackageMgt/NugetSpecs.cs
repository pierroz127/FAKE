﻿using System;
using System.IO;
using System.Linq;
using Fake;
using Machine.Specifications;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Collections;

namespace Test.FAKECore.PackageMgt
{
    public class when_packing_with_nuspec_template
    {
        static string tempDir, pkgFile, nuspecFile;
        static FSharpFunc<NuGetHelper.NuGetParams, NuGetHelper.NuGetParams> nugetParams;

        Establish context = () =>
        {
            tempDir = Path.GetTempPath();
            pkgFile = Path.Combine(tempDir, "fake.0.0.1.nupkg");
            nuspecFile = Path.Combine(TestData.TestDataDir, "fake.nuspec");

            try { File.Delete(pkgFile); } catch (FileNotFoundException) {}

            nugetParams = FSharpFuncUtil.ToFSharpFunc<NuGetHelper.NuGetParams, NuGetHelper.NuGetParams>(
                p => new NuGetHelper.NuGetParams(
                    authors: ListModule.OfSeq(new [] { "author" }),
                    project: "fake",
                    description: "description",
                    outputPath: tempDir,
                    summary: "summary",
                    workingDir: TestData.TestDataDir,
                    version: "0.0.1",

                    files: ListModule.OfSeq(new [] { new Tuple<string, FSharpOption<string>, FSharpOption<string>>("*.*", FSharpOption<string>.None, FSharpOption<string>.None) }),

                    accessKey: p.AccessKey,
                    copyright: p.Copyright,
                    dependencies: p.Dependencies,
                    dependenciesByFramework: p.DependenciesByFramework,
                    includeReferencedProjects: p.IncludeReferencedProjects,
                    noPackageAnalysis: p.NoPackageAnalysis,
                    projectFile: p.ProjectFile,
                    properties: p.Properties,
                    publish: p.Publish,
                    publishTrials: p.PublishTrials,
                    publishUrl: p.PublishUrl,
                    references: p.References,
                    referencesByFramework: p.ReferencesByFramework,
                    releaseNotes: p.ReleaseNotes,
                    symbolPackage: p.SymbolPackage,
                    tags: p.Tags,
                    timeOut: p.TimeOut,
                    title: p.Title,
                    toolPath: p.ToolPath
                )
            );
        };

        Because of = () => NuGetHelper.NuGetPack(nugetParams, nuspecFile);
        It should_create_nupkg_file = () =>
        {
            File.Exists(pkgFile).ShouldBeTrue();
        };
    }

    public class when_packing_with_a_complete_nuspec_file
    {
        static string tempDir, pkgFile, nuspecFile;
        static FSharpFunc<NuGetHelper.NuGetParams, NuGetHelper.NuGetParams> nugetParams;

        Establish context = () =>
        {
            tempDir = Path.GetTempPath();
            pkgFile = Path.Combine(tempDir, "fake_complete.0.0.1.nupkg");
            nuspecFile = Path.Combine(TestData.TestDataDir, "fake_complete.nuspec");

            try { File.Delete(pkgFile); } catch (FileNotFoundException) {}

            nugetParams = FSharpFuncUtil.ToFSharpFunc<NuGetHelper.NuGetParams, NuGetHelper.NuGetParams>(
                p => new NuGetHelper.NuGetParams(
                    authors: ListModule.OfSeq(new [] { "author" }),
                    project: "fake",
                    description: "description",
                    outputPath: tempDir,
                    summary: "summary",
                    workingDir: TestData.TestDataDir,
                    version: "0.0.1",

                    files: ListModule.OfSeq(new [] { new Tuple<string, FSharpOption<string>, FSharpOption<string>>("*.*", FSharpOption<string>.None, FSharpOption<string>.None) }),

                    accessKey: p.AccessKey,
                    copyright: p.Copyright,
                    dependencies: p.Dependencies,
                    dependenciesByFramework: p.DependenciesByFramework,
                    includeReferencedProjects: p.IncludeReferencedProjects,
                    noPackageAnalysis: p.NoPackageAnalysis,
                    projectFile: p.ProjectFile,
                    properties: p.Properties,
                    publish: p.Publish,
                    publishTrials: p.PublishTrials,
                    publishUrl: p.PublishUrl,
                    references: p.References,
                    referencesByFramework: p.ReferencesByFramework,
                    releaseNotes: p.ReleaseNotes,
                    symbolPackage: p.SymbolPackage,
                    tags: p.Tags,
                    timeOut: p.TimeOut,
                    title: p.Title,
                    toolPath: p.ToolPath
                )
            );
        };

        Because of = () => NuGetHelper.NuGetPack(nugetParams, nuspecFile);
        It should_create_nupkg_file = () =>
        {
            File.Exists(pkgFile).ShouldBeTrue();
        };
    }
}
