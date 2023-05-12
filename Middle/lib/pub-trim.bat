@echo off
rmdir /q /s "../Pub"
dotnet publish -c Debug -o ../pub --self-contained --runtime win-x64 -p:PublishTrimmed=True -p:TrimMode=Link  
