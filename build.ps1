Write-Host "Build release version" -ForegroundColor Green
dotnet publish src -c Release -o build
Write-Host "Create zip archive" -ForegroundColor Green
Compress-7Zip -ArchiveFileName storytimer.zip -Path build -OutputPath release