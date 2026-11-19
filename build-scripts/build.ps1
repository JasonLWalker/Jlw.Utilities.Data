param([string]$packageName="", [string]$buildType="Release", [string]$versionSuffix="", [string]$versionPrefix="")

# Set the Current directory path into the $workingDir variable
$workingDir=(Get-Item -Path ".\").FullName

if (-Not ($packageName)){
	# Set the Current directory name into the $packageName variable
	$packageName=(Get-Item -Path ".\").Name
}

# Install dependencies
#dotnet restore

# Build/Pack with dotnet
if (-Not ($versionSuffix)){
dotnet build -p:VersionPrefix=$versionPrefix -p:Configuration=$buildType
} else {
dotnet build -p:VersionPrefix=$versionPrefix -p:VersionSuffix=$versionSuffix -p:Configuration=$buildType
}
