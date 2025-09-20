@echo off
echo Building Maui-ECharts Solution...
echo.

REM Restore packages
echo Restoring NuGet packages...
dotnet restore
if %ERRORLEVEL% NEQ 0 (
    echo Failed to restore packages
    exit /b %ERRORLEVEL%
)

REM Build the solution
echo Building solution...
dotnet build -c Release
if %ERRORLEVEL% NEQ 0 (
    echo Build failed
    exit /b %ERRORLEVEL%
)

REM Pack the NuGet package
echo Creating NuGet package...
cd Maui-ECharts
dotnet pack -c Release --output ..\nupkg
if %ERRORLEVEL% NEQ 0 (
    echo Failed to create NuGet package
    exit /b %ERRORLEVEL%
)
cd ..

echo.
echo Build completed successfully!
echo NuGet package created in nupkg folder
pause