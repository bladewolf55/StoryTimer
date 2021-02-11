Write-Host "Build release version" -ForegroundColor Green
dotnet publish src -c Release -o build
Write-Host "Create zip archive" -ForegroundColor Green
$version = Read-Host -Prompt Version?
$destination = Join-Path "release" "StoryTimer-$version.zip"
Compress-Archive  -Path build -DestinationPath $destination 