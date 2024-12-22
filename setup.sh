#!/bin/bash

print_help() {
    echo "  setup.sh [COMMAND]"
    echo ""
    echo "  COMMAND: "
    echo "  make-migrate"
    echo "  db-update"
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
        *)
            echo "Command not found"
            print_help
            ;;
    esac
}

main "$@"
