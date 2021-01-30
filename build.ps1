Write-Host "Build release version" -ForegroundColor Green
dotnet publish src -c Release -o build
Write-Host "Create zip archive" -ForegroundColor Green
$version = Read-Host -Prompt Version?
Compress-7Zip -ArchiveFileName "StoryTimer-$version.zip" -Path build -OutputPath release