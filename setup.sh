#!/bin/bash

print_help() {
    echo "  setup.sh [COMMAND]"
    echo ""
    echo "  COMMAND: "
    echo "  make-migrate    Make new migration"
    echo "  db-update       Update database"
    echo "  run             Run"
}

main() {
    case "$1" in
        -h|--help)
            print_help
            ;;
        "db-update")
            echo "dotnet ef database update --project src/IPM.Infrastructure --startup-project src/IPM.WebApi"
            dotnet ef database update --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
            ;;
        "make-migrate")
            echo "dotnet ef migrations add NewMigration --project src/IPM.Infrastructure --startup-project src/IPM.WebApi"
            dotnet ef migrations add NewMigration --project src/IPM.Infrastructure --startup-project src/IPM.WebApi
            ;;
        "run")
            echo "dotnet run --project src/IPM.WebApi"
            dotnet run --project src/IPM.WebApi
            ;;
        *)
            echo "Command not found"
            print_help
            ;;
    esac
}

main "$@"