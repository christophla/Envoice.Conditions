<#
.SYNOPSIS
	Project tasks
.PARAMETER Compose
	Runs docker-compose.
.PARAMETER Build
	Builds the solution projects.
.PARAMETER Clean
	Cleans all solution project files
.PARAMETER IntegrationTests
    Builds the projects and executes the integration tests.
.PARAMETER NuGetPublish
	Deploys the nuget projects.
.PARAMETER UnitTests
	Builds the projects and runs the unit tests.
.PARAMETER Environment
	The envirponment to build for (Debug or Release), defaults to Debug
.EXAMPLE
	C:\PS> .\project-tasks.ps1 -Build -Debug
#>

[CmdletBinding(PositionalBinding = $false)]
Param(
    [Parameter(Mandatory = $True, ParameterSetName = "Build")]
    [switch]$Build,
    [Parameter(Mandatory = $True, ParameterSetName = "Clean")]
    [switch]$Clean,
    [Parameter(Mandatory = $True, ParameterSetName = "IntegrationTests")]
    [switch]$IntegrationTests,
    [Parameter(Mandatory = $True, ParameterSetName = "NuGetPublish")]
    [switch]$NuGetPublish,
    [Parameter(Mandatory = $True, ParameterSetName = "UnitTests")]
    [switch]$UnitTests,
    [parameter(ParameterSetName = "Build")]
    [parameter(ParameterSetName = "Clean")]
    [parameter(ParameterSetName = "IntegrationTests")]
    [parameter(ParameterSetName = "NuGetPublish")]
    [parameter(ParameterSetName = "UnitTests")]
    [ValidateNotNullOrEmpty()]
    [String]$Environment = "Debug"
)

$nugetFeedUri = "https://www.nuget.org/F/envoice/api/v2/package"
$nugetKey = $Env:nuget_KEY_Envoice
$nugetVersion = "1.0.0"
$nugetVersionSuffix = ""

# Welcome message
function Welcome () {

    Write-Host "                         _          " -ForegroundColor "Blue"
    Write-Host "  ___  ____ _   ______  (_)_______  " -ForegroundColor "Blue"
    Write-Host " / _ \/ __ \ | / / __ \/ / ___/ _ \ " -ForegroundColor "Blue"
    Write-Host "/  __/ / / / |/ / /_/ / / /__/  __/ " -ForegroundColor "Blue"
    Write-Host "\___/_/ /_/|___/\____/_/\___/\___/  " -ForegroundColor "Blue"
    Write-Host ""
}

# Builds the project.
function BuildProject () {

    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"
    Write-Host "+ Building project                              " -ForegroundColor "Green"
    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"

    dotnet restore
    dotnet build
}

# Cleans the project
function CleanAll () {

    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"
    Write-Host "+ Cleaning project                              " -ForegroundColor "Green"
    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"

    dotnet clean
}

# Runs the integration tests.
function IntegrationTests () {


    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"
    Write-Host "+ Running integration tests                     " -ForegroundColor "Green"
    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"

    Set-Location test

    Get-ChildItem -Directory -Filter "*.IntegrationTests*" |
        ForEach-Object {
        Set-Location $_.FullName # or whatever
        dotnet test
        Set-Location ..
    }

}

# Deploys nuget packages to nuget feed
function nugetPublish () {

    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"
    Write-Host "+ Deploying to nuget feed                       " -ForegroundColor "Green"
    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"

    Write-Host "Using Key: $nugetKey" -ForegroundColor "Yellow"

    Set-Location src

    Get-ChildItem -Filter "*.nuspec" -Recurse -Depth 1 |
      ForEach-Object {

        $packageName = $_.BaseName
        Set-Location $_.BaseName

        if ($nugetVersionSuffix) {

          dotnet pack -c $Environment --include-source --include-symbols --version-suffix $nugetVersionSuffix

          Write-Host "Publishing: $packageName.$nugetVersion-$nugetVersionSuffix" -ForegroundColor "Yellow"

          Invoke-WebRequest `
            -uri $nugetFeedUri `
            -InFile "bin/$Environment/$packageName.$nugetVersion-$nugetVersionSuffix.nupkg" `
            -Headers @{"X-NuGet-ApiKey" = "$nugetKey"} `
            -Method "PUT" `
            -ContentType "multipart/form-data"

        }
        else {

          dotnet pack -c $Environment --include-source --include-symbols

          Write-Host "Publishing: $packageName.$nugetVersion" -ForegroundColor "Yellow"

          Invoke-WebRequest `
            -uri $nugetFeedUri `
            -InFile "bin/$Environment/$packageName.$nugetVersion.nupkg" `
            -Headers @{"X-nuget-ApiKey" = "$nugetKey"} `
            -Method "PUT" `
            -ContentType "multipart/form-data"

        }

        Set-Location ..
    }

}

# Runs the unit tests.
function UnitTests () {

    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"
    Write-Host "+ Running unit tests                            " -ForegroundColor "Green"
    Write-Host "++++++++++++++++++++++++++++++++++++++++++++++++" -ForegroundColor "Green"

    Set-Location test

    Get-ChildItem -Directory -Filter "*.UnitTests*" |
        ForEach-Object {
        Set-Location $_.FullName # or whatever
        dotnet test
        Set-Location ..
    }

}

$Environment = $Environment.ToLowerInvariant()

# Call the correct function for the parameter that was used

Welcome

if ($Build) {
    BuildProject
}
elseif ($Clean) {
    CleanAll
}
elseif ($IntegrationTests) {
    BuildProject
    IntegrationTests
}
elseif ($NuGetPublish) {
    BuildProject
    nugetPublish
}
elseif ($UnitTests) {
    BuildProject
    UnitTests
}
