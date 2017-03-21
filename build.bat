@ECHO OFF

:: Use Release build configuration unless specified
IF "%1"=="" (
CALL build.bat Release
SET build=%errorlevel%
EXIT /b %build%
)

IF NOT EXIST .\packages\nuget\nuget.exe (
IF NOT EXIST .\packages\nuget\ MKDIR .\packages\nuget\
ECHO ^(New-Object System.Net.WebClient^).DownloadFile('https://dist.nuget.org/win-x86-commandline/v3.5.0/nuget.exe', '.\\packages\\nuget\\nuget.exe'^) > .\\packages\\nuget\\nuget.ps1
PowerShell.exe -ExecutionPolicy Bypass -File .\\packages\\nuget\\nuget.ps1
)

.\packages\nuget\nuget.exe restore

:: Build and package
IF NOT EXIST .\artifacts MKDIR .\artifacts
"C:\Program Files (x86)\MSBuild\14.0\Bin\Msbuild.exe" /t:Rebuild "Mass Transit Extension Methods.sln" /p:Configuration=%1
.\packages\nuget\nuget.exe pack .\src\Svenkle.MassTransitExtensionMethods\Svenkle.MassTransitExtensionMethods.csproj -Prop Configuration=%1 -Verbosity normal -OutputDirectory .\artifacts

EXIT /b 0