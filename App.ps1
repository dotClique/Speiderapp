<#
.SYNOPSIS
  Speiderapp setup and automation script
.DESCRIPTION
  This script simplifies common tasks necessary for the development of Speiderapp.
.NOTES
  Version:       1
  Author:        Dentsor
  Creation Date: 2022-01-27
  Last Modified: 2022-01-27
.PARAMETER Start
  Specify the modules to start (comma-separated)
.PARAMETER Detach
  Run Docker-containers in detached state
.PARAMETER Action
  Specify the desired action to run
.PARAMETER OperatingSystem
  You may specify operating system if you wish, by default it is set to Auto which uses Powershell to select the appropriate verion.
#>
[CmdletBinding()]
param (
  [Parameter(
    ParameterSetName = "Start",
    Mandatory = $false,
    ValueFromPipeline = $true,
    ValueFromPipelineByPropertyName = $true
  )]
  [ValidateSet("All", "Database", "Backend", "Frontend")]
    [String[]]$Start=@("All"),
  [Parameter(
    ParameterSetName = "Actions",
		Position = 0,
		Mandatory = $true,
		ValueFromPipelineByPropertyName = $true
		)]
		[ValidateSet("Help", "Restore", "Format", "Migrate", "ActivateVenv", "DeactivateVenv")]
		[String]$Action="Help",
 [Parameter(
    ParameterSetName = "Start",
    Mandatory = $false,
    ValueFromPipeline = $true,
    ValueFromPipelineByPropertyName = $true
  )]
    [Switch]$Detach,
  [Parameter(
		Mandatory = $false,
		ValueFromPipeline = $true,
		ValueFromPipelineByPropertyName = $true
		)]
		[Alias("OS")]
		[ValidateSet("Auto", "Windows", "Linux", "Mac")]
		[String]$OperatingSystem = "Auto"
)
######################
#     Variables      #
######################
$AllModules = "database", "backend", "frontend"
if ($OperatingSystem -like "Auto") {
	if ($IsWindows) { $OperatingSystem = "Windows" }
	elseif ($IsMac) { $OperatingSystem = "Mac" }
	elseif ($IsLinux) { $OperatingSystem = "Linux" }
}

$ModulesToStart = (& {If($Start.Contains("All")) { $AllModules } Else { $Start }}).ToLower()

######################
#     Functions      #
######################
Function ActionHelp() {
	Get-Help $PSScriptRoot/App.ps1
}
Function ActionRestore() {
	Switch($OperatingSystem)
	{
		"Windows" { ActionRestoreWindows }
		"Mac" { ActionRestoreMac }
		"Linux" { ActionRestoreLinux }
	}
}
Function ActionRestoreWindows() {
	python -m venv venv-windows
	./venv-windows/Scripts/Activate.ps1
	python -m pip install -r requirements.pip
	pre-commit install
	dotnet tool restore
	dotnet restore
}
Function ActionRestoreMac() { ActionRestoreLinux }
Function ActionRestoreLinux() {
	python3 -m venv venv-linux
	./venv-linux/bin/Activate.ps1
	python3 -m pip install -r requirements.pip
	pre-commit install
	dotnet tool restore
	dotnet restore
}
Function ActionFormat() {
	dotnet format --severity info
}
Function ActionMigrate() {
	if ($Detach) {
		docker-compose run --detach --rm backend /bin/sh -c "dotnet tool restore; dotnet ef database update --project SpeiderappAPI"
	} else {
		docker-compose run --rm backend /bin/sh -c "dotnet tool restore; dotnet ef database update --project SpeiderappAPI"
	}
}
Function StartModules() {
	if ($Detach) {
		docker-compose up --detach $ModulesToStart
	} else {
		docker-compose up $ModulesToStart
	}
}
Function ActionActivateVenv() {
	switch ($OperatingSystem)
	{
		"Windows" { ./venv-windows/Scripts/Activate.ps1 }
		"Mac" { ./venv-linux/bin/Activate.ps1 }
		"Linux" { ./venv-linuc/bin/Activate.ps1 }
	}
}
Function ActionDeactivateVenv() {
	deactivate
}

######################
#     The Script     #
######################
Switch ($PsCmdlet.ParameterSetName) {
  "Actions" {
    Switch ($Action) {
      "Help" { ActionHelp }
      "Restore" { ActionRestore }
      "Format"  { ActionFormat }
      "Migrate" { ActionMigrate }
      "ActivateVenv" { ActionActivateVenv }
      "DeactivateVenv" { ActionDeactivateVenv }
    }
  }
  "Start" { StartModules }
}
