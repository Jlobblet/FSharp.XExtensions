#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.DotNet.NuGet
nuget Fake.IO.FileSystem
nuget Fake.Core.Target //"
#load ".fake/build.fsx/intellisense.fsx"

open System
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

[<Literal>]
let solution = "FSharp.XExtensions.sln"

[<Literal>]
let NugetSource = "https://api.nuget.org/v3/index.json"

let (|NullOrWhitespaceString|ValueString|) (str: string) =
    if String.isNullOrWhiteSpace str then
        NullOrWhitespaceString
    else
        ValueString str

let tryGetEnvironmentVariable name =
    let tryString =
        function
        | NullOrWhitespaceString -> None
        | ValueString var -> Some var

    [ Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)
      Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
      Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine) ]
    |> List.choose tryString
    |> List.tryHead

let getEnvironmentVariable name =
    match tryGetEnvironmentVariable name with
    | None -> failwith $"Could not find environment variable %s{name}"
    | Some var -> var

// Targets

Target.initEnvironment ()

// Cleaning

Target.create "Clean"
<| fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    ++ "NuGet"
    |> Shell.cleanDirs

// Restore

Target.create "Restore"
<| fun _ -> solution |> DotNet.restore id

// Build

Target.create "Build"
<| fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (
        DotNet.build
            (fun o ->
                { o with
                      Configuration = DotNet.BuildConfiguration.Release
                      NoLogo = true
                      NoRestore = true })
    )

// NuGet

Target.create "Create NuGet packages"
<| fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (
        DotNet.pack
            (fun o ->
                { o with
                      NoLogo = true
                      OutputPath = Some "NuGet" })
    )

Target.create "Push NuGet packages"
<| fun _ ->
    let apiKey = getEnvironmentVariable "NUGET_KEY"

    !! "NuGet/FSharp.XExtensions.*.nupkg"
    |> Seq.iter (
        DotNet.nugetPush
            (fun o ->
                { o with
                      PushParams =
                          { o.PushParams with
                                ApiKey = Some apiKey
                                Source = Some NugetSource } })
    )

// Combinations

Target.create "All" ignore
Target.create "Deploy" ignore

// Dependencies

"Clean"
==> "Restore"
==> "Build"
==> "All"
==> "Create NuGet packages"
==> "Push NuGet packages"
==> "Deploy"

// Run

Target.runOrDefaultWithArguments "All"
