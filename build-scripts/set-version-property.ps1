param([string]$buildType="Release", [string]$versionSuffix="", [string]$versionPrefix="")

if (-Not ($versionPrefix)){
	$versionPrefix="4.8.$([System.TimeSpan]::FromTicks($([System.DateTime]::UtcNow.Ticks)).Subtract($([System.TimeSpan]::FromTicks(630822816000000000))).TotalDays.ToString().SubString(0,9))"
}

$global:vPrefix = $versionPrefix
$global:vSuffix = $versionSuffix
Write-Host $versionPrefix$versionSuffix