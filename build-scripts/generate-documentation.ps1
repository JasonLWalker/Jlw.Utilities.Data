param([string]$sourcePath, [string]$outputPath)

Write-Host "===================== Generating Documentation Markdown ====================="
dotnet tool install xmldoc2markdown
dotnet xmldoc2md $sourcePath\Jlw.Utilities.Data.dll --output $outputPath\Jlw.Utilities.Data --member-accessibility-level public --back-button