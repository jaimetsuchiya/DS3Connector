@ECHO OFF
.\tools\nuget\NuGet.exe pack .\src\DS3Connector\DS3Connector.csproj -build -Prop Configuration=Release 
.\tools\nuget\NuGet.exe push *.nupkg -Source http://pm.ironmountain.com.br/api/v2/package
pause
