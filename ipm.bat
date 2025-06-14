@echo off
setlocal enabledelayedexpansion

if "%1"=="" goto :help

if "%1"=="-h" goto :help
if "%1"=="--help" goto :help

if "%1"=="fe:install" (
    echo npm --prefix ./src/IPM.ClientApp install
    npm --prefix ./src/IPM.ClientApp install
    exit /b
)

if "%1"=="fe:dev" (
    echo npm --prefix ./src/IPM.ClientApp run dev
    npm --prefix ./src/IPM.ClientApp run dev
    exit /b
)

if "%1"=="fe:build" (
    echo npm --prefix ./src/IPM.ClientApp run build
    echo del /q .\src\IPM.WebApi\Views\Home\Index.cshtml
    echo move /Y .\src\IPM.WebApi\wwwroot\Index.cshtml .\src\IPM.WebApi\Views\Home\
    npm --prefix ./src/IPM.ClientApp run build ^
        && del /q .\src\IPM.WebApi\Views\Home\Index.cshtml ^
        && move /Y .\src\IPM.WebApi\wwwroot\Index.cshtml .\src\IPM.WebApi\Views\Home\
    exit /b
)

if "%1"=="db:update" (
    echo dotnet ef database update --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    dotnet ef database update --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    exit /b
)

if "%1"=="db:drop" (
    echo dotnet ef database drop --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    dotnet ef database drop --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    exit /b
)

if "%1"=="mg:remove" (
    echo dotnet ef migrations remove --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    dotnet ef migrations remove --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    exit /b
)

if "%1"=="mg:new" (
    set migration_name=NewMigration
    if not "%2"=="" set migration_name=%2
    echo dotnet ef migrations add %migration_name% --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    dotnet ef migrations add %migration_name% --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
    exit /b
)

if "%1"=="be:run" (
    echo dotnet run --project src/IPM.WebApi
    dotnet run --project src/IPM.WebApi
    exit /b
)

if "%1"=="be:dev" (
    echo dotnet watch --project src/IPM.WebApi
    dotnet watch --project src/IPM.WebApi
    exit /b
)

if "%1"=="be:build" (
    echo dotnet build --project src/IPM.WebApi
    dotnet build --project src/IPM.WebApi
    exit /b
)

echo Command not found: %1
goto :help

:help
echo A small script to make dev life better
echo USAGE: ipm [COMMAND]
echo.
echo COMMAND:  fe:dev          Run FE dev
echo           fe:build        Build FE
echo           fe:install      Install FE dependencies
echo           be:run          Run
echo           be:dev          Run and hot reload
echo           be:build        Build
echo           mg:new ^<name^>   Make new migration
echo           mg:remove       Remove migration
echo           db:update       Update database
echo           db:drop         Drop database
echo           dk:run          Docker run (not available now)
exit /b

